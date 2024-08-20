using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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
            adpLeer = new SqlDataAdapter("spCargarProveedor", conexion);
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
            newProv.ShowDialog();

            conexion.Open();
            dtleer.Clear();
            adpLeer.Fill(dtleer);
            conexion.Close();

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            try 
            {
                cmbOpcion.Items.Add("Todos");
                cmbOpcion.Items.Add("Activos");
                cmbOpcion.Items.Add("Inactivos");
                txtTexto.Enabled = false;


                //cuando se abre el formProveedor
                dgcrudProv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgcrudProv.AllowUserToAddRows = false;
                dgcrudProv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgcrudProv.ReadOnly = true;

                //esto hace la funcion de mostrar solo los proveedores de estado activo
                //su funcion es cuando se eliminan , evitar que aparezcan en el dg.
                adpLeer.Fill(dtleer);
                //DataView verActivos = dtleer.DefaultView;
                //verActivos.RowFilter = "Activo = true";
                dgcrudProv.DataSource = dtleer;
                //dgcrudProv.DataSource = verActivos.ToTable();
                conexion.Close();
            }
            catch(Exception ex) 
            { 

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                //cmbTipo.SelectedValue = filaSeleccionada.Cells["Tipo"].Value.ToString();
                txtDireccion.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                txtEmail.Text = filaSeleccionada.Cells["Email"].Value.ToString();
                chkEstado.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);

                string tipoProveedor = filaSeleccionada.Cells["Tipo"].Value.ToString();

                // Establecer el valor seleccionado en el ComboBox
                LlenarComboBoxTipoProveedor(tipoProveedor);

                //prueba
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        { 


            //btn actualizar o modificar 
            // todos los campos deben ir llenos para no insertar datos no deseados 
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtRtn.Text) ||
                cmbTipo.SelectedIndex == -1 || 
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || txtTelefono.Text.Length != 9 || txtRtn.Text.Length != 16)

            {


                MessageBox.Show("Por favor, complete todos los campos requeridos de manera correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }

            try
            {

                int proveedorId = Convert.ToInt32(dgcrudProv.CurrentRow.Cells["Proveedorid"].Value);
                string tipoActual = cmbTipo.SelectedValue.ToString();

                // Llenar el ComboBox con el valor actual seleccionado
                LlenarComboBoxTipoProveedor(tipoActual);


                using (SqlCommand cmdActualizar = new SqlCommand("SpUpdate", conexion))
                {
                    cmdActualizar.CommandType = CommandType.StoredProcedure;


                    
                    // Añadir los parámetros necesarios para el procedimiento almacenado
                    cmdActualizar.Parameters.AddWithValue("@proveedorid", proveedorId);
                    cmdActualizar.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmdActualizar.Parameters.AddWithValue("@rtn", txtRtn.Text);
                    cmdActualizar.Parameters.AddWithValue("@tipo", tipoActual);
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

                    // Volver a cargar los datos en el DataGridView
                    CargarDatosProveedor(); // Método para recargar los datos

                    LimpiarCampos();
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

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtRtn.Clear();
            cmbTipo.SelectedIndex = -1;
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkEstado.Checked = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            //aqui unicamente lo elimina del dg mas no de la base de datos, teniendo como condicional 
            //si esta activo o no.
            // seleccionar proveedor para eliminar 
            if (dgcrudProv.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtTelefono_Leave(object sender, EventArgs e)
        {

            if (txtTelefono.Text.Length != 9)
            {
                MessageBox.Show("El formato del Telefono debe ser 0000-0000", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CargarDatosProveedor()
        {
            try
            {
                using (SqlCommand cmdCargar = new SqlCommand("spCargarProveedor", conexion)) // Asegúrate de usar el procedimiento almacenado correcto
                {
                    cmdCargar.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmdCargar);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgcrudProv.DataSource = dt; // Asigna los nuevos datos al DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void LlenarComboBoxTipoProveedor(string tipoSeleccionado = null)
        {
            DataTable dtTipos = ObtenerTiposDeProveedores();

            cmbTipo.DataSource = dtTipos;            // Establece el DataSource del ComboBox
            cmbTipo.DisplayMember = "Nombre";        // Configura el miembro a mostrar (Nombre completo)
            cmbTipo.ValueMember = "Valor";           // Configura el valor a almacenar (L o E)

            if (tipoSeleccionado != null)
            {
                cmbTipo.SelectedValue = tipoSeleccionado; // Establece el valor seleccionado después de llenar el ComboBox
            }
            else
            {
                cmbTipo.SelectedIndex = -1; // Si no se proporciona un valor, no selecciona nada
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

            if (txtTexto.Text.Length == 0)
            {
                dtleer.DefaultView.RowFilter = ""; // Sin filtro
            }
            else
            {
                if (dtleer.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    dtleer.DefaultView.RowFilter = cmbCampo.Text + " LIKE '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        dtleer.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        dtleer.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }
            }

            // Actualiza el DataGridView para reflejar los cambios en el filtro
            dgcrudProv.DataSource = dtleer.DefaultView.ToTable();
        }

        private void cmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string spNombre = "";

                switch (cmbOpcion.SelectedItem.ToString())
                {
                    case "Todos":

                        spNombre = "spRead";
                        break;

                    case "Activos":

                        spNombre = "spCargarProveedor";
                        break;

                    case "Inactivos":

                        spNombre = "spCargarProveedorInactivos";
                        break;
                }

                if (!string.IsNullOrEmpty(spNombre))
                {
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }
                    // Configura el SqlDataAdapter con el stored procedure seleccionado
                    adpLeer = new SqlDataAdapter(spNombre, conexion);
                    adpLeer.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Vuelve a llenar el DataTable y asigna los datos al DataGridView
                    dtleer.Clear();
                    adpLeer.Fill(dtleer);
                    dgcrudProv.DataSource = dtleer;

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCampo_Click(object sender, EventArgs e)
        {
            txtTexto.Enabled = true;
        }
    }
}
