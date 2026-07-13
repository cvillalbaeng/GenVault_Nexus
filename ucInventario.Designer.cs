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
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 255, 200);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(552, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "📦 GESTIÓN DE INVENTARIO - GenVault C.A.";
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(20, 70);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(910, 480);
            this.dgvInventario.TabIndex = 1;
            // 
            // lblAlertas
            // 
            this.lblAlertas.AutoSize = true;
            this.lblAlertas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertas.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblAlertas.Location = new System.Drawing.Point(20, 565);
            this.lblAlertas.Name = "lblAlertas";
            this.lblAlertas.Size = new System.Drawing.Size(500, 23);
            this.lblAlertas.TabIndex = 2;
            this.lblAlertas.Text = "Presione ANALIZAR STOCK CRÍTICO para revisar el inventario.";
            // 
            // btnAnalizarStock
            // 
            this.btnAnalizarStock.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnAnalizarStock.FlatAppearance.BorderSize = 0;
            this.btnAnalizarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizarStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAnalizarStock.ForeColor = System.Drawing.Color.White;
            this.btnAnalizarStock.Location = new System.Drawing.Point(20, 605);
            this.btnAnalizarStock.Name = "btnAnalizarStock";
            this.btnAnalizarStock.Size = new System.Drawing.Size(320, 45);
            this.btnAnalizarStock.TabIndex = 3;
            this.btnAnalizarStock.Text = "ANALIZAR STOCK CRÍTICO";
            this.btnAnalizarStock.UseVisualStyleBackColor = false;
            this.btnAnalizarStock.Click += new System.EventHandler(this.btnAnalizarStock_Click);
            // 
            // ucInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.Controls.Add(this.btnAnalizarStock);
            this.Controls.Add(this.lblAlertas);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ucInventario";
            this.Size = new System.Drawing.Size(950, 670);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Label lblAlertas;
        private System.Windows.Forms.Button btnAnalizarStock;
    }
}
