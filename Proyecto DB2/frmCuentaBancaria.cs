using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class frmCuentaBancaria : Form
    {
        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlConnection conexion;
        SqlDataAdapter adpvercuenta;
        
        DataTable dtcuenta;
      
    
        public frmCuentaBancaria()
        {
            InitializeComponent();
        }
        public frmCuentaBancaria(SqlConnection conexionC)
        {
            InitializeComponent();
            conexion = new SqlConnection(url);
            dtcuenta  = new DataTable();
            adpvercuenta = new SqlDataAdapter ("spvercuenta",conexionC);
            adpvercuenta.SelectCommand.CommandType = CommandType.StoredProcedure;



            adpvercuenta.InsertCommand = new SqlCommand("spinsertarcuenta", conexionC);
            adpvercuenta.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpvercuenta.InsertCommand.Parameters.Add("@nombreBanco", SqlDbType.VarChar, 50, "NombreBanco");
            adpvercuenta.InsertCommand.Parameters.Add("@Numerodecuenta", SqlDbType.VarChar, 50, "NumeroCuenta");
            adpvercuenta.InsertCommand.Parameters.Add("@tipocuenta", SqlDbType.VarChar, 50, "TipoCuenta");
            adpvercuenta.InsertCommand.Parameters.Add("@saldoactual", SqlDbType.VarChar, 50, "SaldoActual");
            adpvercuenta.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit, 0, "Activo");


            adpvercuenta.UpdateCommand = new SqlCommand("spModificarCuenta", conexionC);
            adpvercuenta.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpvercuenta.UpdateCommand.Parameters.Add("@cuentaid", SqlDbType.Int, 4, "CuentaID");
            adpvercuenta.UpdateCommand.Parameters.Add("@nombreBanco", SqlDbType.VarChar, 50, "NombreBanco");
            adpvercuenta.UpdateCommand.Parameters.Add("@Numerodecuenta", SqlDbType.VarChar, 50, "NumeroCuenta");
            adpvercuenta.UpdateCommand.Parameters.Add("@tipocuenta", SqlDbType.VarChar, 50, "TipoCuenta");
            adpvercuenta.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit, 0, "Activo");

         



        }

        private void frmCuentaBancaria_Load(object sender, EventArgs e)
        {

            adpvercuenta.Fill(dtcuenta);
            dgCuenta.DataSource = dtcuenta;
        }

        private void dgCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //aqui se obtiene la fila seleccionada y se muestra en los campos
                DataGridViewRow filaSeleccionada = dgCuenta.Rows[e.RowIndex];


                txtNombreCuenta.Text = filaSeleccionada.Cells["NombreBanco"].Value.ToString();
                txtNumeroDeCuenta.Text = filaSeleccionada.Cells["NumeroCuenta"].Value.ToString();
               
                
                string tipoCuenta = filaSeleccionada.Cells["TipoCuenta"].Value.ToString();
               /* bool activo = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                chkEstadoCuenta.Checked = activo;*/

                // Seleccionar el tipo de cuenta en el ComboBox si coincide con uno de los valores predefinidos
                switch (tipoCuenta)
                {
                    case "C":
                        cbxTipoCuenta.SelectedItem = "Corriente Empresarial";
                        break;
                    case "A":
                        cbxTipoCuenta.SelectedItem = "Ahorros Empresarial";
                        break;
                    case "N":
                        cbxTipoCuenta.SelectedItem = "Nominal Empresarial";
                        break;

                    default:
                        // Opcional: manejar el caso donde el tipo de cuenta no coincide
                        cbxTipoCuenta.SelectedIndex = -1; // Deselecciona si no hay coincidencia
                        break;

                }




            }
        }

        private void btnInsertarCuenta_Click(object sender, EventArgs e)
        {

            // Aqui se hace uso de lafuncion validar datos 
            if (!ValidarDatos())
            {
                MessageBox.Show("Por favor, complete los campos,Nombre Banco,Numero Cuenta y Tipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {

                adpvercuenta.Update(dtcuenta);
                MessageBox.Show("Cuenta Agregada","confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                adpvercuenta.Update(dtcuenta);
                MessageBox.Show("Cuenta modificada ", "confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivarCuenta_Click(object sender, EventArgs e)
        {

         
        }

        private void dgCuenta_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //ver la columna saldoactual
            if (dgCuenta.Columns[e.ColumnIndex].Name == "SaldoActual")
            {
                //para ver el valor del valor de saldoactual
                DataRowView VerSaldo = dgCuenta.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (VerSaldo != null)  {
              
                    
                 bool Esnulo = VerSaldo.Row.IsNull("SaldoActual");

               if (Esnulo){
                    
                        //si es nulo permite agregar valor A saldo
                        e.Cancel = false;
                    }
                    else{
                 
                        //si hay valor pues no se puede xd 
                        e.Cancel = true;
                        MessageBox.Show("No se permite modificar el saldo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }
              }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string spNombre = "";

                switch (cbxVer.SelectedItem.ToString())
                {
                    case "Todas":

                        spNombre = "spVerCuenta";
                        break;

                    case "Activas":

                        spNombre = "spCuentasActivas";
                        break;

                    case "Inactivas":

                        spNombre = "spCuentasInactivas";
                        break;
                }

                if (!string.IsNullOrEmpty(spNombre))
                {
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }
                    // Configura el SqlDataAdapter con el stored procedure seleccionado
                    adpvercuenta = new SqlDataAdapter(spNombre, conexion);
                    adpvercuenta.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Vuelve a llenar el DataTable y asigna los datos al DataGridView
                    dtcuenta.Clear();
                    adpvercuenta.Fill(dtcuenta);
                    dgCuenta.DataSource = dtcuenta;

                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //para ver si los campos tienen contenido o no 
        private bool ValidarDatos()
        {
            foreach (DataRow row in dtcuenta.Rows)
            {
                // Verificar si los campos requeridos están vacíos
                if (string.IsNullOrWhiteSpace(row["NombreBanco"].ToString()) || //o
                    string.IsNullOrWhiteSpace(row["NumeroCuenta"].ToString()) || //o
                    string.IsNullOrWhiteSpace(row["TipoCuenta"].ToString()) ||//o
                    string.IsNullOrWhiteSpace(row["SaldoActual"].ToString()))
                {
                    return false; // Hay un campo vacío
                }
            }
            return true; // Tcampos que se requieren estan completos para inseertar
        }


    }

}
