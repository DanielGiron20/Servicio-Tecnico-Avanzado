namespace Proyecto_DB2
{
    partial class Compras
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultarCompra = new System.Windows.Forms.Button();
            this.dgCompra = new System.Windows.Forms.DataGridView();
            this.btrnInsertarCompra = new System.Windows.Forms.Button();
            this.btnModificarCompra = new System.Windows.Forms.Button();
            this.btnDesactivarCompra = new System.Windows.Forms.Button();
            this.btnIsertarExistente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // btnConsultarCompra
            // 
            this.btnConsultarCompra.Location = new System.Drawing.Point(497, 299);
            this.btnConsultarCompra.Name = "btnConsultarCompra";
            this.btnConsultarCompra.Size = new System.Drawing.Size(84, 35);
            this.btnConsultarCompra.TabIndex = 2;
            this.btnConsultarCompra.Text = "Consultar";
            this.btnConsultarCompra.UseVisualStyleBackColor = true;
            this.btnConsultarCompra.Click += new System.EventHandler(this.btnConsultarCompra_Click);
            // 
            // dgCompra
            // 
            this.dgCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompra.Location = new System.Drawing.Point(38, 51);
            this.dgCompra.Name = "dgCompra";
            this.dgCompra.Size = new System.Drawing.Size(543, 231);
            this.dgCompra.TabIndex = 3;
            this.dgCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellContentClick);
            // 
            // btrnInsertarCompra
            // 
            this.btrnInsertarCompra.Location = new System.Drawing.Point(38, 299);
            this.btrnInsertarCompra.Name = "btrnInsertarCompra";
            this.btrnInsertarCompra.Size = new System.Drawing.Size(87, 35);
            this.btrnInsertarCompra.TabIndex = 4;
            this.btrnInsertarCompra.Text = "Insertar";
            this.btrnInsertarCompra.UseVisualStyleBackColor = true;
            this.btrnInsertarCompra.Click += new System.EventHandler(this.btrnInsertarCompra_Click);
            // 
            // btnModificarCompra
            // 
            this.btnModificarCompra.Location = new System.Drawing.Point(307, 299);
            this.btnModificarCompra.Name = "btnModificarCompra";
            this.btnModificarCompra.Size = new System.Drawing.Size(75, 35);
            this.btnModificarCompra.TabIndex = 5;
            this.btnModificarCompra.Text = "Modificar";
            this.btnModificarCompra.UseVisualStyleBackColor = true;
            // 
            // btnDesactivarCompra
            // 
            this.btnDesactivarCompra.Location = new System.Drawing.Point(400, 299);
            this.btnDesactivarCompra.Name = "btnDesactivarCompra";
            this.btnDesactivarCompra.Size = new System.Drawing.Size(78, 35);
            this.btnDesactivarCompra.TabIndex = 6;
            this.btnDesactivarCompra.Text = "Desactivar";
            this.btnDesactivarCompra.UseVisualStyleBackColor = true;
            // 
            // btnIsertarExistente
            // 
            this.btnIsertarExistente.Location = new System.Drawing.Point(38, 340);
            this.btnIsertarExistente.Name = "btnIsertarExistente";
            this.btnIsertarExistente.Size = new System.Drawing.Size(87, 46);
            this.btnIsertarExistente.TabIndex = 7;
            this.btnIsertarExistente.Text = "Compra Existente";
            this.btnIsertarExistente.UseVisualStyleBackColor = true;
            this.btnIsertarExistente.Click += new System.EventHandler(this.btnIsertarExistente_Click);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 424);
            this.Controls.Add(this.btnIsertarExistente);
            this.Controls.Add(this.btnDesactivarCompra);
            this.Controls.Add(this.btnModificarCompra);
            this.Controls.Add(this.btrnInsertarCompra);
            this.Controls.Add(this.dgCompra);
            this.Controls.Add(this.btnConsultarCompra);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Compras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.Compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultarCompra;
        private System.Windows.Forms.DataGridView dgCompra;
        private System.Windows.Forms.Button btrnInsertarCompra;
        private System.Windows.Forms.Button btnModificarCompra;
        private System.Windows.Forms.Button btnDesactivarCompra;
        private System.Windows.Forms.Button btnIsertarExistente;
    }
}