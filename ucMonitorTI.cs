using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorTI
{
    public partial class ucMonitorTI : UserControl
    {
        Random generadorAleatorio = new Random();

        public ucMonitorTI()
        {
            InitializeComponent();
        }

        private void tmrRed_Tick(object sender, EventArgs e)
        {
            // Genera un número de tráfico entre 40% y 100%
            int traficoActual = generadorAleatorio.Next(40, 101);

            pbRed.Value = traficoActual;
            lblTrafico.Text = "Tráfico de Red Borde: " + traficoActual.ToString() + "%";

            if (traficoActual >= 95)
            {
                lblAlertaZabbix.Visible = true;
            }
            else
            {
                lblAlertaZabbix.Visible = false;
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
