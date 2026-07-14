using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
        
            // Trim() elimina espacios en blanco accidentales que el usuario deje al inicio o al final
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text.Trim();

            // Validamos las credenciales simuladas de GenVault
            if (usuario == "investigador" && clave == "genvault123")
            {
                lblMensaje.ForeColor = Color.LimeGreen;
                lblMensaje.Text = "Acceso Concedido. Bienvenido a GenVault Nexus.";
                // Aquí luego Christian conectará este evento para ocultar el login
            }
            else
            { 
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "ACCESO DENEGADO. Credenciales inválidas.";

                // Limpiamos la contraseña y devolvemos el foco al usuario por comodidad
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }
    
    }
}
