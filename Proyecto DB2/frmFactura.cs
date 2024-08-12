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
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        public frmFactura(SqlConnection cnx)
        {
            InitializeComponent();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
