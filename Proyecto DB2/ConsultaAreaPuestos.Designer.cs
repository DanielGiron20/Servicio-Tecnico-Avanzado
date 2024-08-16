namespace Proyecto_DB2
{
    partial class ConsultaAreasPuestos
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
            this.dgAreaPuestos = new System.Windows.Forms.DataGridView();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAreaPuestos
            // 
            this.dgAreaPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAreaPuestos.Location = new System.Drawing.Point(12, 12);
            this.dgAreaPuestos.Name = "dgAreaPuestos";
            this.dgAreaPuestos.RowHeadersWidth = 51;
            this.dgAreaPuestos.RowTemplate.Height = 24;
            this.dgAreaPuestos.Size = new System.Drawing.Size(776, 296);
            this.dgAreaPuestos.TabIndex = 0;
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(12, 330);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(121, 24);
            this.cmbArea.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(674, 379);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(114, 59);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // ConsultaAreasPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.dgAreaPuestos);
            this.Name = "ConsultaAreasPuestos";
            this.Text = "ConsultaAreasPuestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).EndInit();

            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAreaPuestos;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Button btnVolver;
    }
}