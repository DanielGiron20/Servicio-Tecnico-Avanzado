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
        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlConnection conexionD;

        public Compras()
        {
            InitializeComponent();
            
        }

        public Compras(SqlConnection conexion)
        {
          
            
            InitializeComponent();
            conexionD = new SqlConnection(url);
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

        private void btrnInsertarCompra_Click(object sender, EventArgs e)
        {
            Form frmInsertarCompra = new frmInsertarCompra();
            frmInsertarCompra.Show();
        }

        private void btnIsertarExistente_Click(object sender, EventArgs e)
        {
            Form frmCompraExistente = new frmCompraExistente();
            frmCompraExistente.Show();
        }

        private void btnModificarCompra_Click(object sender, EventArgs e)
        {
            Form frmeditarcompra = new frmeditarcompra();
            frmeditarcompra.Show();
        }

        private void btnDesactivarCompra_Click(object sender, EventArgs e)
        {
            if (dgCompra.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int id = Convert.ToInt32(dgCompra.CurrentRow.Cells["CompraID"].Value);


            SqlCommand cmd = new SqlCommand("spDesactivarCompra", conexionD);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@compraid", id);

            try
            {

                conexionD.Open();
                cmd.ExecuteNonQuery();
                conexionD.Close();
                // Eliminar la fila del dgcrudProv para que de impresion de eliminado 
                dgCompra.Rows.Remove(dgCompra.CurrentRow);

                MessageBox.Show("Compra eliminada exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
