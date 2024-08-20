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
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
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
            // 
            // btnEditarEmpleado
            // 
            this.btnEditarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnEditarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnEditarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEmpleado.Location = new System.Drawing.Point(16, 475);
            this.btnEditarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(122, 48);
            this.btnEditarEmpleado.TabIndex = 1;
            this.btnEditarEmpleado.Text = "Editar Empleado";
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            this.btnEditarEmpleado.Click += new System.EventHandler(this.btnEditarEmpleado_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(146, 475);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(122, 48);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.btnAgregarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(276, 475);
            this.btnAgregarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(122, 48);
            this.btnAgregarEmpleado.TabIndex = 3;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
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
            this.btnCerrar.TabIndex = 4;
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
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Detalle de Planilla";
            // 
            // PlanillaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 540);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditarEmpleado);
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
        private System.Windows.Forms.Button btnEditarEmpleado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
    }
}