namespace Proyecto_DB2
{
    partial class PlanillaDetalle
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
            this.dgPlanillaDetalle = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanillaDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPlanillaDetalle
            // 
            this.dgPlanillaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlanillaDetalle.Location = new System.Drawing.Point(16, 50);
            this.dgPlanillaDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.dgPlanillaDetalle.Name = "dgPlanillaDetalle";
            this.dgPlanillaDetalle.RowHeadersWidth = 51;
            this.dgPlanillaDetalle.Size = new System.Drawing.Size(882, 380);
            this.dgPlanillaDetalle.TabIndex = 0;
            this.dgPlanillaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPlanillaDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPlanillaDetalle_CellValueChanged);
            this.dgPlanillaDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgPlanillaDetalle_CellValidating);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(16, 475);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(122, 48);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(167, 475);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 48);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(776, 475);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(122, 48);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(16, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(231, 29);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Detalle de Planilla";
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnAgregarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(311, 475);
            this.btnAgregarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(122, 48);
            this.btnAgregarEmpleado.TabIndex = 5;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // PlanillaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 540);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgPlanillaDetalle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlanillaDetalle";
            this.Text = "Detalle de Planilla";
            this.Load += new System.EventHandler(this.PlanillaDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlanillaDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgPlanillaDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAgregarEmpleado;
    }
}