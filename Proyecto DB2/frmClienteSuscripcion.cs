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
    public partial class frmClienteSuscripcion : Form
    {
        public frmClienteSuscripcion()
        {
            InitializeComponent();
        }

        public frmClienteSuscripcion(SqlConnection conexion)
        {
            InitializeComponent();
        }

        private void frmClienteSuscripcion_Load(object sender, EventArgs e)
        {

        }
    }
}
