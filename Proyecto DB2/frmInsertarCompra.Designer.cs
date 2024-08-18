namespace Proyecto_DB2
{
    partial class frmInsertarCompra
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
            this.btnInsertarCompra = new System.Windows.Forms.Button();
            this.btnCancelarCompra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumentoArticulo = new System.Windows.Forms.TextBox();
            this.cbxTipoCompra = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProveedorIDCompra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVerProceedorCompra = new System.Windows.Forms.Button();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarraArticulo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCostoCD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxTasaArticulo = new System.Windows.Forms.ComboBox();
            this.txtCantidadCD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlAyudaNuevo = new System.Windows.Forms.Panel();
            this.dgAayudaNuevo = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.CbxInsertarEstado = new System.Windows.Forms.ComboBox();
            this.pnlAyudaNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAayudaNuevo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertarCompra
            // 
            this.btnInsertarCompra.Location = new System.Drawing.Point(511, 315);
            this.btnInsertarCompra.Name = "btnInsertarCompra";
            this.btnInsertarCompra.Size = new System.Drawing.Size(85, 48);
            this.btnInsertarCompra.TabIndex = 0;
            this.btnInsertarCompra.Text = "Insertar";
            this.btnInsertarCompra.UseVisualStyleBackColor = true;
            this.btnInsertarCompra.Click += new System.EventHandler(this.btnInsertarCompra_Click);
            // 
            // btnCancelarCompra
            // 
            this.btnCancelarCompra.Location = new System.Drawing.Point(602, 315);
            this.btnCancelarCompra.Name = "btnCancelarCompra";
            this.btnCancelarCompra.Size = new System.Drawing.Size(79, 48);
            this.btnCancelarCompra.TabIndex = 1;
            this.btnCancelarCompra.Text = "Cancelar";
            this.btnCancelarCompra.UseVisualStyleBackColor = true;
            this.btnCancelarCompra.Click += new System.EventHandler(this.btnCancelarCompra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Documento";
            // 
            // txtDocumentoArticulo
            // 
            this.txtDocumentoArticulo.Location = new System.Drawing.Point(130, 186);
            this.txtDocumentoArticulo.Name = "txtDocumentoArticulo";
            this.txtDocumentoArticulo.Size = new System.Drawing.Size(208, 20);
            this.txtDocumentoArticulo.TabIndex = 4;
            // 
            // cbxTipoCompra
            // 
            this.cbxTipoCompra.FormattingEnabled = true;
            this.cbxTipoCompra.Items.AddRange(new object[] {
            "C",
            "E"});
            this.cbxTipoCompra.Location = new System.Drawing.Point(130, 222);
            this.cbxTipoCompra.Name = "cbxTipoCompra";
            this.cbxTipoCompra.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoCompra.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tipo";
            // 
            // txtProveedorIDCompra
            // 
            this.txtProveedorIDCompra.Location = new System.Drawing.Point(130, 96);
            this.txtProveedorIDCompra.Name = "txtProveedorIDCompra";
            this.txtProveedorIDCompra.Size = new System.Drawing.Size(208, 20);
            this.txtProveedorIDCompra.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "ProveedorID";
            // 
            // btnVerProceedorCompra
            // 
            this.btnVerProceedorCompra.Location = new System.Drawing.Point(344, 96);
            this.btnVerProceedorCompra.Name = "btnVerProceedorCompra";
            this.btnVerProceedorCompra.Size = new System.Drawing.Size(75, 23);
            this.btnVerProceedorCompra.TabIndex = 14;
            this.btnVerProceedorCompra.Text = "Ayuda";
            this.btnVerProceedorCompra.UseVisualStyleBackColor = true;
            this.btnVerProceedorCompra.Click += new System.EventHandler(this.btnVerProceedorCompra_Click);
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Location = new System.Drawing.Point(130, 135);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(208, 20);
            this.txtFechaCompra.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Fecha";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(521, 116);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(208, 20);
            this.txtPrecioCompra.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tasa Isv";
            // 
            // txtBarraArticulo
            // 
            this.txtBarraArticulo.Location = new System.Drawing.Point(130, 308);
            this.txtBarraArticulo.Name = "txtBarraArticulo";
            this.txtBarraArticulo.Size = new System.Drawing.Size(208, 20);
            this.txtBarraArticulo.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Barra articulo";
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Location = new System.Drawing.Point(130, 265);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(208, 20);
            this.txtNombreArticulo.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Nombre Articulo";
            // 
            // txtCostoCD
            // 
            this.txtCostoCD.Location = new System.Drawing.Point(521, 235);
            this.txtCostoCD.Name = "txtCostoCD";
            this.txtCostoCD.Size = new System.Drawing.Size(103, 20);
            this.txtCostoCD.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(471, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Costo";
            // 
            // cbxTasaArticulo
            // 
            this.cbxTasaArticulo.FormattingEnabled = true;
            this.cbxTasaArticulo.Items.AddRange(new object[] {
            "15%",
            "18%"});
            this.cbxTasaArticulo.Location = new System.Drawing.Point(521, 159);
            this.cbxTasaArticulo.Name = "cbxTasaArticulo";
            this.cbxTasaArticulo.Size = new System.Drawing.Size(121, 21);
            this.cbxTasaArticulo.TabIndex = 27;
            // 
            // txtCantidadCD
            // 
            this.txtCantidadCD.Location = new System.Drawing.Point(521, 200);
            this.txtCantidadCD.Name = "txtCantidadCD";
            this.txtCantidadCD.Size = new System.Drawing.Size(103, 20);
            this.txtCantidadCD.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(457, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Cantidad";
            // 
            // pnlAyudaNuevo
            // 
            this.pnlAyudaNuevo.Controls.Add(this.dgAayudaNuevo);
            this.pnlAyudaNuevo.Location = new System.Drawing.Point(438, 96);
            this.pnlAyudaNuevo.Name = "pnlAyudaNuevo";
            this.pnlAyudaNuevo.Size = new System.Drawing.Size(308, 110);
            this.pnlAyudaNuevo.TabIndex = 30;
            this.pnlAyudaNuevo.Visible = false;
            // 
            // dgAayudaNuevo
            // 
            this.dgAayudaNuevo.AllowUserToOrderColumns = true;
            this.dgAayudaNuevo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAayudaNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAayudaNuevo.Location = new System.Drawing.Point(0, 0);
            this.dgAayudaNuevo.Name = "dgAayudaNuevo";
            this.dgAayudaNuevo.Size = new System.Drawing.Size(308, 110);
            this.dgAayudaNuevo.TabIndex = 0;
            this.dgAayudaNuevo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAayudaNuevo_CellContentClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Estado";
            // 
            // CbxInsertarEstado
            // 
            this.CbxInsertarEstado.FormattingEnabled = true;
            this.CbxInsertarEstado.Items.AddRange(new object[] {
            "C",
            "P"});
            this.CbxInsertarEstado.Location = new System.Drawing.Point(314, 222);
            this.CbxInsertarEstado.Name = "CbxInsertarEstado";
            this.CbxInsertarEstado.Size = new System.Drawing.Size(121, 21);
            this.CbxInsertarEstado.TabIndex = 31;
            // 
            // frmInsertarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CbxInsertarEstado);
            this.Controls.Add(this.pnlAyudaNuevo);
            this.Controls.Add(this.txtCantidadCD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxTasaArticulo);
            this.Controls.Add(this.txtCostoCD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBarraArticulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNombreArticulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecioCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVerProceedorCompra);
            this.Controls.Add(this.txtProveedorIDCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTipoCompra);
            this.Controls.Add(this.txtDocumentoArticulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCompra);
            this.Controls.Add(this.btnInsertarCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertarCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInsertarCompra";
            this.Load += new System.EventHandler(this.frmInsertarCompra_Load);
            this.pnlAyudaNuevo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAayudaNuevo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsertarCompra;
        private System.Windows.Forms.Button btnCancelarCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocumentoArticulo;
        private System.Windows.Forms.ComboBox cbxTipoCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProveedorIDCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerProceedorCompra;
        private System.Windows.Forms.TextBox txtFechaCompra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarraArticulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCostoCD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxTasaArticulo;
        private System.Windows.Forms.TextBox txtCantidadCD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlAyudaNuevo;
        private System.Windows.Forms.DataGridView dgAayudaNuevo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CbxInsertarEstado;
    }
}