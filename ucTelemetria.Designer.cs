namespace GenVault_Nexus
{
    partial class ucTelemetria
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTelemetria));
            this.btnVentilacion = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.tmrClima = new System.Windows.Forms.Timer(this.components);
            this.lblAlertaTemp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVentilacion
            // 
            this.btnVentilacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVentilacion.BackColor = System.Drawing.Color.DarkCyan;
            this.btnVentilacion.FlatAppearance.BorderSize = 0;
            this.btnVentilacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentilacion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentilacion.ForeColor = System.Drawing.Color.White;
            this.btnVentilacion.Location = new System.Drawing.Point(757, 34);
            this.btnVentilacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVentilacion.Name = "btnVentilacion";
            this.btnVentilacion.Size = new System.Drawing.Size(347, 116);
            this.btnVentilacion.TabIndex = 0;
            this.btnVentilacion.Text = "FORZAR VENTILACIÓN";
            this.btnVentilacion.UseVisualStyleBackColor = false;
            this.btnVentilacion.Click += new System.EventHandler(this.btnVentilacion_Click);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.BackColor = System.Drawing.Color.Transparent;
            this.lblTemperatura.Font = new System.Drawing.Font("Segoe UI", 55F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTemperatura.Location = new System.Drawing.Point(25, 34);
            this.lblTemperatura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(222, 99);
            this.lblTemperatura.TabIndex = 1;
            this.lblTemperatura.Text = "24 °C";
            this.lblTemperatura.Click += new System.EventHandler(this.lblTemperatura_Click);
            // 
            // tmrClima
            // 
            this.tmrClima.Enabled = true;
            this.tmrClima.Interval = 2000;
            this.tmrClima.Tick += new System.EventHandler(this.tmrClima_Tick);
            // 
            // lblAlertaTemp
            // 
            this.lblAlertaTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlertaTemp.BackColor = System.Drawing.Color.Red;
            this.lblAlertaTemp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertaTemp.ForeColor = System.Drawing.Color.White;
            this.lblAlertaTemp.Location = new System.Drawing.Point(280, 43);
            this.lblAlertaTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertaTemp.Name = "lblAlertaTemp";
            this.lblAlertaTemp.Size = new System.Drawing.Size(368, 80);
            this.lblAlertaTemp.TabIndex = 2;
            this.lblAlertaTemp.Text = "CRÍTICO: RIESGO DE DAÑO EN UNIDAD A";
            this.lblAlertaTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlertaTemp.Visible = false;
            this.lblAlertaTemp.Click += new System.EventHandler(this.lblAlertaTemp_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblTemperatura);
            this.panel1.Controls.Add(this.lblAlertaTemp);
            this.panel1.Controls.Add(this.btnVentilacion);
            this.panel1.Location = new System.Drawing.Point(26, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 172);
            this.panel1.TabIndex = 5;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(26, 27);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1145, 514);
            this.axWindowsMediaPlayer1.TabIndex = 4;
            // 
            // ucTelemetria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucTelemetria";
            this.Size = new System.Drawing.Size(1267, 800);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVentilacion;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Timer tmrClima;
        private System.Windows.Forms.Label lblAlertaTemp;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel panel1;
    }
}