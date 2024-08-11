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
    public partial class frmProveedor : Form
    {

        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlDataAdapter adpLeer;
        DataTable dtleer;
        SqlConnection conexion;
        public frmProveedor()
        {
            InitializeComponent();
            conexion = new SqlConnection(url);
          
            conexion.Open(); 
            dtleer = new DataTable();
            adpLeer = new SqlDataAdapter("spRead", conexion);
            adpLeer.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            //insertar nuevo proveedor
            Form newProv = new frmNuevoProv(conexion);
            newProv.Show();
            
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            //cuando se abre el formProveedor


            //esto hace la funcion de mostrar solo los proveedores de estado activo
            //su funcion es cuando se eliminan , evitar que aparezcan en el dg.
            adpLeer.Fill(dtleer);
            DataView verActivos = dtleer.DefaultView;
            verActivos.RowFilter = "Activo = true";
            dgcrudProv.DataSource= dtleer;
            dgcrudProv.DataSource = verActivos.ToTable();
           conexion.Close();

    }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgcrudProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //al dar doble click se vayan los datos a los campoas
            

            if (e.RowIndex >= 0)
            {
                //aqui se obtiene la fila seleccionada y se muestra en los campos
                DataGridViewRow filaSeleccionada = dgcrudProv.Rows[e.RowIndex];

                
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtRtn.Text = filaSeleccionada.Cells["Rtn"].Value.ToString();
                txtTipo.Text = filaSeleccionada.Cells["Tipo"].Value.ToString();
                txtDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                txtEmail.Text = filaSeleccionada.Cells["Email"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //btn actualizar o modificar 
            // todos los campos deben ir llenos para no insertar datos no deseados 
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRtn.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int proveedorId = Convert.ToInt32(dgcrudProv.CurrentRow.Cells["Proveedorid"].Value);

                using (SqlCommand cmdActualizar = new SqlCommand("SpUpdate", conexion))
                {
                    cmdActualizar.CommandType = CommandType.StoredProcedure;



                    // Añadir los parámetros necesarios para el procedimiento almacenado
                    cmdActualizar.Parameters.AddWithValue("@proveedorid", proveedorId);
                    cmdActualizar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmdActualizar.Parameters.AddWithValue("@rtn", txtRtn.Text);
                    cmdActualizar.Parameters.AddWithValue("@tipo", txtTipo.Text);
                    cmdActualizar.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmdActualizar.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmdActualizar.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdActualizar.Parameters.AddWithValue("@activo", chkEstado.Checked);

                  
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }

                    //Ejecutar comando de registro.
                    cmdActualizar.ExecuteNonQuery();

                    
                    MessageBox.Show("Proveedor actualizado exitosamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //aqui unicamente lo elimina del dg mas no de la base de datos, teniendo como condicional 
            //si esta activo o no.
            // seleccionar proveedor para eliminar 
            if (dgcrudProv.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int id = Convert.ToInt32(dgcrudProv.CurrentRow.Cells["ProveedorID"].Value);


            SqlCommand cmd = new SqlCommand("SpDesactivar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@proveedorid", id);

            try
            {
               
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                // Eliminar la fila del dgcrudProv para que de impresion de eliminado 
                dgcrudProv.Rows.Remove(dgcrudProv.CurrentRow);

                MessageBox.Show("Proveedor eliminado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
