using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucBaseDatos : UserControl
    {
        private DataTable tablaAuditoria = new DataTable("Auditoria");
        private string rutaArchivoAuditoria = Path.Combine(Application.StartupPath, "base_datos_auditoria.xml");
        private string rutaArchivoUsuarios = Path.Combine(Application.StartupPath, "base_datos_usuarios.xml");

        private DataGridView dgvAuditoria;
        private Button btnRespaldar;
        private Button btnRefrescar;
        private Label lblTitulo;

        public ucBaseDatos()
        {
            InitializeComponent();
            ConfigurarInterfazYEstilos();
            CargarDatosAuditoria();
        }

        private void ConfigurarInterfazYEstilos()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(20);

            // Título de la sección
            lblTitulo = new Label()
            {
                Text = "Centro de Mantenimiento, Respaldos y Auditoría Forense",
                ForeColor = Color.Cyan,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            this.Controls.Add(lblTitulo);

            // Botón de Respaldo de Base de Datos (Estilo Gestión de Personal)
            btnRespaldar = new Button()
            {
                Text = "Generar Respaldo (Backup XML)",
                Location = new Point(20, 60),
                Size = new Size(240, 40),
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnRespaldar.FlatAppearance.BorderSize = 0;
            btnRespaldar.Click += BtnRespaldar_Click;
            this.Controls.Add(btnRespaldar);

            // Botón para refrescar los logs
            btnRefrescar = new Button()
            {
                Text = "Actualizar Registros",
                Location = new Point(275, 60),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnRefrescar.FlatAppearance.BorderSize = 0;
            btnRefrescar.Click += (s, e) => CargarDatosAuditoria();
            this.Controls.Add(btnRefrescar);

            // DataGridView para mostrar la Auditoría (Con scroll activo y estilo consistente)
            dgvAuditoria = new DataGridView()
            {
                Location = new Point(20, 120),
                Size = new Size(950, 480),
                BackgroundColor = Color.FromArgb(30, 30, 30),
                GridColor = Color.FromArgb(60, 60, 60),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ScrollBars = ScrollBars.Both,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            // Estilos de la tabla idénticos a ucUsuario
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.BorderStyle = BorderStyle.None;

            dgvAuditoria.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAuditoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
            dgvAuditoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.Cyan;
            dgvAuditoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvAuditoria.ColumnHeadersHeight = 35;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvAuditoria.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvAuditoria.DefaultCellStyle.ForeColor = Color.White;
            dgvAuditoria.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dgvAuditoria.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAuditoria.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            this.Controls.Add(dgvAuditoria);
        }

        private void CargarDatosAuditoria()
        {
            try
            {
                tablaAuditoria.Clear();
                if (File.Exists(rutaArchivoAuditoria))
                {
                    // Lectura nativa directa para respetar la codificación y evitar caracteres corruptos
                    tablaAuditoria.ReadXml(rutaArchivoAuditoria);

                    dgvAuditoria.DataSource = tablaAuditoria;

                    // Ordenar por fecha y hora descendente si existen las columnas
                    if (tablaAuditoria.Columns.Contains("Fecha") && tablaAuditoria.Columns.Contains("Hora"))
                    {
                        tablaAuditoria.DefaultView.Sort = "Fecha DESC, Hora DESC";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros de auditoría: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRespaldar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(rutaArchivoUsuarios))
            {
                MessageBox.Show("No se encontró el archivo principal de base de datos de usuarios para respaldar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo XML de Respaldo (*.xml)|*.xml";
                sfd.FileName = $"GenVault_Respaldo_Usuarios_{DateTime.Now:yyyyMMdd_HHmmss}.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(rutaArchivoUsuarios, sfd.FileName, true);

                        // ========================================================
                        // REGISTRO DE AUDITORÍA: RESPALDO DE BASE DE DATOS
                        // ========================================================
                        Auditoria.Registrar(
                            "Mantenimiento y Respaldos",
                            "RESPALDO_BASE_DATOS",
                            $"Se generó una copia de seguridad exitosa de la base de datos en la ruta: {sfd.FileName}"
                        );

                        MessageBox.Show("Copia de seguridad (Backup) generada y almacenada con éxito.", "Respaldo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosAuditoria(); // Refrescar la tabla para ver el nuevo registro de auditoría
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el respaldo físico: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}