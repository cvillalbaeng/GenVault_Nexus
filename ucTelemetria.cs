using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucTelemetria : UserControl
    {
    int temperaturaActual = 24;
    Random clima = new Random();

    private void tmrClima_Tick(object sender, EventArgs e)
    {
        temperaturaActual += clima.Next(-1, 4);
        lblTemperatura.Text = temperaturaActual.ToString() + "°C";

        if (temperaturaActual > 35)
        {
            lblAlertaTemp.Visible = true;
            
        }
    }

    
        public ucTelemetria()
        {
            InitializeComponent();
        }

        private void lblTemperatura_Click(object sender, EventArgs e)
        {

        }

        private void btnVentilacion_Click(object sender, EventArgs e)
        {
            temperaturaActual = 24;
            lblTemperatura.Text = "24 °C";
            lblAlertaTemp.Visible = false;
        }

        private void lblAlertaTemp_Click(object sender, EventArgs e)
        {

        }
    }
}
