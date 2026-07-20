using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace GenVault_Nexus
{
    public partial class ucInventario : UserControl
    {
        private DataTable tablaInventario = new DataTable();

        public ucInventario()
        {
            InitializeComponent();
            this.Load += ucInventario_Load;
        }

        private void ucInventario_Load(object sender, EventArgs e)
        {
            dgvInventario.RightToLeft = RightToLeft.No;
            dgvInventario.Columns.Clear();
            dgvInventario.AutoGenerateColumns = false;

            ConfigurarColumnas();
            CargarDatosSimulados();
            ConstruirColumnasGrid();

            dgvInventario.DataSource = tablaInventario;
            EstilizarGrid();

            dgvInventario.SelectionChanged += dgvInventario_SelectionChanged;
        }

        private void ConstruirColumnasGrid()
        {
            dgvInventario.Columns.Clear();
            DataGridViewTextBoxColumn colMaterial = new DataGridViewTextBoxColumn { Name = "Material", DataPropertyName = "Material", HeaderText = "Material", Width = 350, DisplayIndex = 0 };
            colMaterial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInventario.Columns.Add(colMaterial);

            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn { Name = "Cantidad", DataPropertyName = "Cantidad", HeaderText = "Cantidad", Width = 120, DisplayIndex = 1 };
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.Columns.Add(colCantidad);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn { Name = "Categoria", DataPropertyName = "Categoria", HeaderText = "Categoría", Width = 200, DisplayIndex = 2 };
            colCategoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInventario.Columns.Add(colCategoria);
        }

        private void ConfigurarColumnas()
        {
            tablaInventario.Columns.Clear();
            tablaInventario.Columns.Add("Material", typeof(string));
            tablaInventario.Columns.Add("Cantidad", typeof(int));
            tablaInventario.Columns.Add("Categoria", typeof(string));
            tablaInventario.DefaultView.Sort = "Cantidad ASC";
        }

        private void CargarDatosSimulados()
        {
            tablaInventario.Rows.Add("Acrílico Polimetilmetacrilato", 45, "Estructural");
            tablaInventario.Rows.Add("Placas de Vidrio Templado", 8, "Estructural");
            tablaInventario.Rows.Add("Sustrato Botánico", 120, "Laboratorio");
        }

        private void EstilizarGrid()
        {
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInventario.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgvInventario.DefaultCellStyle.ForeColor = Color.Gainsboro;
            dgvInventario.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dgvInventario.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null && dgvInventario.CurrentRow.DataBoundItem is DataRowView fila)
            {
                txtNombreInsumo.Text = fila["Material"].ToString();
                txtCantidad.Text = fila["Cantidad"].ToString();
                txtCategoria.Text = fila["Categoria"].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreInsumo.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("¡Atención! Para registrar un nuevo insumo, es obligatorio completar todos los campos.\n\nPor favor, verifique los datos y vuelva a intentar.", "Campo Incompleto - GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in tablaInventario.Rows)
            {
                if (row["Material"].ToString().Equals(txtNombreInsumo.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El material ya existe en el sistema. Utilice el botón 'Modificar' para ajustar existencias.", "Material Duplicado - GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (!int.TryParse(txtCantidad.Text, out int cant)) { MessageBox.Show("Cantidad inválida. Ingrese solo números enteros.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            tablaInventario.Rows.Add(txtNombreInsumo.Text.Trim(), cant, txtCategoria.Text.Trim());
            LimpiarCajas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN CRÍTICA: Verificamos que realmente haya una fila seleccionada en la interfaz
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un registro de la tabla haciendo clic en él antes de modificar.",
                                "Sin Selección - GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvInventario.CurrentRow != null && dgvInventario.CurrentRow.DataBoundItem is DataRowView fila)
            {
                if (!int.TryParse(txtCantidad.Text, out int cant))
                {
                    MessageBox.Show("Cantidad inválida.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                fila["Material"] = txtNombreInsumo.Text.Trim();
                fila["Cantidad"] = cant;
                fila["Categoria"] = txtCategoria.Text.Trim();

                MessageBox.Show("Registro actualizado correctamente.", "Éxito - GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCajas();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow != null)
            {
                ((DataRowView)dgvInventario.CurrentRow.DataBoundItem).Delete();
                LimpiarCajas();
            }
        }

        private void LimpiarCajas()
        {
            dgvInventario.SelectionChanged -= dgvInventario_SelectionChanged;
            txtNombreInsumo.Clear();
            txtCantidad.Clear();
            txtCategoria.Clear();
            dgvInventario.ClearSelection();
            dgvInventario.SelectionChanged += dgvInventario_SelectionChanged;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCajas();

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            tablaInventario.DefaultView.RowFilter = string.IsNullOrEmpty(filtro) ? "" : $"Material LIKE '%{filtro}%' OR Categoria LIKE '%{filtro}%'";
        }

        private void btnAnalizarStock_Click(object sender, EventArgs e)
        {
            if (tablaInventario.Rows.Count == 0)
            {
                MessageBox.Show("El inventario no contiene materiales registrados para analizar.", "Inventario Vacío - GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAlertas.Text = "⚠️ Inventario vacío.";
                lblAlertas.ForeColor = Color.Yellow;
                return;
            }

            int contadorCriticos = 0;
            foreach (DataGridViewRow fila in dgvInventario.Rows)
            {
                int cantidadStock = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                if (cantidadStock <= 1) { fila.DefaultCellStyle.BackColor = Color.DarkRed; fila.DefaultCellStyle.ForeColor = Color.White; contadorCriticos++; }
                else if (cantidadStock < 10) { fila.DefaultCellStyle.BackColor = Color.DarkOrange; fila.DefaultCellStyle.ForeColor = Color.Black; contadorCriticos++; }
                else { fila.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38); fila.DefaultCellStyle.ForeColor = Color.Gainsboro; }
            }

            ActualizarLabelAlertas(contadorCriticos);
            MostrarResumenOrdenCompra(contadorCriticos);
        }

        private void ActualizarLabelAlertas(int cantidadCriticos)
        {
            lblAlertas.Text = cantidadCriticos == 0 ? "✅ Inventario estable." : $"🔴 {cantidadCriticos} ítem(s) requieren Orden de Compra.";
            lblAlertas.ForeColor = cantidadCriticos == 0 ? Color.LightGreen : Color.OrangeRed;
        }

        private void MostrarResumenOrdenCompra(int contador)
        {
            MessageBox.Show(contador == 0 ? "Inventario en niveles saludables." : $"Se han detectado {contador} insumos en niveles bajos/críticos. Revise el resaltado en pantalla.", "Análisis de Stock - GenVault C.A.", MessageBoxButtons.OK, contador == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "OrdenCompra_" + DateTime.Now.ToString("ddMMyyyy") };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("Material;Cantidad;Categoria");
                    foreach (DataGridViewRow fila in dgvInventario.Rows)
                    {
                        int cant = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                        if (cant < 10) sw.WriteLine($"{fila.Cells["Material"].Value};{cant};{fila.Cells["Categoria"].Value}");
                    }
                }
                MessageBox.Show("Exportación exitosa.", "GenVault C.A.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblAlertas_Click(object sender, EventArgs e) { }
        private void txtCantidad_TextChanged(object sender, EventArgs e) { }
        private void txtNombreInsumo_TextChanged(object sender, EventArgs e) { }
    }
}