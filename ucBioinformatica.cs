using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucBioinformatica : UserControl
    {
        private DataTable tablaEspecimenes;
        private Random random = new Random();

        public ucBioinformatica()
        {
            InitializeComponent();
            cmbEstado.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEstado.DrawItem += cmbEstado_DrawItem;
        }

        private void ucBioinformatica_Load(object sender, EventArgs e)
        {
            InicializarTabla();
            dgvEspecimenes.DataSource = tablaEspecimenes;
            ConfigurarEstiloTabla();
            dgvEspecimenes.SelectionChanged += dgvEspecimenes_SelectionChanged;

            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnEjecutarPAM.Click += btnEjecutarPAM_Click;
        }

        private void InicializarTabla()
        {
            tablaEspecimenes = new DataTable();
            tablaEspecimenes.Columns.Add("Codigo", typeof(string));
            tablaEspecimenes.Columns.Add("Nombre", typeof(string));
            tablaEspecimenes.Columns.Add("Especie", typeof(string));
            tablaEspecimenes.Columns.Add("Estado", typeof(string));
            tablaEspecimenes.Columns.Add("Fecha", typeof(string));
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

                foreach (DataRow fila in tablaEspecimenes.Rows)
                {
                    if (fila["Codigo"].ToString().Trim().ToUpper() == txtCodigo.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("ALERTA: Este código ya existe.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarCampos();
                        return;
                    }
                }

                tablaEspecimenes.Rows.Add(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtEspecie.Text,
                    cmbEstado.Text,
                    dtpFecha.Value.ToShortDateString()
                );

                LimpiarCampos();
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

            // 1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEspecie.Text))
            {
                MessageBox.Show("El código, el nombre y la especie son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar Estado
            if (cmbEstado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Debe seleccionar un estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView filaActual = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;

            // 3. RADAR ANTI-DUPLICADOS (Versión Modificar)
            foreach (DataRow fila in tablaEspecimenes.Rows)
            {
                // Verifica si el código existe, PERO ignora la fila que estamos modificando
                if (fila["Codigo"].ToString().Trim().ToUpper() == txtCodigo.Text.Trim().ToUpper() && fila != filaActual.Row)
                {
                    MessageBox.Show("ALERTA: Ya existe OTRO espécimen usando este código.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Aborta la modificación
                }
            }

            // 4. Si todo está en orden, aplicamos los cambios
            filaActual["Codigo"] = txtCodigo.Text;
            filaActual["Nombre"] = txtNombre.Text;
            filaActual["Especie"] = txtEspecie.Text;
            filaActual["Estado"] = cmbEstado.Text;
            filaActual["Fecha"] = dtpFecha.Value.ToShortDateString();

            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecimenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Seguro que deseas eliminar este espécimen?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                DataRowView fila = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;
                fila.Row.Delete();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
           dgvEspecimenes.SelectionChanged -= dgvEspecimenes_SelectionChanged;

            // Lipiamos todas las cajas
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
        }

        private async void btnEjecutarPAM_Click(object sender, EventArgs e)
        {
            if (tablaEspecimenes == null || tablaEspecimenes.Rows.Count == 0)
            {
                MessageBox.Show("No hay especímenes registrados. Debe agregar al menos uno para ejecutar el proceso PAM.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnEjecutarPAM.Enabled = false;
            pbPAM.Value = 0;
            lblResultadoPAM.Text = "Resultado: Ejecutando...";

            try
            {
                for (int i = 0; i <= 100; i += 5)
                {
                    pbPAM.Value = i;
                    await System.Threading.Tasks.Task.Delay(80);
                }

                string[] resultadosPosibles =
                {
            "Mutación estable detectada",
            "Fallo genético crítico",
            "Sin cambios significativos",
            "Mutación beneficiosa aislada",
            "Secuencia corrupta - reintentar"
        };

                string resultado = resultadosPosibles[random.Next(resultadosPosibles.Length)];
                lblResultadoPAM.Text = "Resultado: " + resultado;
            }
            finally
            {
                btnEjecutarPAM.Enabled = true;
            }
        }
    }
}