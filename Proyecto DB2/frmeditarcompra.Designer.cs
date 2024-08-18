namespace Proyecto_DB2
{
    partial class frmeditarcompra
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
            this.dgModificarCompra = new System.Windows.Forms.DataGridView();
            this.btnGuardarModificar = new System.Windows.Forms.Button();
            this.btnCancelarModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgModificarCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // dgModificarCompra
            // 
            this.dgModificarCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgModificarCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgModificarCompra.Location = new System.Drawing.Point(74, 46);
            this.dgModificarCompra.Name = "dgModificarCompra";
            this.dgModificarCompra.Size = new System.Drawing.Size(638, 279);
            this.dgModificarCompra.TabIndex = 0;
            // 
            // btnGuardarModificar
            // 
            this.btnGuardarModificar.Location = new System.Drawing.Point(496, 331);
            this.btnGuardarModificar.Name = "btnGuardarModificar";
            this.btnGuardarModificar.Size = new System.Drawing.Size(112, 45);
            this.btnGuardarModificar.TabIndex = 1;
            this.btnGuardarModificar.Text = "Salvar";
            this.btnGuardarModificar.UseVisualStyleBackColor = true;
            this.btnGuardarModificar.Click += new System.EventHandler(this.btnGuardarModificar_Click);
            // 
            // btnCancelarModificar
            // 
            this.btnCancelarModificar.Location = new System.Drawing.Point(614, 331);
            this.btnCancelarModificar.Name = "btnCancelarModificar";
            this.btnCancelarModificar.Size = new System.Drawing.Size(98, 45);
            this.btnCancelarModificar.TabIndex = 2;
            this.btnCancelarModificar.Text = "Cancelar";
            this.btnCancelarModificar.UseVisualStyleBackColor = true;
            this.btnCancelarModificar.Click += new System.EventHandler(this.btnCancelarModificar_Click);
            // 
            // frmeditarcompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelarModificar);
            this.Controls.Add(this.btnGuardarModificar);
            this.Controls.Add(this.dgModificarCompra);
            this.Name = "frmeditarcompra";
            this.Text = "frmeditarcompra";
            this.Load += new System.EventHandler(this.frmeditarcompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgModificarCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgModificarCompra;
        private System.Windows.Forms.Button btnGuardarModificar;
        private System.Windows.Forms.Button btnCancelarModificar;
    }
}