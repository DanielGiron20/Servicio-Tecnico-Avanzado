namespace Proyecto_DB2
{
    partial class frmClienteSuscripcion
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmbCampo = new System.Windows.Forms.ComboBox();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(71, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(554, 358);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSalir.Location = new System.Drawing.Point(530, 63);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(95, 44);
            this.cmdSalir.TabIndex = 18;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmbCampo
            // 
            this.cmbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Items.AddRange(new object[] {
            "ClienteID",
            "ClienteNombre",
            "Activo",
            "PaqueteID",
            "PaqueteNombre"});
            this.cmbCampo.Location = new System.Drawing.Point(71, 75);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(142, 21);
            this.cmbCampo.TabIndex = 20;
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(279, 76);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(195, 20);
            this.txtTexto.TabIndex = 22;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Buscar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(370, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Consulta de Suscripciones de Clientes";
            // 
            // frmClienteSuscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 507);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCampo);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClienteSuscripcion";
            this.Text = "frmClienteSuscripciones";
            this.Load += new System.EventHandler(this.frmClienteSuscripcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.ComboBox cmbCampo;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
    }
}