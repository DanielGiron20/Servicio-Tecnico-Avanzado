namespace Proyecto_DB2
{
    partial class frmCompraExistente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgVerArticuloCD = new System.Windows.Forms.DataGridView();
            this.txtCantidadCD1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxTasaArticulo1 = new System.Windows.Forms.ComboBox();
            this.txtCostoCD1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBarraArticulo1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreArticulo1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioCompra1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaCompra1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVerProceedorCompra = new System.Windows.Forms.Button();
            this.txtProveedorIDCompra1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTipoCompra1 = new System.Windows.Forms.ComboBox();
            this.txtDocumentoArticulo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarCompraExistente = new System.Windows.Forms.Button();
            this.btnInsertarCompra1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtArticuloid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlBtnAyuda = new System.Windows.Forms.Panel();
            this.dgAyudaProveedor = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgVerArticuloCD)).BeginInit();
            this.pnlBtnAyuda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAyudaProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVerArticuloCD
            // 
            this.dgVerArticuloCD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVerArticuloCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVerArticuloCD.Location = new System.Drawing.Point(81, 32);
            this.dgVerArticuloCD.Name = "dgVerArticuloCD";
            this.dgVerArticuloCD.Size = new System.Drawing.Size(696, 192);
            this.dgVerArticuloCD.TabIndex = 0;
            this.dgVerArticuloCD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVerArticuloCD_CellContentClick);
            // 
            // txtCantidadCD1
            // 
            this.txtCantidadCD1.Location = new System.Drawing.Point(569, 357);
            this.txtCantidadCD1.Name = "txtCantidadCD1";
            this.txtCantidadCD1.Size = new System.Drawing.Size(103, 20);
            this.txtCantidadCD1.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(503, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Cantidad";
            // 
            // cbxTasaArticulo1
            // 
            this.cbxTasaArticulo1.FormattingEnabled = true;
            this.cbxTasaArticulo1.Items.AddRange(new object[] {
            "15%",
            "18%"});
            this.cbxTasaArticulo1.Location = new System.Drawing.Point(569, 316);
            this.cbxTasaArticulo1.Name = "cbxTasaArticulo1";
            this.cbxTasaArticulo1.Size = new System.Drawing.Size(121, 21);
            this.cbxTasaArticulo1.TabIndex = 50;
            // 
            // txtCostoCD1
            // 
            this.txtCostoCD1.Location = new System.Drawing.Point(569, 392);
            this.txtCostoCD1.Name = "txtCostoCD1";
            this.txtCostoCD1.Size = new System.Drawing.Size(103, 20);
            this.txtCostoCD1.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(517, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Costo";
            // 
            // txtBarraArticulo1
            // 
            this.txtBarraArticulo1.Location = new System.Drawing.Point(169, 479);
            this.txtBarraArticulo1.Name = "txtBarraArticulo1";
            this.txtBarraArticulo1.Size = new System.Drawing.Size(208, 20);
            this.txtBarraArticulo1.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Barra articulo";
            // 
            // txtNombreArticulo1
            // 
            this.txtNombreArticulo1.Enabled = false;
            this.txtNombreArticulo1.Location = new System.Drawing.Point(169, 436);
            this.txtNombreArticulo1.Name = "txtNombreArticulo1";
            this.txtNombreArticulo1.Size = new System.Drawing.Size(208, 20);
            this.txtNombreArticulo1.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Nombre Articulo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tasa Isv";
            // 
            // txtPrecioCompra1
            // 
            this.txtPrecioCompra1.Location = new System.Drawing.Point(569, 273);
            this.txtPrecioCompra1.Name = "txtPrecioCompra1";
            this.txtPrecioCompra1.Size = new System.Drawing.Size(208, 20);
            this.txtPrecioCompra1.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Precio";
            // 
            // txtFechaCompra1
            // 
            this.txtFechaCompra1.Location = new System.Drawing.Point(169, 306);
            this.txtFechaCompra1.Name = "txtFechaCompra1";
            this.txtFechaCompra1.Size = new System.Drawing.Size(208, 20);
            this.txtFechaCompra1.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Fecha";
            // 
            // btnVerProceedorCompra
            // 
            this.btnVerProceedorCompra.Location = new System.Drawing.Point(383, 267);
            this.btnVerProceedorCompra.Name = "btnVerProceedorCompra";
            this.btnVerProceedorCompra.Size = new System.Drawing.Size(75, 23);
            this.btnVerProceedorCompra.TabIndex = 38;
            this.btnVerProceedorCompra.Text = "Ayuda";
            this.btnVerProceedorCompra.UseVisualStyleBackColor = true;
            this.btnVerProceedorCompra.Click += new System.EventHandler(this.btnVerProceedorCompra_Click);
            // 
            // txtProveedorIDCompra1
            // 
            this.txtProveedorIDCompra1.Location = new System.Drawing.Point(169, 267);
            this.txtProveedorIDCompra1.Name = "txtProveedorIDCompra1";
            this.txtProveedorIDCompra1.Size = new System.Drawing.Size(208, 20);
            this.txtProveedorIDCompra1.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "ProveedorID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tipo";
            // 
            // cbxTipoCompra1
            // 
            this.cbxTipoCompra1.FormattingEnabled = true;
            this.cbxTipoCompra1.Items.AddRange(new object[] {
            "C",
            "E"});
            this.cbxTipoCompra1.Location = new System.Drawing.Point(169, 398);
            this.cbxTipoCompra1.Name = "cbxTipoCompra1";
            this.cbxTipoCompra1.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoCompra1.TabIndex = 34;
            // 
            // txtDocumentoArticulo1
            // 
            this.txtDocumentoArticulo1.Location = new System.Drawing.Point(169, 357);
            this.txtDocumentoArticulo1.Name = "txtDocumentoArticulo1";
            this.txtDocumentoArticulo1.Size = new System.Drawing.Size(208, 20);
            this.txtDocumentoArticulo1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Documento";
            // 
            // btnCancelarCompraExistente
            // 
            this.btnCancelarCompraExistente.Location = new System.Drawing.Point(678, 518);
            this.btnCancelarCompraExistente.Name = "btnCancelarCompraExistente";
            this.btnCancelarCompraExistente.Size = new System.Drawing.Size(108, 48);
            this.btnCancelarCompraExistente.TabIndex = 31;
            this.btnCancelarCompraExistente.Text = "Cancelar";
            this.btnCancelarCompraExistente.UseVisualStyleBackColor = true;
            this.btnCancelarCompraExistente.Click += new System.EventHandler(this.btnCancelarCompraExistente_Click);
            // 
            // btnInsertarCompra1
            // 
            this.btnInsertarCompra1.Location = new System.Drawing.Point(560, 518);
            this.btnInsertarCompra1.Name = "btnInsertarCompra1";
            this.btnInsertarCompra1.Size = new System.Drawing.Size(112, 48);
            this.btnInsertarCompra1.TabIndex = 30;
            this.btnInsertarCompra1.Text = "Insertar";
            this.btnInsertarCompra1.UseVisualStyleBackColor = true;
            this.btnInsertarCompra1.Click += new System.EventHandler(this.btnInsertarCompra_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(383, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "año/mes/dia";
            // 
            // txtArticuloid
            // 
            this.txtArticuloid.Enabled = false;
            this.txtArticuloid.Location = new System.Drawing.Point(169, 230);
            this.txtArticuloid.Name = "txtArticuloid";
            this.txtArticuloid.Size = new System.Drawing.Size(39, 20);
            this.txtArticuloid.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(71, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "ArticuloID";
            // 
            // pnlBtnAyuda
            // 
            this.pnlBtnAyuda.Controls.Add(this.dgAyudaProveedor);
            this.pnlBtnAyuda.Location = new System.Drawing.Point(464, 267);
            this.pnlBtnAyuda.Name = "pnlBtnAyuda";
            this.pnlBtnAyuda.Size = new System.Drawing.Size(313, 145);
            this.pnlBtnAyuda.TabIndex = 56;
            this.pnlBtnAyuda.Visible = false;
            this.pnlBtnAyuda.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBtnAyuda_Paint);
            // 
            // dgAyudaProveedor
            // 
            this.dgAyudaProveedor.AllowUserToOrderColumns = true;
            this.dgAyudaProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAyudaProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAyudaProveedor.Location = new System.Drawing.Point(0, 1);
            this.dgAyudaProveedor.Name = "dgAyudaProveedor";
            this.dgAyudaProveedor.Size = new System.Drawing.Size(310, 145);
            this.dgAyudaProveedor.TabIndex = 0;
            this.dgAyudaProveedor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyudaProveedor_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(296, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 58;
            this.label13.Text = "Estado";
            // 
            // cbxEstado
            // 
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Items.AddRange(new object[] {
            "C",
            "P"});
            this.cbxEstado.Location = new System.Drawing.Point(337, 400);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(121, 21);
            this.cbxEstado.TabIndex = 57;
            // 
            // frmCompraExistente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 587);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxEstado);
            this.Controls.Add(this.pnlBtnAyuda);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtArticuloid);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCantidadCD1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxTasaArticulo1);
            this.Controls.Add(this.txtCostoCD1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBarraArticulo1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNombreArticulo1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecioCompra1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaCompra1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVerProceedorCompra);
            this.Controls.Add(this.txtProveedorIDCompra1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTipoCompra1);
            this.Controls.Add(this.txtDocumentoArticulo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCompraExistente);
            this.Controls.Add(this.btnInsertarCompra1);
            this.Controls.Add(this.dgVerArticuloCD);
            this.Name = "frmCompraExistente";
            this.Text = "frmCompraExistente";
            this.Load += new System.EventHandler(this.frmCompraExistente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVerArticuloCD)).EndInit();
            this.pnlBtnAyuda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAyudaProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVerArticuloCD;
        private System.Windows.Forms.TextBox txtCantidadCD1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxTasaArticulo1;
        private System.Windows.Forms.TextBox txtCostoCD1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBarraArticulo1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreArticulo1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioCompra1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaCompra1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVerProceedorCompra;
        private System.Windows.Forms.TextBox txtProveedorIDCompra1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTipoCompra1;
        private System.Windows.Forms.TextBox txtDocumentoArticulo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelarCompraExistente;
        private System.Windows.Forms.Button btnInsertarCompra1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtArticuloid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlBtnAyuda;
        private System.Windows.Forms.DataGridView dgAyudaProveedor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxEstado;
    }
}