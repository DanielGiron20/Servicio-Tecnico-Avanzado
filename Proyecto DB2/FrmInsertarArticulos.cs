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
    public partial class FrmInsertarArticulos : Form
    {

        private Inventario _inventario;
        public FrmInsertarArticulos(Inventario inventario)
        {
            InitializeComponent();
            _inventario = inventario;
            CargarProximoID();
        }

        public bool EsActualizacion { get; set; }

        public string ArticuloID
        {
            get { return txtArticuloID.Text; }
            set { txtArticuloID.Text = value; }
        }

        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }

        public string Barra
        {
            get { return txtBarra.Text; }
            set { txtBarra.Text = value; }
        }

        public string Precio
        {
            get { return txtPrecio.Text; }
            set { txtPrecio.Text = value; }
        }

        public string TasaIVA
        {
            get { return cmbTasa.SelectedItem.ToString(); }
            set { cmbTasa.SelectedItem = value; }
        }
        public string Existencia
        {
            get { return txtExistencia.Text; }
            set { txtExistencia.Text = value; }
        }

        public bool Activo
        {
            get { return chActivo.Checked; }
            set { chActivo.Checked = value; }
        }

        private void CargarProximoID()
        {
            try
            {

                CConexion conexion = new CConexion();
                SqlConnection con = conexion.EstablecerConexion();


                SqlCommand cmd = new SqlCommand("sp_ObtenerProximoID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tabla", "Articulo");
                cmd.Parameters.AddWithValue("@ColumnaID", "ArticuloID");


                SqlParameter parametroID = new SqlParameter("@ProximoID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parametroID);

                cmd.ExecuteNonQuery();

                int proximoID = (int)parametroID.Value;
                txtArticuloID.Text = proximoID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el próximo ID: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInsertarArticulos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Articulo;
            if (int.TryParse(txtArticuloID.Text, out Articulo))
            {
                
                string nombre = txtNombre.Text;
                string barra = txtBarra.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                float tasaIVA = float.Parse(cmbTasa.SelectedItem.ToString());
                int Existencia = int.Parse(txtExistencia.Text);
                bool activo = chActivo.Checked;



                CConexion conexion = new CConexion();
                SqlConnection con = conexion.EstablecerConexion();

                try
                {
                    SqlCommand cmd;

                    if (EsActualizacion)
                    {
                        cmd = new SqlCommand("sp_ModificarArticulo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@ArticuloID", Articulo);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Barra", barra);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaISV", tasaIVA);
                        cmd.Parameters.AddWithValue("@Existencia", Existencia);
                        cmd.Parameters.AddWithValue("@Activo", activo);

                    }
                    else
                    {
                        cmd = new SqlCommand("sp_InsertarArticulo", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Barra", barra);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaISV", tasaIVA);
                        cmd.Parameters.AddWithValue("@Existencia", Existencia);
                        cmd.Parameters.AddWithValue("@Activo", activo);
                    }

                    cmd.ExecuteNonQuery();
                    _inventario.cargarProductos(null);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el articulo: {ex.Message}");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                MessageBox.Show("Operación completada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("ID de Articulo inválido.");
            }
        }
    }
}
