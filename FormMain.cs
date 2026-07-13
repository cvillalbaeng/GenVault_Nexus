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
        // Importación de librerías de Windows para mover pantallas sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public FormMain()
        {
            InitializeComponent();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cierra todos los sub-módulos, limpia la RAM y apaga el programa por completo
            Application.Exit();
        }

       // private void btnTelemetria_Click(object sender, EventArgs e)
       // {
            // Creamos la instancia técnica del componente de telemetría de Ricardo
            //ucTelemetria moduloTelemetria = new ucTelemetria();

            // Lo enviamos a la función maestra para que lo incruste en la pantalla
          // MostrarModulo(moduloTelemetria);
       // }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCiberseguridad_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Ciberseguridad y Accesos";
                   
            pnlContenedor.Controls.Clear();
            // TODO: Reemplazar esta línea anterior cuando entreguen el módudulo e inyectar la siguiente línea comentada:
            // MostrarModulo(new ucCiberseguridad());

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            // Si la ventana está normal, la maximiza. Si ya está maximizada, la restaura.
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBioinformatica_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Bioinformática";
            pnlContenedor.Controls.Clear();
            // TODO: Reemplazar esta línea anterior cuando entreguen el módudulo e inyectar la siguiente línea comentada:
            // MostrarModulo(new ucBioinformatica());
        }

        private void btnBaseDeDatos_Click(object sender, EventArgs e)
        {
            lblCabecera.Text = "GenVault > Base de Datos";
            pnlContenedor.Controls.Clear();
            // TODO: Reemplazar esta línea anterior cuando entreguen el módudulo e inyectar la siguiente línea comentada:
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
            pnlContenedor.Controls.Clear();
            // TODO: Reemplazar esta línea anterior cuando entreguen el módudulo e inyectar la siguiente línea comentada:
            // MostrarModulo(new ucLogistica());
        }
    }
}