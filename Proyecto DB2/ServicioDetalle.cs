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
    public partial class ServicioDetalle : Form
    {
        private int servicioID;
        public ServicioDetalle(int servicioID)
        {
            InitializeComponent();
            this.servicioID = servicioID;
        }

        public void CargarArticulosPorServicio(int servicioID)
        {
            CConexion conn = new CConexion();
            SqlConnection con = conn.EstablecerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerArticulosPorServicio", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServicioID", servicioID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewArticulosServicio.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            
        }

        private void ServicioDetalle_Load(object sender, EventArgs e)
        {
            CargarArticulosPorServicio(servicioID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngresoArticulosxServicio IngresoArticulos = new IngresoArticulosxServicio(servicioID, this);
            IngresoArticulos.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridViewArticulosServicio.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridViewArticulosServicio.SelectedRows[0];

                IngresoArticulosxServicio formularioIngreso = new IngresoArticulosxServicio(servicioID, this)
                {
                    EsActualizacion = true, 
                    ServicioID = servicioID.ToString(),
                    ArriculoID1 = filaSeleccionada.Cells["ArticuloID"].Value.ToString(),
                    Cantidad1 = filaSeleccionada.Cells["Cantidad"].Value.ToString(),
                    Activo = (filaSeleccionada.Cells["Activo"].Value.ToString() == "True")

            };

                formularioIngreso.ShowDialog();
                CargarArticulosPorServicio(servicioID);
            
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.");
            
    }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow filaSeleccionada = dataGridViewArticulosServicio.SelectedRows[0];
                string articulo = filaSeleccionada.Cells["ArticuloID"].Value.ToString();
                int articuloIDE = int.Parse(articulo);
                CConexion con = new CConexion();
                SqlConnection connection = con.EstablecerConexion();
                SqlCommand cmd = new SqlCommand("EliminarServicioDetalle", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServicioID", servicioID);
                cmd.Parameters.AddWithValue("@ArticuloID", articuloIDE);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Articulo eliminado exitosamente");
                CargarArticulosPorServicio(servicioID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el detalle del servicio: " + ex.Message);
            }
        }
    }
}
