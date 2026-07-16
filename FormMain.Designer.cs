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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEmergencia = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnBaseDeDatos = new System.Windows.Forms.Button();
            this.btnBioinformatica = new System.Windows.Forms.Button();
            this.btnLogistica = new System.Windows.Forms.Button();
            this.btnCiberseguridad = new System.Windows.Forms.Button();
            this.btnTelemetria = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCabecera = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeReloj = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(1167, 28);
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
            this.btnMinimizar.Location = new System.Drawing.Point(1062, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 28);
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
            this.btnMaximizar.Location = new System.Drawing.Point(1097, 0);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(35, 28);
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
            this.btnCerrar.Location = new System.Drawing.Point(1132, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 28);
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
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.btnEmergencia);
            this.pnlMenu.Controls.Add(this.btnMonitor);
            this.pnlMenu.Controls.Add(this.btnBaseDeDatos);
            this.pnlMenu.Controls.Add(this.btnBioinformatica);
            this.pnlMenu.Controls.Add(this.btnLogistica);
            this.pnlMenu.Controls.Add(this.btnCiberseguridad);
            this.pnlMenu.Controls.Add(this.btnTelemetria);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 28);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 690);
            this.pnlMenu.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnEmergencia
            // 
            this.btnEmergencia.FlatAppearance.BorderSize = 0;
            this.btnEmergencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnEmergencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmergencia.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmergencia.ForeColor = System.Drawing.Color.White;
            this.btnEmergencia.Location = new System.Drawing.Point(11, 586);
            this.btnEmergencia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEmergencia.Name = "btnEmergencia";
            this.btnEmergencia.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmergencia.Size = new System.Drawing.Size(216, 60);
            this.btnEmergencia.TabIndex = 7;
            this.btnEmergencia.Text = "🚨 PROTOCOLOS DE EMERGENCIA";
            this.toolTip1.SetToolTip(this.btnEmergencia, "Panel de control de incendios y anulación manual del sistema Fail-Open de electro" +
        "imanes");
            this.btnEmergencia.UseVisualStyleBackColor = true;
            this.btnEmergencia.Click += new System.EventHandler(this.btnEmergencia_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.FlatAppearance.BorderSize = 0;
            this.btnMonitor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonitor.ForeColor = System.Drawing.Color.White;
            this.btnMonitor.Location = new System.Drawing.Point(11, 366);
            this.btnMonitor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMonitor.Size = new System.Drawing.Size(216, 65);
            this.btnMonitor.TabIndex = 5;
            this.btnMonitor.Text = "🖥️  MONITOR DE INFRAESTRUCTURA TI";
            this.toolTip1.SetToolTip(this.btnMonitor, "Monitoreo de tráfico y estado del Bio-Core Alpha");
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnBaseDeDatos
            // 
            this.btnBaseDeDatos.FlatAppearance.BorderSize = 0;
            this.btnBaseDeDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnBaseDeDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaseDeDatos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaseDeDatos.ForeColor = System.Drawing.Color.White;
            this.btnBaseDeDatos.Location = new System.Drawing.Point(11, 290);
            this.btnBaseDeDatos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBaseDeDatos.Name = "btnBaseDeDatos";
            this.btnBaseDeDatos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBaseDeDatos.Size = new System.Drawing.Size(216, 42);
            this.btnBaseDeDatos.TabIndex = 4;
            this.btnBaseDeDatos.Text = "🗄️ BASE DE DATOS";
            this.toolTip1.SetToolTip(this.btnBaseDeDatos, "Gestión centralizada (CRUD) del núcleo y registro de especímenes de prueba");
            this.btnBaseDeDatos.UseVisualStyleBackColor = true;
            this.btnBaseDeDatos.Click += new System.EventHandler(this.btnBaseDeDatos_Click);
            // 
            // btnBioinformatica
            // 
            this.btnBioinformatica.FlatAppearance.BorderSize = 0;
            this.btnBioinformatica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnBioinformatica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBioinformatica.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBioinformatica.ForeColor = System.Drawing.Color.White;
            this.btnBioinformatica.Location = new System.Drawing.Point(18, 206);
            this.btnBioinformatica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBioinformatica.Name = "btnBioinformatica";
            this.btnBioinformatica.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBioinformatica.Size = new System.Drawing.Size(216, 42);
            this.btnBioinformatica.TabIndex = 3;
            this.btnBioinformatica.Text = "🧬 BIOINFORMÁTICA";
            this.toolTip1.SetToolTip(this.btnBioinformatica, "Simulación del Programación de Algoritmos de Mutación (PAM) y análisis genómico");
            this.btnBioinformatica.UseVisualStyleBackColor = true;
            this.btnBioinformatica.Click += new System.EventHandler(this.btnBioinformatica_Click);
            // 
            // btnLogistica
            // 
            this.btnLogistica.FlatAppearance.BorderSize = 0;
            this.btnLogistica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnLogistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogistica.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogistica.ForeColor = System.Drawing.Color.White;
            this.btnLogistica.Location = new System.Drawing.Point(2, 514);
            this.btnLogistica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogistica.Name = "btnLogistica";
            this.btnLogistica.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogistica.Size = new System.Drawing.Size(216, 59);
            this.btnLogistica.TabIndex = 2;
            this.btnLogistica.Text = "📦 LÓGISTICA E INVENTARIO";
            this.toolTip1.SetToolTip(this.btnLogistica, "Control de stock de reactivos e insumos con generación automática de órdenes de c" +
        "ompra");
            this.btnLogistica.UseVisualStyleBackColor = true;
            this.btnLogistica.Click += new System.EventHandler(this.btnLogistica_Click);
            // 
            // btnCiberseguridad
            // 
            this.btnCiberseguridad.FlatAppearance.BorderSize = 0;
            this.btnCiberseguridad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnCiberseguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCiberseguridad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCiberseguridad.ForeColor = System.Drawing.Color.White;
            this.btnCiberseguridad.Location = new System.Drawing.Point(18, 115);
            this.btnCiberseguridad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCiberseguridad.Name = "btnCiberseguridad";
            this.btnCiberseguridad.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCiberseguridad.Size = new System.Drawing.Size(216, 66);
            this.btnCiberseguridad.TabIndex = 1;
            this.btnCiberseguridad.Text = "🔐 CERRAR SESIÓN";
            this.btnCiberseguridad.UseVisualStyleBackColor = true;
            this.btnCiberseguridad.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnTelemetria
            // 
            this.btnTelemetria.FlatAppearance.BorderSize = 0;
            this.btnTelemetria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnTelemetria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelemetria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTelemetria.ForeColor = System.Drawing.Color.White;
            this.btnTelemetria.Location = new System.Drawing.Point(11, 435);
            this.btnTelemetria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTelemetria.Name = "btnTelemetria";
            this.btnTelemetria.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTelemetria.Size = new System.Drawing.Size(216, 76);
            this.btnTelemetria.TabIndex = 0;
            this.btnTelemetria.Text = "🌡️ UNIDAD DE TELEMETRIA";
            this.toolTip1.SetToolTip(this.btnTelemetria, "Vigilancia de sensores SNMP (temperatura/humedad) y estado de contención en Unida" +
        "des A, B y C");
            this.btnTelemetria.UseVisualStyleBackColor = true;
            this.btnTelemetria.Click += new System.EventHandler(this.btnTelemetria_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Font = new System.Drawing.Font("Marlett", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.pnlContenedor.Location = new System.Drawing.Point(250, 28);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(917, 690);
            this.pnlContenedor.TabIndex = 2;
            this.toolTip1.SetToolTip(this.pnlContenedor, "Control de acceso RFID y asignación de roles corporativos");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCabecera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 19);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblCabecera
            // 
            this.lblCabecera.AutoSize = true;
            this.lblCabecera.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecera.ForeColor = System.Drawing.Color.Cyan;
            this.lblCabecera.Location = new System.Drawing.Point(4, 1);
            this.lblCabecera.Name = "lblCabecera";
            this.lblCabecera.Size = new System.Drawing.Size(268, 17);
            this.lblCabecera.TabIndex = 0;
            this.lblCabecera.Text = "GetValultNexusERP > Dashboard Principal";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblHora});
            this.statusStrip1.Location = new System.Drawing.Point(250, 696);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(917, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Cyan;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(261, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Usuario: Esperando inicio de sesión...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Cyan;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(261, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Servidor: Bio-Core Alpha (Desconectado)";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Cyan;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(261, 17);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "Módulo Activo: Ninguno";
            // 
            // lblHora
            // 
            this.lblHora.ForeColor = System.Drawing.Color.Cyan;
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(118, 17);
            this.lblHora.Text = "toolStripStatusLabel4";
            // 
            // timeReloj
            // 
            this.timeReloj.Enabled = true;
            this.timeReloj.Interval = 1000;
            this.timeReloj.Tick += new System.EventHandler(this.timeReloj_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1167, 718);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnTelemetria;
        private System.Windows.Forms.Button btnCiberseguridad;
        private System.Windows.Forms.Button btnLogistica;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnBaseDeDatos;
        private System.Windows.Forms.Button btnBioinformatica;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnEmergencia;
        private System.Windows.Forms.Timer timeReloj;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCabecera;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

