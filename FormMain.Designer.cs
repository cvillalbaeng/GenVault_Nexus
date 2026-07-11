namespace GenVault_Nexus
{
    partial class FormMain
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTelemetria = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.btnEmergencia = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlHeader.Controls.Add(this.btnMinimizar);
            this.pnlHeader.Controls.Add(this.btnMaximizar);
            this.pnlHeader.Controls.Add(this.btnCerrar);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1280, 32);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnMinimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Marlett", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(1175, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 32);
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.Text = "0";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMaximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Font = new System.Drawing.Font("Marlett", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMaximizar.ForeColor = System.Drawing.Color.White;
            this.btnMaximizar.Location = new System.Drawing.Point(1210, 0);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(35, 32);
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.Text = "1";
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Marlett", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1245, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 32);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "r";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GenVault Nexus ERP";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlMenu.Controls.Add(this.btnEmergencia);
            this.pnlMenu.Controls.Add(this.button6);
            this.pnlMenu.Controls.Add(this.button5);
            this.pnlMenu.Controls.Add(this.button4);
            this.pnlMenu.Controls.Add(this.button3);
            this.pnlMenu.Controls.Add(this.button2);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.btnTelemetria);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 32);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 688);
            this.pnlMenu.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(9, 265);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(216, 42);
            this.button6.TabIndex = 6;
            this.button6.Text = "PROTOCOLOS DE EMERGENCIA";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(7, 155);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(216, 42);
            this.button5.TabIndex = 5;
            this.button5.Text = "MONITOR DE TI";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(9, 110);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(216, 42);
            this.button4.TabIndex = 4;
            this.button4.Text = "BASE DE DATOS";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(9, 64);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(216, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "BIOINFORMÁTICA";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 323);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(216, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "LÓGISTICA E INVENTARIO";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(216, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "CIBERSEGURIDAD Y LOGIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTelemetria
            // 
            this.btnTelemetria.FlatAppearance.BorderSize = 0;
            this.btnTelemetria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelemetria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTelemetria.ForeColor = System.Drawing.Color.White;
            this.btnTelemetria.Location = new System.Drawing.Point(7, 210);
            this.btnTelemetria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTelemetria.Name = "btnTelemetria";
            this.btnTelemetria.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTelemetria.Size = new System.Drawing.Size(216, 42);
            this.btnTelemetria.TabIndex = 0;
            this.btnTelemetria.Text = "UNIDAD DE TELEMETRIA";
            this.btnTelemetria.UseVisualStyleBackColor = true;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Font = new System.Drawing.Font("Marlett", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.pnlContenedor.Location = new System.Drawing.Point(250, 32);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1030, 688);
            this.pnlContenedor.TabIndex = 2;
            // 
            // btnEmergencia
            // 
            this.btnEmergencia.FlatAppearance.BorderSize = 0;
            this.btnEmergencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmergencia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmergencia.ForeColor = System.Drawing.Color.White;
            this.btnEmergencia.Location = new System.Drawing.Point(11, 369);
            this.btnEmergencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmergencia.Name = "btnEmergencia";
            this.btnEmergencia.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmergencia.Size = new System.Drawing.Size(216, 42);
            this.btnEmergencia.TabIndex = 7;
            this.btnEmergencia.Text = "EMERGENCIAS";
            this.btnEmergencia.UseVisualStyleBackColor = true;
            this.btnEmergencia.Click += new System.EventHandler(this.btnEmergencia_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnTelemetria;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnEmergencia;
    }
}

