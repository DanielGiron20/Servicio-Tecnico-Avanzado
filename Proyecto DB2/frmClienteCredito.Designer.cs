namespace Proyecto_DB2
{
    partial class frmClienteCredito
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCerrada = new System.Windows.Forms.CheckBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdInsertar = new System.Windows.Forms.Button();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.txtFacturaID = new System.Windows.Forms.TextBox();
            this.txtTermino = new System.Windows.Forms.TextBox();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.cmdCalcular = new System.Windows.Forms.Button();
            this.cmdVerID = new System.Windows.Forms.Button();
            this.txtLimiteDisponible = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalFactura = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFechaFactura = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdCalcularTotal = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdCambiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(749, 245);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ClienteID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "FacturaID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Termino de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Limite de Credito";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Limite Disponible";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha de Vencimiento";
            // 
            // chkCerrada
            // 
            this.chkCerrada.AutoSize = true;
            this.chkCerrada.Location = new System.Drawing.Point(479, 102);
            this.chkCerrada.Name = "chkCerrada";
            this.chkCerrada.Size = new System.Drawing.Size(63, 17);
            this.chkCerrada.TabIndex = 9;
            this.chkCerrada.Text = "Cerrada";
            this.chkCerrada.UseVisualStyleBackColor = true;
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSalir.Location = new System.Drawing.Point(673, 178);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(88, 32);
            this.cmdSalir.TabIndex = 16;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdModificar.Location = new System.Drawing.Point(673, 65);
            this.cmdModificar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(88, 32);
            this.cmdModificar.TabIndex = 15;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdInsertar
            // 
            this.cmdInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInsertar.Location = new System.Drawing.Point(673, 24);
            this.cmdInsertar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdInsertar.Name = "cmdInsertar";
            this.cmdInsertar.Size = new System.Drawing.Size(88, 32);
            this.cmdInsertar.TabIndex = 14;
            this.cmdInsertar.Text = "Insertar";
            this.cmdInsertar.UseVisualStyleBackColor = true;
            this.cmdInsertar.Click += new System.EventHandler(this.cmdInsertar_Click);
            // 
            // txtClienteID
            // 
            this.txtClienteID.Enabled = false;
            this.txtClienteID.Location = new System.Drawing.Point(116, 24);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.Size = new System.Drawing.Size(100, 20);
            this.txtClienteID.TabIndex = 18;
            // 
            // txtFacturaID
            // 
            this.txtFacturaID.Enabled = false;
            this.txtFacturaID.Location = new System.Drawing.Point(116, 62);
            this.txtFacturaID.Name = "txtFacturaID";
            this.txtFacturaID.Size = new System.Drawing.Size(100, 20);
            this.txtFacturaID.TabIndex = 19;
            // 
            // txtTermino
            // 
            this.txtTermino.Location = new System.Drawing.Point(369, 100);
            this.txtTermino.Name = "txtTermino";
            this.txtTermino.Size = new System.Drawing.Size(92, 20);
            this.txtTermino.TabIndex = 20;
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.Location = new System.Drawing.Point(369, 24);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(173, 20);
            this.txtLimiteCredito.TabIndex = 21;
            // 
            // cmdCalcular
            // 
            this.cmdCalcular.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCalcular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdCalcular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCalcular.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCalcular.Location = new System.Drawing.Point(567, 24);
            this.cmdCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCalcular.Name = "cmdCalcular";
            this.cmdCalcular.Size = new System.Drawing.Size(88, 32);
            this.cmdCalcular.TabIndex = 23;
            this.cmdCalcular.Text = "Calcular";
            this.cmdCalcular.UseVisualStyleBackColor = true;
            this.cmdCalcular.Click += new System.EventHandler(this.cmdCalcular_Click);
            // 
            // cmdVerID
            // 
            this.cmdVerID.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdVerID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdVerID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdVerID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdVerID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdVerID.Location = new System.Drawing.Point(95, 141);
            this.cmdVerID.Margin = new System.Windows.Forms.Padding(2);
            this.cmdVerID.Name = "cmdVerID";
            this.cmdVerID.Size = new System.Drawing.Size(121, 37);
            this.cmdVerID.TabIndex = 24;
            this.cmdVerID.Text = "Ver Datos Factura";
            this.cmdVerID.UseVisualStyleBackColor = true;
            this.cmdVerID.Click += new System.EventHandler(this.cmdVerID_Click);
            // 
            // txtLimiteDisponible
            // 
            this.txtLimiteDisponible.Location = new System.Drawing.Point(370, 62);
            this.txtLimiteDisponible.Name = "txtLimiteDisponible";
            this.txtLimiteDisponible.Size = new System.Drawing.Size(172, 20);
            this.txtLimiteDisponible.TabIndex = 25;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(369, 138);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(172, 20);
            this.dtpFecha.TabIndex = 28;
            // 
            // txtPago
            // 
            this.txtPago.Location = new System.Drawing.Point(448, 182);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(207, 20);
            this.txtPago.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Monto a pagar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "TotalFactura";
            // 
            // txtTotalFactura
            // 
            this.txtTotalFactura.Enabled = false;
            this.txtTotalFactura.Location = new System.Drawing.Point(97, 200);
            this.txtTotalFactura.Name = "txtTotalFactura";
            this.txtTotalFactura.Size = new System.Drawing.Size(100, 20);
            this.txtTotalFactura.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Fecha Factura";
            // 
            // txtFechaFactura
            // 
            this.txtFechaFactura.Enabled = false;
            this.txtFechaFactura.Location = new System.Drawing.Point(116, 100);
            this.txtFechaFactura.Name = "txtFechaFactura";
            this.txtFechaFactura.Size = new System.Drawing.Size(100, 20);
            this.txtFechaFactura.TabIndex = 34;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmdCalcularTotal
            // 
            this.cmdCalcularTotal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCalcularTotal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdCalcularTotal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdCalcularTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCalcularTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCalcularTotal.Location = new System.Drawing.Point(211, 200);
            this.cmdCalcularTotal.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCalcularTotal.Name = "cmdCalcularTotal";
            this.cmdCalcularTotal.Size = new System.Drawing.Size(88, 25);
            this.cmdCalcularTotal.TabIndex = 35;
            this.cmdCalcularTotal.Text = "Obtener";
            this.cmdCalcularTotal.UseVisualStyleBackColor = true;
            this.cmdCalcularTotal.Click += new System.EventHandler(this.cmdCalcularTotal_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBorrar.Location = new System.Drawing.Point(673, 103);
            this.cmdBorrar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(88, 32);
            this.cmdBorrar.TabIndex = 36;
            this.cmdBorrar.Text = "Quitar Fila";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdCambiar
            // 
            this.cmdCambiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cmdCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCambiar.Location = new System.Drawing.Point(567, 89);
            this.cmdCambiar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCambiar.Name = "cmdCambiar";
            this.cmdCambiar.Size = new System.Drawing.Size(88, 46);
            this.cmdCambiar.TabIndex = 37;
            this.cmdCambiar.Text = "Cambiar Estado";
            this.cmdCambiar.UseVisualStyleBackColor = true;
            this.cmdCambiar.Click += new System.EventHandler(this.cmdCambiar_Click);
            // 
            // frmClienteCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 498);
            this.Controls.Add(this.cmdCambiar);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdCalcularTotal);
            this.Controls.Add(this.txtFechaFactura);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalFactura);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtLimiteDisponible);
            this.Controls.Add(this.cmdVerID);
            this.Controls.Add(this.cmdCalcular);
            this.Controls.Add(this.txtLimiteCredito);
            this.Controls.Add(this.txtTermino);
            this.Controls.Add(this.txtFacturaID);
            this.Controls.Add(this.txtClienteID);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdInsertar);
            this.Controls.Add(this.chkCerrada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmClienteCredito";
            this.Text = "frmClienteCredito";
            this.Load += new System.EventHandler(this.frmClienteCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkCerrada;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdInsertar;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.TextBox txtFacturaID;
        private System.Windows.Forms.TextBox txtTermino;
        private System.Windows.Forms.TextBox txtLimiteCredito;
        private System.Windows.Forms.Button cmdCalcular;
        private System.Windows.Forms.Button cmdVerID;
        private System.Windows.Forms.TextBox txtLimiteDisponible;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalFactura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFechaFactura;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button cmdCalcularTotal;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdCambiar;
    }
}