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
    public partial class frmNuevoProv : Form
        
    {

        private SqlConnection conexion;
        


        public frmNuevoProv()
        {
            InitializeComponent();
        }

        //segundo constructor
      
        public frmNuevoProv(SqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            
        }


        private void frmNuevoProv_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRtn.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Inserte todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            try
            {
                using (SqlCommand cmdInsertar = new SqlCommand("SpCrear", conexion))
                {
                    cmdInsertar.CommandType = CommandType.StoredProcedure;

              
                    cmdInsertar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmdInsertar.Parameters.AddWithValue("@rtn", txtRtn.Text);
                    cmdInsertar.Parameters.AddWithValue("@tipo", txtTipo.Text);
                    cmdInsertar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmdInsertar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmdInsertar.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdInsertar.Parameters.AddWithValue("@activo", chkEstado.Checked);

                    // Abrir la conexión si está cerrada
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    // Ejecutar el comando para insertar el nuevo registro
                    cmdInsertar.ExecuteNonQuery();

                    // se limpian dando la sensacion que se agregaron exitosamente 
                    txtNombre.Clear();
                    txtRtn.Clear();
                    txtTipo.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();
                    chkEstado.Checked = false;

       

                    MessageBox.Show("Proveedor creado exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión 
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
