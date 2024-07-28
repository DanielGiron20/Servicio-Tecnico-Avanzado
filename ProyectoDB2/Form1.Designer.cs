
namespace ProyectoClinica
{
    partial class CentroMedicoLaPaz
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelMenuLateral = new Panel();
            panelQuirofanos = new Panel();
            BtnAgenda = new Button();
            BtnQuirofano = new Button();
            BtnQuirofanos = new Button();
            panelAdmin = new Panel();
            BtnAdminPrecio = new Button();
            BtnAdminFarmacia = new Button();
            BtnAdminHospital = new Button();
            panelHospitalizaciones = new Panel();
            BtnVerHozpitalizaciones = new Button();
            BtnHospitalizaciones = new Button();
            panelDoctores = new Panel();
            btnVerDoctores = new Button();
            btnDoctores = new Button();
            panelSubMenuPacientes = new Panel();
            btnVerPacientes = new Button();
            BtnPacientes = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            panelDePaneles = new Panel();
            pictureBoxGrande = new PictureBox();
            PanelMenuLateral.SuspendLayout();
            panelQuirofanos.SuspendLayout();
            panelAdmin.SuspendLayout();
            panelHospitalizaciones.SuspendLayout();
            panelDoctores.SuspendLayout();
            panelSubMenuPacientes.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelDePaneles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGrande).BeginInit();
            SuspendLayout();
            // 
            // PanelMenuLateral
            // 
            PanelMenuLateral.BackColor = Color.Black;
            PanelMenuLateral.Controls.Add(panelQuirofanos);
            PanelMenuLateral.Controls.Add(BtnQuirofanos);
            PanelMenuLateral.Controls.Add(panelAdmin);
            PanelMenuLateral.Controls.Add(BtnAdminHospital);
            PanelMenuLateral.Controls.Add(panelHospitalizaciones);
            PanelMenuLateral.Controls.Add(BtnHospitalizaciones);
            PanelMenuLateral.Controls.Add(panelDoctores);
            PanelMenuLateral.Controls.Add(btnDoctores);
            PanelMenuLateral.Controls.Add(panelSubMenuPacientes);
            PanelMenuLateral.Controls.Add(BtnPacientes);
            PanelMenuLateral.Controls.Add(panelLogo);
            PanelMenuLateral.Dock = DockStyle.Left;
            PanelMenuLateral.Location = new Point(0, 0);
            PanelMenuLateral.Name = "PanelMenuLateral";
            PanelMenuLateral.Size = new Size(256, 1050);
            PanelMenuLateral.TabIndex = 0;
            // 
            // panelQuirofanos
            // 
            panelQuirofanos.BackColor = Color.FromArgb(64, 64, 64);
            panelQuirofanos.Controls.Add(BtnAgenda);
            panelQuirofanos.Controls.Add(BtnQuirofano);
            panelQuirofanos.Dock = DockStyle.Top;
            panelQuirofanos.Location = new Point(0, 1036);
            panelQuirofanos.Name = "panelQuirofanos";
            panelQuirofanos.Size = new Size(256, 133);
            panelQuirofanos.TabIndex = 8;
            // 
            // BtnAgenda
            // 
            BtnAgenda.Dock = DockStyle.Top;
            BtnAgenda.FlatAppearance.BorderSize = 0;
            BtnAgenda.FlatStyle = FlatStyle.Flat;
            BtnAgenda.ForeColor = SystemColors.ControlLightLight;
            BtnAgenda.Location = new Point(0, 63);
            BtnAgenda.Name = "BtnAgenda";
            BtnAgenda.Padding = new Padding(35, 0, 0, 0);
            BtnAgenda.Size = new Size(256, 65);
            BtnAgenda.TabIndex = 1;
            BtnAgenda.Text = "-";
            BtnAgenda.TextAlign = ContentAlignment.MiddleLeft;
            BtnAgenda.UseVisualStyleBackColor = true;
            BtnAgenda.Click += BtnAgenda_Click;
            // 
            // BtnQuirofano
            // 
            BtnQuirofano.Dock = DockStyle.Top;
            BtnQuirofano.FlatAppearance.BorderSize = 0;
            BtnQuirofano.FlatStyle = FlatStyle.Flat;
            BtnQuirofano.ForeColor = SystemColors.ControlLightLight;
            BtnQuirofano.Location = new Point(0, 0);
            BtnQuirofano.Name = "BtnQuirofano";
            BtnQuirofano.Padding = new Padding(35, 0, 0, 0);
            BtnQuirofano.Size = new Size(256, 63);
            BtnQuirofano.TabIndex = 0;
            BtnQuirofano.Text = "Ver inventario";
            BtnQuirofano.TextAlign = ContentAlignment.MiddleLeft;
            BtnQuirofano.UseVisualStyleBackColor = true;
            BtnQuirofano.Click += BtnQuirofano_Click;
            // 
            // BtnQuirofanos
            // 
            BtnQuirofanos.Dock = DockStyle.Top;
            BtnQuirofanos.FlatAppearance.BorderSize = 0;
            BtnQuirofanos.FlatAppearance.MouseDownBackColor = Color.Gray;
            BtnQuirofanos.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnQuirofanos.FlatStyle = FlatStyle.Flat;
            BtnQuirofanos.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            BtnQuirofanos.ForeColor = SystemColors.ControlLightLight;
            BtnQuirofanos.Location = new Point(0, 954);
            BtnQuirofanos.Name = "BtnQuirofanos";
            BtnQuirofanos.Padding = new Padding(10, 0, 0, 0);
            BtnQuirofanos.Size = new Size(256, 82);
            BtnQuirofanos.TabIndex = 7;
            BtnQuirofanos.Text = "Inventario";
            BtnQuirofanos.TextAlign = ContentAlignment.MiddleLeft;
            BtnQuirofanos.UseVisualStyleBackColor = true;
            BtnQuirofanos.Click += BtnQuirofanos_Click;
            // 
            // panelAdmin
            // 
            panelAdmin.BackColor = Color.FromArgb(64, 64, 64);
            panelAdmin.Controls.Add(BtnAdminPrecio);
            panelAdmin.Controls.Add(BtnAdminFarmacia);
            panelAdmin.Dock = DockStyle.Top;
            panelAdmin.Location = new Point(0, 804);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(256, 150);
            panelAdmin.TabIndex = 6;
            // 
            // BtnAdminPrecio
            // 
            BtnAdminPrecio.Dock = DockStyle.Top;
            BtnAdminPrecio.FlatAppearance.BorderSize = 0;
            BtnAdminPrecio.FlatStyle = FlatStyle.Flat;
            BtnAdminPrecio.ForeColor = SystemColors.ControlLightLight;
            BtnAdminPrecio.Location = new Point(0, 72);
            BtnAdminPrecio.Name = "BtnAdminPrecio";
            BtnAdminPrecio.Padding = new Padding(35, 0, 0, 0);
            BtnAdminPrecio.Size = new Size(256, 75);
            BtnAdminPrecio.TabIndex = 1;
            BtnAdminPrecio.Text = "Ver tecnicos";
            BtnAdminPrecio.TextAlign = ContentAlignment.MiddleLeft;
            BtnAdminPrecio.UseVisualStyleBackColor = true;
            BtnAdminPrecio.Click += button3_Click;
            // 
            // BtnAdminFarmacia
            // 
            BtnAdminFarmacia.Dock = DockStyle.Top;
            BtnAdminFarmacia.FlatAppearance.BorderSize = 0;
            BtnAdminFarmacia.FlatStyle = FlatStyle.Flat;
            BtnAdminFarmacia.ForeColor = SystemColors.ControlLightLight;
            BtnAdminFarmacia.Location = new Point(0, 0);
            BtnAdminFarmacia.Name = "BtnAdminFarmacia";
            BtnAdminFarmacia.Padding = new Padding(35, 0, 0, 0);
            BtnAdminFarmacia.Size = new Size(256, 72);
            BtnAdminFarmacia.TabIndex = 0;
            BtnAdminFarmacia.Text = "Compras";
            BtnAdminFarmacia.TextAlign = ContentAlignment.MiddleLeft;
            BtnAdminFarmacia.UseVisualStyleBackColor = true;
            BtnAdminFarmacia.Click += button2_Click_1;
            // 
            // BtnAdminHospital
            // 
            BtnAdminHospital.BackgroundImageLayout = ImageLayout.None;
            BtnAdminHospital.Dock = DockStyle.Top;
            BtnAdminHospital.FlatAppearance.BorderSize = 0;
            BtnAdminHospital.FlatAppearance.MouseDownBackColor = Color.Gray;
            BtnAdminHospital.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnAdminHospital.FlatStyle = FlatStyle.Flat;
            BtnAdminHospital.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAdminHospital.ForeColor = SystemColors.ControlLightLight;
            BtnAdminHospital.Location = new Point(0, 705);
            BtnAdminHospital.Name = "BtnAdminHospital";
            BtnAdminHospital.Padding = new Padding(10, 0, 0, 0);
            BtnAdminHospital.Size = new Size(256, 99);
            BtnAdminHospital.TabIndex = 2;
            BtnAdminHospital.Text = "Administracion ";
            BtnAdminHospital.TextAlign = ContentAlignment.MiddleLeft;
            BtnAdminHospital.UseVisualStyleBackColor = true;
            BtnAdminHospital.Click += BtnAdminHospital_Click_1;
            // 
            // panelHospitalizaciones
            // 
            panelHospitalizaciones.BackColor = Color.FromArgb(64, 64, 64);
            panelHospitalizaciones.Controls.Add(BtnVerHozpitalizaciones);
            panelHospitalizaciones.Dock = DockStyle.Top;
            panelHospitalizaciones.Location = new Point(0, 643);
            panelHospitalizaciones.Name = "panelHospitalizaciones";
            panelHospitalizaciones.Size = new Size(256, 62);
            panelHospitalizaciones.TabIndex = 4;
            // 
            // BtnVerHozpitalizaciones
            // 
            BtnVerHozpitalizaciones.Dock = DockStyle.Top;
            BtnVerHozpitalizaciones.FlatAppearance.BorderSize = 0;
            BtnVerHozpitalizaciones.FlatStyle = FlatStyle.Flat;
            BtnVerHozpitalizaciones.ForeColor = SystemColors.ControlLightLight;
            BtnVerHozpitalizaciones.Location = new Point(0, 0);
            BtnVerHozpitalizaciones.Name = "BtnVerHozpitalizaciones";
            BtnVerHozpitalizaciones.Padding = new Padding(35, 0, 0, 0);
            BtnVerHozpitalizaciones.Size = new Size(256, 62);
            BtnVerHozpitalizaciones.TabIndex = 0;
            BtnVerHozpitalizaciones.Text = "Ver clientes";
            BtnVerHozpitalizaciones.TextAlign = ContentAlignment.MiddleLeft;
            BtnVerHozpitalizaciones.UseVisualStyleBackColor = true;
            BtnVerHozpitalizaciones.Click += BtnVerHozpitalizaciones_Click;
            // 
            // BtnHospitalizaciones
            // 
            BtnHospitalizaciones.Dock = DockStyle.Top;
            BtnHospitalizaciones.FlatAppearance.BorderSize = 0;
            BtnHospitalizaciones.FlatAppearance.MouseDownBackColor = Color.Gray;
            BtnHospitalizaciones.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnHospitalizaciones.FlatStyle = FlatStyle.Flat;
            BtnHospitalizaciones.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            BtnHospitalizaciones.ForeColor = SystemColors.ControlLightLight;
            BtnHospitalizaciones.Location = new Point(0, 550);
            BtnHospitalizaciones.Name = "BtnHospitalizaciones";
            BtnHospitalizaciones.Padding = new Padding(10, 0, 0, 0);
            BtnHospitalizaciones.Size = new Size(256, 93);
            BtnHospitalizaciones.TabIndex = 2;
            BtnHospitalizaciones.Text = "Clientes";
            BtnHospitalizaciones.TextAlign = ContentAlignment.MiddleLeft;
            BtnHospitalizaciones.UseVisualStyleBackColor = true;
            BtnHospitalizaciones.Click += BtnHospitalizaciones_Click;
            // 
            // panelDoctores
            // 
            panelDoctores.BackColor = Color.FromArgb(64, 64, 64);
            panelDoctores.Controls.Add(btnVerDoctores);
            panelDoctores.Dock = DockStyle.Top;
            panelDoctores.Location = new Point(0, 485);
            panelDoctores.Name = "panelDoctores";
            panelDoctores.Size = new Size(256, 65);
            panelDoctores.TabIndex = 3;
            // 
            // btnVerDoctores
            // 
            btnVerDoctores.Dock = DockStyle.Top;
            btnVerDoctores.FlatAppearance.BorderSize = 0;
            btnVerDoctores.FlatStyle = FlatStyle.Flat;
            btnVerDoctores.ForeColor = SystemColors.ControlLightLight;
            btnVerDoctores.Location = new Point(0, 0);
            btnVerDoctores.Name = "btnVerDoctores";
            btnVerDoctores.Padding = new Padding(35, 0, 0, 0);
            btnVerDoctores.Size = new Size(256, 65);
            btnVerDoctores.TabIndex = 0;
            btnVerDoctores.Text = "Ver planes y servicios";
            btnVerDoctores.TextAlign = ContentAlignment.MiddleLeft;
            btnVerDoctores.UseVisualStyleBackColor = true;
            btnVerDoctores.Click += button2_Click;
            // 
            // btnDoctores
            // 
            btnDoctores.Dock = DockStyle.Top;
            btnDoctores.FlatAppearance.BorderSize = 0;
            btnDoctores.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnDoctores.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnDoctores.FlatStyle = FlatStyle.Flat;
            btnDoctores.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnDoctores.ForeColor = SystemColors.ControlLightLight;
            btnDoctores.Location = new Point(0, 394);
            btnDoctores.Name = "btnDoctores";
            btnDoctores.Padding = new Padding(10, 0, 0, 0);
            btnDoctores.Size = new Size(256, 91);
            btnDoctores.TabIndex = 2;
            btnDoctores.Text = "Servicios";
            btnDoctores.TextAlign = ContentAlignment.MiddleLeft;
            btnDoctores.UseVisualStyleBackColor = true;
            btnDoctores.Click += brnDoctores_Click;
            // 
            // panelSubMenuPacientes
            // 
            panelSubMenuPacientes.BackColor = Color.FromArgb(64, 64, 64);
            panelSubMenuPacientes.Controls.Add(btnVerPacientes);
            panelSubMenuPacientes.Dock = DockStyle.Top;
            panelSubMenuPacientes.Location = new Point(0, 313);
            panelSubMenuPacientes.Name = "panelSubMenuPacientes";
            panelSubMenuPacientes.Size = new Size(256, 81);
            panelSubMenuPacientes.TabIndex = 1;
            // 
            // btnVerPacientes
            // 
            btnVerPacientes.Dock = DockStyle.Top;
            btnVerPacientes.FlatAppearance.BorderSize = 0;
            btnVerPacientes.FlatStyle = FlatStyle.Flat;
            btnVerPacientes.ForeColor = SystemColors.ControlLightLight;
            btnVerPacientes.Location = new Point(0, 0);
            btnVerPacientes.Name = "btnVerPacientes";
            btnVerPacientes.Padding = new Padding(35, 0, 0, 0);
            btnVerPacientes.Size = new Size(256, 81);
            btnVerPacientes.TabIndex = 0;
            btnVerPacientes.Text = "Servicios pendientes";
            btnVerPacientes.TextAlign = ContentAlignment.MiddleLeft;
            btnVerPacientes.UseVisualStyleBackColor = true;
            btnVerPacientes.Click += button1_Click;
            // 
            // BtnPacientes
            // 
            BtnPacientes.AccessibleName = "BtnVerPacientes";
            BtnPacientes.Dock = DockStyle.Top;
            BtnPacientes.FlatAppearance.BorderSize = 0;
            BtnPacientes.FlatAppearance.MouseDownBackColor = Color.Gray;
            BtnPacientes.FlatAppearance.MouseOverBackColor = Color.Gray;
            BtnPacientes.FlatStyle = FlatStyle.Flat;
            BtnPacientes.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPacientes.ForeColor = SystemColors.ControlLightLight;
            BtnPacientes.Location = new Point(0, 211);
            BtnPacientes.Name = "BtnPacientes";
            BtnPacientes.Padding = new Padding(10, 0, 0, 0);
            BtnPacientes.Size = new Size(256, 102);
            BtnPacientes.TabIndex = 0;
            BtnPacientes.Text = "Agenda";
            BtnPacientes.TextAlign = ContentAlignment.MiddleLeft;
            BtnPacientes.UseVisualStyleBackColor = true;
            BtnPacientes.Click += BtnPacientes_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(256, 211);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Captura_de_pantalla_2024_07_28_154510;
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 209);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelDePaneles
            // 
            panelDePaneles.BackColor = Color.FromArgb(65, 65, 65);
            panelDePaneles.Controls.Add(pictureBoxGrande);
            panelDePaneles.Dock = DockStyle.Fill;
            panelDePaneles.Location = new Point(256, 0);
            panelDePaneles.Name = "panelDePaneles";
            panelDePaneles.Size = new Size(1613, 1050);
            panelDePaneles.TabIndex = 1;
            // 
            // pictureBoxGrande
            // 
            pictureBoxGrande.Dock = DockStyle.Fill;
            pictureBoxGrande.Enabled = false;
            pictureBoxGrande.Image = Properties.Resources.WhatsApp_Image_2024_07_28_at_15_35_08;
            pictureBoxGrande.InitialImage = null;
            pictureBoxGrande.Location = new Point(0, 0);
            pictureBoxGrande.Name = "pictureBoxGrande";
            pictureBoxGrande.Size = new Size(1613, 1050);
            pictureBoxGrande.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGrande.TabIndex = 0;
            pictureBoxGrande.TabStop = false;
            pictureBoxGrande.Click += pictureBoxGrande_Click;
            // 
            // CentroMedicoLaPaz
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1869, 1050);
            Controls.Add(panelDePaneles);
            Controls.Add(PanelMenuLateral);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "CentroMedicoLaPaz";
            Text = "Centro Medico La Paz Host";
            PanelMenuLateral.ResumeLayout(false);
            panelQuirofanos.ResumeLayout(false);
            panelAdmin.ResumeLayout(false);
            panelHospitalizaciones.ResumeLayout(false);
            panelDoctores.ResumeLayout(false);
            panelSubMenuPacientes.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelDePaneles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGrande).EndInit();
            ResumeLayout(false);
        }

        private void pictureBoxGrande_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel PanelMenuLateral;
        private Panel panelSubMenuPacientes;
        private Button BtnPacientes;
        private Panel panelLogo;
        private Button btnVerPacientes;
        private Button btnDoctores;
        private Panel panelDoctores;
        private Button btnVerDoctores;
        private Panel panelDePaneles;
        private PictureBox pictureBoxGrande;
        private Button BtnHospitalizaciones;
        private Panel panelHospitalizaciones;
        private Button BtnVerHozpitalizaciones;
        private Button BtnAdminHospital;
        private Panel panelAdmin;
        private Button BtnAdminFarmacia;
        private Button BtnAdminPrecio;
        private Button BtnQuirofanos;
        private Panel panelQuirofanos;
        private Button BtnQuirofano;
        private Button BtnAgenda;
        private PictureBox pictureBox1;
    }
}