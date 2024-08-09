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
    public partial class frmCliente : Form
    {
        SqlDataAdapter adpCliente;
        DataTable tabCliente;

        /*public DataTable tCliente
        {
            get { return tabCliente; }
        }*/

        public frmCliente()
        {
            InitializeComponent();
        }
        public frmCliente(SqlConnection conexion, int ClienteId)
        {
            InitializeComponent();

            adpCliente = new SqlDataAdapter();

            adpCliente.SelectCommand = new SqlCommand("spClienteSelect", conexion);
            adpCliente.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCliente.SelectCommand.Parameters.AddWithValue("@clienteid", ClienteId);

            adpCliente.InsertCommand = comando("spClienteInsert", conexion);
            adpCliente.UpdateCommand = comando("spClienteUpdate", conexion);

        }

        private SqlCommand comando(String sql, SqlConnection con)
        {
            //Metodo para evitar escirbir el command type  y setear parametros
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20, "DNI");
            cmd.Parameters.Add("@rtn", SqlDbType.VarChar, 20, "RTN");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100, "Direccion");
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1, "Sexo");
            cmd.Parameters.Add("@civil", SqlDbType.VarChar, 1, "Civil");
            cmd.Parameters.Add("@razon", SqlDbType.VarChar, 50, "Razon");
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20, "Telefono");
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50, "Email");
            cmd.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");


            return cmd;
        }



        private void frmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                txtClienteID.Enabled = false;

                tabCliente = new DataTable();
                adpCliente.Fill(tabCliente);


                cmbSexo.Items.Add("Masculino");
                cmbSexo.Items.Add("Femenino");

                cmbCivil.Items.Add("Soltero");
                cmbCivil.Items.Add("Casado");
                cmbCivil.Items.Add("Union Libre");

                cmbTipo.Items.Add("Persona Natural");
                cmbTipo.Items.Add("Empresa");


                if(tabCliente.Rows.Count == 0) 
                {
                    tabCliente.Rows.Add();
                }
                else
                {
                    txtClienteID.Text = tabCliente.Rows[0]["clienteid"].ToString();
                    txtDNI.Text = tabCliente.Rows[0]["dni"].ToString();
                    txtRTN.Text = tabCliente.Rows[0]["rtn"].ToString();
                    txtNombre.Text = tabCliente.Rows[0]["nombre"].ToString();
                    //cmbTipo.SelectedValue = tabCliente.Rows[0]["tipo"].ToString();
                    txtDireccion.Text = tabCliente.Rows[0]["direccion"].ToString();
                    //cmbSexo.SelectedItem = tabCliente.Rows[0]["sexo"].ToString();
                    //cmbCivil.SelectedItem = tabCliente.Rows[0]["civil"].ToString();
                    txtRazon.Text = tabCliente.Rows[0]["razon"].ToString();
                    txtTelefono.Text = tabCliente.Rows[0]["telefono"].ToString();
                    txtEmail.Text = tabCliente.Rows[0]["email"].ToString();
                    chkActivo.Checked = (bool)tabCliente.Rows[0]["activo"];

                   
                    // Configurar el ComboBox para Tipo
                    string tipo = tabCliente.Rows[0]["tipo"].ToString();
                    if (tipo == "P")
                    {
                        cmbTipo.SelectedIndex = cmbTipo.Items.IndexOf("Persona Natural");
                        cmbSexo.Enabled = true;
                        cmbCivil.Enabled = true;
                    }
                    else if (tipo == "E")
                    {
                        cmbTipo.SelectedIndex = cmbTipo.Items.IndexOf("Empresa");
                        cmbSexo.Enabled = false;
                        cmbSexo.SelectedIndex = -1;
                        cmbCivil.Enabled = false;
                        cmbCivil.SelectedIndex = -1;
                    }

                    // Configurar el ComboBox para Sexo
                    string sexo = tabCliente.Rows[0]["sexo"].ToString();
                    if (sexo == "M")
                    {
                        cmbSexo.SelectedIndex = cmbSexo.Items.IndexOf("Masculino");
                    }
                    else if (sexo == "F")
                    {
                        cmbSexo.SelectedIndex = cmbSexo.Items.IndexOf("Femenino");
                    }

                    // Configurar el ComboBox para Civil
                    string civil = tabCliente.Rows[0]["civil"].ToString();
                    if (civil == "S")
                    {
                        cmbCivil.SelectedIndex = cmbCivil.Items.IndexOf("Soltero");
                    }
                    else if (civil == "C")
                    {
                        cmbCivil.SelectedIndex = cmbCivil.Items.IndexOf("Casado");
                    }
                    else if (civil == "U")
                    {
                        cmbCivil.SelectedIndex = cmbCivil.Items.IndexOf("Union Libre");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                bool errores = false;
                errorProvider1.Clear();

                if(txtDNI.Text.Length == 0)
                {
                    errorProvider1.SetError(txtDNI, "Falta la identidad del cliente");
                    errores = true;
                }

                if (txtRTN.Text.Length == 0)
                {
                    errorProvider1.SetError(txtRTN, "Falta el RTN del cliente");
                }

                if (txtNombre.Text.Length == 0) 
                {
                    errorProvider1.SetError(txtNombre, "Falta el nombre del cliente");
                    errores = true;
                }

                if (cmbTipo.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbTipo, "Falta el tipo del cliente");
                    errores = true;
                }

                if (txtDireccion.Text.Length == 0)
                {
                    errorProvider1.SetError(txtDireccion, "Falta la direccion del cliente");
                    errores = true;
                }

                if (cmbSexo.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbSexo, "Falta el sexo del cliente");
                }

                if (cmbCivil.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbCivil, "Falta el estado civil del cliente");
                }

                if (txtRazon.Text.Length == 0)
                {
                    errorProvider1.SetError(txtRazon, "Falta la razon del cliente");
                }

                if (txtTelefono.Text.Length == 0)
                {
                    errorProvider1.SetError(txtTelefono, "Falta el telefono del cliente");
                    errores = true;
                }

                if (txtEmail.Text.Length == 0)
                {
                    errorProvider1.SetError(txtEmail, "Falta el correo electronico del cliente");
                    
                }


                if(!errores) 
                {
                    String[] sexos = { "M", "F" };
                    String[] tipos = { "P", "E" };
                    String[] estadosciviles = { "S", "C", "U" };


                    tabCliente.Rows[0]["dni"] = txtDNI.Text;
                    tabCliente.Rows[0]["rtn"] = txtRTN.Text;
                    tabCliente.Rows[0]["nombre"] = txtNombre.Text;
                    tabCliente.Rows[0]["tipo"] = tipos[cmbTipo.SelectedIndex];
                    tabCliente.Rows[0]["direccion"] = txtDireccion.Text;
                    tabCliente.Rows[0]["sexo"] = sexos[cmbSexo.SelectedIndex];
                    tabCliente.Rows[0]["civil"] = estadosciviles[cmbCivil.SelectedIndex];
                    tabCliente.Rows[0]["razon"] = txtRazon.Text;
                    tabCliente.Rows[0]["telefono"] = txtTelefono.Text;
                    tabCliente.Rows[0]["email"] = txtEmail.Text;
                    tabCliente.Rows[0]["activo"] = chkActivo.Checked;

                    

                    adpCliente.Update(tabCliente);
                    Close();
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
