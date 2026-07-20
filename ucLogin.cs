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
            txtPassword.KeyPress += txtPassword_KeyPress;
            this.Load += ucLogin_Load;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Capturamos lo que el usuario escribió en la pantalla
            string usuarioIngresado = txtUsuario.Text.Trim();
            string claveIngresada = txtPassword.Text.Trim();

            // 2. Usamos la clase de Abdul para abrir la bóveda
            using (var conexion = ConexionDB.ObtenerConexion())
            {
                // Abrimos la comunicación con el archivo .sqlite
                conexion.Open();

                // 3. Preparamos la orden SQL
                // Pedimos que nos devuelva el "Rol" solo si el usuario y la clave coinciden exactamente
                string query = "SELECT Rol FROM Usuarios WHERE NombreUsuario = @user AND Password = @pass";

                using (var comando = new System.Data.SQLite.SQLiteCommand(query, conexion))
                {
                    // 4. Blindamos la consulta contra inyecciones SQL asignando los parámetros de forma segura
                    comando.Parameters.AddWithValue("@user", usuarioIngresado);
                    comando.Parameters.AddWithValue("@pass", claveIngresada);

                    // 5. Ejecutamos la consulta. 
                    // ExecuteScalar() busca la respuesta. Si encuentra al usuario, guarda el Rol. Si no, devuelve null.
                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        // Si el resultado no es nulo, significa que las credenciales son correctas
                        string rolObtenido = resultado.ToString();

                        MessageBox.Show($"¡Acceso concedido!\nBienvenido investigador. Rol detectado: {rolObtenido}",
                                        "Seguridad GenVault",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // (Próximamente aquí enlazaremos el código para desbloquear el menú del FormMain)
                    }
                    else
                    {
                        // Si es nulo, el usuario no existe o la clave está mal
                        MessageBox.Show("Credenciales incorrectas o el usuario no existe en la base de datos.",
                                        "Alerta de Seguridad",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Capturamos los datos
            string usuarioIngresado = txtUsuario.Text.Trim();
            string claveIngresada = txtPassword.Text.Trim();

            using (var conexion = ConexionDB.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT Rol FROM Usuarios WHERE NombreUsuario = @user AND Password = @pass";

                using (var comando = new System.Data.SQLite.SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@user", usuarioIngresado);
                    comando.Parameters.AddWithValue("@pass", claveIngresada);

                    object resultado = comando.ExecuteScalar();

                    // === AQUÍ ENTRA LA NUEVA LÓGICA ===
                    if (resultado != null)
                    {
                        // Extraemos el rol de la base de datos
                        string rolObtenido = resultado.ToString();

                        MessageBox.Show($"¡Acceso concedido!\nBienvenido investigador. Rol detectado: {rolObtenido}", "Seguridad GenVault", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // COMUNICACIÓN CON FORM MAIN:
                        // Buscamos cuál es el formulario principal que contiene a este módulo
                        FormMain ventanaPrincipal = (FormMain)this.FindForm();

                        // Si lo encontramos, le pasamos los datos para que actualice la barra y el menú
                        if (ventanaPrincipal != null)
                        {
                            ventanaPrincipal.IniciarSesion(usuarioIngresado, rolObtenido);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas o el usuario no existe.", "Alerta de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // ===================================
                }
            }
        }
    }
}