using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace GenVault_Nexus
{
    public partial class ucInventario : UserControl
    {

        // Un DataGridView es Temporal
        // Usando un DataTable, separo la LÓGICA (los datos crudos: 
        // nombre del insumo, cantidad, etc.) de la PRESENTACIÓN 
        // (cómo se ve en el grid, colores, tamaños de columna).
        //
        // Cuando el compañero del:
        // Módulo 8 (Backend/SQLite) entregue su ConexionDB.cs, yo NO
        // tengo que reescribir el analizador de stock ni tocar el
        // DataGridView. Solo cambio de dónde SALEN los datos: en vez
        // de llenarlos manualmente aquí, los voy a traer con una
        // consulta SQL y los sigo metiendo en el mismo Dt.
        // El resto del código no se toca.
        // // ============================================================
        private DataTable tablaInventario = new DataTable();

        public ucInventario()
        {
            InitializeComponent();
            this.Load += ucInventario_Load;
        }

        private void ucInventario_Load(object sender, EventArgs e)
        {
            ConfigurarColumnas();
            CargarDatosSimulados();
            // insumos ni de laboratorios, solo sabe DIBUJAR una tabla.
            // Le entregamos el DataTable y Windows Forms se encarga
            // de renderizar filas y columnas automáticamente.
            dgvInventario.DataSource = tablaInventario;

            EstilizarGrid();
        }

        // Define la ESTRUCTURA de la tabla, como el CREATE TABLE de una BD
        private void ConfigurarColumnas()
        {
            tablaInventario.Columns.Add("Material", typeof(string));
            tablaInventario.Columns.Add("Cantidad", typeof(int));
        }

        // Simula los registros que en el futuro vendrán de SQLite
        //(Módulo 8). Por ahora están hardcodeados.
        private void CargarDatosSimulados()
        {
            tablaInventario.Rows.Add("Acrílico Polimetilmetacrilato", 45);
            tablaInventario.Rows.Add("Placas de Vidrio Templado", 8);
            tablaInventario.Rows.Add("Sustrato Botánico", 120);
            tablaInventario.Rows.Add("Reactivos Secuencia ADN", 4);
            tablaInventario.Rows.Add("Guantes de Nitrilo (Caja x100)", 25);
            tablaInventario.Rows.Add("Jeringas Estériles 10ml", 3);
            tablaInventario.Rows.Add("Alcohol Isopropílico (Litros)", 60);
            tablaInventario.Rows.Add("Puntas para Micropipeta", 0);
        }

        // Colores,ETC.
        private void EstilizarGrid()
        {
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.GridColor = Color.FromArgb(60, 60, 60);
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.ReadOnly = true;

            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInventario.ColumnHeadersHeight = 35;

            dgvInventario.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgvInventario.DefaultCellStyle.ForeColor = Color.Gainsboro;
            dgvInventario.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dgvInventario.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvInventario.RowTemplate.Height = 30;

            if (dgvInventario.Columns["Material"] != null)
                dgvInventario.Columns["Material"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvInventario.Columns["Material"].Width = 550;

            if (dgvInventario.Columns["Cantidad"] != null)
                dgvInventario.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvInventario.Columns["Cantidad"].Width = 150;

        }

        // ============================================================
        // LÓGICA PRINCIPAL: Reemplaza el "criterio visual" del analista
        // ============================================================
        //   - Cantidad <= 1   -> Stock CRÍTICO (rojo oscuro)
        //   - Cantidad < 10   -> Stock BAJO (naranja)
        //   - Cantidad >= 10  -> Stock saludable (sin alerta)
        // ============================================================
        private void btnAnalizarStock_Click(object sender, EventArgs e)
        {
            int contadorCriticos = 0;

            foreach (DataGridViewRow fila in dgvInventario.Rows)
            {
                if (fila.Cells["Cantidad"].Value == null) continue;

                int cantidadStock = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                if (cantidadStock <= 1)
                {
                    // Stock crítico extremo -> Orden de Compra URGENTE
                    fila.DefaultCellStyle.BackColor = Color.DarkRed;
                    fila.DefaultCellStyle.ForeColor = Color.White;
                    contadorCriticos++;
                }
                else if (cantidadStock < 10)
                {
                    // Stock bajo -> Sugerencia de Orden de Compra
                    fila.DefaultCellStyle.BackColor = Color.DarkOrange;
                    fila.DefaultCellStyle.ForeColor = Color.Black;
                    contadorCriticos++;
                }
                else
                {
                    // Stock saludable -> se restaura el color normal
                    // esto evita que quede pintado si el usuario
                    // presiona el botón varias veces
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
                    fila.DefaultCellStyle.ForeColor = Color.Gainsboro;
                }
            }

            ActualizarLabelAlertas(contadorCriticos);
            MostrarResumenOrdenCompra(contadorCriticos);
        }

        // Actualiza el contador visual de alertas debajo del grid
        private void ActualizarLabelAlertas(int cantidadCriticos)
        {
            if (cantidadCriticos == 0)
            {
                lblAlertas.Text = "✅ Inventario estable. No se requieren Órdenes de Compra.";
                lblAlertas.ForeColor = Color.LightGreen;
            }
            else
            {
                lblAlertas.Text = "🔴 " + cantidadCriticos + " ítem(s) requieren Orden de Compra sugerida.";
                lblAlertas.ForeColor = Color.OrangeRed;
            }
        }

        // Muestra el MessageBox simulando la notificación
        // que en un sistema real se le enviaría al departamento de Compras.
        private void MostrarResumenOrdenCompra(int cantidadCriticos)
        {
            if (cantidadCriticos == 0)
            {
                MessageBox.Show(
                    "El inventario se encuentra en niveles saludables.\nNo se generaron órdenes de compra.",
                    "Análisis de Stock - GenVault C.A.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Se han generado " + cantidadCriticos + " sugerencia(s) de Orden de Compra.\n\n" +
                    "Revise las filas resaltadas en el inventario para más detalle.",
                    "Análisis de Stock - GenVault C.A.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblAlertas_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Abrimos la ventana típica de Windows para "Guardar archivo como..."
            SaveFileDialog ventanaGuardar = new SaveFileDialog();
            ventanaGuardar.Filter = "Archivo CSV (*.csv)|*.csv";
            ventanaGuardar.Title = "Guardar Sugerencia de Orden de Compra";
            ventanaGuardar.FileName = "OrdenCompra_GenVault_" + DateTime.Now.ToString("ddMMyyyy");

            // 2. Si el usuario elige una ruta y le da a "Guardar"...
            if (ventanaGuardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Preparamos el constructor de texto para escribir el archivo
                    using (StreamWriter escritor = new StreamWriter(ventanaGuardar.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Escribimos la cabecera del archivo
                        escritor.WriteLine("Material;Cantidad_Actual;Estado");

                        // 4. Recorremos toda la tabla (el DataGridView) fila por fila
                        foreach (DataGridViewRow fila in dgvInventario.Rows)
                        {
                            if (fila.Cells["Cantidad"].Value != null)
                            {
                                string material = fila.Cells["Material"].Value.ToString();
                                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                                // Solo exportamos los que necesitan compra (Críticos o Bajos)
                                if (cantidad < 10)
                                {
                                    string estado = (cantidad <= 1) ? "CRITICO" : "BAJO";

                                    // Escribimos la línea separada por comas (formato CSV)
                                    // Cambia la coma por un punto y coma:
                                    escritor.WriteLine($"{material};{cantidad};{estado}");
                                }
                            }
                        }
                    }

                    // 5. Avisamos que fue un éxito
                    MessageBox.Show("Orden de compra exportada exitosamente.", "Exportación GenVault", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}