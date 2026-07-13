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
            this.btnVentilacion = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.tmrClima = new System.Windows.Forms.Timer(this.components);
            this.lblAlertaTemp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVentilacion
            // 
            this.btnVentilacion.BackColor = System.Drawing.Color.Silver;
            this.btnVentilacion.Font = new System.Drawing.Font("Segoe UI", 40F);
            this.btnVentilacion.Location = new System.Drawing.Point(162, 393);
            this.btnVentilacion.Name = "btnVentilacion";
            this.btnVentilacion.Size = new System.Drawing.Size(585, 97);
            this.btnVentilacion.TabIndex = 0;
            this.btnVentilacion.Text = "FORZAR VENTILACIÓN";
            this.btnVentilacion.UseVisualStyleBackColor = false;
            this.btnVentilacion.Click += new System.EventHandler(this.btnVentilacion_Click);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTemperatura.Font = new System.Drawing.Font("Segoe UI", 100F);
            this.lblTemperatura.Location = new System.Drawing.Point(283, 80);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(332, 177);
            this.lblTemperatura.TabIndex = 1;
            this.lblTemperatura.Text = "24°c";
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
            this.lblAlertaTemp.BackColor = System.Drawing.Color.Red;
            this.lblAlertaTemp.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblAlertaTemp.Location = new System.Drawing.Point(283, 293);
            this.lblAlertaTemp.Name = "lblAlertaTemp";
            this.lblAlertaTemp.Size = new System.Drawing.Size(332, 59);
            this.lblAlertaTemp.TabIndex = 2;
            this.lblAlertaTemp.Text = "CRÍTICO: RIESGO DE DAÑO EN UNIDAD A";
            this.lblAlertaTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlertaTemp.Visible = false;
            // 
            // ucTelemetria
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.lblAlertaTemp);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.btnVentilacion);
            this.Name = "ucTelemetria";
            this.Size = new System.Drawing.Size(950, 670);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVentilacion;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Timer tmrClima;
        private System.Windows.Forms.Label lblAlertaTemp;
    }
}
