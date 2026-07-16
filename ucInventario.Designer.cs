namespace GenVault_Nexus
{
    partial class ucInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.lblAlertas = new System.Windows.Forms.Label();
            this.btnAnalizarStock = new System.Windows.Forms.Button();
            this.btnExportarOrdenDeCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTitulo.Location = new System.Drawing.Point(23, 21);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(521, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📦 GESTIÓN DE INVENTARIO - GenVault C.A";
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(23, 75);
            this.dgvInventario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.Size = new System.Drawing.Size(1343, 577);
            this.dgvInventario.TabIndex = 1;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // lblAlertas
            // 
            this.lblAlertas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlertas.AutoSize = true;
            this.lblAlertas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertas.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblAlertas.Location = new System.Drawing.Point(277, 563);
            this.lblAlertas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertas.Name = "lblAlertas";
            this.lblAlertas.Size = new System.Drawing.Size(480, 23);
            this.lblAlertas.TabIndex = 2;
            this.lblAlertas.Text = "Presione ANALIZAR STOCK CRÍTICO para revisar el inventario.";
            this.lblAlertas.Click += new System.EventHandler(this.lblAlertas_Click);
            // 
            // btnAnalizarStock
            // 
            this.btnAnalizarStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalizarStock.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAnalizarStock.FlatAppearance.BorderSize = 0;
            this.btnAnalizarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizarStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAnalizarStock.ForeColor = System.Drawing.Color.White;
            this.btnAnalizarStock.Location = new System.Drawing.Point(282, 610);
            this.btnAnalizarStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnalizarStock.Name = "btnAnalizarStock";
            this.btnAnalizarStock.Size = new System.Drawing.Size(365, 48);
            this.btnAnalizarStock.TabIndex = 3;
            this.btnAnalizarStock.Text = "ANALIZAR STOCK CRÍTICO";
            this.btnAnalizarStock.UseVisualStyleBackColor = false;
            this.btnAnalizarStock.Click += new System.EventHandler(this.btnAnalizarStock_Click);
            // 
            // btnExportarOrdenDeCompra
            // 
            this.btnExportarOrdenDeCompra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportarOrdenDeCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnExportarOrdenDeCompra.FlatAppearance.BorderSize = 0;
            this.btnExportarOrdenDeCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarOrdenDeCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarOrdenDeCompra.ForeColor = System.Drawing.Color.White;
            this.btnExportarOrdenDeCompra.Location = new System.Drawing.Point(724, 610);
            this.btnExportarOrdenDeCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarOrdenDeCompra.Name = "btnExportarOrdenDeCompra";
            this.btnExportarOrdenDeCompra.Size = new System.Drawing.Size(219, 48);
            this.btnExportarOrdenDeCompra.TabIndex = 4;
            this.btnExportarOrdenDeCompra.Text = "EXPORTAR ORDEN (CSV)";
            this.btnExportarOrdenDeCompra.UseVisualStyleBackColor = false;
            this.btnExportarOrdenDeCompra.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // ucInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.btnExportarOrdenDeCompra);
            this.Controls.Add(this.btnAnalizarStock);
            this.Controls.Add(this.lblAlertas);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucInventario";
            this.Size = new System.Drawing.Size(1388, 780);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Label lblAlertas;
        private System.Windows.Forms.Button btnAnalizarStock;
        private System.Windows.Forms.Button btnExportarOrdenDeCompra;
    }
}
