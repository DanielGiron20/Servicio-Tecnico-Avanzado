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
    public partial class IngresoArticulosxServicio : Form
    {
       
        private int servicioID;
        private ServicioDetalle _serviciodetalle;
        public IngresoArticulosxServicio(int servicioID, ServicioDetalle serviciodetalle)
        {
            InitializeComponent();
            this.servicioID = servicioID;
            AServicioID.Text = servicioID.ToString();
            _serviciodetalle = serviciodetalle;
        }


        public bool EsActualizacion { get; set; }

        public string ServicioID
        {
            get { return AServicioID.Text; }
            set { AServicioID.Text = value; }
        }
        public string ArriculoID1
        {
            get { return ArticuloID.Text; }
            set { ArticuloID.Text = value; }
        }
        public string Cantidad1
        {
            get { return Cantidad.Text; }
            set { Cantidad.Text = value; }
        }
        public bool Activo1
        {
            get { return Activo.Checked;  }
            set { Activo.Checked = value; }
        }


        private void IngresoArticulosxServicio_Load(object sender, EventArgs e)
        {

        }

        private void InsertarServicioDetalle(int servicioID, int articuloID, int cantidad, bool activo)
        {
            try
            {
                CConexion con = new CConexion();
                SqlConnection connection = con.EstablecerConexion();
                SqlCommand cmd = new SqlCommand("InsertarServicioDetalle", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServicioID", servicioID);
                cmd.Parameters.AddWithValue("@ArticuloID", articuloID);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Activo", activo);

               
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el detalle del servicio: " + ex.Message);
            }
        }

        private void ModificarServicioDetalle(int servicioID, int articuloID, int cantidad, bool activo)
        {
            try
            {
                CConexion con = new CConexion();
                SqlConnection connection = con.EstablecerConexion();
                SqlCommand cmd = new SqlCommand("ModificarServicioDetalle", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServicioID", servicioID);
                cmd.Parameters.AddWithValue("@ArticuloID", articuloID);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Activo", activo);


                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el detalle del servicio: " + ex.Message);
            }
        }





        private void button3_Click(object sender, EventArgs e)
        {
            using (SeleccionArticulos formArticulos = new SeleccionArticulos())
            {
                if (formArticulos.ShowDialog() == DialogResult.OK)
                {
                    int selectedArticuloID = formArticulos.SelectedArticuloID;
                    ArticuloID.Text = selectedArticuloID.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int servicioID = int.Parse(AServicioID.Text);
            int articuloID = int.Parse(ArticuloID.Text);
            int cantidad = int.Parse(Cantidad.Text);
            bool activo = Activo.Checked;

            CConexion conexion = new CConexion();
                SqlConnection con = conexion.EstablecerConexion();

                if (EsActualizacion)
                {
                    try
                    {
                        ModificarServicioDetalle(servicioID, articuloID, cantidad, activo);
                        MessageBox.Show("Detalle del servicio modificado exitosamente.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al modificar el detalle del servicio: " + ex.Message);
                    }


                }
                else
                {


                    try
                    {
                        InsertarServicioDetalle(servicioID, articuloID, cantidad, activo);
                        MessageBox.Show("Detalle del servicio insertado exitosamente.");
                    _serviciodetalle.CargarArticulosPorServicio(servicioID);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el detalle del servicio: " + ex.Message);
                    }
                }
        }
    }
}
