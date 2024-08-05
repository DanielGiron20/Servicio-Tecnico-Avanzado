namespace Proyecto_DB2
{
    partial class IngresarServicios
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtServicioID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.cmbTasa = new System.Windows.Forms.ComboBox();
            this.cmbActivo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso de servicios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servicio_ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Activo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(561, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Duracion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(559, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tasa IVA";
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(321, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 72);
            this.button1.TabIndex = 8;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(542, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 72);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtServicioID
            // 
            this.txtServicioID.Location = new System.Drawing.Point(212, 153);
            this.txtServicioID.Name = "txtServicioID";
            this.txtServicioID.ReadOnly = true;
            this.txtServicioID.Size = new System.Drawing.Size(92, 26);
            this.txtServicioID.TabIndex = 10;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(212, 224);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(272, 26);
            this.txtNombre.TabIndex = 11;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(212, 297);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(272, 69);
            this.txtDescripcion.TabIndex = 12;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(212, 398);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(272, 26);
            this.txtPrecio.TabIndex = 13;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(663, 224);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(272, 26);
            this.txtDuracion.TabIndex = 15;
            // 
            // cmbTasa
            // 
            this.cmbTasa.FormattingEnabled = true;
            this.cmbTasa.Items.AddRange(new object[] {
            "0",
            "10",
            "15",
            "19"});
            this.cmbTasa.Location = new System.Drawing.Point(663, 153);
            this.cmbTasa.Name = "cmbTasa";
            this.cmbTasa.Size = new System.Drawing.Size(89, 28);
            this.cmbTasa.TabIndex = 16;
            // 
            // cmbActivo
            // 
            this.cmbActivo.FormattingEnabled = true;
            this.cmbActivo.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cmbActivo.Location = new System.Drawing.Point(663, 295);
            this.cmbActivo.Name = "cmbActivo";
            this.cmbActivo.Size = new System.Drawing.Size(103, 28);
            this.cmbActivo.TabIndex = 17;
            // 
            // IngresarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 628);
            this.Controls.Add(this.cmbActivo);
            this.Controls.Add(this.cmbTasa);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtServicioID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IngresarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.IngresarServicios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtServicioID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.ComboBox cmbTasa;
        private System.Windows.Forms.ComboBox cmbActivo;
    }
}