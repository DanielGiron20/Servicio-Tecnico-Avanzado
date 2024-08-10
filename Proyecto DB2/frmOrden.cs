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
        SqlDataAdapter adpOrden;
        DataTable dtOrden;
        

        public frmOrden()
        {
            InitializeComponent();

        }

        public frmOrden(SqlConnection cnx)
        {
            InitializeComponent();

            adpOrden = new SqlDataAdapter();
            dtOrden = new DataTable();

            adpOrden.SelectCommand = new SqlCommand("spSelectOrden", cnx);
            adpOrden.SelectCommand.CommandType = CommandType.StoredProcedure;


            adpOrden.InsertCommand = new SqlCommand("spInsertarOrden", cnx);
            adpOrden.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpOrden.InsertCommand.Parameters.Add("@ordenid", SqlDbType.Int, 4, "OrdenID");
            adpOrden.InsertCommand.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            adpOrden.InsertCommand.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            adpOrden.InsertCommand.Parameters.Add("@tipoOrden", SqlDbType.VarChar, 1, "TipoOrden");
            adpOrden.InsertCommand.Parameters.Add("@duracion", SqlDbType.Int, 4, "Duracion");
            adpOrden.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpOrden.InsertCommand.Parameters.Add("@fechaInicio", SqlDbType.DateTime, 8, "FechaInicio");
            adpOrden.InsertCommand.Parameters.Add("@fechaFinal", SqlDbType.DateTime, 8, "FechaFinal");
            adpOrden.InsertCommand.Parameters.Add("@activo", SqlDbType.Int, 1, "Activo");
            adpOrden.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;
        }

        private void refrescardgvOrden()
        {

        }

        private void obtenerOrdenes()
        {
            
        }

        private void frmOrden_Load(object sender, EventArgs e)
        {
            try
            {
                dtOrden = new DataTable();
                adpOrden.Fill(dtOrden);
                dgvOrden.DataSource = dtOrden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
