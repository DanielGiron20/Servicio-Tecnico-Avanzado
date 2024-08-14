namespace Proyecto_DB2
{
    partial class frmConsultaCompra
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
            this.txtbxProveedorid = new System.Windows.Forms.TextBox();
            this.txtbxCompraid = new System.Windows.Forms.TextBox();
            this.txtbxFecha = new System.Windows.Forms.TextBox();
            this.txtbxNombre = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxTelefono = new System.Windows.Forms.TextBox();
            this.txtbxRtn = new System.Windows.Forms.TextBox();
            this.txtbxDireccion = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Label();
            this.txtbxBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarConsulta = new System.Windows.Forms.Button();
            this.btnRefrescarConsulta = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxConsulta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtbxProveedorid
            // 
            this.txtbxProveedorid.Location = new System.Drawing.Point(173, 192);
            this.txtbxProveedorid.Name = "txtbxProveedorid";
            this.txtbxProveedorid.Size = new System.Drawing.Size(213, 20);
            this.txtbxProveedorid.TabIndex = 0;
            // 
            // txtbxCompraid
            // 
            this.txtbxCompraid.Location = new System.Drawing.Point(173, 228);
            this.txtbxCompraid.Name = "txtbxCompraid";
            this.txtbxCompraid.Size = new System.Drawing.Size(213, 20);
            this.txtbxCompraid.TabIndex = 1;
            // 
            // txtbxFecha
            // 
            this.txtbxFecha.Location = new System.Drawing.Point(173, 274);
            this.txtbxFecha.Name = "txtbxFecha";
            this.txtbxFecha.Size = new System.Drawing.Size(213, 20);
            this.txtbxFecha.TabIndex = 2;
            // 
            // txtbxNombre
            // 
            this.txtbxNombre.Location = new System.Drawing.Point(173, 313);
            this.txtbxNombre.Name = "txtbxNombre";
            this.txtbxNombre.Size = new System.Drawing.Size(213, 20);
            this.txtbxNombre.TabIndex = 3;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(474, 314);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(206, 20);
            this.txtbxEmail.TabIndex = 7;
            // 
            // txtbxTelefono
            // 
            this.txtbxTelefono.Location = new System.Drawing.Point(474, 275);
            this.txtbxTelefono.Name = "txtbxTelefono";
            this.txtbxTelefono.Size = new System.Drawing.Size(206, 20);
            this.txtbxTelefono.TabIndex = 6;
            // 
            // txtbxRtn
            // 
            this.txtbxRtn.Location = new System.Drawing.Point(474, 232);
            this.txtbxRtn.Name = "txtbxRtn";
            this.txtbxRtn.Size = new System.Drawing.Size(206, 20);
            this.txtbxRtn.TabIndex = 5;
            // 
            // txtbxDireccion
            // 
            this.txtbxDireccion.Location = new System.Drawing.Point(474, 193);
            this.txtbxDireccion.Name = "txtbxDireccion";
            this.txtbxDireccion.Size = new System.Drawing.Size(206, 20);
            this.txtbxDireccion.TabIndex = 4;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(77, 199);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(67, 13);
            this.txt.TabIndex = 8;
            this.txt.Text = "ProveedorID";
            this.txt.Click += new System.EventHandler(this.txt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CompraID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha Compra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre Provedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "RTN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Direccion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Email";
            // 
            // buscar
            // 
            this.buscar.AutoSize = true;
            this.buscar.Location = new System.Drawing.Point(75, 134);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(40, 13);
            this.buscar.TabIndex = 15;
            this.buscar.Text = "Buscar";
            // 
            // txtbxBuscar
            // 
            this.txtbxBuscar.Location = new System.Drawing.Point(121, 131);
            this.txtbxBuscar.Name = "txtbxBuscar";
            this.txtbxBuscar.Size = new System.Drawing.Size(221, 20);
            this.txtbxBuscar.TabIndex = 16;
            // 
            // btnBuscarConsulta
            // 
            this.btnBuscarConsulta.Location = new System.Drawing.Point(348, 129);
            this.btnBuscarConsulta.Name = "btnBuscarConsulta";
            this.btnBuscarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarConsulta.TabIndex = 17;
            this.btnBuscarConsulta.Text = "Buscar";
            this.btnBuscarConsulta.UseVisualStyleBackColor = true;
            this.btnBuscarConsulta.Click += new System.EventHandler(this.btnBuscarConsulta_Click);
            // 
            // btnRefrescarConsulta
            // 
            this.btnRefrescarConsulta.Location = new System.Drawing.Point(429, 128);
            this.btnRefrescarConsulta.Name = "btnRefrescarConsulta";
            this.btnRefrescarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescarConsulta.TabIndex = 18;
            this.btnRefrescarConsulta.Text = "Refrescar";
            this.btnRefrescarConsulta.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Buscar Por:";
            // 
            // cbxConsulta
            // 
            this.cbxConsulta.FormattingEnabled = true;
            this.cbxConsulta.Items.AddRange(new object[] {
            "CompraID",
            "ProveedorID",
            "NombreProveedor"});
            this.cbxConsulta.Location = new System.Drawing.Point(144, 76);
            this.cbxConsulta.Name = "cbxConsulta";
            this.cbxConsulta.Size = new System.Drawing.Size(155, 21);
            this.cbxConsulta.TabIndex = 20;
            // 
            // frmConsultaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxConsulta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRefrescarConsulta);
            this.Controls.Add(this.btnBuscarConsulta);
            this.Controls.Add(this.txtbxBuscar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.txtbxTelefono);
            this.Controls.Add(this.txtbxRtn);
            this.Controls.Add(this.txtbxDireccion);
            this.Controls.Add(this.txtbxNombre);
            this.Controls.Add(this.txtbxFecha);
            this.Controls.Add(this.txtbxCompraid);
            this.Controls.Add(this.txtbxProveedorid);
            this.Name = "frmConsultaCompra";
            this.Text = "datagrdata";
            this.Load += new System.EventHandler(this.frmConsultaCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxProveedorid;
        private System.Windows.Forms.TextBox txtbxCompraid;
        private System.Windows.Forms.TextBox txtbxFecha;
        private System.Windows.Forms.TextBox txtbxNombre;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxTelefono;
        private System.Windows.Forms.TextBox txtbxRtn;
        private System.Windows.Forms.TextBox txtbxDireccion;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label buscar;
        private System.Windows.Forms.TextBox txtbxBuscar;
        private System.Windows.Forms.Button btnBuscarConsulta;
        private System.Windows.Forms.Button btnRefrescarConsulta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxConsulta;
    }
}