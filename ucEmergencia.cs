using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucEmergencia : UserControl
    {
        private bool incendioReproduciendose = false;

        public ucEmergencia()
        {
            InitializeComponent();

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.stretchToFit = true;

            // Suscribimos un evento para apagar el video si el usuario sale del control
            this.VisibleChanged += ucEmergencia_VisibleChanged;
        }

        private void ReproducirVideo(string nombreArchivo)
        {
            string rutaVideo = Path.Combine(Application.StartupPath, nombreArchivo);

            if (File.Exists(rutaVideo))
            {
                if (axWindowsMediaPlayer1.URL != rutaVideo)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    axWindowsMediaPlayer1.URL = rutaVideo;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de video: " + rutaVideo, "Error de Multimedia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NUEVO: Método que se dispara automáticamente cuando sales del módulo o cambias de pestaña
        private void ucEmergencia_VisibleChanged(object sender, EventArgs e)
        {
            // Si el control ya no está visible (ej. cambiaste de módulo), detenemos el audio por completo
            if (!this.Visible)
            {
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    axWindowsMediaPlayer1.URL = string.Empty; // Limpia la ruta para liberar el archivo de video
                }
                catch
                {
                    // Evita excepciones si el componente ya fue destruido
                }
            }
        }

        private void btnIncendio_Click(object sender, EventArgs e)
        {
            lblEstadoFuego.Text = "Alarmas: ¡DETECTANDO FUEGO!";
            lblEstadoFuego.ForeColor = Color.Red;

            Auditoria.Registrar("Protocolos de Emergencia", "ACTIVACION_ALARMA_FUEGO", "Se activó manualmente la alarma de detección de fuego en el sistema.");

            if (!incendioReproduciendose)
            {
                incendioReproduciendose = true;
                ReproducirVideo("Incendio video1 .mp4");
            }

            DialogResult respuesta = MessageBox.Show(
                "ALERTA DE EVACUACIÓN. El sistema intentará desactivar todas las puertas (Fail-Open).\n\n¿Desea ANULAR esta orden y mantener las jaulas B y C cerradas por seguridad biológica?",
                "Protocolo de Contención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                lblEstadoPuertas.Text = "Electroimanes: BLOQUEO DE EMERGENCIA ACTIVADO";
                lblEstadoPuertas.ForeColor = Color.LimeGreen;

                ReproducirVideo("Contención exitosa de especimen video 2. mp4.mp4");

                Auditoria.Registrar("Protocolos de Emergencia", "ANULACION_EVACUACION", "Se anuló la apertura fail-open: Las jaulas B y C se mantuvieron bloqueadas por seguridad biológica.");

                MessageBox.Show("Falla corregida. Especímenes peligrosos asegurados.");
            }
            else
            {
                lblEstadoPuertas.Text = "Electroimanes: APAGADOS. ¡PELIGRO DE FUGA!";
                lblEstadoPuertas.ForeColor = Color.Red;

                ReproducirVideo("Fuga de especimenes peligrosos video1_.mp4");

                Auditoria.Registrar("Protocolos de Emergencia", "EJECUCION_FAIL_OPEN", "Se permitió el protocolo de evacuación: Electroimanes apagados en todas las áreas.");
            }
        }
    }
}