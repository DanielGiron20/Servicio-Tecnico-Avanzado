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
using System.Net.Sockets;

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

            LlenarComboBoxTipoProveedor();
        }


        private void frmNuevoProv_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = -1;
            
        }

        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRtn.Text) ||
                cmbTipo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                txtTelefono.Text.Length != 9 || txtRtn.Text.Length != 16)
            {
                MessageBox.Show("Inserte todos los campos requeridos de manera correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            try
            {
                using (SqlCommand cmdInsertar = new SqlCommand("SpCrear", conexion))
                {
                    cmdInsertar.CommandType = CommandType.StoredProcedure;

              
                    cmdInsertar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmdInsertar.Parameters.AddWithValue("@rtn", txtRtn.Text);
                    cmdInsertar.Parameters.AddWithValue("@tipo", cmbTipo.SelectedValue);
                    cmdInsertar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmdInsertar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmdInsertar.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdInsertar.Parameters.AddWithValue("@activo", chkEstado.Checked);

                    //parametro para obtener el estado con respecto al correo 

                    SqlParameter EstadoCorreo = new SqlParameter
                    {
                        ParameterName = "@estadoObtenido",
                        SqlDbType = SqlDbType.Int, 
                        Direction = ParameterDirection.Output
                    };
                    cmdInsertar.Parameters.Add(EstadoCorreo);


                    // Abrir la conexión si está cerrada
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    // Ejecutar el comando para insertar el nuevo registro
                    cmdInsertar.ExecuteNonQuery();

                    int estado = (int)cmdInsertar.Parameters["@estadoObtenido"].Value;

                    if (estado == 0)
                    {

                        // se cierra el form dando la sensacion que se agregaron exitosamente 
                        MessageBox.Show("Proveedor creado exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Close();

                    }
                    else
                    {

                     MessageBox.Show("Correo ingresado no valido ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir sin guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               this.Close();
        }

        private DataTable ObtenerTiposDeProveedores()
        {
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add("Valor", typeof(string));  // Columna para almacenar el valor (L, E)
            dtTipos.Columns.Add("Nombre", typeof(string)); // Columna para mostrar el nombre largo (Proveedor Local, Proveedor Extranjero)

            // Agregar filas con el valor y el nombre
            dtTipos.Rows.Add("L", "Proveedor Local");
            dtTipos.Rows.Add("E", "Proveedor Extranjero");

            return dtTipos;
        }

        private void LlenarComboBoxTipoProveedor()
        {
            DataTable dtTipos = ObtenerTiposDeProveedores();

            cmbTipo.DataSource = dtTipos;            // Establece el DataSource del ComboBox
            cmbTipo.DisplayMember = "Nombre";        // Configura el miembro a mostrar (Nombre completo)
            cmbTipo.ValueMember = "Valor";           // Configura el valor a almacenar (L o E)
        }

        private void txtRtn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string rawText = new string(txtRtn.Text.Where(char.IsDigit).ToArray());

                if (rawText.Length > 0)
                {
                    if (rawText.Length <= 4)
                    {
                        txtRtn.Text = rawText;
                    }
                    else if (rawText.Length <= 8)
                    {
                        txtRtn.Text = rawText.Insert(4, "-");
                    }
                    else if (rawText.Length <= 14)
                    {
                        txtRtn.Text = rawText.Insert(4, "-").Insert(9, "-");
                    }
                    else
                    {
                        txtRtn.Text = rawText.Insert(4, "-").Insert(9, "-").Substring(0, 15);
                    }

                    // Coloca el cursor al final del texto
                    txtRtn.SelectionStart = txtRtn.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("El formato del RTN debe ser 0000-0000-000000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtRtn_Leave(object sender, EventArgs e)
        {
            if (txtRtn.Text.Length != 16)
            {
                MessageBox.Show("El formato del RTN debe ser 0000-0000-000000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string rawText = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());

                if (rawText.Length > 0)
                {
                    if (rawText.Length <= 4)
                    {
                        txtTelefono.Text = rawText;
                    }
                    else if (rawText.Length <= 8)
                    {
                        txtTelefono.Text = rawText.Insert(4, "-");
                    }
                    else
                    {
                        txtTelefono.Text = rawText.Insert(4, "-").Substring(0, 9);
                    }

                    // Coloca el cursor al final del texto
                    txtTelefono.SelectionStart = txtTelefono.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("El formato del teléfono debe ser 0000-0000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length != 9)
            {
                MessageBox.Show("El formato del Telefono debe ser 0000-0000", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
