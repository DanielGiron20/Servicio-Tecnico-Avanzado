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
    public partial class frmInsertarCompra : Form
    {
        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlConnection conexion;
        SqlDataAdapter adpCompraDetalle;
        public frmInsertarCompra()
        {
            InitializeComponent();
            conexion = new SqlConnection(url);

            
            
        }

        private void frmInsertarCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmdInsertarCompra = new SqlCommand("InsertarNuevaCompra", conexion))
                {
                    cmdInsertarCompra.CommandType = CommandType.StoredProcedure;
                    double tasaisv = 0.00;

                    switch (cbxTasaArticulo.SelectedItem.ToString())
                    {
                        case "15%":
                            tasaisv = 0.15;
                            break;
                        case "18%":
                            tasaisv = 0.18;
                            break;
                        default:
                            // Manejo del caso en que no se seleccione una tasa válida.
                            tasaisv = 0.00;
                            break;
                    }


                    cmdInsertarCompra.Parameters.AddWithValue("@ProveedorID", txtProveedorIDCompra.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Fecha",txtFechaCompra.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Documento", txtDocumentoArticulo.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Tipo", cbxTasaArticulo.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@NombreArticulo", txtNombreArticulo.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@BarraArticulo", txtBarraArticulo.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@PrecioArticulo", txtPrecioCompra.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@TasaISV", tasaisv);
                    cmdInsertarCompra.Parameters.AddWithValue("@Cantidad", txtCantidadCD.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Costo", txtCostoCD.Text);

                    conexion.Open();
                    cmdInsertarCompra.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Compra registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir sin guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
 }

