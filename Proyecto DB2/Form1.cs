using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class Form1 : Form
    {
        SqlConnection conexionMenu;

        public Form1()
        {
            InitializeComponent();
            personalizar();
        }

        public Form1(SqlConnection cnx)
        {
            InitializeComponent();
            personalizar();
        }

        private void personalizar()
        {
            panel3.Visible = false;
            panel4.Visible = false;  
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            pnlSubMenuGestionVentas.Visible = false;
            pnlverproveedor.Visible = false;
        }

        private void ocultar()
        {
            if(panel3.Visible == true)
            panel3.Visible=false;
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel5.Visible == true)
                panel5.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
            if (panel7.Visible == true)
                panel7.Visible = false;
            if(pnlSubMenuGestionVentas.Visible == true)
                pnlSubMenuGestionVentas.Visible = false;
            if (pnlverproveedor.Visible == true)
                pnlverproveedor.Visible = false;
        }

        private void mostrar(Panel subMenu)
        {
                if(subMenu.Visible == false)
            {
                ocultar();
                subMenu.Visible = true;
            }
                else
                subMenu.Visible = false;    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar(panel3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchildform(new Agenda());
            ocultar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mostrar(panel4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openchildform(new Servicios());
            ocultar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mostrar(panel5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openchildform(new frmClienteLista(conexionMenu));
            ocultar();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mostrar(panel6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openchildform(new Compras(conexionMenu));
            ocultar();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openchildform(new frmEmpleado());    
            ocultar();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mostrar(panel7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openchildform(new Inventario());
            ocultar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();

            if (frm.Conectado)
            {
                conexionMenu = frm.Con;
            }
            else 
            {
                this.Dispose();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private Form activo = null;
        private void openchildform(Form child)
        {
            if (activo != null)
                activo.Close();
            activo = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel8.Controls.Add(child);
            panel8.Tag = child;
            child.BringToFront();
            child.Show();


        }

        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            mostrar(pnlSubMenuGestionVentas);
        }

        private void btnOrdenMD_Click(object sender, EventArgs e)
        {
            openchildform(new frmOrden(conexionMenu));
            ocultar();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            openchildform(new frmFactura(conexionMenu));
            ocultar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {

            mostrar(pnlverproveedor);
        }

        private void verProveedor_Click(object sender, EventArgs e)
        {
            openchildform(new frmProveedor());
            ocultar();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openchildform(new frmPaqueteLista(conexionMenu));
            ocultar();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openchildform(new frmClienteSuscripcion(conexionMenu));
            ocultar();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openchildform(new frmClienteCredito(conexionMenu));
            ocultar();
        }
    }

}
