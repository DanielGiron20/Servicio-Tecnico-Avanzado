namespace Proyecto_DB2
{
    partial class SeleccionArticulos
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
            this.dataGridViewArticulo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewArticulo
            // 
            this.dataGridViewArticulo.AllowUserToAddRows = false;
            this.dataGridViewArticulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticulo.Location = new System.Drawing.Point(8, 19);
            this.dataGridViewArticulo.Name = "dataGridViewArticulo";
            this.dataGridViewArticulo.RowHeadersWidth = 62;
            this.dataGridViewArticulo.RowTemplate.Height = 28;
            this.dataGridViewArticulo.Size = new System.Drawing.Size(993, 492);
            this.dataGridViewArticulo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeleccionArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 583);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewArticulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionArticulos";
            this.Load += new System.EventHandler(this.SeleccionArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewArticulo;
        private System.Windows.Forms.Button button1;
    }
}