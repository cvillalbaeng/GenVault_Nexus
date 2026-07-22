using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucUsuario : UserControl
    {
        // ========================================================
        // VARIABLES GLOBALES
        // ========================================================
        private DataTable tablaFichas = new DataTable("Usuarios");
        private byte[] fotoUsuarioActual = null;
        private int indiceFilaSeleccionada = -1;

        public ucUsuario()
        {
            InitializeComponent();
            ConfigurarDepartamentosYCargos();
            ConfigurarEstructuraDatos();
            ConfigurarPlaceholders();
            ConfigurarEstiloTabla();
        }

        // ========================================================
        // MATRIZ DE SEGURIDAD Y JERARQUÍA
        // ========================================================
        private int ObtenerNivel(string departamento, string cargo)
        {
            if (departamento == "Ciberseguridad") return 1; // Nivel 1: Dios (Admin)

            if (departamento == "Dirección de Seguridad")
            {
                if (cargo == "Director de Seguridad") return 2; // Nivel 2: Semidiós
                if (cargo == "Supervisor de Operaciones de Control") return 3; // Nivel 3: Jefe
            }

            return 4; // Nivel 4: Operativos (Logística, Bioinformática, Telemetría, etc.)
        }

        private bool ValidarAutorizacion(DataRow filaDestino, string accion)
        {
            string docDestino = filaDestino["Documento"].ToString();
            string deptoDestino = filaDestino["Departamento"].ToString();
            string cargoDestino = filaDestino["Cargo"].ToString();

            // 1. Evitar el "Fuego Amigo"
            if (docDestino == SesionGlobal.Documento)
            {
                MessageBox.Show($"Operación denegada: No puedes {accion} tu propia cuenta de usuario.", "Protección del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            // 2. Validar Choque de Jerarquías
            int miNivel = ObtenerNivel(SesionGlobal.Departamento, SesionGlobal.Cargo);
            int nivelDestino = ObtenerNivel(deptoDestino, cargoDestino);

            if (miNivel >= nivelDestino)
            {
                MessageBox.Show($"Acceso Denegado: Tu rango jerárquico actual ({SesionGlobal.Cargo}) no tiene autorización para alterar el perfil de un {cargoDestino}.", "Restricción de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // ========================================================
        // CONFIGURACIÓN DE DEPARTAMENTOS Y CARGOS OFICIALES
        // ========================================================
        private void ConfigurarDepartamentosYCargos()
        {
            cmbDepartamento.Items.Clear();
            cmbDepartamento.Items.Add("Ciberseguridad");
            cmbDepartamento.Items.Add("Dirección de Seguridad");
            cmbDepartamento.Items.Add("Logística e Inventario");
            cmbDepartamento.Items.Add("Bioinformática");
            cmbDepartamento.Items.Add("Unidad de Telemetría");
            cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbDepartamento.SelectedIndexChanged += cmbDepartamento_SelectedIndexChanged;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCargo.Items.Clear();
            string depto = cmbDepartamento.SelectedItem?.ToString();

            if (depto == "Ciberseguridad")
            {
                cmbCargo.Items.Add("Administrador de Red");
                cmbCargo.Items.Add("Analista de Ciberseguridad");
                cmbCargo.Items.Add("Especialista en Infraestructura TI");
            }
            else if (depto == "Dirección de Seguridad")
            {
                cmbCargo.Items.Add("Director de Seguridad");
                cmbCargo.Items.Add("Supervisor de Operaciones de Control");
            }
            else if (depto == "Logística e Inventario")
            {
                cmbCargo.Items.Add("Jefe de Logística");
                cmbCargo.Items.Add("Analista de Inventario y Almacén");
            }
            else if (depto == "Bioinformática")
            {
                cmbCargo.Items.Add("Investigador Bioinformático");
                cmbCargo.Items.Add("Analista de Procesamiento de Datos");
            }
            else if (depto == "Unidad de Telemetría")
            {
                cmbCargo.Items.Add("Ingeniero de Telemetría");
                cmbCargo.Items.Add("Operador de Sistemas Remotos");
            }
        }

        // ========================================================
        // UX: BORRADO AUTOMÁTICO RECURSIVO (PLACEHOLDERS)
        // ========================================================
        private void ConfigurarPlaceholders()
        {
            AsignarEventosPlaceholders(this.Controls);
        }

        private void AsignarEventosPlaceholders(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                if (c is TextBox txt)
                {
                    txt.Tag = txt.Text;
                    txt.Enter += TextBox_Enter;
                    txt.Leave += TextBox_Leave;
                }
                if (c.HasChildren)
                {
                    AsignarEventosPlaceholders(c.Controls);
                }
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && txt.Text == txt.Tag.ToString()) txt.Text = "";
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && string.IsNullOrWhiteSpace(txt.Text)) txt.Text = txt.Tag.ToString();
        }

        // ========================================================
        // DISEÑO DE TABLA Y ENLACE DE EVENTO
        // ========================================================
        private void ConfigurarEstiloTabla()
        {
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AllowUserToResizeColumns = false;
            dgvUsuarios.AllowUserToOrderColumns = false;

            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvUsuarios.GridColor = Color.FromArgb(60, 60, 60);

            dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuarios.ScrollBars = ScrollBars.Both; // Scroll activo vertical y horizontal

            if (dgvUsuarios.Columns["Fotografia"] != null)
            {
                dgvUsuarios.Columns["Fotografia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvUsuarios.Columns["Fotografia"].Width = 60;
            }

            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Cyan;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight = 35;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        // ========================================================
        // ESTRUCTURA DE DATOS
        // ========================================================
        private string rutaArchivoXML = Path.Combine(Application.StartupPath, "base_datos_usuarios.xml");

        private void ConfigurarEstructuraDatos()
        {
            tablaFichas.Columns.Add("Nombres", typeof(string));
            tablaFichas.Columns.Add("Apellidos", typeof(string));
            tablaFichas.Columns.Add("TipoDocumento", typeof(string));
            tablaFichas.Columns.Add("Documento", typeof(string));
            tablaFichas.Columns.Add("Sexo", typeof(string));
            tablaFichas.Columns.Add("FechaNacimiento", typeof(DateTime));
            tablaFichas.Columns.Add("Telefono", typeof(string));
            tablaFichas.Columns.Add("Correo", typeof(string));
            tablaFichas.Columns.Add("Direccion", typeof(string));
            tablaFichas.Columns.Add("Alergias", typeof(string));
            tablaFichas.Columns.Add("Enfermedades", typeof(string));
            tablaFichas.Columns.Add("CondicionesEspeciales", typeof(string));
            tablaFichas.Columns.Add("ContactoEmergencia_Nombre", typeof(string));
            tablaFichas.Columns.Add("ContactoEmergencia_Parentesco", typeof(string));
            tablaFichas.Columns.Add("ContactoEmergencia_Telefono", typeof(string));
            tablaFichas.Columns.Add("Fotografia", typeof(byte[]));
            tablaFichas.Columns.Add("Departamento", typeof(string));
            tablaFichas.Columns.Add("Cargo", typeof(string));
            tablaFichas.Columns.Add("FechaIngreso", typeof(DateTime));
            tablaFichas.Columns.Add("Estado", typeof(string));
            tablaFichas.Columns.Add("Usuario", typeof(string));
            tablaFichas.Columns.Add("Password", typeof(string));

            if (System.IO.File.Exists(rutaArchivoXML))
            {
                tablaFichas.ReadXml(rutaArchivoXML);
            }
            else
            {
                tablaFichas.Rows.Add(
                    "Administrador", "Sistema", "V", "00000000", "Masculino",
                    new DateTime(1990, 1, 1), "04120000000", "admin@genvault.com",
                    "Oficina Principal de Ciberseguridad", "Ninguna", "Ninguna", "Ninguna",
                    "N/A", "N/A", "0000000", null, "Ciberseguridad", "Administrador de Red",
                    DateTime.Now, "Activo", "admin", Seguridad.EncriptarClave("1234")
                );

                tablaFichas.WriteXml(rutaArchivoXML, XmlWriteMode.WriteSchema);
            }

            dgvUsuarios.DataSource = tablaFichas;
        }

        private void GuardarBaseDatosDisco()
        {
            try
            {
                tablaFichas.WriteXml(rutaArchivoXML, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la base de datos en disco: " + ex.Message, "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========================================================
        // VALIDACIONES
        // ========================================================
        private bool ValidarTextoYPalabras(string texto, int maxPalabras)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            if (texto.Trim().Length < 3) return false;
            if (!Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")) return false;
            return true;
        }

        private bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return false;
            return Regex.IsMatch(telefono.Trim(), @"^\d{7,15}$");
        }

        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private bool ValidarDatosCompletos()
        {
            if (fotoUsuarioActual == null)
            {
                MessageBox.Show("Debe cargar una fotografía del personal antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarTextoYPalabras(txtNombres.Text, 4) || txtNombres.Text == txtNombres.Tag?.ToString())
            {
                MessageBox.Show("Nombres inválidos. Solo letras, mínimo 3 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidarTextoYPalabras(txtApellidos.Text, 4) || txtApellidos.Text == txtApellidos.Tag?.ToString())
            {
                MessageBox.Show("Apellidos inválidos. Solo letras, mínimo 3 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDocumento.Text) || txtDocumento.Text == txtDocumento.Tag?.ToString() || !Regex.IsMatch(txtDocumento.Text, @"^\d{6,10}$"))
            {
                MessageBox.Show("Documento inválido. Ingrese solo números (entre 6 y 10 dígitos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbSexo.SelectedIndex == -1 || cmbTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar Tipo de Documento y Sexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int edad = DateTime.Today.Year - dtpFechaNac.Value.Year;
            if (dtpFechaNac.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 18)
            {
                MessageBox.Show("El personal debe ser mayor de edad (mínimo 18 años). Verifique la fecha de nacimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidarTelefono(txtTelefono.Text) || txtTelefono.Text == txtTelefono.Tag?.ToString())
            {
                MessageBox.Show("Teléfono personal inválido. Ingrese solo números (mínimo 7).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidarCorreo(txtCorreo.Text) || txtCorreo.Text == txtCorreo.Tag?.ToString())
            {
                MessageBox.Show("Correo obligatorio y con formato válido (@dominio.com).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDireccion.Text == txtDireccion.Tag?.ToString() || txtDireccion.Text.Trim().Length < 15)
            {
                MessageBox.Show("La dirección es obligatoria y debe ser detallada (mínimo 15 caracteres).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAlergias.Text) || txtAlergias.Text == txtAlergias.Tag?.ToString())
            {
                MessageBox.Show("El campo Alergias está vacío. Si no posee, escriba la palabra 'Ninguna'.", "Ficha Médica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEnfermedades.Text) || txtEnfermedades.Text == txtEnfermedades.Tag?.ToString())
            {
                MessageBox.Show("El campo Enfermedades está vacío. Si no posee, escriba la palabra 'Ninguna'.", "Ficha Médica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCondiciones.Text) || txtCondiciones.Text == txtCondiciones.Tag?.ToString())
            {
                MessageBox.Show("El campo Condiciones Especiales está vacío. Si no posee, escriba 'Ninguna'.", "Ficha Médica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarTextoYPalabras(txtEmergenciaNombre.Text, 4) || txtEmergenciaNombre.Text == txtEmergenciaNombre.Tag?.ToString())
            {
                MessageBox.Show("Nombre del contacto de emergencia obligatorio (solo letras).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtParentesco.Text == txtParentesco.Tag?.ToString() || string.IsNullOrWhiteSpace(txtParentesco.Text))
            {
                MessageBox.Show("Debe indicar el Parentesco (Ej: Madre, Esposo, Hermano).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ValidarTelefono(txtEmergenciaTelefono.Text) || txtEmergenciaTelefono.Text == txtEmergenciaTelefono.Tag?.ToString())
            {
                MessageBox.Show("Teléfono de emergencia inválido. Ingrese solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbDepartamento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Departamento obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Cargo obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarFotografia()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotoUsuarioActual = File.ReadAllBytes(ofd.FileName);
                    pbFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            CargarFotografia();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(termino) || termino == txtBuscar.Tag?.ToString())
            {
                tablaFichas.DefaultView.RowFilter = "";
            }
            else
            {
                tablaFichas.DefaultView.RowFilter = $"Documento LIKE '%{termino}%' OR Nombres LIKE '%{termino}%' OR Apellidos LIKE '%{termino}%' OR Correo LIKE '%{termino}%' OR Telefono LIKE '%{termino}%' OR Departamento LIKE '%{termino}%' OR Cargo LIKE '%{termino}%'";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (indiceFilaSeleccionada >= 0)
            {
                MessageBox.Show("Ya hay un usuario seleccionado. Haga clic en Limpiar para agregar uno nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarDatosCompletos()) return;

            // 1. Verificación de documento duplicado
            foreach (DataRow row in tablaFichas.Rows)
            {
                if (row["Documento"].ToString() == txtDocumento.Text && row["TipoDocumento"].ToString() == cmbTipoDoc.Text)
                {
                    MessageBox.Show("El usuario ya existe en el sistema.");
                    return;
                }
            }

            // 2. Validación de Jerarquía para creación
            string deptoSeleccionado = cmbDepartamento.SelectedItem.ToString();
            string cargoSeleccionado = cmbCargo.SelectedItem.ToString();

            int miNivel = ObtenerNivel(SesionGlobal.Departamento, SesionGlobal.Cargo);
            int nivelNuevoUsuario = ObtenerNivel(deptoSeleccionado, cargoSeleccionado);

            if (miNivel >= nivelNuevoUsuario)
            {
                MessageBox.Show($"Acceso Denegado: Su rango jerárquico ({SesionGlobal.Cargo}) no tiene autorización para crear cuentas con el cargo de {cargoSeleccionado}.", "Restricción de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Validación de Puesto Único (Vacante)
            if (cargoSeleccionado == "Director de Seguridad" || cargoSeleccionado == "Administrador de Red")
            {
                foreach (DataRow row in tablaFichas.Rows)
                {
                    if (row["Cargo"].ToString() == cargoSeleccionado)
                    {
                        MessageBox.Show($"Violación de Integridad:\n\nEl cargo de '{cargoSeleccionado}' ya se encuentra ocupado en el sistema.", "Cargo No Vacante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // 4. Preparación de Credenciales Seguras
            string primerNombre = txtNombres.Text.Trim().Split(' ')[0].ToLower();
            string primerApellido = txtApellidos.Text.Trim().Split(' ')[0].ToLower();
            string usuarioGenerado = $"{primerNombre}.{primerApellido}";

            string passwordPlana = txtDocumento.Text.Trim();
            string passwordEncriptada = Seguridad.EncriptarClave(passwordPlana);

            // 5. Inyección a la Base de Datos
            tablaFichas.Rows.Add(
                txtNombres.Text, txtApellidos.Text, cmbTipoDoc.Text, txtDocumento.Text,
                cmbSexo.Text, dtpFechaNac.Value.Date, txtTelefono.Text, txtCorreo.Text,
                txtDireccion.Text, txtAlergias.Text, txtEnfermedades.Text, txtCondiciones.Text,
                txtEmergenciaNombre.Text, txtParentesco.Text, txtEmergenciaTelefono.Text,
                fotoUsuarioActual, deptoSeleccionado, cargoSeleccionado,
                DateTime.Now, "Pendiente", usuarioGenerado, passwordEncriptada
            );

            GuardarBaseDatosDisco();

            // ========================================================
            // REGISTRO DE AUDITORÍA: CREACIÓN DE USUARIO
            // ========================================================
            Auditoria.Registrar("Gestión de Personal", "REGISTRO_USUARIO", $"Se creó el registro pendiente para el documento {txtDocumento.Text} ({cargoSeleccionado}).");

            LimpiarFormulario();

            MessageBox.Show($"Registro guardado con éxito. Estado: Pendiente de autorización.\n\nCredenciales generadas:\nUsuario: {usuarioGenerado}\nContraseña Temporal: {passwordPlana}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (indiceFilaSeleccionada >= 0)
            {
                DataRow fila = tablaFichas.Rows[indiceFilaSeleccionada];

                if (!ValidarAutorizacion(fila, "modificar")) return;

                if (!ValidarDatosCompletos()) return;

                string cargoSeleccionado = cmbCargo.SelectedItem.ToString();
                string documentoActualUsuarioEditado = fila["Documento"].ToString();

                if (cargoSeleccionado == "Director de Seguridad" || cargoSeleccionado == "Administrador de Red")
                {
                    foreach (DataRow row in tablaFichas.Rows)
                    {
                        if (row["Cargo"].ToString() == cargoSeleccionado && row["Documento"].ToString() != documentoActualUsuarioEditado)
                        {
                            MessageBox.Show($"Violación de Integridad:\n\nEl cargo de '{cargoSeleccionado}' ya se encuentra ocupado por otro usuario.", "Cargo No Vacante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                foreach (DataRow row in tablaFichas.Rows)
                {
                    if (row != fila && row["Documento"].ToString() == txtDocumento.Text && row["TipoDocumento"].ToString() == cmbTipoDoc.Text)
                    {
                        MessageBox.Show("El número de documento que intenta asignar ya pertenece a otro usuario.", "Duplicado Detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                fila["Nombres"] = txtNombres.Text;
                fila["Apellidos"] = txtApellidos.Text;
                fila["TipoDocumento"] = cmbTipoDoc.Text;
                fila["Documento"] = txtDocumento.Text;
                fila["Sexo"] = cmbSexo.Text;
                fila["FechaNacimiento"] = dtpFechaNac.Value.Date;
                fila["Telefono"] = txtTelefono.Text;
                fila["Correo"] = txtCorreo.Text;
                fila["Direccion"] = txtDireccion.Text;
                fila["Alergias"] = txtAlergias.Text;
                fila["Enfermedades"] = txtEnfermedades.Text;
                fila["CondicionesEspeciales"] = txtCondiciones.Text;
                fila["ContactoEmergencia_Nombre"] = txtEmergenciaNombre.Text;
                fila["ContactoEmergencia_Parentesco"] = txtParentesco.Text;
                fila["ContactoEmergencia_Telefono"] = txtEmergenciaTelefono.Text;
                fila["Fotografia"] = fotoUsuarioActual;
                fila["Departamento"] = cmbDepartamento.SelectedItem.ToString();
                fila["Cargo"] = cargoSeleccionado;

                GuardarBaseDatosDisco();

                // ========================================================
                // REGISTRO DE AUDITORÍA: MODIFICACIÓN DE USUARIO
                // ========================================================
                Auditoria.Registrar("Gestión de Personal", "MODIFICACION_USUARIO", $"Se actualizaron los datos del usuario con documento {documentoActualUsuarioEditado}.");

                MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la tabla primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (indiceFilaSeleccionada >= 0)
            {
                DataRow fila = tablaFichas.Rows[indiceFilaSeleccionada];
                string docEliminado = fila["Documento"].ToString();

                if (!ValidarAutorizacion(fila, "eliminar")) return;

                DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este registro permanentemente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    tablaFichas.Rows.RemoveAt(indiceFilaSeleccionada);
                    GuardarBaseDatosDisco();

                    // ========================================================
                    // REGISTRO DE AUDITORÍA: ELIMINACIÓN DE USUARIO
                    // ========================================================
                    Auditoria.Registrar("Gestión de Personal", "ELIMINACION_USUARIO", $"Se eliminó permanentemente el registro del usuario con documento {docEliminado}.");

                    LimpiarFormulario();
                    MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Seleccione un usuario de la tabla primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (indiceFilaSeleccionada >= 0)
            {
                DataRow fila = tablaFichas.Rows[indiceFilaSeleccionada];
                string docAfectado = fila["Documento"].ToString();

                if (!ValidarAutorizacion(fila, "gestionar el estado de")) return;

                string estadoActual = fila["Estado"].ToString();
                int miNivel = ObtenerNivel(SesionGlobal.Departamento, SesionGlobal.Cargo);

                // ========================================================
                // APROBACIÓN DE NUEVO INGRESO
                // ========================================================
                if (estadoActual.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    if (miNivel > 2)
                    {
                        MessageBox.Show("Segregación de Funciones:\n\nSu cargo le permite registrar nuevos ingresos, pero la APROBACIÓN y activación definitiva del personal es competencia exclusiva del Director de Seguridad o del Administrador de Red.", "Autorización Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    fila["Estado"] = "Activo";

                    // REGISTRO DE AUDITORÍA
                    Auditoria.Registrar("Gestión de Personal", "APROBACION_USUARIO", $"Se aprobó y activó la cuenta del usuario con documento {docAfectado}.");

                    MessageBox.Show("El usuario ha sido APROBADO y activado con éxito.", "Autorización de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ========================================================
                // DESBLOQUEO DE CUENTA
                // ========================================================
                else if (estadoActual.Equals("Bloqueado", StringComparison.OrdinalIgnoreCase))
                {
                    if (miNivel > 2)
                    {
                        MessageBox.Show("Protocolo de Seguridad:\n\nComo Supervisor, usted tiene la autoridad para BLOQUEAR preventivamente a un empleado, pero el DESBLOQUEO y la restitución de credenciales requiere auditoría obligatoria por parte del Director de Seguridad o del Administrador de Red.", "Autorización Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    fila["Estado"] = "Activo";

                    // REGISTRO DE AUDITORÍA
                    Auditoria.Registrar("Gestión de Personal", "DESBLOQUEO_USUARIO", $"Se restituyó y desbloqueó el acceso al usuario con documento {docAfectado}.");

                    MessageBox.Show("El usuario ha sido DESBLOQUEADO.", "Seguridad Restablecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ========================================================
                // BLOQUEO PREVENTIVO
                // ========================================================
                else if (estadoActual.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                {
                    fila["Estado"] = "Bloqueado";

                    // REGISTRO DE AUDITORÍA
                    Auditoria.Registrar("Gestión de Personal", "BLOQUEO_USUARIO", $"Se aplicó bloqueo preventivo al usuario con documento {docAfectado}.");

                    MessageBox.Show("El usuario ha sido BLOQUEADO preventivamente.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                GuardarBaseDatosDisco();
                ActualizarBotonBloqueo(fila["Estado"].ToString());
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la tabla primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceFilaSeleccionada = e.RowIndex;
                DataGridViewRow fila = dgvUsuarios.Rows[indiceFilaSeleccionada];

                txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                cmbTipoDoc.Text = fila.Cells["TipoDocumento"].Value.ToString();
                txtDocumento.Text = fila.Cells["Documento"].Value.ToString();
                cmbSexo.Text = fila.Cells["Sexo"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                txtAlergias.Text = fila.Cells["Alergias"].Value.ToString();
                txtEnfermedades.Text = fila.Cells["Enfermedades"].Value.ToString();
                txtCondiciones.Text = fila.Cells["CondicionesEspeciales"].Value.ToString();
                txtEmergenciaNombre.Text = fila.Cells["ContactoEmergencia_Nombre"].Value.ToString();
                txtParentesco.Text = fila.Cells["ContactoEmergencia_Parentesco"].Value.ToString();
                txtEmergenciaTelefono.Text = fila.Cells["ContactoEmergencia_Telefono"].Value.ToString();

                string depto = fila.Cells["Departamento"].Value.ToString();
                cmbDepartamento.Text = depto;
                cmbDepartamento_SelectedIndexChanged(null, null);
                cmbCargo.Text = fila.Cells["Cargo"].Value.ToString();

                if (fila.Cells["Fotografia"].Value != DBNull.Value)
                {
                    fotoUsuarioActual = (byte[])fila.Cells["Fotografia"].Value;
                    using (MemoryStream ms = new MemoryStream(fotoUsuarioActual))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbFoto.Image = null;
                }

                ActualizarBotonBloqueo(fila.Cells["Estado"].Value.ToString());
            }
        }

        private void LimpiarFormulario()
        {
            indiceFilaSeleccionada = -1;
            dgvUsuarios.ClearSelection();

            txtNombres.Text = txtNombres.Tag?.ToString();
            txtApellidos.Text = txtApellidos.Tag?.ToString();
            txtDocumento.Text = txtDocumento.Tag?.ToString();
            txtTelefono.Text = txtTelefono.Tag?.ToString();
            txtCorreo.Text = txtCorreo.Tag?.ToString();
            txtDireccion.Text = txtDireccion.Tag?.ToString();
            txtAlergias.Text = txtAlergias.Tag?.ToString();
            txtEnfermedades.Text = txtEnfermedades.Tag?.ToString();
            txtCondiciones.Text = txtCondiciones.Tag?.ToString();
            txtEmergenciaNombre.Text = txtEmergenciaNombre.Tag?.ToString();
            txtParentesco.Text = txtParentesco.Tag?.ToString();
            txtEmergenciaTelefono.Text = txtEmergenciaTelefono.Tag?.ToString();

            cmbDepartamento.SelectedIndex = -1;
            cmbCargo.Items.Clear();

            pbFoto.Image = null;
            fotoUsuarioActual = null;
            cmbSexo.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;
            dtpFechaNac.Value = DateTime.Now;

            ActualizarBotonBloqueo("Activo");
        }

        private void ucUsuario_Load(object sender, EventArgs e) { }

        private void ActualizarBotonBloqueo(string estado)
        {
            btnBloquear.BackColor = Color.White;

            if (estado.Trim().Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                btnBloquear.Text = "APROBAR / ACTIVAR";
                btnBloquear.ForeColor = Color.DarkGreen;
            }
            else if (estado.Trim().Equals("Bloqueado", StringComparison.OrdinalIgnoreCase))
            {
                btnBloquear.Text = "DESBLOQUEAR";
                btnBloquear.ForeColor = Color.DarkCyan;
            }
            else
            {
                btnBloquear.Text = "BLOQUEAR ACCESO";
                btnBloquear.ForeColor = Color.Firebrick;
            }

            btnBloquear.Refresh();
        }
    }

    public static class SesionGlobal
    {
        public static string Documento { get; set; } = "00000000";
        public static string Departamento { get; set; } = "Ciberseguridad";
        public static string Cargo { get; set; } = "Administrador de Red";
    }
}