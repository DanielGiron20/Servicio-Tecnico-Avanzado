using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class frmeditarcompra : Form
    {
        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlConnection conexion;
        SqlDataAdapter adpmodificar;
        SqlDataAdapter adpver;
        DataTable dtmodificar;
        
        public frmeditarcompra()
        {
            InitializeComponent();
            dtmodificar = new DataTable();
            conexion = new SqlConnection(url);
            
            adpver = new SqlDataAdapter("spModificarCompra",conexion);
            adpver.SelectCommand.CommandType = CommandType.StoredProcedure;


            adpmodificar = new SqlDataAdapter("spModificarCompraDetalle", conexion);
            adpmodificar.UpdateCommand = new SqlCommand("spModificarCompraDetalle", conexion);
            adpmodificar.UpdateCommand.CommandType = CommandType.StoredProcedure;

            adpmodificar.UpdateCommand.Parameters.Add("@compraid", SqlDbType.Int, 4, "CompraID");
            adpmodificar.UpdateCommand.Parameters.Add("@articuloid", SqlDbType.Int, 4, "ArticuloID");
            adpmodificar.UpdateCommand.Parameters.Add("@Proveedorid", SqlDbType.Int, 4, "ProveedorID");
            adpmodificar.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.DateTime, 8, "Fecha");
            adpmodificar.UpdateCommand.Parameters.Add("@Documento", SqlDbType.VarChar, 50, "Documento");
            adpmodificar.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 1, "Tipo");
            adpmodificar.UpdateCommand.Parameters.Add("@Estado", SqlDbType.VarChar, 1, "Estado");
            adpmodificar.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Int, 4, "Cantidad");
            adpmodificar.UpdateCommand.Parameters.Add("@Costo", SqlDbType.Float, 4, "Costo");


        }

        private void frmeditarcompra_Load(object sender, EventArgs e)
        {

            adpver.Fill(dtmodificar);
            dgModificarCompra.DataSource = dtmodificar;

        }

        private void btnGuardarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                adpmodificar.Update(dtmodificar);
                MessageBox.Show("Compra modificada con exito", "confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir sin guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
