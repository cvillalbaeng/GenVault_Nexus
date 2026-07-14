using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucLogin : UserControl
    {
        public event EventHandler LoginExitoso;

        // 📦 NUEVO: Variables públicas para guardar los datos del usuario que logró entrar
        public string NombreUsuarioLogueado { get; private set; }
        public string DepartamentoLogueado { get; private set; }

        public ucLogin()
        {
            InitializeComponent();
            btnIngresar.Click += btnIngresar_Click;
            txtPassword.KeyPress += txtPassword_KeyPress;
            this.Load += ucLogin_Load;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text.Trim();

            // 🕵️‍♂️ USUARIO 1: Bioinformática
            if (usuario == "investigador" && clave == "genvault123")
            {
                NombreUsuarioLogueado = "Investigador Alpha";
                DepartamentoLogueado = "Bioinformática";
                DarAcceso();
            }
            // 🛡️ USUARIO 2: Ciberseguridad / Admin
            else if (usuario == "admin" && clave == "admin123")
            {
                NombreUsuarioLogueado = "Administrador de Red";
                DepartamentoLogueado = "Ciberseguridad";
                DarAcceso();
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "ACCESO DENEGADO. Credenciales inválidas.";
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }

        // Método auxiliar para no repetir código
        private void DarAcceso()
        {
            lblMensaje.ForeColor = Color.LimeGreen;
            lblMensaje.Text = "Acceso Concedido. Inicializando GenVault Nexus...";
            LoginExitoso?.Invoke(this, EventArgs.Empty);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnIngresar.PerformClick();
            }
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}