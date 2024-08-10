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

                ToolTip infoToolTipRTN = new ToolTip();
                infoToolTipRTN.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                infoToolTipRTN.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                infoToolTipRTN.SetToolTip(txtRTN, "El RTN es opcional.");

                ToolTip infoToolTipRazon = new ToolTip();
                infoToolTipRazon.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                infoToolTipRazon.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                infoToolTipRazon.SetToolTip(txtRazon, "La Razon es opcional.");


                ToolTip infoToolTipEmail = new ToolTip();
                infoToolTipEmail.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                infoToolTipEmail.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                infoToolTipEmail.SetToolTip(txtEmail, "El e-mail es opcional.");


                cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;

                if (tabCliente.Rows.Count == 0) 
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

                if( txtDNI.Enabled == true && txtDNI.Text.Length != 15)
                {
                    errorProvider1.SetError(txtDNI, "Falta la identidad del cliente o no es valida");
                    errores = true;
                }
               

                
                if (txtRTN.Text.Length != 0 && (txtRTN.Text.Length < 16 || txtRTN.Text.Length > 16))
                {
                    errorProvider1.SetError(txtRTN, "El RTN del cliente no es valido");
                    errores = true;
                }
                

                if (txtNombre.Text.Length == 0 ) 
                {
                    errorProvider1.SetError(txtNombre, "Falta el nombre del cliente");
                    errores = true;
                }
                else
                {
                    if (txtNombre.Text.Any(char.IsDigit))
                    {
                        errorProvider1.SetError(txtNombre, "El nombre no debe contener números");
                        errores = true;
                    }
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

                if (cmbSexo.SelectedIndex < 0  && cmbSexo.Enabled == true)
                {
                    errorProvider1.SetError(cmbSexo, "Falta el sexo del cliente");
                    errores = true;
                }

                if (cmbCivil.SelectedIndex < 0 && cmbCivil.Enabled == true)
                {
                    errorProvider1.SetError(cmbCivil, "Falta el estado civil del cliente");
                    errores = true;
                }

                if (txtRazon.Text.Length == 0)
                {
                    ToolTip infoToolTip = new ToolTip();
                    infoToolTip.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                    infoToolTip.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                    infoToolTip.SetToolTip(txtRazon, "La Razon es opcional.");
                }

                if (txtTelefono.Text.Length != 9)
                {
                    errorProvider1.SetError(txtTelefono, "Falta el telefono del cliente o no es valido");
                    errores = true;
                }

                if (txtEmail.Text.Length == 0)
                {
                    ToolTip infoToolTip = new ToolTip();
                    infoToolTip.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                    infoToolTip.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                    infoToolTip.SetToolTip(txtEmail, "El e-mail es opcional.");
                }


                if(!errores) 
                {
                    if (MessageBox.Show("Desea guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipo.SelectedItem.ToString() == "Empresa") 
            {
                txtDNI.Enabled = false;
                txtDNI.Text = "";
                cmbSexo.SelectedIndex = -1;
                cmbSexo.Enabled = false;

                cmbCivil.SelectedIndex = -1;
                cmbCivil.Enabled = false;

            }
            else if (cmbTipo.SelectedItem.ToString() == "Persona Natural")
            {
                txtDNI.Enabled = true;
                cmbSexo.Enabled = true;
                cmbCivil.Enabled = true;    
            }
        }

        
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string rawText = new string(txtDNI.Text.Where(char.IsDigit).ToArray());

                if (rawText.Length > 0)
                {
                    if (rawText.Length <= 4)
                    {
                        txtDNI.Text = rawText;
                    }
                    else if (rawText.Length <= 8)
                    {
                        txtDNI.Text = rawText.Insert(4, "-");
                    }
                    else if (rawText.Length <= 13)
                    {
                        txtDNI.Text = rawText.Insert(4, "-").Insert(9, "-");
                    }
                    else
                    {
                        txtDNI.Text = rawText.Insert(4, "-").Insert(9, "-").Substring(0, 14);
                    }

                    // Coloca el cursor al final del texto
                    txtDNI.SelectionStart = txtDNI.Text.Length;

                }
            }
            catch 
            {
                MessageBox.Show("El formato del DNI debe ser 0000-0000-00000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            // Opcional: verifica si el formato es correcto al salir del TextBox
            if (txtDNI.Text.Length != 15)
            {
                MessageBox.Show("El formato del DNI debe ser 0000-0000-00000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtRTN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string rawText = new string(txtRTN.Text.Where(char.IsDigit).ToArray());

                if (rawText.Length > 0)
                {
                    if (rawText.Length <= 4)
                    {
                        txtRTN.Text = rawText;
                    }
                    else if (rawText.Length <= 8)
                    {
                        txtRTN.Text = rawText.Insert(4, "-");
                    }
                    else if (rawText.Length <= 14)
                    {
                        txtRTN.Text = rawText.Insert(4, "-").Insert(9, "-");
                    }
                    else
                    {
                        txtRTN.Text = rawText.Insert(4, "-").Insert(9, "-").Substring(0, 15);
                    }

                    // Coloca el cursor al final del texto
                    txtRTN.SelectionStart = txtRTN.Text.Length;
                }
            }
            catch
            {
                MessageBox.Show("El formato del RTN debe ser 0000-0000-000000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtRTN_Leave(object sender, EventArgs e)
        {
            if (txtRTN.Text.Length != 16)
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
