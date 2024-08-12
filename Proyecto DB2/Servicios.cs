using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_DB2
{
    public partial class Servicios : Form
    {

        public Servicios()
        {
            InitializeComponent();
            cargarServicios(null);
        }


        public void ActualizarDataGridView()
        {
            cargarServicios(null);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cargarServicios(bool? activo)
        {
            CConexion conexion = new CConexion();
            SqlConnection con = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
               
                con = conexion.EstablecerConexion();

               
                if (con != null)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerServiciosPorEstado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (activo.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Activo", activo.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Activo", DBNull.Value);
                        }

                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }

                   
                    dataGridViewServicios.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar servicios: {ex.Message}");
            }
            finally
            {
                
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                if (da != null)
                {
                    da.Dispose();
                }
            }

        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngresarServicios form = new IngresarServicios(this);
            form.ShowDialog();
        }

        private void cmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOpcion.SelectedItem.ToString())
            {
                case "Todos":
                    cargarServicios(null);
                    break;
                case "Activos":
                    cargarServicios(true); 
                    break;
                case "Inactivos":
                    cargarServicios(false); 
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewServicios.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridViewServicios.SelectedRows[0];

                IngresarServicios formularioIngreso = new IngresarServicios(this)
                {
                    EsActualizacion = true, // Establecer el modo de actualización
                    ServicioID = filaSeleccionada.Cells["ServicioID"].Value.ToString(),
                    Nombre = filaSeleccionada.Cells["Nombre"].Value.ToString(),
                    Descripcion = filaSeleccionada.Cells["Descripcion"].Value.ToString(),
                    Precio = filaSeleccionada.Cells["Precio"].Value.ToString(),
                    TasaIVA = filaSeleccionada.Cells["TasaIVA"].Value.ToString(),
                    Duracion = filaSeleccionada.Cells["Duracion"].Value.ToString(),
                    Activo = filaSeleccionada.Cells["Activo"].Value.ToString() == "1" ? "Sí" : "No"
                };

                formularioIngreso.ShowDialog();
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewServicios.SelectedRows.Count > 0)
            {
                int servicioID = Convert.ToInt32(dataGridViewServicios.SelectedRows[0].Cells["ServicioID"].Value);

                // Crear instancia del formulario de artículos y pasar el ID del servicio
                ServicioDetalle Articulos = new ServicioDetalle(servicioID);
                Articulos.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un servicio.");
            }
        }
    }
}
