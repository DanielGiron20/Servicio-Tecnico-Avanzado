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
    public partial class frmOrden : Form
    {
        public frmOrden()
        {
            InitializeComponent();
        }

        public frmOrden(SqlConnection cnx)
        {
            InitializeComponent();


        }

        private void frmOrden_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
