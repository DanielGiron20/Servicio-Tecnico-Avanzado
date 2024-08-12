namespace Proyecto_DB2
{
    partial class frmOrden
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtOrdenID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClienteID = new System.Windows.Forms.ComboBox();
            this.cmbNombreCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNombreEmpleado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEmpleadoID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoOrden = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvOrdenDet = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrdenDetId = new System.Windows.Forms.TextBox();
            this.cmbPaqueteId = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbServicioID = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOrdenID2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cmbTipoOrdenNombre = new System.Windows.Forms.ComboBox();
            this.cmbEstadoNombre = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLimpiarOrdenDet = new System.Windows.Forms.Button();
            this.chkActivoOrdenDet = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbNombrePaquete = new System.Windows.Forms.ComboBox();
            this.cmbNombreServicio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden";
            // 
            // dgvOrden
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvOrden.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Location = new System.Drawing.Point(28, 231);
            this.dgvOrden.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.Size = new System.Drawing.Size(761, 279);
            this.dgvOrden.TabIndex = 27;
            this.dgvOrden.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrden_CellDoubleClick);
            this.dgvOrden.SelectionChanged += new System.EventHandler(this.dgvOrden_SelectionChanged);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(28, 516);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(104, 37);
            this.btnInsertar.TabIndex = 28;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Location = new System.Drawing.Point(736, 16);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(56, 28);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtOrdenID
            // 
            this.txtOrdenID.Enabled = false;
            this.txtOrdenID.Location = new System.Drawing.Point(111, 63);
            this.txtOrdenID.Name = "txtOrdenID";
            this.txtOrdenID.Size = new System.Drawing.Size(48, 20);
            this.txtOrdenID.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "OrdenID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "ClienteID";
            // 
            // cmbClienteID
            // 
            this.cmbClienteID.FormattingEnabled = true;
            this.cmbClienteID.Location = new System.Drawing.Point(111, 102);
            this.cmbClienteID.Name = "cmbClienteID";
            this.cmbClienteID.Size = new System.Drawing.Size(48, 21);
            this.cmbClienteID.TabIndex = 34;
            // 
            // cmbNombreCliente
            // 
            this.cmbNombreCliente.FormattingEnabled = true;
            this.cmbNombreCliente.Location = new System.Drawing.Point(242, 102);
            this.cmbNombreCliente.Name = "cmbNombreCliente";
            this.cmbNombreCliente.Size = new System.Drawing.Size(138, 21);
            this.cmbNombreCliente.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Nombre";
            // 
            // cmbNombreEmpleado
            // 
            this.cmbNombreEmpleado.FormattingEnabled = true;
            this.cmbNombreEmpleado.Location = new System.Drawing.Point(242, 143);
            this.cmbNombreEmpleado.Name = "cmbNombreEmpleado";
            this.cmbNombreEmpleado.Size = new System.Drawing.Size(138, 21);
            this.cmbNombreEmpleado.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Nombre";
            // 
            // cmbEmpleadoID
            // 
            this.cmbEmpleadoID.FormattingEnabled = true;
            this.cmbEmpleadoID.Location = new System.Drawing.Point(111, 143);
            this.cmbEmpleadoID.Name = "cmbEmpleadoID";
            this.cmbEmpleadoID.Size = new System.Drawing.Size(48, 21);
            this.cmbEmpleadoID.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "EmpleadoID";
            // 
            // cmbTipoOrden
            // 
            this.cmbTipoOrden.FormattingEnabled = true;
            this.cmbTipoOrden.Location = new System.Drawing.Point(111, 181);
            this.cmbTipoOrden.Name = "cmbTipoOrden";
            this.cmbTipoOrden.Size = new System.Drawing.Size(48, 21);
            this.cmbTipoOrden.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tipo Orden";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(451, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Duracion";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Enabled = false;
            this.txtDuracion.Location = new System.Drawing.Point(520, 62);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.ReadOnly = true;
            this.txtDuracion.Size = new System.Drawing.Size(48, 20);
            this.txtDuracion.TabIndex = 43;
            this.txtDuracion.Text = "0";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(520, 101);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(48, 21);
            this.cmbEstado.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(462, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "Estado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(433, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "Fecha Inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(520, 143);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 48;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(520, 178);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFinal.TabIndex = 50;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(435, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Fecha Final";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(152, 516);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(104, 37);
            this.btnModificar.TabIndex = 51;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvOrdenDet
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvOrdenDet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenDet.Location = new System.Drawing.Point(28, 820);
            this.dgvOrdenDet.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.dgvOrdenDet.Name = "dgvOrdenDet";
            this.dgvOrdenDet.Size = new System.Drawing.Size(761, 325);
            this.dgvOrdenDet.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(333, 639);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 31);
            this.label12.TabIndex = 53;
            this.label12.Text = "Orden Detalle";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 707);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 55;
            this.label13.Text = "OrdenDetalleID";
            // 
            // txtOrdenDetId
            // 
            this.txtOrdenDetId.Enabled = false;
            this.txtOrdenDetId.Location = new System.Drawing.Point(131, 705);
            this.txtOrdenDetId.Name = "txtOrdenDetId";
            this.txtOrdenDetId.Size = new System.Drawing.Size(48, 20);
            this.txtOrdenDetId.TabIndex = 54;
            // 
            // cmbPaqueteId
            // 
            this.cmbPaqueteId.FormattingEnabled = true;
            this.cmbPaqueteId.Location = new System.Drawing.Point(274, 705);
            this.cmbPaqueteId.Name = "cmbPaqueteId";
            this.cmbPaqueteId.Size = new System.Drawing.Size(48, 21);
            this.cmbPaqueteId.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(197, 707);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 16);
            this.label14.TabIndex = 56;
            this.label14.Text = "PaqueteID";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cmbServicioID
            // 
            this.cmbServicioID.FormattingEnabled = true;
            this.cmbServicioID.Location = new System.Drawing.Point(583, 705);
            this.cmbServicioID.Name = "cmbServicioID";
            this.cmbServicioID.Size = new System.Drawing.Size(48, 21);
            this.cmbServicioID.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(506, 707);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 16);
            this.label15.TabIndex = 58;
            this.label15.Text = "ServicioID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(54, 761);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 16);
            this.label16.TabIndex = 60;
            this.label16.Text = "OrdenID";
            // 
            // txtOrdenID2
            // 
            this.txtOrdenID2.Enabled = false;
            this.txtOrdenID2.Location = new System.Drawing.Point(131, 759);
            this.txtOrdenID2.Name = "txtOrdenID2";
            this.txtOrdenID2.Size = new System.Drawing.Size(48, 20);
            this.txtOrdenID2.TabIndex = 61;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(207, 761);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 16);
            this.label17.TabIndex = 63;
            this.label17.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(274, 759);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(48, 20);
            this.txtCantidad.TabIndex = 62;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 1156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 64;
            this.button1.Text = "Insertar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 1156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 37);
            this.button2.TabIndex = 65;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Enabled = false;
            this.chkActivo.Location = new System.Drawing.Point(736, 64);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 67;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cmbTipoOrdenNombre
            // 
            this.cmbTipoOrdenNombre.FormattingEnabled = true;
            this.cmbTipoOrdenNombre.Location = new System.Drawing.Point(182, 181);
            this.cmbTipoOrdenNombre.Name = "cmbTipoOrdenNombre";
            this.cmbTipoOrdenNombre.Size = new System.Drawing.Size(74, 21);
            this.cmbTipoOrdenNombre.TabIndex = 68;
            // 
            // cmbEstadoNombre
            // 
            this.cmbEstadoNombre.FormattingEnabled = true;
            this.cmbEstadoNombre.Location = new System.Drawing.Point(578, 100);
            this.cmbEstadoNombre.Name = "cmbEstadoNombre";
            this.cmbEstadoNombre.Size = new System.Drawing.Size(74, 21);
            this.cmbEstadoNombre.TabIndex = 69;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(276, 516);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 37);
            this.button4.TabIndex = 70;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLimpiarOrdenDet
            // 
            this.btnLimpiarOrdenDet.Location = new System.Drawing.Point(274, 1156);
            this.btnLimpiarOrdenDet.Name = "btnLimpiarOrdenDet";
            this.btnLimpiarOrdenDet.Size = new System.Drawing.Size(104, 37);
            this.btnLimpiarOrdenDet.TabIndex = 71;
            this.btnLimpiarOrdenDet.Text = "Limpiar";
            this.btnLimpiarOrdenDet.UseVisualStyleBackColor = true;
            this.btnLimpiarOrdenDet.Click += new System.EventHandler(this.btnLimpiarOrdenDet_Click);
            // 
            // chkActivoOrdenDet
            // 
            this.chkActivoOrdenDet.AutoSize = true;
            this.chkActivoOrdenDet.Checked = true;
            this.chkActivoOrdenDet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivoOrdenDet.Enabled = false;
            this.chkActivoOrdenDet.Location = new System.Drawing.Point(733, 653);
            this.chkActivoOrdenDet.Name = "chkActivoOrdenDet";
            this.chkActivoOrdenDet.Size = new System.Drawing.Size(56, 17);
            this.chkActivoOrdenDet.TabIndex = 72;
            this.chkActivoOrdenDet.Text = "Activo";
            this.chkActivoOrdenDet.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(686, 1182);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 36);
            this.label18.TabIndex = 73;
            // 
            // cmbNombrePaquete
            // 
            this.cmbNombrePaquete.FormattingEnabled = true;
            this.cmbNombrePaquete.Location = new System.Drawing.Point(328, 705);
            this.cmbNombrePaquete.Name = "cmbNombrePaquete";
            this.cmbNombrePaquete.Size = new System.Drawing.Size(152, 21);
            this.cmbNombrePaquete.TabIndex = 74;
            // 
            // cmbNombreServicio
            // 
            this.cmbNombreServicio.FormattingEnabled = true;
            this.cmbNombreServicio.Location = new System.Drawing.Point(637, 705);
            this.cmbNombreServicio.Name = "cmbNombreServicio";
            this.cmbNombreServicio.Size = new System.Drawing.Size(152, 21);
            this.cmbNombreServicio.TabIndex = 75;
            // 
            // frmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(828, 749);
            this.Controls.Add(this.cmbNombreServicio);
            this.Controls.Add(this.cmbNombrePaquete);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.chkActivoOrdenDet);
            this.Controls.Add(this.btnLimpiarOrdenDet);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cmbEstadoNombre);
            this.Controls.Add(this.cmbTipoOrdenNombre);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtOrdenID2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbServicioID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbPaqueteId);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtOrdenDetId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvOrdenDet);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.cmbTipoOrden);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbNombreEmpleado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEmpleadoID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbNombreCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbClienteID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrdenID);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.dgvOrden);
            this.Controls.Add(this.label1);
            this.Name = "frmOrden";
            this.Text = "frmOrden";
            this.Load += new System.EventHandler(this.frmOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtOrdenID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClienteID;
        private System.Windows.Forms.ComboBox cmbNombreCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNombreEmpleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEmpleadoID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoOrden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvOrdenDet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrdenDetId;
        private System.Windows.Forms.ComboBox cmbPaqueteId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbServicioID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOrdenID2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cmbTipoOrdenNombre;
        private System.Windows.Forms.ComboBox cmbEstadoNombre;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLimpiarOrdenDet;
        private System.Windows.Forms.CheckBox chkActivoOrdenDet;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbNombrePaquete;
        private System.Windows.Forms.ComboBox cmbNombreServicio;
    }
}