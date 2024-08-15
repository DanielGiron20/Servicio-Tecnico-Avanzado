using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class frmEmpleado : Form
    {
        SqlDataAdapter adpEmpleado;
        SqlDataAdapter adpPuesto;

        DataTable tabEmpleado;
        DataTable tabPuesto;


        public frmEmpleado()
        {
            InitializeComponent();
        }

        public frmEmpleado(SqlConnection conexion, int EmpleadoId )
        {
            InitializeComponent();

            adpPuesto = new SqlDataAdapter("SELECT PuestoID, Nombre FROM Puesto WHERE Activo =  1",conexion);
            
            adpEmpleado = new SqlDataAdapter();

            adpEmpleado.SelectCommand = new SqlCommand("spEmpleadoSelect", conexion);
            adpEmpleado.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpEmpleado.SelectCommand.Parameters.AddWithValue("@empleadoid", EmpleadoId);

            adpEmpleado.InsertCommand = comando("spEmpleadoInsert", conexion);
            adpEmpleado.UpdateCommand = comando("spEmpleadoUpdate", conexion);

        }

        private SqlCommand comando(String sql, SqlConnection con)
        {
            //Metodo para evitar escirbir el command type  y setear parametros
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100, "Direccion");
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20, "Telefono");
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50, "Email");
            cmd.Parameters.Add("@puestoid", SqlDbType.Int, 4, "PuestoID");
            cmd.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20, "DNI");
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1, "Sexo");
            return cmd;
        }



        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                txtEmpleadoID.Enabled = false;

                tabEmpleado = new DataTable();
                adpEmpleado.Fill(tabEmpleado);

                cmbSexo.Items.Add("Masculino");
                cmbSexo.Items.Add("Femenino");

                

                tabPuesto = new DataTable();
                adpPuesto.Fill(tabPuesto);
                
                cmbPuesto.DataSource = tabPuesto;
                cmbPuesto.DisplayMember = "Nombre";
                cmbPuesto.ValueMember = "PuestoID";

                cmbPuesto.SelectedIndex = -1;


                ToolTip infoToolTipEmail = new ToolTip();
                infoToolTipEmail.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                infoToolTipEmail.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                infoToolTipEmail.SetToolTip(txtEmail, "El e-mail es opcional.");

                if ( tabEmpleado.Rows.Count == 0 )
                {
                    tabEmpleado.Rows.Add();
                }
                else
                {
                    txtEmpleadoID.Text = tabEmpleado.Rows[0]["empleadoid"].ToString();
                    txtDNI.Text = tabEmpleado.Rows[0]["dni"].ToString();
                    txtNombre.Text = tabEmpleado.Rows[0]["nombre"].ToString();
                    txtDireccion.Text = tabEmpleado.Rows[0]["direccion"].ToString();
                    txtTelefono.Text = tabEmpleado.Rows[0]["telefono"].ToString();
                    cmbSexo.SelectedValue = tabEmpleado.Rows[0]["sexo"].ToString();
                    txtEmail.Text = tabEmpleado.Rows[0]["email"].ToString();
                    cmbPuesto.SelectedValue = tabEmpleado.Rows[0]["puestoid"].ToString();
                    chkActivo.Checked = (bool)tabEmpleado.Rows[0]["activo"];

                    string sexo = tabEmpleado.Rows[0]["sexo"].ToString();
                    if (sexo == "M")
                    {
                        cmbSexo.SelectedIndex = cmbSexo.Items.IndexOf("Masculino");
                    }
                    else if (sexo == "F")
                    {
                        cmbSexo.SelectedIndex = cmbSexo.Items.IndexOf("Femenino");
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

                if (txtDNI.Text.Length != 15)
                {
                    errorProvider1.SetError(txtDNI, "Falta la identidad del empleado o no es valida");
                    errores = true;
                }

                if (txtNombre.Text.Length == 0)
                {
                    errorProvider1.SetError(txtNombre, "Falta el nombre del empleado");
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

                if (txtDireccion.Text.Length == 0)
                {
                    errorProvider1.SetError(txtDireccion, "Falta la direccion del empleado");
                    errores = true;
                }

                if (txtTelefono.Text.Length != 9)
                {
                    errorProvider1.SetError(txtTelefono, "Falta el telefono del empleado o no es valido");
                    errores = true;
                }

                if (cmbSexo.SelectedIndex < 0 )
                {
                    errorProvider1.SetError(cmbSexo, "Falta el sexo del empleado");
                    errores = true;
                }

                if (txtEmail.Text.Length == 0)
                {
                    ToolTip infoToolTip = new ToolTip();
                    infoToolTip.ToolTipIcon = ToolTipIcon.Info; // Muestra un ícono informativo
                    infoToolTip.IsBalloon = true; // Opcional: Hace que el ToolTip sea de estilo globo
                    infoToolTip.SetToolTip(txtEmail, "El e-mail es opcional.");
                }

                if (cmbPuesto.SelectedIndex < 0)
                {
                    errorProvider1.SetError(cmbPuesto, "Falta el puesto del empleado");
                    errores = true;
                }

                if (chkActivo.Checked == false)
                {
                    errorProvider1.SetError(chkActivo, "Marque la casilla de activo");
                }

                if (!errores)
                {
                    if(MessageBox.Show("Desea guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        String[] sexos = { "M", "F" };

                        tabEmpleado.Rows[0]["dni"] = txtDNI.Text;
                        tabEmpleado.Rows[0]["nombre"] = txtNombre.Text;
                        tabEmpleado.Rows[0]["direccion"] = txtDireccion.Text;
                        tabEmpleado.Rows[0]["telefono"] = txtTelefono.Text;
                        tabEmpleado.Rows[0]["sexo"] = sexos[cmbSexo.SelectedIndex];
                        
                        if (txtEmail.Text != "")
                            tabEmpleado.Rows[0]["email"] = txtEmail.Text;
                        else
                            tabEmpleado.Rows[0]["email"] = DBNull.Value;

                        tabEmpleado.Rows[0]["puestoid"] = cmbPuesto.SelectedValue;
                        tabEmpleado.Rows[0]["activo"] = chkActivo.Checked;

                        adpEmpleado.Update(tabEmpleado);
                        Close();

                    }
                }

            }
            catch (SqlException ex)
            {

                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    if (ex.Errors[i].Number == 2627)
                    {
                        MessageBox.Show("Los numeros de telefonos o DNI deben ser unicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Errors[i].Message, ex.Errors[i].Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

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
            if (txtDNI.Text.Length != 15)
            {
                MessageBox.Show("El formato del DNI debe ser 0000-0000-00000.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cmdAgregarPuesto_Click(object sender, EventArgs e)
        {
            using (PuestoEmpleado frm = new PuestoEmpleado())
            {
                frm.ShowDialog();

                // Recargar los datos del ComboBox de Puestos
                tabPuesto.Clear(); // Limpia la tabla actual
                adpPuesto.Fill(tabPuesto); // Vuelve a llenar la tabla con datos actualizados

                // Actualiza el DataSource del ComboBox
                cmbPuesto.DataSource = null;
                cmbPuesto.DataSource = tabPuesto;
                cmbPuesto.DisplayMember = "Nombre";
                cmbPuesto.ValueMember = "PuestoID";
            }

        }
    }
}
