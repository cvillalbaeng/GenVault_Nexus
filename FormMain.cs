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
        // TODO: Integración BD (Logística) - Reemplazar la carga de datos manual (Mock) en el DataTable por la consulta SQL hacia ConexionDB.cs cuando el backend (SQLite) esté integrado.
        // TODO: Integrar conexión SQL a la base de datos para validar credenciales reales y extraer el departamento del usuario dinámicamente.
        // TODO: UI/UX - Crear un formulario base personalizado (CustomMessageBox) para reemplazar las alertas genéricas de Windows y unificar el diseño con el Dark Mode.
        // TODO: UI/UX - Diseñar e integrar el isotipo/logo institucional de GenVault Nexus en la pantalla de Login y en la cabecera del FormMain.
        // TODO: Seguridad (Audit Trail) - Crear método global en C# y tabla en SQL para registrar TODO evento crítico. Debe capturar: Fecha/Hora, Usuario logueado, Módulo (Login, Emergencias, Telemetría, etc.) y Acción detallada (ej. "Inició sesión", "Activó simulacro", "Cambió temperatura").
        // TODO: Panel de Admin (Diseño) - Diseñar la ficha de registro de usuarios incluyendo un PictureBox para cargar la Fotografía de perfil y campos de Cédula/Cargo. La Base de Datos debe estar preparada para almacenar imágenes (VARBINARY) o sus rutas.
        // TODO: Gestión de Usuarios (CRUD) - Desarrollar la lógica en el panel de Administrador para Crear, Modificar, Inhabilitar y Listar usuarios del sistema. Debe incluir la asignación dinámica de Roles/Departamentos y la encriptación segura de contraseñas al insertarlas en la base de datos.

        // Importación de librerías de Windows para mover pantallas sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormMain()
        {
            InitializeComponent();

            // 1. Al arrancar el programa, cerramos todas las puertas
            BloquearMenu();

            // 2. Obligamos a mostrar la taquilla de Ciberseguridad
            CargarPantallaInicial();
        }

        // ====================================================================
        // MÉTODOS DE SEGURIDAD Y CONTROL DE ACCESO
        // ====================================================================
        private void BloquearMenu()
        {
            // Apagamos todos los botones de los departamentos existentes
            btnBioinformatica.Enabled = false;
            btnBaseDeDatos.Enabled = false;
            btnTelemetria.Enabled = false;
            btnLogistica.Enabled = false;
            btnMonitor.Enabled = false;
            btnEmergencia.Enabled = false;
        }

        private void CargarPantallaInicial()
        {
            lblCabecera.Text = "GenVault > Autenticación de Usuario";
            pnlContenedor.Controls.Clear();

            // Creamos el módulo de login y le conectamos el cable de validación
            ucLogin moduloLogin = new ucLogin();
            moduloLogin.LoginExitoso += ModuloLogin_LoginExitoso;
            MostrarModulo(moduloLogin);
        }

        // El sistema llama automáticamente a esto cuando el login es correcto
        private void ModuloLogin_LoginExitoso(object sender, EventArgs e)
        {
            // Extraemos la información del usuario
            ucLogin loginAprobado = (ucLogin)sender;
            string nombre = loginAprobado.NombreUsuarioLogueado;
            string departamento = loginAprobado.DepartamentoLogueado;

            // Actualizamos la barra de estado inferior
            lblCabecera.Text = $"GenVault > {departamento}";
            toolStripStatusLabel1.Text = $"Usuario: {nombre} (Conectado)";
            toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (En Línea)";
            toolStripStatusLabel3.Text = $"Módulo Activo: {departamento}";

            // LÓGICA DE DESBLOQUEO POR DEPARTAMENTOS REALES
            if (departamento == "Bioinformática")
            {
                btnBioinformatica.Enabled = true;
                MostrarModulo(new ucBioinformatica());
            }
            else if (departamento == "Ciberseguridad")
            {
                // Al administrador de red le damos acceso al Monitor TI y a Emergencias
                btnMonitor.Enabled = true;
                btnEmergencia.Enabled = true;
                MostrarModulo(new ucMonitorTI());
            }
            // Agregamos los demás para cuando la Base de Datos esté lista:
            else if (departamento == "Base de Datos")
            {
                btnBaseDeDatos.Enabled = true;
            }
            else if (departamento == "Telemetría")
            {
                btnTelemetria.Enabled = true;
                MostrarModulo(new ucTelemetria());
            }
            else if (departamento == "Logística")
            {
                btnLogistica.Enabled = true;
                MostrarModulo(new ucInventario());
            }
        }

        // ====================================================================
        // FUNCIÓN MAESTRA: Limpia el panel central e incrusta el módulo pedido
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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Como el sistema arranca con Login, este botón ahora sirve para "Cerrar Sesión"
            // Borramos los datos de la barra inferior
            toolStripStatusLabel1.Text = "Usuario: Esperando inicio de sesión...";
            toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (Desconectado)";
            toolStripStatusLabel3.Text = "Módulo Activo: Ninguno";

            // Bloqueamos las puertas y volvemos a la pantalla inicial
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
            MostrarModulo(new ucMonitorTI());
        }

        private void btnEmergencia_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Protocolos de Emergencia";
            MostrarModulo(new ucEmergencia());
        }

        private void timeReloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void btnBioinformatica_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Bioinformática";
            MostrarModulo(new ucBioinformatica());
        }

        private void btnBaseDeDatos_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Base de Datos";
            pnlContenedor.Controls.Clear();
            // TODO: Reemplazar esta línea anterior cuando entreguen el módulo e inyectar la siguiente línea comentada:
            // MostrarModulo(new ucBaseDatos());
        }

        private void btnTelemetria_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Unidad de Telemetría";
            MostrarModulo(new ucTelemetria());
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Logística e Inventario";
            MostrarModulo(new ucInventario());
        }

        // Métodos vacíos de diseño dejados intactos por precaución
        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}