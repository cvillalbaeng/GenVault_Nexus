namespace GenVault_Nexus
{
    partial class ucEmergencia
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblEstadoFuego = new Label();
            lblEstadoPuertas = new Label();
            btnIncendio = new Button();
            SuspendLayout();
            // 
            // lblEstadoFuego
            // 
            lblEstadoFuego.AutoSize = true;
            lblEstadoFuego.Font = new Font("Segoe UI", 9.5F);
            lblEstadoFuego.ForeColor = Color.White;
            lblEstadoFuego.Location = new Point(348, 167);
            lblEstadoFuego.Name = "lblEstadoFuego";
            lblEstadoFuego.Size = new Size(138, 17);
            lblEstadoFuego.TabIndex = 0;
            lblEstadoFuego.Text = "Alarmas: SILENCIADAS";
            // 
            // lblEstadoPuertas
            // 
            lblEstadoPuertas.AutoSize = true;
            lblEstadoPuertas.Font = new Font("Segoe UI", 9.5F);
            lblEstadoPuertas.ForeColor = Color.White;
            lblEstadoPuertas.Location = new Point(339, 212);
            lblEstadoPuertas.Name = "lblEstadoPuertas";
            lblEstadoPuertas.Size = new Size(147, 17);
            lblEstadoPuertas.TabIndex = 1;
            lblEstadoPuertas.Text = "Electroimanes: ACTIVOS";
            // 
            // btnIncendio
            // 
            btnIncendio.BackColor = Color.Red;
            btnIncendio.Font = new Font("Segoe UI", 12F);
            btnIncendio.ForeColor = Color.White;
            btnIncendio.Location = new Point(160, 286);
            btnIncendio.Name = "btnIncendio";
            btnIncendio.Size = new Size(489, 184);
            btnIncendio.TabIndex = 2;
            btnIncendio.Text = "SIMULAR INCENDIO";
            btnIncendio.UseVisualStyleBackColor = false;
            btnIncendio.Click += btnIncendio_Click;
            // 
            // ucEmergencia
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(btnIncendio);
            Controls.Add(lblEstadoPuertas);
            Controls.Add(lblEstadoFuego);
            Font = new Font("Segoe UI", 8.25F);
            Name = "ucEmergencia";
            Size = new Size(814, 581);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEstadoFuego;
        private Label lblEstadoPuertas;
        private Button btnIncendio;
    }
}
