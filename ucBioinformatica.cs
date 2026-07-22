using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GenVault_Nexus
{
    public partial class ucBioinformatica : UserControl
    {
        private DataTable tablaEspecimenes = new DataTable();
        private Random random = new Random();

        public ucBioinformatica()
        {
            InitializeComponent();
            cmbEstado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEstado.DrawItem += cmbEstado_DrawItem;
        }

        private void ucBioinformatica_Load(object sender, EventArgs e)
        {
            CargarDatosDesdeSQLite();
            ConfigurarEstiloTabla();
            dgvEspecimenes.SelectionChanged += dgvEspecimenes_SelectionChanged;

            btnAgregar.Click += btnAgregar_Click;
            btnGuardarCambios.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnEjecutarPAM.Click += btnEjecutarPAM_Click;

            // Configuración inicial del reproductor
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.Visible = false; // Inicia oculto

            // CORRECCIÓN VITAL: Desactivar el auto-inicio automático del motor de Windows Media
            try { axWindowsMediaPlayer1.settings.autoStart = false; } catch { }

            // Suscripción estricta para apagar y limpiar el audio si el usuario sale del módulo
            this.VisibleChanged += ucBioinformatica_VisibleChanged;
        }

        private void ucBioinformatica_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                DetenerYLimpiarVideo();
            }
        }

        private void DetenerYLimpiarVideo()
        {
            try
            {
                if (axWindowsMediaPlayer1 != null)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    axWindowsMediaPlayer1.URL = string.Empty; // Limpia la ruta para liberar el archivo de audio/video por completo
                    axWindowsMediaPlayer1.Visible = false;
                }
            }
            catch { }
        }

        private void CargarDatosDesdeSQLite()
        {
            try
            {
                using (SQLiteConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "SELECT Codigo, Nombre, Especie, Estado, Fecha FROM Especimenes";
                    using (SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, conexion))
                    {
                        tablaEspecimenes.Clear();
                        tablaEspecimenes = new DataTable();
                        adaptador.Fill(tablaEspecimenes);
                        dgvEspecimenes.DataSource = tablaEspecimenes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincronizar con el servidor Bio-Core Alpha (SQLite): " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEstiloTabla()
        {
            dgvEspecimenes.BackgroundColor = Color.FromArgb(26, 31, 38);
            dgvEspecimenes.GridColor = Color.FromArgb(42, 49, 60);
            dgvEspecimenes.DefaultCellStyle.BackColor = Color.FromArgb(42, 49, 60);
            dgvEspecimenes.DefaultCellStyle.ForeColor = Color.White;
            dgvEspecimenes.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dgvEspecimenes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEspecimenes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 42, 51);
            dgvEspecimenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEspecimenes.EnableHeadersVisualStyles = false;
            dgvEspecimenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEspecimenes.ScrollBars = ScrollBars.Both;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtEspecie.Text))
                {
                    MessageBox.Show("El código, el nombre y la especie son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbEstado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpFecha.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha no puede ser anterior a la actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string codigoEsp = txtCodigo.Text.Trim();
                string nombreEsp = txtNombre.Text.Trim();
                string especieEsp = txtEspecie.Text.Trim();
                string estadoEsp = cmbEstado.Text;
                string fechaEsp = dtpFecha.Value.ToShortDateString();

                using (SQLiteConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "INSERT INTO Especimenes (Codigo, Nombre, Especie, Estado, Fecha) VALUES (@codigo, @nombre, @especie, @estado, @fecha)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigoEsp);
                        cmd.Parameters.AddWithValue("@nombre", nombreEsp);
                        cmd.Parameters.AddWithValue("@especie", especieEsp);
                        cmd.Parameters.AddWithValue("@estado", estadoEsp);
                        cmd.Parameters.AddWithValue("@fecha", fechaEsp);
                        cmd.ExecuteNonQuery();
                    }
                }

                Auditoria.Registrar("Bioinformática", "REGISTRO_ESPECIMEN", $"Se registró el espécimen '{nombreEsp}' (Código: {codigoEsp}, Especie: {especieEsp}).");

                CargarDatosDesdeSQLite();
                LimpiarCampos();
                dgvEspecimenes.ClearSelection();
                MessageBox.Show("Espécimen registrado y almacenado con éxito en el Bio-Core Alpha.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed"))
                {
                    MessageBox.Show("ALERTA: Ya existe un espécimen registrado con este código en la base de datos.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error de SQLite: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnAgregar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEspecimenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila de la tabla para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEspecie.Text))
            {
                MessageBox.Show("El código, el nombre y la especie son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEstado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Debe seleccionar un estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView filaActual = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;
            string codigoOriginal = filaActual["Codigo"].ToString();
            string codigoMod = txtCodigo.Text.Trim();

            try
            {
                using (SQLiteConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "UPDATE Especimenes SET Codigo = @nuevoCodigo, Nombre = @nombre, Especie = @especie, Estado = @estado, Fecha = @fecha WHERE Codigo = @codigoOriginal";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nuevoCodigo", codigoMod);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@especie", txtEspecie.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.Text);
                        cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@codigoOriginal", codigoOriginal);
                        cmd.ExecuteNonQuery();
                    }
                }

                Auditoria.Registrar("Bioinformática", "MODIFICACION_ESPECIMEN", $"Se actualizaron los datos del espécimen con código '{codigoMod}'.");

                CargarDatosDesdeSQLite();
                LimpiarCampos();
                MessageBox.Show("Espécimen modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecimenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Seguro que deseas eliminar este espécimen de la base de datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                DataRowView fila = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;
                string codigoEliminado = fila["Codigo"].ToString();
                string nombreEliminado = fila["Nombre"].ToString();

                try
                {
                    using (SQLiteConnection conexion = ConexionDB.ObtenerConexion())
                    {
                        conexion.Open();
                        string query = "DELETE FROM Especimenes WHERE Codigo = @codigo";

                        using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigoEliminado);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    Auditoria.Registrar("Bioinformática", "ELIMINACION_ESPECIMEN", $"Se eliminó el espécimen '{nombreEliminado}' (Código: {codigoEliminado}).");

                    CargarDatosDesdeSQLite();
                    LimpiarCampos();
                    MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            dgvEspecimenes.SelectionChanged -= dgvEspecimenes_SelectionChanged;

            txtCodigo.Clear();
            txtNombre.Clear();
            txtEspecie.Clear();
            cmbEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;

            dgvEspecimenes.ClearSelection();

            dgvEspecimenes.SelectionChanged += dgvEspecimenes_SelectionChanged;
        }

        private void cmbEstado_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Brush backgroundBrush = isSelected ? new SolidBrush(Color.DarkCyan) : new SolidBrush(cmbEstado.BackColor);

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            e.Graphics.DrawString(cmbEstado.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void dgvEspecimenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEspecimenes.CurrentRow == null) return;

            DataRowView fila = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;
            if (fila == null) return;

            txtCodigo.Text = fila["Codigo"].ToString();
            txtNombre.Text = fila["Nombre"].ToString();
            txtEspecie.Text = fila["Especie"].ToString();
            cmbEstado.Text = fila["Estado"].ToString();
            if (DateTime.TryParse(fila["Fecha"].ToString(), out DateTime fechaParsed))
            {
                dtpFecha.Value = fechaParsed;
            }
        }

        private async void btnEjecutarPAM_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN ESTRICTA: Se requieren al menos 2 especímenes registrados para ejecutar el PAM
            if (tablaEspecimenes == null || tablaEspecimenes.Rows.Count < 2 || dgvEspecimenes.Rows.Count < 2)
            {
                MessageBox.Show("Se requieren al menos 2 especímenes registrados en la base de datos para ejecutar el proceso PAM.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnEjecutarPAM.Enabled = false;

            // BLINDAJE DE AUDIO: Detenemos y limpiamos el reproductor agresivamente ANTES de empezar el proceso.
            // Así garantizamos que no haya ningún video residual en caché intentando reproducirse si el resultado es negativo.
            DetenerYLimpiarVideo();

            pbPAM.Value = 0;
            lblResultadoPAM.Text = "Resultado: Ejecutando...";

            try
            {
                for (int i = 0; i <= 100; i += 5)
                {
                    pbPAM.Value = i;
                    await Task.Delay(80);
                }

                string[] resultadosPosibles =
                {
                    "Mutación beneficiosa aislada",
                    "Fallo genético crítico",
                    "Sin cambios significativos",
                    "Mutación estable detectada",
                    "Secuencia corrupta - reintentar"
                };

                string resultado = resultadosPosibles[random.Next(resultadosPosibles.Length)];
                lblResultadoPAM.Text = "Resultado: " + resultado;

                // ========================================================
                // CINEMÁTICA CONDICIONAL: ÉXITO (BENEFICIOSA O ESTABLE)
                // ========================================================
                if (resultado == "Mutación beneficiosa aislada" || resultado == "Mutación estable detectada")
                {
                    string rutaVideo = Path.Combine(Application.StartupPath, "video 1 ejecutar PAM .mp4");

                    if (File.Exists(rutaVideo))
                    {
                        axWindowsMediaPlayer1.Visible = true;
                        axWindowsMediaPlayer1.BringToFront();

                        axWindowsMediaPlayer1.URL = rutaVideo;
                        axWindowsMediaPlayer1.Ctlcontrols.play();

                        // Espera a que termine la reproducción antes de ocultarse automáticamente
                        await Task.Delay(9000);

                        DetenerYLimpiarVideo();
                    }
                }

                Auditoria.Registrar("Bioinformática", "EJECUCION_PAM", $"Se ejecutó el Proceso Analítico Mutagénico (PAM) con resultado: '{resultado}'.");
            }
            finally
            {
                btnEjecutarPAM.Enabled = true;
            }
        }
    }
}