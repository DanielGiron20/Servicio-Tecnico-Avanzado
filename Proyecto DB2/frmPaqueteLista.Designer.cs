﻿namespace Proyecto_DB2
{
    partial class frmPaqueteLista
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
            this.cmdInsertar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdDesactivar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOpcion = new System.Windows.Forms.ComboBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmbCampo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(650, 364);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmdInsertar
            // 
            this.cmdInsertar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdInsertar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInsertar.Location = new System.Drawing.Point(12, 433);
            this.cmdInsertar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdInsertar.Name = "cmdInsertar";
            this.cmdInsertar.Size = new System.Drawing.Size(95, 44);
            this.cmdInsertar.TabIndex = 9;
            this.cmdInsertar.Text = "Insertar";
            this.cmdInsertar.UseVisualStyleBackColor = true;
            this.cmdInsertar.Click += new System.EventHandler(this.cmdInsertar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdModificar.Location = new System.Drawing.Point(111, 433);
            this.cmdModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(95, 44);
            this.cmdModificar.TabIndex = 10;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdDesactivar
            // 
            this.cmdDesactivar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDesactivar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumPurple;
            this.cmdDesactivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
            this.cmdDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDesactivar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDesactivar.Location = new System.Drawing.Point(210, 433);
            this.cmdDesactivar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdDesactivar.Name = "cmdDesactivar";
            this.cmdDesactivar.Size = new System.Drawing.Size(95, 44);
            this.cmdDesactivar.TabIndex = 14;
            this.cmdDesactivar.Text = "Desactivar";
            this.cmdDesactivar.UseVisualStyleBackColor = true;
            this.cmdDesactivar.Click += new System.EventHandler(this.cmdDesactivar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 449);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ver paquetes";
            // 
            // cmbOpcion
            // 
            this.cmbOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpcion.FormattingEnabled = true;
            this.cmbOpcion.Location = new System.Drawing.Point(403, 446);
            this.cmbOpcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbOpcion.Name = "cmbOpcion";
            this.cmbOpcion.Size = new System.Drawing.Size(135, 21);
            this.cmbOpcion.TabIndex = 16;
            this.cmbOpcion.SelectedIndexChanged += new System.EventHandler(this.cmbOpcion_SelectedIndexChanged);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSalir.Location = new System.Drawing.Point(598, 433);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(64, 44);
            this.cmdSalir.TabIndex = 17;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmbCampo
            // 
            this.cmbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCampo.FormattingEnabled = true;
            this.cmbCampo.Items.AddRange(new object[] {
            "Nombre",
            "Descripcion",
            "PrecioMensual",
            "CantidadHoras"});
            this.cmbCampo.Location = new System.Drawing.Point(12, 18);
            this.cmbCampo.Name = "cmbCampo";
            this.cmbCampo.Size = new System.Drawing.Size(142, 21);
            this.cmbCampo.TabIndex = 18;
            this.cmbCampo.SelectedIndexChanged += new System.EventHandler(this.cmbCampo_SelectedIndexChanged);
            this.cmbCampo.Click += new System.EventHandler(this.cmbCampo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Buscar:";
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(229, 18);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(233, 20);
            this.txtTexto.TabIndex = 20;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // frmPaqueteLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 487);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCampo);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmbOpcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdDesactivar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdInsertar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaqueteLista";
            this.Text = "frmPaqueteLista";
            this.Load += new System.EventHandler(this.frmPaqueteLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdInsertar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdDesactivar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOpcion;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.ComboBox cmbCampo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
    }
}