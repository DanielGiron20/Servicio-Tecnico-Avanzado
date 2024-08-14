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
    public partial class frmConsultaCompra : Form
    {

        SqlDataAdapter adpConsulta;
        SqlCommand cmdparametro;

        public frmConsultaCompra()
        {
            InitializeComponent();
        }

      

        private void txt_Click(object sender, EventArgs e)
        {

        }

        private void frmConsultaCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarConsulta_Click(object sender, EventArgs e)
        {
            try   {
         
                // obtiene el valor del nombre de filtro para usarlo en el switch
                string tipoFiltro = cbxConsulta.SelectedItem.ToString();

                // solo toma la informacion necesaria
                string TextoBusqueda = txtbxBuscar.Text.Trim();

                if (string.IsNullOrEmpty(TextoBusqueda)) {
               
                    MessageBox.Show("El campo de búsqueda no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el texto de búsqueda es válido según el tipo de filtro
                if ((tipoFiltro == "ProveedorID" || tipoFiltro == "CompraID") && TextoBusqueda.Any(char.IsLetter)) {
               
                    MessageBox.Show("no permitido texto para ProveedorID o CompraID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tipoFiltro == "NombreProveedor" && TextoBusqueda.All(char.IsDigit)) {
               
                    MessageBox.Show("No permitido ingresar  un numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
                using (SqlConnection conexionE = new SqlConnection(url)){
                
                    conexionE.Open();

                    using (SqlCommand cmdparametro = new SqlCommand()){
                    
                        cmdparametro.Connection = conexionE;
                        cmdparametro.CommandType = CommandType.Text;

                   switch (tipoFiltro){
                        
                            case "CompraID":
                                cmdparametro.CommandText = "SELECT * FROM dbo.FConsultaCompraid(@CompraID)";
                                cmdparametro.Parameters.AddWithValue("@CompraID", TextoBusqueda);
                                break;

                            case "ProveedorID":
                                cmdparametro.CommandText = "SELECT * FROM dbo.FConsultaProvId(@ProveedorID)";
                                cmdparametro.Parameters.AddWithValue("@ProveedorID", TextoBusqueda);
                                break;

                            case "NombreProveedor":
                                cmdparametro.CommandText = "SELECT * FROM dbo.FConsultaNombre(@nombre)";
                                cmdparametro.Parameters.AddWithValue("@nombre", TextoBusqueda);
                                break;

                            default:
                                MessageBox.Show("Seleccione un parámetro de búsqueda válido.");
                                return;
                            }

                        //lee los resultados obtenidos
                        using (SqlDataReader reader = cmdparametro.ExecuteReader())
                        {
                         if (reader.Read()){
                            
                                //muestra los valores en los textbox
                                txtbxCompraid.Text = reader["compraid"].ToString();
                                txtbxProveedorid.Text = reader["proveedorid"].ToString();
                                txtbxFecha.Text = reader["fecha"].ToString();
                                txtbxNombre.Text = reader["nombre"].ToString();
                                txtbxDireccion.Text = reader["direccion"].ToString();
                                txtbxRtn.Text = reader["rtn"].ToString();
                                txtbxTelefono.Text = reader["telefono"].ToString();
                                txtbxEmail.Text = reader["email"].ToString();
                            }
                            else{
                            
                                // se limpia los TextBox si no datos 
                                txtbxCompraid.Text = "";
                                txtbxProveedorid.Text = "";
                                txtbxFecha.Text = "";
                                txtbxNombre.Text = "";
                                txtbxDireccion.Text = "";
                                txtbxRtn.Text = "";
                                txtbxTelefono.Text = "";
                                txtbxEmail.Text = "";
                                MessageBox.Show("No se encontraron resultados.");
                            }
                        }
                         }
                     }
            }
            catch (Exception ex)
            {
                //no permite buscar si no se ha seleccionado una opcion de busqueda
                MessageBox.Show("Debe seleccionar un tipo de búsqueda. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}

