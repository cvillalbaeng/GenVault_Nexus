using MonitorTI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class FormMain : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormMain()
        {
            InitializeComponent();

            // ====================================================================
            // INICIALIZACIÓN DE BASE DE DATOS SQLITE (MÓDULO DE EQUIPO)
            // ====================================================================
            ConexionDB.InicializarDB();

            // ====================================================================
            // SOLUCIÓN DE DIMENSIONES (Adaptable para Monitores y Laptops)
            // ====================================================================
            this.MinimumSize = new Size(1024, 700);
            this.AutoScroll = true;
            this.WindowState = FormWindowState.Maximized;

            // Al arrancar el programa, cerramos puertas y ocultamos botones
            BloquearMenu();

            // Obligamos a mostrar la taquilla de inicio de sesión
            CargarPantallaInicial();
        }

        // ====================================================================
        // MÉTODO DE JERARQUÍA REQUERIDO POR LA MATRIZ DE SEGURIDAD
        // ====================================================================
        private int ObtenerNivel(string departamento, string cargo)
        {
            if (departamento == "Ciberseguridad") return 1; // Nivel 1: Administrador / Superusuario

            if (departamento == "Dirección de Seguridad")
            {
                if (cargo == "Director de Seguridad") return 2; // Nivel 2
                if (cargo == "Supervisor de Operaciones de Control") return 3; // Nivel 3
            }

            return 4; // Nivel 4: Operativos
        }

        // ====================================================================
        // MÉTODOS DE SEGURIDAD Y CONTROL DE ACCESO
        // ====================================================================
        private void BloquearMenu()
        {
            // Ocultamos TODOS los botones del panel lateral (Visibilidad en False)
            btnBioinformatica.Visible = false;
            btnBaseDeDatos.Visible = false;
            btnTelemetria.Visible = false;
            btnLogistica.Visible = false;
            btnMonitor.Visible = false;
            btnEmergencia.Visible = false;

            if (btnUsuarios != null)
            {
                btnUsuarios.Visible = false;
            }

            // Ocultamos también el botón de Cerrar Sesión en la pantalla de Login
            btnCerrarSesion.Visible = false;
        }

        public void IniciarSesion(string nombreUsuario, string rol)
        {
            toolStripStatusLabel1.Text = $"Usuario: {nombreUsuario} [{rol}]";
            toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (Conectado)";
            toolStripStatusLabel3.Text = "Módulo Activo: Panel de Control";

            pnlContenedor.Controls.Clear();
            lblCabecera.Text = "GenVault > Panel de Control";
        }

        private void CargarPantallaInicial()
        {
            lblCabecera.Text = "GenVault > Autenticación de Usuario";
            pnlContenedor.Controls.Clear();

            ucLogin moduloLogin = new ucLogin();
            moduloLogin.LoginExitoso += ModuloLogin_LoginExitoso;
            MostrarModulo(moduloLogin);
        }

        private void ModuloLogin_LoginExitoso(object sender, EventArgs e)
        {
            ucLogin loginAprobado = (ucLogin)sender;
            string nombre = loginAprobado.NombreUsuarioLogueado;
            string departamento = loginAprobado.DepartamentoLogueado;

            lblCabecera.Text = $"GenVault > {departamento}";
            toolStripStatusLabel1.Text = $"Usuario: {nombre} (Conectado)";
            toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (En Línea)";
            toolStripStatusLabel3.Text = $"Módulo Activo: {departamento}";

            // Al iniciar sesión exitosamente, mostramos el botón de Cerrar Sesión
            btnCerrarSesion.Visible = true;

            // ====================================================================
            // MATRIZ DE SEGURIDAD: LÓGICA DE VISIBILIDAD DINÁMICA POR DEPARTAMENTOS
            // ====================================================================

            string cargoActual = GenVault_Nexus.SesionGlobal.Cargo;
            int nivelActual = ObtenerNivel(departamento, cargoActual);

            // ====================================================================
            // 1. SUPERUSUARIO (ADMINISTRADOR DE RED / CIBERSEGURIDAD - NIVEL 1)
            // ====================================================================
            if (nivelActual == 1 || departamento == "Ciberseguridad")
            {
                // EL ADMIN TIENE ACCESO ABSOLUTO A TODOS LOS MÓDULOS
                btnMonitor.Visible = true;
                btnEmergencia.Visible = true;
                btnBaseDeDatos.Visible = true;
                btnLogistica.Visible = true;
                btnBioinformatica.Visible = true;
                btnTelemetria.Visible = true;
                if (btnUsuarios != null) btnUsuarios.Visible = true;

                MostrarModulo(new ucMonitorTI()); // Inicia viendo el Monitor TI
                return;
            }

            // ====================================================================
            // 2. PERMISOS GRANULARES PARA LOS DEMÁS CARGOS (Niveles 2, 3 y 4)
            // ====================================================================
            if (departamento == "Dirección de Seguridad")
            {
                btnEmergencia.Visible = true;
                btnMonitor.Visible = true;
                if (btnUsuarios != null) btnUsuarios.Visible = true;

                MostrarModulo(new ucUsuario()); // Inicia en el gestor de personal
            }
            else if (departamento == "Logística e Inventario")
            {
                btnLogistica.Visible = true;
                MostrarModulo(new ucInventario());
            }
            else if (departamento == "Bioinformática")
            {
                btnBioinformatica.Visible = true;
                MostrarModulo(new ucBioinformatica());
            }
            else if (departamento == "Unidad de Telemetría")
            {
                btnTelemetria.Visible = true;
                MostrarModulo(new ucTelemetria());
            }
            else
            {
                pnlContenedor.Controls.Clear();
                MessageBox.Show("Advertencia: No se han configurado permisos visuales para este departamento.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ====================================================================
        // FUNCIÓN MAESTRA
        // ====================================================================
        private void MostrarModulo(System.Windows.Forms.UserControl moduloNuevo)
        {
            pnlContenedor.Controls.Clear();
            moduloNuevo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(moduloNuevo);
            moduloNuevo.BringToFront();
        }

        // ====================================================================
        // EVENTOS DE BOTONES Y CONTROLES DE LA INTERFAZ
        // ====================================================================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Usuario: Esperando inicio de sesión...";
            toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (Desconectado)";
            toolStripStatusLabel3.Text = "Módulo Activo: Ninguno";

            BloquearMenu();
            CargarPantallaInicial();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Monitor de Infraestructura TI";
            toolStripStatusLabel3.Text = "Módulo Activo: Monitor TI";
            MostrarModulo(new ucMonitorTI());
        }

        private void btnEmergencia_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Protocolos de Emergencia";
            toolStripStatusLabel3.Text = "Módulo Activo: Emergencia";
            MostrarModulo(new ucEmergencia());
        }

        private void timeReloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void btnBioinformatica_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Bioinformática";
            toolStripStatusLabel3.Text = "Módulo Activo: Bioinformática";
            MostrarModulo(new ucBioinformatica());
        }

        private void btnBaseDeDatos_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Mantenimiento y Respaldos";
            toolStripStatusLabel3.Text = "Módulo Activo: Mantenimiento DB";

            MostrarModulo(new ucBaseDatos());
        }

        private void btnTelemetria_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Unidad de Telemetría";
            toolStripStatusLabel3.Text = "Módulo Activo: Telemetría";
            MostrarModulo(new ucTelemetria());
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Logística e Inventario";
            toolStripStatusLabel3.Text = "Módulo Activo: Logística e Inventario";
            MostrarModulo(new ucInventario());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Gestión de Personal y Seguridad";
            toolStripStatusLabel3.Text = "Módulo Activo: Gestión de Personal";
            MostrarModulo(new ucUsuario());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}