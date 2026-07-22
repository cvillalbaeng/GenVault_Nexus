using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public partial class ucLogin : UserControl
    {
        public event EventHandler LoginExitoso;

        public string NombreUsuarioLogueado { get; private set; }
        public string DepartamentoLogueado { get; private set; }

        // Diccionario estático para recordar los intentos fallidos mientras la app esté abierta
        private static Dictionary<string, int> intentosPorUsuario = new Dictionary<string, int>();

        public ucLogin()
        {
            InitializeComponent();
            txtPassword.KeyPress += txtPassword_KeyPress;
            this.Load += ucLogin_Load;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string claveIngresada = txtPassword.Text; // Quitamos el Trim() por si la clave tiene espacios intencionales

            string rutaArchivoXML = Path.Combine(Application.StartupPath, "base_datos_usuarios.xml");
            DataTable tablaLogin = new DataTable("Usuarios");

            // 1. Columnas
            tablaLogin.Columns.Add("Nombres", typeof(string));
            tablaLogin.Columns.Add("Apellidos", typeof(string));
            tablaLogin.Columns.Add("TipoDocumento", typeof(string));
            tablaLogin.Columns.Add("Documento", typeof(string));
            tablaLogin.Columns.Add("Sexo", typeof(string));
            tablaLogin.Columns.Add("FechaNacimiento", typeof(DateTime));
            tablaLogin.Columns.Add("Telefono", typeof(string));
            tablaLogin.Columns.Add("Correo", typeof(string));
            tablaLogin.Columns.Add("Direccion", typeof(string));
            tablaLogin.Columns.Add("Alergias", typeof(string));
            tablaLogin.Columns.Add("Enfermedades", typeof(string));
            tablaLogin.Columns.Add("CondicionesEspeciales", typeof(string));
            tablaLogin.Columns.Add("ContactoEmergencia_Nombre", typeof(string));
            tablaLogin.Columns.Add("ContactoEmergencia_Parentesco", typeof(string));
            tablaLogin.Columns.Add("ContactoEmergencia_Telefono", typeof(string));
            tablaLogin.Columns.Add("Fotografia", typeof(byte[]));
            tablaLogin.Columns.Add("Departamento", typeof(string));
            tablaLogin.Columns.Add("Cargo", typeof(string));
            tablaLogin.Columns.Add("FechaIngreso", typeof(DateTime));
            tablaLogin.Columns.Add("Estado", typeof(string));
            tablaLogin.Columns.Add("Usuario", typeof(string));
            tablaLogin.Columns.Add("Password", typeof(string));

            // 2. Carga o Creación
            if (System.IO.File.Exists(rutaArchivoXML))
            {
                tablaLogin.ReadXml(rutaArchivoXML);
            }
            else
            {
                tablaLogin.Rows.Add(
                    "Administrador", "Sistema", "V", "00000000", "Masculino",
                    new DateTime(1990, 1, 1), "04120000000", "admin@genvault.com",
                    "Oficina Principal de Ciberseguridad", "Ninguna", "Ninguna", "Ninguna",
                    "N/A", "N/A", "0000000", null, "Ciberseguridad", "Administrador de Red",
                    DateTime.Now, "Activo", "admin", Seguridad.EncriptarClave("1234")
                );
                tablaLogin.WriteXml(rutaArchivoXML, XmlWriteMode.WriteSchema);
            }

            // 3. Validar si el usuario existe (SENSIBILIDAD A MAYÚSCULAS)
            DataRow usuarioEncontrado = null;
            foreach (DataRow row in tablaLogin.Rows)
            {
                if (row["Usuario"].ToString().Equals(usuarioIngresado, StringComparison.Ordinal) ||
                    row["Documento"].ToString() == usuarioIngresado)
                {
                    usuarioEncontrado = row;
                    break;
                }
            }

            if (usuarioEncontrado == null)
            {
                // ========================================================
                // REGISTRO DE AUDITORÍA: INTENTO FALLIDO (USUARIO INVÁLIDO)
                // ========================================================
                Auditoria.Registrar("Seguridad", "LOGIN_FALLIDO", $"Intento de acceso fallido con usuario/documento no registrado: '{usuarioIngresado}'.");

                MessageBox.Show("Usuario o credenciales inválidas. Verifique mayúsculas y minúsculas.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Verificar ESTADO
            string estadoActual = usuarioEncontrado["Estado"]?.ToString().Trim();

            if (estadoActual.Equals("Bloqueado", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Su usuario fue bloqueado. Debe contactar al departamento de soporte técnico para su desbloqueo.",
                                "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (estadoActual.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Su cuenta se encuentra en estado PENDIENTE.\n\nDebe esperar la autorización y activación definitiva por parte del Director de Seguridad o el Administrador.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 5. Validar Contraseña e Intentos Fallidos
            string claveRealHash = usuarioEncontrado["Password"].ToString();
            string nombreUsuarioReal = usuarioEncontrado["Usuario"].ToString();

            // Encriptamos lo que el usuario acaba de escribir en la taquilla para compararlo
            string claveIngresadaHash = Seguridad.EncriptarClave(claveIngresada);

            if (claveIngresadaHash == claveRealHash)
            {
                // Limpiamos los intentos si ingresa con éxito
                if (intentosPorUsuario.ContainsKey(nombreUsuarioReal))
                {
                    intentosPorUsuario.Remove(nombreUsuarioReal);
                }

                this.NombreUsuarioLogueado = $"{usuarioEncontrado["Nombres"]} {usuarioEncontrado["Apellidos"]}";
                this.DepartamentoLogueado = usuarioEncontrado["Departamento"].ToString();

                GenVault_Nexus.SesionGlobal.Documento = usuarioEncontrado["Documento"].ToString();
                GenVault_Nexus.SesionGlobal.Departamento = usuarioEncontrado["Departamento"].ToString();
                GenVault_Nexus.SesionGlobal.Cargo = usuarioEncontrado["Cargo"].ToString();

                // ==========================================================
                // REGISTRO DE AUDITORÍA: LOGIN EXITOSO
                // ==========================================================
                Auditoria.Registrar("Seguridad", "LOGIN_EXITOSO", $"El usuario '{nombreUsuarioReal}' inició sesión exitosamente en el departamento de {DepartamentoLogueado}.");

                // ==========================================================
                // INTERCEPTOR DE PRIMER LOGIN (Forzar Cambio de Clave)
                // ==========================================================
                bool esClavePorDefecto = (claveIngresada == usuarioEncontrado["Documento"].ToString() ||
                                         (nombreUsuarioReal == "admin" && claveIngresada == "1234"));

                if (esClavePorDefecto)
                {
                    using (FormCambiarClave frmCambio = new FormCambiarClave(nombreUsuarioReal, rutaArchivoXML, tablaLogin))
                    {
                        if (frmCambio.ShowDialog() == DialogResult.OK)
                        {
                            DarAcceso();
                        }
                        else
                        {
                            MessageBox.Show("Acceso denegado. Es obligatorio establecer una contraseña personal para entrar.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    DarAcceso();
                }
            }
            else
            {
                // LÓGICA DE 3 INTENTOS FALLIDOS
                if (!intentosPorUsuario.ContainsKey(nombreUsuarioReal))
                {
                    intentosPorUsuario[nombreUsuarioReal] = 0;
                }

                intentosPorUsuario[nombreUsuarioReal]++;
                int intentosRestantes = 3 - intentosPorUsuario[nombreUsuarioReal];

                if (intentosRestantes <= 0)
                {
                    usuarioEncontrado["Estado"] = "Bloqueado";
                    tablaLogin.WriteXml(rutaArchivoXML, XmlWriteMode.WriteSchema);

                    // ========================================================
                    // REGISTRO DE AUDITORÍA: BLOQUEO POR EXCESO DE INTENTOS
                    // ========================================================
                    Auditoria.Registrar("Seguridad", "BLOQUEO_POR_INTENTOS", $"La cuenta del usuario '{nombreUsuarioReal}' fue bloqueada automáticamente tras superar 3 intentos fallidos de contraseña.");

                    MessageBox.Show("ALERTA DE SEGURIDAD:\n\nSu cuenta ha sido BLOQUEADA por exceder el límite de 3 intentos fallidos. Contacte a Ciberseguridad.", "Bloqueo de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // ========================================================
                    // REGISTRO DE AUDITORÍA: INTENTO FALLIDO (CLAVE INCORRECTA)
                    // ========================================================
                    Auditoria.Registrar("Seguridad", "LOGIN_FALLIDO", $"Contraseña incorrecta para el usuario '{nombreUsuarioReal}'. Intentos restantes: {intentosRestantes}.");

                    MessageBox.Show($"Contraseña incorrecta.\n\nADVERTENCIA: Le quedan {intentosRestantes} intento(s) antes de que la cuenta sea bloqueada.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DarAcceso()
        {
            if (lblMensaje != null)
            {
                lblMensaje.ForeColor = Color.LimeGreen;
                lblMensaje.Text = "Acceso Concedido. Inicializando GenVault Nexus...";
            }
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
    } // <-- FIN DE LA CLASE ucLogin

    // ========================================================
    // MOTOR DE CRIPTOGRAFÍA
    // ========================================================
    public static class Seguridad
    {
        public static string EncriptarClave(string clavePlana)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(clavePlana));
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}