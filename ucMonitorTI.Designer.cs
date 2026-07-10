namespace MonitorTI
{
    partial class ucMonitorTI
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
            this.pbRed = new System.Windows.Forms.ProgressBar();
            this.lblTrafico = new System.Windows.Forms.Label();
            this.lblAlertaZabbix = new System.Windows.Forms.Label();
            this.tmrRed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbRed
            // 
            this.pbRed.Location = new System.Drawing.Point(50, 280);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(850, 40);
            this.pbRed.TabIndex = 0;
            // 
            // lblTrafico
            // 
            this.lblTrafico.AutoSize = true;
            this.lblTrafico.ForeColor = System.Drawing.Color.White;
            this.lblTrafico.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrafico.Location = new System.Drawing.Point(50, 240);
            this.lblTrafico.Name = "lblTrafico";
            this.lblTrafico.Size = new System.Drawing.Size(300, 25);
            this.lblTrafico.TabIndex = 1;
            this.lblTrafico.Text = "Tráfico de Red Borde: 0%";
            // 
            // lblAlertaZabbix
            // 
            this.lblAlertaZabbix.AutoSize = true;
            this.lblAlertaZabbix.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAlertaZabbix.ForeColor = System.Drawing.Color.Red;
            this.lblAlertaZabbix.Location = new System.Drawing.Point(200, 380);
            this.lblAlertaZabbix.Name = "lblAlertaZabbix";
            this.lblAlertaZabbix.Size = new System.Drawing.Size(500, 30);
            this.lblAlertaZabbix.TabIndex = 2;
            this.lblAlertaZabbix.Text = "ALERTA ZABBIX: SATURACIÓN DE RED";
            this.lblAlertaZabbix.Visible = false;
            // 
            // tmrRed
            // 
            this.tmrRed.Enabled = true;
            this.tmrRed.Interval = 1500;
            this.tmrRed.Tick += new System.EventHandler(this.tmrRed_Tick);
            // 
            // ucMonitorTI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.lblAlertaZabbix);
            this.Controls.Add(this.lblTrafico);
            this.Controls.Add(this.pbRed);
            this.Name = "ucMonitorTI";
            this.Size = new System.Drawing.Size(950, 670);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbRed;
        private System.Windows.Forms.Label lblTrafico;
        private System.Windows.Forms.Label lblAlertaZabbix;
        private System.Windows.Forms.Timer tmrRed;
    }
}
