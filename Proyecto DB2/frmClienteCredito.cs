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
    public partial class frmClienteCredito : Form
    {
        SqlConnection con;

        public frmClienteCredito()
        {
            InitializeComponent();
        }

        public frmClienteCredito(SqlConnection conexion)
        {
            InitializeComponent();

            con = conexion;
        }

        private void frmClienteCredito_Load(object sender, EventArgs e)
        {

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdVerID_Click(object sender, EventArgs e)
        {
            frmClienteFacturaID frm = new frmClienteFacturaID(con);
            frm.ShowDialog();
        }
    }
}
