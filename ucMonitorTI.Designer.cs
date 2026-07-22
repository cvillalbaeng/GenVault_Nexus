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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMonitorTI));
            this.pbRed = new System.Windows.Forms.ProgressBar();
            this.lblTrafico = new System.Windows.Forms.Label();
            this.lblAlertaZabbix = new System.Windows.Forms.Label();
            this.tmrRed = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRed
            // 
            this.pbRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRed.Location = new System.Drawing.Point(42, 639);
            this.pbRed.Margin = new System.Windows.Forms.Padding(4);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(1133, 49);
            this.pbRed.TabIndex = 0;
            this.pbRed.Click += new System.EventHandler(this.pbRed_Click);
            // 
            // lblTrafico
            // 
            this.lblTrafico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrafico.AutoSize = true;
            this.lblTrafico.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrafico.ForeColor = System.Drawing.Color.White;
            this.lblTrafico.Location = new System.Drawing.Point(37, 610);
            this.lblTrafico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrafico.Name = "lblTrafico";
            this.lblTrafico.Size = new System.Drawing.Size(235, 25);
            this.lblTrafico.TabIndex = 1;
            this.lblTrafico.Text = "Tráfico de Red Borde: 0%";
            // 
            // lblAlertaZabbix
            // 
            this.lblAlertaZabbix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlertaZabbix.AutoSize = true;
            this.lblAlertaZabbix.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAlertaZabbix.ForeColor = System.Drawing.Color.Red;
            this.lblAlertaZabbix.Location = new System.Drawing.Point(377, 586);
            this.lblAlertaZabbix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertaZabbix.Name = "lblAlertaZabbix";
            this.lblAlertaZabbix.Size = new System.Drawing.Size(406, 30);
            this.lblAlertaZabbix.TabIndex = 2;
            this.lblAlertaZabbix.Text = "ALERTA ZABBIX: SATURACIÓN DE RED";
            this.lblAlertaZabbix.Visible = false;
            this.lblAlertaZabbix.Click += new System.EventHandler(this.lblAlertaZabbix_Click);
            // 
            // tmrRed
            // 
            this.tmrRed.Enabled = true;
            this.tmrRed.Interval = 3000;
            this.tmrRed.Tick += new System.EventHandler(this.tmrRed_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(63, 56);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1133, 407);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // ucMonitorTI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lblAlertaZabbix);
            this.Controls.Add(this.lblTrafico);
            this.Controls.Add(this.pbRed);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucMonitorTI";
            this.Size = new System.Drawing.Size(1267, 825);
            this.Load += new System.EventHandler(this.ucMonitorTI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbRed;
        private System.Windows.Forms.Label lblTrafico;
        private System.Windows.Forms.Label lblAlertaZabbix;
        private System.Windows.Forms.Timer tmrRed;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}