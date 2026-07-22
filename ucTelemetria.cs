using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucTelemetria : UserControl
    {
        int temperaturaActual = 24;
        Random clima = new Random();

        // Bandera para asegurar que el video crítico solo se dispare al entrar en zona de peligro
        bool estadoCritico = false;

        public ucTelemetria()
        {
            InitializeComponent();

            // Configuración inicial del reproductor ActiveX
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.stretchToFit = true;

            // Prevención de Audio Fantasma al cambiar de módulos
            this.VisibleChanged += ucTelemetria_VisibleChanged;

            // Inicia permanentemente reproduciendo el video normal de fondo
            ReproducirVideo("telemetria_normal.mp4.mp4");
        }

        private void ucTelemetria_VisibleChanged(object sender, EventArgs e)
        {
            // Si el usuario cambia a otra pantalla, apagamos el reproductor agresivamente
            if (!this.Visible)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = string.Empty;
            }
            else
            {
                // Si vuelve a entrar, reanudamos el estado que corresponda
                if (estadoCritico)
                    ReproducirVideo("telemetria_critico.mp4.mp4");
                else
                    ReproducirVideo("telemetria_normal.mp4.mp4");
            }
        }

        // Método auxiliar para cambiar de video de forma limpia
        private void ReproducirVideo(string nombreArchivo)
        {
            string rutaVideo = Path.Combine(Application.StartupPath, nombreArchivo);

            if (File.Exists(rutaVideo))
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = rutaVideo;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de video en: " + rutaVideo, "Error de Multimedia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrClima_Tick(object sender, EventArgs e)
        {
            temperaturaActual += clima.Next(-1, 4);
            lblTemperatura.Text = temperaturaActual.ToString() + "°C";

            // Condición estricta: Solo salta al video crítico al superar los 35°C por primera vez
            if (temperaturaActual > 35)
            {
                lblAlertaTemp.Visible = true;

                if (!estadoCritico)
                {
                    estadoCritico = true;
                    // Aseguramos que el loop esté activo para la alerta crítica
                    axWindowsMediaPlayer1.settings.setMode("loop", true);

                    // El video crítico sale EXCLUSIVAMENTE al haber riesgo crítico
                    ReproducirVideo("telemetria_critico.mp4.mp4");
                }
            }
        }

        // Convertimos el botón a "async" para poder esperar a que termine el video de recuperación
        private async void btnVentilacion_Click(object sender, EventArgs e)
        {
            temperaturaActual = 24;
            lblTemperatura.Text = "24 °C";
            lblAlertaTemp.Visible = false;

            // Evaluamos si el botón se presiona bajo amenaza crítica o por simple prevención
            if (estadoCritico)
            {
                estadoCritico = false;

                // 1. Apagamos el bucle temporalmente para que el video de recuperación se vea UNA sola vez
                axWindowsMediaPlayer1.settings.setMode("loop", false);
                ReproducirVideo("telemetria_recuperacion.mp4.mp4");

                // 2. Desactivamos el botón temporalmente para que el usuario no interrumpa la cinemática
                btnVentilacion.Enabled = false;

                // ========================================================
                // 3. TIEMPO DE ESPERA DEL VIDEO DE RECUPERACIÓN
                // Ajusta este número al tiempo exacto que dura tu video (ej. 6000 ms = 6 segundos)
                // ========================================================
                await Task.Delay(6000);

                // 4. Tras terminar el video, volvemos a encender el bucle y ponemos la telemetría normal
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                ReproducirVideo("telemetria_normal.mp4.mp4");

                // 5. Reactivamos el botón
                btnVentilacion.Enabled = true;
            }
            else
            {
                // Si se pulsa en estado normal, se mantiene firmemente el video normal y el loop
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                ReproducirVideo("telemetria_normal.mp4.mp4");
            }

            // ========================================================
            // REGISTRO DE AUDITORÍA: ACCIÓN DE VENTILACIÓN Y CONTROL TÉRMICO
            // ========================================================
            Auditoria.Registrar("Unidad de Telemetría", "ACCION_VENTILACION", "Se activó el control de ventilación para enfriar y restablecer la temperatura a 24°C.");
        }

        private void lblTemperatura_Click(object sender, EventArgs e)
        {

        }

        private void lblAlertaTemp_Click(object sender, EventArgs e)
        {

        }
    }
}