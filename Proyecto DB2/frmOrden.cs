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
        }

        private void refrescardgvOrden()
        {

        }

        private void obtenerOrdenes()
        {
            CConexion con = new CConexion();
            SqlConnection c=null;

            try
            {
                
                c = con.EstablecerConexion();

                adpOrden = new SqlDataAdapter("spSelectOrden", c);
                adpOrden.SelectCommand.CommandType = CommandType.StoredProcedure;

                dtOrden = new DataTable();
                adpOrden.Fill(dtOrden);
                dgvOrden.DataSource = dtOrden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                if(c != null && c.State == ConnectionState.Open)
                {
                    c.Close();
                }
            }
        }

        private void frmOrden_Load(object sender, EventArgs e)
        {
            obtenerOrdenes();
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
            CConexion con = new CConexion();
            SqlConnection c = null;

            try
            {
                adpOrden = new SqlDataAdapter();
                dtOrden = new DataTable();

                c = con.EstablecerConexion();

                adpOrden.InsertCommand.Parameters["@clienteid"].Value = Convert.ToInt32(cmbClienteID.SelectedItem.ToString());
                adpOrden.InsertCommand.Parameters["@empleadoid"].Value = Convert.ToInt32(cmbEmpleadoID.SelectedItem.ToString());
                adpOrden.InsertCommand.Parameters["@tipoOrden"].Value = cmbTipoOrden.SelectedItem.ToString();
                adpOrden.InsertCommand.Parameters["@duracion"].Value = Convert.ToInt32(txtDuracion.Text);
                adpOrden.InsertCommand.Parameters["@estado"].Value = cmbEstado.SelectedItem.ToString();
                adpOrden.InsertCommand.Parameters["@fechaInicio"].Value = dtpFechaInicio.Value;
                adpOrden.InsertCommand.Parameters["@fechaFinal"].Value = dtpFechaFinal.Value;
                adpOrden.InsertCommand.Parameters["@activo"].Value = Convert.ToInt32(chkActivo.Checked);

                adpOrden.Update(dtOrden);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
