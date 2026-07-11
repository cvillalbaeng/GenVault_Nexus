using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucEmergencia : UserControl
    {
        public ucEmergencia()
        {
            InitializeComponent();
        }

        private void btnIncendio_Click(object sender, EventArgs e)
        {
            // Apenas le dan al boton, cambiamos el texto a rojo avisando del fuego
            lblEstadoFuego.Text = "Alarmas: ¡DETECTANDO FUEGO!";
            lblEstadoFuego.ForeColor = Color.Red;

            // Aqui evitamos la falla de la auditoria. Preguntamos antes de apagar los imanes.
            DialogResult respuesta = MessageBox.Show(
                "ALERTA DE EVACUACIÓN. El sistema intentará desactivar todas las puertas (Fail-Open).\n\n¿Desea ANULAR esta orden y mantener las jaulas B y C cerradas por seguridad biológica?",
                "Protocolo de Contención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Revisamos que decidio el usuario
            if (respuesta == DialogResult.Yes)
            {
                // Uff, le dio a que si. Mantenemos bloqueadas las unidades B y C.
                lblEstadoPuertas.Text = "Electroimanes: BLOQUEO DE EMERGENCIA ACTIVADO";
                lblEstadoPuertas.ForeColor = Color.LimeGreen; // Color verde para indicar seguridad

                MessageBox.Show("Falla corregida. Especímenes peligrosos asegurados.");
            }
            else
            {
                // Le dio a que no... se apagan los electroimanes y hay peligro de fuga.
                lblEstadoPuertas.Text = "Electroimanes: APAGADOS. ¡PELIGRO DE FUGA!";
                lblEstadoPuertas.ForeColor = Color.Red;
            }
        }
    }
}
