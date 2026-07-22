using System;
using System.Drawing;
using System.Windows.Forms;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEmergencia));
            this.lblEstadoFuego = new System.Windows.Forms.Label();
            this.lblEstadoPuertas = new System.Windows.Forms.Label();
            this.btnIncendio = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstadoFuego
            // 
            this.lblEstadoFuego.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoFuego.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoFuego.ForeColor = System.Drawing.Color.White;
            this.lblEstadoFuego.Location = new System.Drawing.Point(241, 430);
            this.lblEstadoFuego.Name = "lblEstadoFuego";
            this.lblEstadoFuego.Size = new System.Drawing.Size(548, 34);
            this.lblEstadoFuego.TabIndex = 0;
            this.lblEstadoFuego.Text = "Alarmas: SILENCIADAS";
            this.lblEstadoFuego.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadoPuertas
            // 
            this.lblEstadoPuertas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoPuertas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoPuertas.ForeColor = System.Drawing.Color.White;
            this.lblEstadoPuertas.Location = new System.Drawing.Point(319, 464);
            this.lblEstadoPuertas.Name = "lblEstadoPuertas";
            this.lblEstadoPuertas.Size = new System.Drawing.Size(363, 34);
            this.lblEstadoPuertas.TabIndex = 1;
            this.lblEstadoPuertas.Text = "Electroimanes: ACTIVOS";
            this.lblEstadoPuertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIncendio
            // 
            this.btnIncendio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncendio.BackColor = System.Drawing.Color.Red;
            this.btnIncendio.FlatAppearance.BorderSize = 0;
            this.btnIncendio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncendio.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncendio.ForeColor = System.Drawing.Color.White;
            this.btnIncendio.Location = new System.Drawing.Point(389, 518);
            this.btnIncendio.Name = "btnIncendio";
            this.btnIncendio.Size = new System.Drawing.Size(231, 85);
            this.btnIncendio.TabIndex = 2;
            this.btnIncendio.Text = "SIMULAR INCENDIO";
            this.btnIncendio.UseVisualStyleBackColor = false;
            this.btnIncendio.Click += new System.EventHandler(this.btnIncendio_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(35, 32);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(846, 337);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // ucEmergencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btnIncendio);
            this.Controls.Add(this.lblEstadoPuertas);
            this.Controls.Add(this.lblEstadoFuego);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ucEmergencia";
            this.Size = new System.Drawing.Size(1089, 629);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEstadoFuego;
        private System.Windows.Forms.Label lblEstadoPuertas;
        private System.Windows.Forms.Button btnIncendio;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}