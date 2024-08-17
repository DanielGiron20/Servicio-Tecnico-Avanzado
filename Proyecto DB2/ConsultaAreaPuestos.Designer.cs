namespace Proyecto_DB2
{
    partial class ConsultaAreasPuestos
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
        private void InitializeComponent()
        {
            this.dgAreaPuestos = new System.Windows.Forms.DataGridView();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAreaPuestos
            // 
            this.dgAreaPuestos.AllowUserToAddRows = false;
            this.dgAreaPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAreaPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAreaPuestos.Location = new System.Drawing.Point(12, 12);
            this.dgAreaPuestos.Name = "dgAreaPuestos";
            this.dgAreaPuestos.RowHeadersWidth = 51;
            this.dgAreaPuestos.RowTemplate.Height = 24;
            this.dgAreaPuestos.Size = new System.Drawing.Size(895, 500);
            this.dgAreaPuestos.TabIndex = 0;
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(59, 581);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(221, 24);
            this.cmbArea.TabIndex = 2;
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(791, 557);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(116, 48);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Área:";
            // 
            // ConsultaAreasPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 631);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgAreaPuestos);
            this.Name = "ConsultaAreasPuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Áreas y Puestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.DataGridView dgAreaPuestos;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
    }
}