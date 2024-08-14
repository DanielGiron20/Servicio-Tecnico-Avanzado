using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class Compras : Form
    {
        
        SqlDataAdapter adpleerc;
        DataTable dtcompra;
        
        public Compras()
        {
            InitializeComponent();
            
        }

        public Compras(SqlConnection conexion)
        {
          
            
            InitializeComponent();
            dtcompra = new DataTable();
            adpleerc = new SqlDataAdapter("spCompra", conexion);
            adpleerc.SelectCommand.CommandType = CommandType.StoredProcedure;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Compras_Load(object sender, EventArgs e)
        {

            adpleerc.Fill(dtcompra);
            dgCompra.DataSource = dtcompra;

        }

        private void btnConsultarCompra_Click(object sender, EventArgs e)
        {
            //btnConsultar
            Form frmconsulta = new frmConsultaCompra();
            frmconsulta.Show();
        }
    }
}
