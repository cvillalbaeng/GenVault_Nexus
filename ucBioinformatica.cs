using System;
using System.Data;
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
            this.Load += ucBioinformatica_Load;
        }

        private void ucBioinformatica_Load(object sender, EventArgs e)
        {
            InicializarTabla();
            dgvEspecimenes.DataSource = tablaEspecimenes;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El código y el nombre son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEspecimenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una fila de la tabla para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView fila = (DataRowView)dgvEspecimenes.CurrentRow.DataBoundItem;
            fila["Codigo"] = txtCodigo.Text;
            fila["Nombre"] = txtNombre.Text;
            fila["Especie"] = txtEspecie.Text;
            fila["Estado"] = cmbEstado.Text;
            fila["Fecha"] = dtpFecha.Value.ToShortDateString();

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
            txtCodigo.Clear();
            txtNombre.Clear();
            txtEspecie.Clear();
            cmbEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dgvEspecimenes.ClearSelection();
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
            btnEjecutarPAM.Enabled = false;
            pbPAM.Value = 0;
            lblResultadoPAM.Text = "Resultado: Ejecutando...";

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

            btnEjecutarPAM.Enabled = true;
        }
    }
}