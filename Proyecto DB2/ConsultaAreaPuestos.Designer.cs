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
            this.lblArea = new System.Windows.Forms.Label();
            this.lblInfoArea = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblEstadisticas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAreaPuestos
            // 
            this.dgAreaPuestos.AllowUserToAddRows = false;
            this.dgAreaPuestos.AllowUserToDeleteRows = false;
            this.dgAreaPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAreaPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAreaPuestos.Location = new System.Drawing.Point(16, 76);
            this.dgAreaPuestos.Margin = new System.Windows.Forms.Padding(4);
            this.dgAreaPuestos.Name = "dgAreaPuestos";
            this.dgAreaPuestos.ReadOnly = true;
            this.dgAreaPuestos.RowHeadersWidth = 51;
            this.dgAreaPuestos.Size = new System.Drawing.Size(882, 377);
            this.dgAreaPuestos.TabIndex = 0;
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(59, 12);
            this.cmbArea.Margin = new System.Windows.Forms.Padding(4);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(265, 24);
            this.cmbArea.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(776, 483);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(122, 48);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Salir";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(12, 15);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 16);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "Área:";
            // 
            // lblInfoArea
            // 
            this.lblInfoArea.AutoSize = true;
            this.lblInfoArea.Location = new System.Drawing.Point(12, 45);
            this.lblInfoArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoArea.Name = "lblInfoArea";
            this.lblInfoArea.Size = new System.Drawing.Size(0, 16);
            this.lblInfoArea.TabIndex = 4;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(73, 469);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(265, 22);
            this.txtBuscar.TabIndex = 5;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(13, 469);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.AutoSize = true;
            this.lblEstadisticas.Location = new System.Drawing.Point(12, 515);
            this.lblEstadisticas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new System.Drawing.Size(0, 16);
            this.lblEstadisticas.TabIndex = 7;
            // 
            // ConsultaAreasPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 540);
            this.Controls.Add(this.lblEstadisticas);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblInfoArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.dgAreaPuestos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsultaAreasPuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Áreas y Puestos";
            ((System.ComponentModel.ISupportInitialize)(this.dgAreaPuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAreaPuestos;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblInfoArea;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblEstadisticas;
    }
}