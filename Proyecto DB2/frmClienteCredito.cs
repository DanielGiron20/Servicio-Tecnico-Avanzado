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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_DB2
{
    public partial class frmClienteCredito : Form
    {
        SqlConnection con;

        SqlDataAdapter adpCredito;
        SqlDataAdapter adpTotal;

        DataTable tabTotal;
        DataTable tabCredito;

        public frmClienteCredito()
        {
            InitializeComponent();
        }

        private void limpiarCredito()
        {
            txtClienteID.Clear();
            txtFacturaID.Clear();
            txtFechaFactura.Clear();
            txtTotalFactura.Clear();
            txtLimiteCredito.Clear();
            txtLimiteDisponible.Clear();
            txtTermino.Clear();
            //dtpFecha.Value = DateTime.MinValue='1/1/0001';
            txtPago.Clear();
            chkCerrada.Checked = false;
        }

        public frmClienteCredito(SqlConnection conexion)
        {
            InitializeComponent();
            try
            {

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                con = conexion;

                adpCredito = new SqlDataAdapter();
                adpTotal = new SqlDataAdapter();
                tabCredito = new DataTable();
                tabTotal = new DataTable();


                adpCredito.SelectCommand = new SqlCommand("spClienteCreditoSelect", conexion);
                adpCredito.SelectCommand.CommandType = CommandType.StoredProcedure;


                adpCredito.InsertCommand = comando("spClienteCreditoInsert", conexion);
                adpCredito.UpdateCommand = comando("spClienteCreditoUpdate", conexion);

                adpTotal.SelectCommand = new SqlCommand("CalcularTotalFacturas", conexion);
                adpTotal.SelectCommand.CommandType = CommandType.StoredProcedure;

                adpCredito.Fill(tabCredito);
                dataGridView1.DataSource = tabCredito;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private SqlCommand comando(String sql, SqlConnection con)
        {
            //Metodo para evitar escirbir el command type  y setear parametros
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            cmd.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
            cmd.Parameters.Add("@terminopago", SqlDbType.Int, 4, "TerminoPago");
            cmd.Parameters.Add("@limitecredito", SqlDbType.Float, 8, "LimiteCredito");
            cmd.Parameters.Add("@pago", SqlDbType.Float, 8, "Pago");
            cmd.Parameters.Add("@fechavencimiento", SqlDbType.DateTime, 8, "FechaVencimiento");
            cmd.Parameters.Add("@cerrada", SqlDbType.Bit, 1, "Cerrada");
            cmd.Parameters.Add("@limitedisponible", SqlDbType.Float, 8, "LimiteDisponible");
            return cmd;
        }

        private void frmClienteCredito_Load(object sender, EventArgs e)
        {
            limpiarCredito();
            dtpFecha.Enabled = false;
            txtLimiteDisponible.Enabled = false;
            chkCerrada.Enabled = false;
            cmdCambiar.Enabled = false; 



            if ( txtClienteID.Text.Length == 0)
                cmdCalcularTotal.Enabled = false;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir sin guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }

        private void cmdVerID_Click(object sender, EventArgs e)
        {
            try
            {

                using (frmClienteFacturaID frm = new frmClienteFacturaID(con))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string[] valores = (string[])frm.Tag;
                        txtClienteID.Text = valores[0]; // Primer columna en TextBox1
                        txtFacturaID.Text = valores[1]; // Segunda columna en TextBox2
                        txtFechaFactura.Text = valores[2]; // Tercer columna en TextBox3
                        cmdCalcularTotal.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdCalcularTotal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtClienteID.Text))
                {
                    // Pasar el valor del ClienteID al parámetro del Stored Procedure
                    adpTotal.SelectCommand.Parameters.Clear();
                    adpTotal.SelectCommand.Parameters.AddWithValue("@clienteid", txtClienteID.Text);
                    adpTotal.SelectCommand.Parameters.AddWithValue("@facturaid", txtFacturaID.Text);
                    // Llenar el DataTable tabTotal con el resultado del Stored Procedure
                    tabTotal = new DataTable();
                    adpTotal.Fill(tabTotal);

                    // Asignar el valor de la segunda columna del primer registro al TextBox txtTotalFactura
                    if (tabTotal.Rows.Count > 0)
                    {
                        txtTotalFactura.Text = tabTotal.Rows[0][1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros para el ClienteID especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTotalFactura.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un ClienteID.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdInsertar_Click(object sender, EventArgs e)
        {
            bool errores = false;

            errorProvider1.Clear();

            if (txtClienteID.Text.Length == 0)
            {
                errorProvider1.SetError(txtClienteID, "Falta el ID del cliente.");
                errores = true;
            }

            if (txtFacturaID.Text.Length == 0)
            {
                errorProvider1.SetError(txtFacturaID, "Falta el ID de la factura.");
                errores = true;
            }

            ////
            if (!float.TryParse(txtLimiteCredito.Text, out float limiteCredito))
            {
                errorProvider1.SetError(txtLimiteCredito, "El límite de crédito debe ser un valor numérico válido");
                errores = true;
            }
            else if (txtLimiteCredito.Text.Length == 0)
            {
                errorProvider1.SetError(txtLimiteCredito, "Falta establecer el límite de crédito");
                errores = true;
            }
            else if (limiteCredito <= float.Parse(txtTotalFactura.Text))
            {
                errorProvider1.SetError(txtLimiteCredito, "El límite de crédito no puede ser menor o igual al total de la factura");
                errores = true;
            }
            else if (limiteCredito < float.Parse(txtLimiteDisponible.Text))
            {
                errorProvider1.SetError(txtLimiteCredito, "El límite de crédito no puede ser menor que el límite disponible");
                errores = true;
            }

            //////
            if (!float.TryParse(txtLimiteDisponible.Text, out float limiteDisponible))
            {
                errorProvider1.SetError(txtLimiteDisponible, "El límite disponible debe ser un valor numérico válido");
                errores = true;
            }
            else if (txtLimiteDisponible.Text.Length == 0)
            {
                errorProvider1.SetError(txtLimiteDisponible, "Falta establecer el límite disponible");
                errores = true;
            }
            else if (float.Parse(txtLimiteCredito.Text) < float.Parse(txtTotalFactura.Text))
            {
                errorProvider1.SetError(txtLimiteCredito, "El límite de crédito no puede ser menor que el total de la factura");
                errores = true;
            }
            else if (limiteDisponible > float.Parse(txtLimiteCredito.Text))
            {
                errorProvider1.SetError(txtLimiteDisponible, "El límite disponible no puede ser mayor que el límite de crédito");
                errores = true;
            }

            /////
            if (!int.TryParse(txtTermino.Text, out int termino) || termino < 0)
            {
                errorProvider1.SetError(txtTermino, "El término de pago debe ser un número entero no negativo");
                errores = true;
            }
            else if (txtTermino.Text.Length == 0)
            {
                errorProvider1.SetError(txtTermino, "Falta establecer el término de pago");
                errores = true;
            }


            //////

            if (dtpFecha.Value == DateTime.MinValue)
            {
                errorProvider1.SetError(dtpFecha, "Falta establecer la fecha de vencimiento");
                errores = true;
            }

            /////
            if (!DateTime.TryParse(txtFechaFactura.Text, out DateTime fechaFactura))
            {
                errorProvider1.SetError(txtFechaFactura, "Fecha de factura no válida");
                errores = true;
            }
            else if (dtpFecha.Value < fechaFactura)
            {
                // Compara las fechas
                errorProvider1.SetError(dtpFecha, "La fecha de vencimiento no puede ser anterior a la fecha de la factura");
                errores = true;
            }


            /////
            if (string.IsNullOrWhiteSpace(txtPago.Text))
            {
                errorProvider1.SetError(txtPago, "Falta establecer el monto a pagar");
               
            }
            else if (!decimal.TryParse(txtPago.Text, out decimal montoPago) || montoPago < 0)
            {
                // Verifica si el texto es un número válido y si es negativo
                errorProvider1.SetError(txtPago, "El monto a pagar debe ser un número válido y no puede ser negativo");
                errores = true;
            }


            if (errores)
            {
                return;
            }

            DataRow nuevaFila = tabCredito.NewRow();

            nuevaFila["ClienteID"] = txtClienteID.Text;
            nuevaFila["FacturaID"] = txtFacturaID.Text;
            nuevaFila["TerminoPago"] = txtTermino.Text;
            nuevaFila["LimiteCredito"] = txtLimiteCredito.Text;
            nuevaFila["Pago"] = txtTermino.Text;
            nuevaFila["FechaVencimiento"] = dtpFecha.Value;
            nuevaFila["Cerrada"] = chkCerrada.Checked;
            nuevaFila["LimiteDisponible"] = txtLimiteDisponible.Text;

            tabCredito.Rows.Add(nuevaFila);

            try
            {
                adpCredito.Update(tabCredito);
                tabCredito.Clear();

                adpCredito.Fill(tabCredito);
                dataGridView1.Refresh();
                MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCredito();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    if (ex.Errors[i].Number == 2627)
                    {
                        MessageBox.Show("Replicacion de filas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Errors[i].Message, ex.Errors[i].Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tabCredito.PrimaryKey = new DataColumn[] { tabCredito.Columns["ClienteID"] };

                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                DataRow filaDatos = tabCredito.Rows.Find(filaSeleccionada.Cells["ClienteID"].Value);

                if (filaDatos != null)
                {
                    filaDatos["ClienteID"] = txtClienteID.Text;
                    filaDatos["FacturaID"] = txtFacturaID.Text;
                    filaDatos["LimiteCredito"] = txtLimiteCredito.Text;
                    filaDatos["LimiteDisponible"] = txtLimiteDisponible.Text;
                    filaDatos["TerminoPago"] = txtTermino.Text;
                    filaDatos["Pago"] = txtPago.Text;
                    filaDatos["FechaVencimiento"] = dtpFecha.Value;

                    try
                    {
                        adpCredito.Update(tabCredito);
                        tabCredito.Clear();
                        adpCredito.Fill(tabCredito);
                        dataGridView1.Refresh();
                        MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        limpiarCredito();
                        cmdInsertar.Enabled = true;
                        cmdModificar.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para actualizar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdCalcular_Click(object sender, EventArgs e)
        {
            bool errores = false; 
            errorProvider1.Clear();

            // Validación y cálculo de LimiteDisponible
            if (float.TryParse(txtLimiteCredito.Text, out float limiteCredito) &&
                float.TryParse(txtTotalFactura.Text, out float totalFactura) &&
                float.TryParse(txtPago.Text, out float pago))
            {
                float limiteDisponible = limiteCredito - totalFactura + pago;
                txtLimiteDisponible.Text = limiteDisponible.ToString("N2");
            }
            else
            {
                errores = true;
                errorProvider1.SetError(txtLimiteCredito, "Por favor, asegúrese de que todos los valores numéricos sean correctos.");
            }

            // Validación y cálculo de FechaVencimiento
            if (int.TryParse(txtTermino.Text, out int terminoPago) &&
                DateTime.TryParse(txtFechaFactura.Text, out DateTime fechaFactura))
            {
                DateTime fechaVencimiento = fechaFactura.AddDays(terminoPago);
                dtpFecha.Value = fechaVencimiento;
            }
            else
            {
                errores = true;
                errorProvider1.SetError(txtTermino, "Por favor, asegúrese de que la fecha y el término de pago sean correctos.");
            }

            // Validar si el monto a pagar es igual al monto de la factura
            if (float.TryParse(txtPago.Text, out float pagoMonto) &&
                float.TryParse(txtTotalFactura.Text, out float totalFacturaMonto))
            {
                if (pagoMonto == totalFacturaMonto)
                {
                    cmdCambiar.Enabled = true;
                }
                else
                {
                    cmdCambiar.Enabled = false;
                }
            }
            else
            {
                cmdCambiar.Enabled = false;
            }

            // Mostrar mensaje de error si hubo errores
            if (!errores)
            {
                MessageBox.Show("Calculos realizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                cmdInsertar.Enabled = false;
                cmdModificar.Enabled = true;
                cmdCalcularTotal.Enabled = true;
                cmdVerID.Enabled = false;
                cmdCalcular.Enabled = true;

                txtClienteID.Text = filaSeleccionada.Cells["ClienteID"].Value.ToString();
                txtFacturaID.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                txtLimiteCredito.Text = filaSeleccionada.Cells["LimiteCredito"].Value.ToString();
                txtLimiteDisponible.Text = filaSeleccionada.Cells["LimiteDisponible"].Value.ToString();
                txtTermino.Text = filaSeleccionada.Cells["TerminoPago"].Value.ToString();
                chkCerrada.Checked = (bool) filaSeleccionada.Cells["Cerrada"].Value;
                dtpFecha.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaVencimiento"].Value.ToString());
                txtPago.Text = filaSeleccionada.Cells["Pago"].Value.ToString();
            }

        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Mostrar un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro que desea quitar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Si el usuario selecciona 'Sí', eliminar la fila
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdCambiar_Click(object sender, EventArgs e)
        {
            int clienteid = (int)tabCredito.DefaultView[dataGridView1.CurrentRow.Index]["ClienteID"];
            int facturaid = (int)tabCredito.DefaultView[dataGridView1.CurrentRow.Index]["FacturaID"];
            if (MessageBox.Show("Desea cambiar a cerrado el estado de la factura", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("spClienteCreditoCerrado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteid", clienteid);
                cmd.Parameters.AddWithValue("@facturaid", facturaid);

                try
                {
                    // Verificar si la conexión está cerrada antes de abrirla
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Asegurarse de cerrar la conexión si fue abierta en este método
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

                tabCredito.Clear();
                adpCredito.Fill(tabCredito);

            }

        }
    }
}
