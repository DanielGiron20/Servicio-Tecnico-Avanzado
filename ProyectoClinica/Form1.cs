using System.Drawing.Imaging;
using System.Security.Policy;
using System.Windows.Forms;

namespace ProyectoClinica
{
    public partial class CentroMedicoLaPaz : Form
    {
        public CentroMedicoLaPaz()
        {
            InitializeComponent();
            EscondersubMenus();
            this.WindowState = FormWindowState.Maximized;
        }
        private void EscondersubMenus()
        {
            panelSubMenuPacientes.Visible = false;
            panelDoctores.Visible = false;
            panelHospitalizaciones.Visible = false;
            panelAdmin.Visible = false;
            panelQuirofanos.Visible = false;
        }
        private void MostrarsubMenus(Panel si)
        {
            if (si.Visible == false)
            {
                EscondersubMenus();
                si.Visible = true;
            }
            else
            {
                si.Visible = false;
            }
        }
        private Form activeForm = null;


        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            MostrarsubMenus(panelSubMenuPacientes);
        }

        private void brnDoctores_Click(object sender, EventArgs e)
        {
            MostrarsubMenus(panelDoctores);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            FormPacientes form2 = new FormPacientes();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form2);
            form2.Visible = true;
            EscondersubMenus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            FormDoctores form = new FormDoctores();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }
        private void BtnHospitalizaciones_Click(object sender, EventArgs e)
        {
            MostrarsubMenus(panelHospitalizaciones);
        }

        private void BtnAdminHospital_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdminHospital_Click_1(object sender, EventArgs e)
        {
            MostrarsubMenus(panelAdmin);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            AdminFarmacia form = new AdminFarmacia();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            FormAdminPrecio form = new FormAdminPrecio();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }

        private void BtnQuirofanos_Click(object sender, EventArgs e)
        {
            MostrarsubMenus(panelQuirofanos);
        }

        private void BtnVerHozpitalizaciones_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            FormHospitalizaciones form = new FormHospitalizaciones();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }

        private void BtnQuirofano_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            formQuirofano form = new formQuirofano();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }

        private void BtnAgenda_Click(object sender, EventArgs e)
        {
            panelDePaneles.Controls.Clear();
            FormAgenda form = new FormAgenda();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelDePaneles.Controls.Add(form);
            form.Visible = true;
            EscondersubMenus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}