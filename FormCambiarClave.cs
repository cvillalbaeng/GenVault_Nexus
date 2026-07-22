using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GenVault_Nexus
{
    public class FormCambiarClave : Form
    {
        private TextBox txtNueva;
        private TextBox txtConfirmar;
        private string usuarioActual;
        private string rutaXml;
        private DataTable tablaFichas;

        public FormCambiarClave(string usuario, string rutaXml, DataTable tablaFichas)
        {
            this.usuarioActual = usuario;
            this.rutaXml = rutaXml;
            this.tablaFichas = tablaFichas;
            ConfigurarPantalla();
        }

        private void ConfigurarPantalla()
        {
            this.Text = "Atención: Cambio de Contraseña Requerido";
            this.Size = new Size(380, 280);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.ControlBox = false; // Oculta la "X" para que no evadan el paso

            Label lblMensaje = new Label()
            {
                Text = $"Bienvenido {usuarioActual}.\nPor políticas de seguridad, debe establecer una contraseña personal y secreta antes de continuar.",
                Location = new Point(20, 20),
                Size = new Size(320, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblNueva = new Label() { Text = "Nueva Contraseña secreta:", Location = new Point(20, 80), AutoSize = true };
            txtNueva = new TextBox() { Location = new Point(20, 100), Width = 320, PasswordChar = '*', BackColor = Color.FromArgb(50, 50, 50), ForeColor = Color.White };

            Label lblConfirmar = new Label() { Text = "Confirmar Contraseña:", Location = new Point(20, 140), AutoSize = true };
            txtConfirmar = new TextBox() { Location = new Point(20, 160), Width = 320, PasswordChar = '*', BackColor = Color.FromArgb(50, 50, 50), ForeColor = Color.White };

            Button btnGuardar = new Button()
            {
                Text = "Guardar y Entrar",
                Location = new Point(20, 200),
                Width = 150,
                Height = 35,
                BackColor = Color.DarkCyan,
                FlatStyle = FlatStyle.Flat
            };
            btnGuardar.Click += BtnGuardar_Click;

            Button btnCancelar = new Button()
            {
                Text = "Cancelar Login",
                Location = new Point(190, 200),
                Width = 150,
                Height = 35,
                BackColor = Color.Firebrick,
                FlatStyle = FlatStyle.Flat
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(lblMensaje);
            this.Controls.Add(lblNueva);
            this.Controls.Add(txtNueva);
            this.Controls.Add(lblConfirmar);
            this.Controls.Add(txtConfirmar);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas de longitud y coincidencia
            if (txtNueva.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNueva.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Encriptamos la nueva clave ANTES de guardarla para poder compararla
            string nuevaClaveEncriptada = Seguridad.EncriptarClave(txtNueva.Text);

            // Busca al usuario en la tabla de memoria para actualizarlo
            foreach (DataRow row in tablaFichas.Rows)
            {
                if (row["Usuario"].ToString() == usuarioActual)
                {
                    string claveActualGuardada = row["Password"].ToString();

                    // ========================================================
                    // 3. REGLA: PREVENIR REUTILIZACIÓN DE CONTRASEÑA
                    // ========================================================
                    if (nuevaClaveEncriptada == claveActualGuardada)
                    {
                        MessageBox.Show("Vulnerabilidad detectada:\n\nLa nueva contraseña no puede ser idéntica a la contraseña temporal o actual. Por políticas de seguridad, debe establecer una contraseña diferente.", "Clave No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        txtNueva.Clear();
                        txtConfirmar.Clear();
                        txtNueva.Focus();
                        return; // Cortamos el flujo, NO se guarda nada.
                    }
                    // ========================================================

                    // Si pasa la validación, procedemos a actualizar
                    row["Password"] = nuevaClaveEncriptada;
                    break;
                }
            }

            // 4. Guardado en disco
            tablaFichas.WriteXml(rutaXml, XmlWriteMode.WriteSchema);

            // ========================================================
            // 5. REGISTRO DE AUDITORÍA: CAMBIO DE CONTRASEÑA
            // ========================================================
            Auditoria.Registrar("Seguridad", "CAMBIO_CONTRASENA", $"El usuario '{usuarioActual}' actualizó y cifró su contraseña correctamente.");

            MessageBox.Show("Contraseña actualizada con éxito y cifrada en la base de datos.", "GenVault Nexus", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}