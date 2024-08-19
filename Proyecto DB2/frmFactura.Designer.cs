namespace Proyecto_DB2
{
    partial class frmFactura
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
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.btnInsertarFac = new System.Windows.Forms.Button();
            this.btnModificarFac = new System.Windows.Forms.Button();
            this.btnLimpiarFac = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.dgvFacturaDet = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFacturaID2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbArticuloID = new System.Windows.Forms.ComboBox();
            this.cmbNombreArticulo = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbOrdenDetID = new System.Windows.Forms.ComboBox();
            this.chkActivoFacturaDet = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtHorasExtras = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFacturaDetID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdBorrarDet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActivoFac = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacturaID = new System.Windows.Forms.TextBox();
            this.cmbClienteID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNombreCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmpleadoID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNombreEmpleado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEstadoFactura = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNombreTipoFac = new System.Windows.Forms.ComboBox();
            this.cmbNombreEstadoFac = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaFac = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFactura
            // 
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Location = new System.Drawing.Point(31, 264);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.Size = new System.Drawing.Size(773, 284);
            this.dgvFactura.TabIndex = 4;
            this.dgvFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactura_CellContentClick);
            this.dgvFactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactura_CellDoubleClick);
            this.dgvFactura.SelectionChanged += new System.EventHandler(this.dgvFactura_SelectionChanged);
            // 
            // btnInsertarFac
            // 
            this.btnInsertarFac.Location = new System.Drawing.Point(31, 554);
            this.btnInsertarFac.Name = "btnInsertarFac";
            this.btnInsertarFac.Size = new System.Drawing.Size(120, 43);
            this.btnInsertarFac.TabIndex = 21;
            this.btnInsertarFac.Text = "Insertar";
            this.btnInsertarFac.UseVisualStyleBackColor = true;
            this.btnInsertarFac.Click += new System.EventHandler(this.btnInsertarFac_Click);
            // 
            // btnModificarFac
            // 
            this.btnModificarFac.Location = new System.Drawing.Point(157, 554);
            this.btnModificarFac.Name = "btnModificarFac";
            this.btnModificarFac.Size = new System.Drawing.Size(120, 43);
            this.btnModificarFac.TabIndex = 22;
            this.btnModificarFac.Text = "Modificar";
            this.btnModificarFac.UseVisualStyleBackColor = true;
            this.btnModificarFac.Click += new System.EventHandler(this.btnModificarFac_Click);
            // 
            // btnLimpiarFac
            // 
            this.btnLimpiarFac.Location = new System.Drawing.Point(283, 554);
            this.btnLimpiarFac.Name = "btnLimpiarFac";
            this.btnLimpiarFac.Size = new System.Drawing.Size(120, 43);
            this.btnLimpiarFac.TabIndex = 23;
            this.btnLimpiarFac.Text = "Limpiar";
            this.btnLimpiarFac.UseVisualStyleBackColor = true;
            this.btnLimpiarFac.Click += new System.EventHandler(this.btnLimpiarFac_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(283, 1156);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 43);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(157, 1156);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 43);
            this.btnModificar.TabIndex = 26;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(31, 1156);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(120, 43);
            this.btnInsertar.TabIndex = 25;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // dgvFacturaDet
            // 
            this.dgvFacturaDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturaDet.Location = new System.Drawing.Point(31, 866);
            this.dgvFacturaDet.Name = "dgvFacturaDet";
            this.dgvFacturaDet.Size = new System.Drawing.Size(773, 284);
            this.dgvFacturaDet.TabIndex = 24;
            this.dgvFacturaDet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturaDet_CellContentClick);
            this.dgvFacturaDet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturaDet_CellDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(301, 643);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 31);
            this.label10.TabIndex = 28;
            this.label10.Text = "Factura Detalle";
            // 
            // txtFacturaID2
            // 
            this.txtFacturaID2.Location = new System.Drawing.Point(135, 741);
            this.txtFacturaID2.Name = "txtFacturaID2";
            this.txtFacturaID2.Size = new System.Drawing.Size(62, 20);
            this.txtFacturaID2.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 742);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "FacturaID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(56, 785);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "ArticuloID";
            // 
            // cmbArticuloID
            // 
            this.cmbArticuloID.FormattingEnabled = true;
            this.cmbArticuloID.Location = new System.Drawing.Point(135, 784);
            this.cmbArticuloID.Name = "cmbArticuloID";
            this.cmbArticuloID.Size = new System.Drawing.Size(62, 21);
            this.cmbArticuloID.TabIndex = 2;
            this.cmbArticuloID.Click += new System.EventHandler(this.cmbArticuloID_Click);
            // 
            // cmbNombreArticulo
            // 
            this.cmbNombreArticulo.FormattingEnabled = true;
            this.cmbNombreArticulo.Location = new System.Drawing.Point(212, 784);
            this.cmbNombreArticulo.Name = "cmbNombreArticulo";
            this.cmbNombreArticulo.Size = new System.Drawing.Size(115, 21);
            this.cmbNombreArticulo.TabIndex = 33;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(135, 827);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(62, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(59, 828);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 34;
            this.label13.Text = "Cantidad";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(358, 697);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 16);
            this.label14.TabIndex = 37;
            this.label14.Text = "OrdenDetatalleID";
            // 
            // cmbOrdenDetID
            // 
            this.cmbOrdenDetID.FormattingEnabled = true;
            this.cmbOrdenDetID.Location = new System.Drawing.Point(475, 696);
            this.cmbOrdenDetID.Name = "cmbOrdenDetID";
            this.cmbOrdenDetID.Size = new System.Drawing.Size(62, 21);
            this.cmbOrdenDetID.TabIndex = 3;
            this.cmbOrdenDetID.Click += new System.EventHandler(this.cmbOrdenDetID_Click);
            // 
            // chkActivoFacturaDet
            // 
            this.chkActivoFacturaDet.AutoSize = true;
            this.chkActivoFacturaDet.Checked = true;
            this.chkActivoFacturaDet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivoFacturaDet.Location = new System.Drawing.Point(413, 788);
            this.chkActivoFacturaDet.Name = "chkActivoFacturaDet";
            this.chkActivoFacturaDet.Size = new System.Drawing.Size(56, 17);
            this.chkActivoFacturaDet.TabIndex = 38;
            this.chkActivoFacturaDet.Text = "Activo";
            this.chkActivoFacturaDet.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(658, 1189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 54);
            this.label15.TabIndex = 39;
            // 
            // txtHorasExtras
            // 
            this.txtHorasExtras.Location = new System.Drawing.Point(475, 743);
            this.txtHorasExtras.Name = "txtHorasExtras";
            this.txtHorasExtras.Size = new System.Drawing.Size(62, 20);
            this.txtHorasExtras.TabIndex = 5;
            this.txtHorasExtras.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(385, 744);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 16);
            this.label16.TabIndex = 40;
            this.label16.Text = "Horas Extras";
            // 
            // txtFacturaDetID
            // 
            this.txtFacturaDetID.Location = new System.Drawing.Point(135, 700);
            this.txtFacturaDetID.Name = "txtFacturaDetID";
            this.txtFacturaDetID.Size = new System.Drawing.Size(62, 20);
            this.txtFacturaDetID.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 701);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 16);
            this.label17.TabIndex = 42;
            this.label17.Text = "FacturaDetalleID";
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Location = new System.Drawing.Point(684, 554);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(120, 43);
            this.cmdBorrar.TabIndex = 44;
            this.cmdBorrar.Text = "Quitar fila";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdBorrarDet
            // 
            this.cmdBorrarDet.Location = new System.Drawing.Point(684, 1156);
            this.cmdBorrarDet.Name = "cmdBorrarDet";
            this.cmdBorrarDet.Size = new System.Drawing.Size(120, 43);
            this.cmdBorrarDet.TabIndex = 45;
            this.cmdBorrarDet.Text = "Quitar fila";
            this.cmdBorrarDet.UseVisualStyleBackColor = true;
            this.cmdBorrarDet.Click += new System.EventHandler(this.cmdBorrarDet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura";
            // 
            // chkActivoFac
            // 
            this.chkActivoFac.AutoSize = true;
            this.chkActivoFac.Checked = true;
            this.chkActivoFac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivoFac.Location = new System.Drawing.Point(525, 202);
            this.chkActivoFac.Name = "chkActivoFac";
            this.chkActivoFac.Size = new System.Drawing.Size(56, 17);
            this.chkActivoFac.TabIndex = 9;
            this.chkActivoFac.Text = "Activo";
            this.chkActivoFac.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "FacturaID";
            // 
            // txtFacturaID
            // 
            this.txtFacturaID.Location = new System.Drawing.Point(114, 77);
            this.txtFacturaID.Name = "txtFacturaID";
            this.txtFacturaID.Size = new System.Drawing.Size(62, 20);
            this.txtFacturaID.TabIndex = 0;
            // 
            // cmbClienteID
            // 
            this.cmbClienteID.FormattingEnabled = true;
            this.cmbClienteID.Location = new System.Drawing.Point(114, 114);
            this.cmbClienteID.Name = "cmbClienteID";
            this.cmbClienteID.Size = new System.Drawing.Size(62, 21);
            this.cmbClienteID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ClienteID";
            // 
            // cmbNombreCliente
            // 
            this.cmbNombreCliente.FormattingEnabled = true;
            this.cmbNombreCliente.Location = new System.Drawing.Point(260, 114);
            this.cmbNombreCliente.Name = "cmbNombreCliente";
            this.cmbNombreCliente.Size = new System.Drawing.Size(117, 21);
            this.cmbNombreCliente.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre";
            // 
            // cmbEmpleadoID
            // 
            this.cmbEmpleadoID.FormattingEnabled = true;
            this.cmbEmpleadoID.Location = new System.Drawing.Point(114, 155);
            this.cmbEmpleadoID.Name = "cmbEmpleadoID";
            this.cmbEmpleadoID.Size = new System.Drawing.Size(62, 21);
            this.cmbEmpleadoID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "VendedorID";
            // 
            // cmbNombreEmpleado
            // 
            this.cmbNombreEmpleado.FormattingEnabled = true;
            this.cmbNombreEmpleado.Location = new System.Drawing.Point(260, 155);
            this.cmbNombreEmpleado.Name = "cmbNombreEmpleado";
            this.cmbNombreEmpleado.Size = new System.Drawing.Size(117, 21);
            this.cmbNombreEmpleado.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(193, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre";
            // 
            // cmbTipoFactura
            // 
            this.cmbTipoFactura.FormattingEnabled = true;
            this.cmbTipoFactura.Location = new System.Drawing.Point(478, 114);
            this.cmbTipoFactura.Name = "cmbTipoFactura";
            this.cmbTipoFactura.Size = new System.Drawing.Size(62, 21);
            this.cmbTipoFactura.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(426, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tipo";
            // 
            // cmbEstadoFactura
            // 
            this.cmbEstadoFactura.FormattingEnabled = true;
            this.cmbEstadoFactura.Location = new System.Drawing.Point(478, 155);
            this.cmbEstadoFactura.Name = "cmbEstadoFactura";
            this.cmbEstadoFactura.Size = new System.Drawing.Size(62, 21);
            this.cmbEstadoFactura.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(411, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Estado";
            // 
            // cmbNombreTipoFac
            // 
            this.cmbNombreTipoFac.FormattingEnabled = true;
            this.cmbNombreTipoFac.Location = new System.Drawing.Point(546, 114);
            this.cmbNombreTipoFac.Name = "cmbNombreTipoFac";
            this.cmbNombreTipoFac.Size = new System.Drawing.Size(117, 21);
            this.cmbNombreTipoFac.TabIndex = 17;
            // 
            // cmbNombreEstadoFac
            // 
            this.cmbNombreEstadoFac.FormattingEnabled = true;
            this.cmbNombreEstadoFac.Location = new System.Drawing.Point(546, 155);
            this.cmbNombreEstadoFac.Name = "cmbNombreEstadoFac";
            this.cmbNombreEstadoFac.Size = new System.Drawing.Size(117, 21);
            this.cmbNombreEstadoFac.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fecha";
            // 
            // dtpFechaFac
            // 
            this.dtpFechaFac.Location = new System.Drawing.Point(114, 203);
            this.dtpFechaFac.Name = "dtpFechaFac";
            this.dtpFechaFac.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFac.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSalir.Location = new System.Drawing.Point(725, 11);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(45, 44);
            this.cmdSalir.TabIndex = 46;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(828, 749);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBorrarDet);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.txtFacturaDetID);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtHorasExtras);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkActivoFacturaDet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbOrdenDetID);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbNombreArticulo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbArticuloID);
            this.Controls.Add(this.txtFacturaID2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.dgvFacturaDet);
            this.Controls.Add(this.btnLimpiarFac);
            this.Controls.Add(this.btnModificarFac);
            this.Controls.Add(this.btnInsertarFac);
            this.Controls.Add(this.dtpFechaFac);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbNombreEstadoFac);
            this.Controls.Add(this.cmbNombreTipoFac);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbEstadoFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTipoFactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbNombreEmpleado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEmpleadoID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbNombreCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbClienteID);
            this.Controls.Add(this.dgvFactura);
            this.Controls.Add(this.txtFacturaID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActivoFac);
            this.Controls.Add(this.label1);
            this.Name = "frmFactura";
            this.Text = "frmFactura";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.Button btnInsertarFac;
        private System.Windows.Forms.Button btnModificarFac;
        private System.Windows.Forms.Button btnLimpiarFac;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.DataGridView dgvFacturaDet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFacturaID2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbArticuloID;
        private System.Windows.Forms.ComboBox cmbNombreArticulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbOrdenDetID;
        private System.Windows.Forms.CheckBox chkActivoFacturaDet;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtHorasExtras;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFacturaDetID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdBorrarDet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActivoFac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFacturaID;
        private System.Windows.Forms.ComboBox cmbClienteID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNombreCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmpleadoID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNombreEmpleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEstadoFactura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbNombreTipoFac;
        private System.Windows.Forms.ComboBox cmbNombreEstadoFac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaFac;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button cmdSalir;
    }
}