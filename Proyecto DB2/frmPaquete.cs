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
    public partial class frmPaquete : Form
    {
        public frmPaquete()
        {
            InitializeComponent();
        }

        public frmPaquete(SqlConnection conexion, int paqueteid )         {
            InitializeComponent();
        }

        private void frmPaquete_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
