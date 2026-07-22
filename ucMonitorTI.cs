using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorTI
{
    public partial class ucMonitorTI : UserControl
    {
        Random generadorAleatorio = new Random();

        // Variable para mantener la memoria del tráfico y que sea progresivo
        private int traficoActual = 40;

        public ucMonitorTI()
        {
            InitializeComponent();
            this.VisibleChanged += ucMonitorTI_VisibleChanged;
        }

        private void ucMonitorTI_Load(object sender, EventArgs e)
        {
            try
            {
                if (axWindowsMediaPlayer1 != null)
                {
                    axWindowsMediaPlayer1.uiMode = "none";
                    axWindowsMediaPlayer1.stretchToFit = true;
                    axWindowsMediaPlayer1.Visible = false;
                    axWindowsMediaPlayer1.settings.autoStart = false;
                }

                // Temporizador a 1 segundo para fluidez
                tmrRed.Interval = 1000;
            }
            catch { }
        }

        private void ucMonitorTI_VisibleChanged(object sender, EventArgs e)
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
                    axWindowsMediaPlayer1.URL = string.Empty;
                    axWindowsMediaPlayer1.Visible = false;
                }
            }
            catch { }
        }

        private async void tmrRed_Tick(object sender, EventArgs e)
        {
            int incremento;

            // ========================================================
            // LÓGICA DE SUSPENSO: Curva de tensión antes de la alerta
            // ========================================================
            if (traficoActual >= 88)
            {
                // Si está en la zona de peligro, sube agónicamente lento (1% o 2% por segundo)
                incremento = generadorAleatorio.Next(1, 3);
            }
            else
            {
                // Si está en niveles normales, sube más rápido (5% a 15% por segundo)
                incremento = generadorAleatorio.Next(5, 16);
            }

            traficoActual += incremento;

            // Tope de seguridad visual para que la barra no dé error si pasa de 100
            if (traficoActual > 100)
            {
                traficoActual = 100;
            }

            pbRed.Value = traficoActual;
            lblTrafico.Text = "Tráfico de Red Borde: " + traficoActual.ToString() + "%";

            // Si llega a 95 o más, explota la crisis
            if (traficoActual >= 95)
            {
                if (!lblAlertaZabbix.Visible)
                {
                    lblAlertaZabbix.Visible = true;

                    string rutaVideo = Path.Combine(Application.StartupPath, "animación alerta zabbix.mp4");

                    if (File.Exists(rutaVideo))
                    {
                        tmrRed.Stop();

                        axWindowsMediaPlayer1.URL = rutaVideo;
                        axWindowsMediaPlayer1.Visible = true;
                        axWindowsMediaPlayer1.BringToFront();
                        axWindowsMediaPlayer1.Ctlcontrols.play();

                        // Esperamos a que la animación de Zabbix termine (Ej: 5000 ms = 5s)
                        await Task.Delay(5000);

                        // REINICIO POST-CRISIS: El sistema "mitigó" el ataque, el tráfico vuelve a bajar de golpe
                        traficoActual = generadorAleatorio.Next(30, 50);
                        lblAlertaZabbix.Visible = false;
                        DetenerYLimpiarVideo();

                        tmrRed.Start();
                    }
                    else
                    {
                        MessageBox.Show("Fallo de ruta: No se encontró el video en:\n" + rutaVideo, "Depuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pbRed_Click(object sender, EventArgs e)
        {
        }

        private void lblAlertaZabbix_Click(object sender, EventArgs e)
        {
        }
    }
}