namespace Proyecto_DB2
{
    partial class frmCuentaBancaria
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
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipoCuenta = new System.Windows.Forms.ComboBox();
            this.dgCuenta = new System.Windows.Forms.DataGridView();
            this.btnInsertarCuenta = new System.Windows.Forms.Button();
            this.btnModificarCuenta = new System.Windows.Forms.Button();
            this.txtNumeroDeCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCuenta = new System.Windows.Forms.TextBox();
            this.cbxVer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCuenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tipos de cuenta";
            // 
            // cbxTipoCuenta
            // 
            this.cbxTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoCuenta.FormattingEnabled = true;
            this.cbxTipoCuenta.Items.AddRange(new object[] {
            "Corriente Empresarial",
            "Ahorros Empresarial",
            "Nominal Empresarial"});
            this.cbxTipoCuenta.Location = new System.Drawing.Point(508, 79);
            this.cbxTipoCuenta.Name = "cbxTipoCuenta";
            this.cbxTipoCuenta.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoCuenta.TabIndex = 9;
            // 
            // dgCuenta
            // 
            this.dgCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCuenta.Location = new System.Drawing.Point(59, 150);
            this.dgCuenta.Name = "dgCuenta";
            this.dgCuenta.Size = new System.Drawing.Size(570, 240);
            this.dgCuenta.TabIndex = 10;
            this.dgCuenta.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgCuenta_CellBeginEdit);
            this.dgCuenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCompra_CellContentClick);
            // 
            // btnInsertarCuenta
            // 
            this.btnInsertarCuenta.Location = new System.Drawing.Point(412, 397);
            this.btnInsertarCuenta.Name = "btnInsertarCuenta";
            this.btnInsertarCuenta.Size = new System.Drawing.Size(102, 41);
            this.btnInsertarCuenta.TabIndex = 11;
            this.btnInsertarCuenta.Text = "Insertar";
            this.btnInsertarCuenta.UseVisualStyleBackColor = true;
            this.btnInsertarCuenta.Click += new System.EventHandler(this.btnInsertarCuenta_Click);
            // 
            // btnModificarCuenta
            // 
            this.btnModificarCuenta.Location = new System.Drawing.Point(527, 397);
            this.btnModificarCuenta.Name = "btnModificarCuenta";
            this.btnModificarCuenta.Size = new System.Drawing.Size(102, 41);
            this.btnModificarCuenta.TabIndex = 12;
            this.btnModificarCuenta.Text = "Modificar";
            this.btnModificarCuenta.UseVisualStyleBackColor = true;
            this.btnModificarCuenta.Click += new System.EventHandler(this.btnModificarCuenta_Click);
            // 
            // txtNumeroDeCuenta
            // 
            this.txtNumeroDeCuenta.Location = new System.Drawing.Point(163, 112);
            this.txtNumeroDeCuenta.Name = "txtNumeroDeCuenta";
            this.txtNumeroDeCuenta.Size = new System.Drawing.Size(191, 20);
            this.txtNumeroDeCuenta.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Numero de cuenta ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Banco";
            // 
            // txtNombreCuenta
            // 
            this.txtNombreCuenta.Location = new System.Drawing.Point(163, 76);
            this.txtNombreCuenta.Name = "txtNombreCuenta";
            this.txtNombreCuenta.Size = new System.Drawing.Size(191, 20);
            this.txtNombreCuenta.TabIndex = 5;
            // 
            // cbxVer
            // 
            this.cbxVer.FormattingEnabled = true;
            this.cbxVer.Items.AddRange(new object[] {
            "Activas",
            "Inactivas",
            "Todas"});
            this.cbxVer.Location = new System.Drawing.Point(508, 119);
            this.cbxVer.Name = "cbxVer";
            this.cbxVer.Size = new System.Drawing.Size(121, 21);
            this.cbxVer.TabIndex = 15;
            this.cbxVer.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ver cuentas";
            // 
            // frmCuentaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroDeCuenta);
            this.Controls.Add(this.btnModificarCuenta);
            this.Controls.Add(this.btnInsertarCuenta);
            this.Controls.Add(this.dgCuenta);
            this.Controls.Add(this.cbxTipoCuenta);
            this.Controls.Add(this.txtNombreCuenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "frmCuentaBancaria";
            this.Text = "frmCuentaBancaria";
            this.Load += new System.EventHandler(this.frmCuentaBancaria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCuenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipoCuenta;
        private System.Windows.Forms.DataGridView dgCuenta;
        private System.Windows.Forms.Button btnInsertarCuenta;
        private System.Windows.Forms.Button btnModificarCuenta;
        private System.Windows.Forms.TextBox txtNumeroDeCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCuenta;
        private System.Windows.Forms.ComboBox cbxVer;
        private System.Windows.Forms.Label label3;
    }
}