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
    public partial class frmFactura : Form
    {

        SqlDataAdapter adpFactura;
        DataTable dtFactura;

        SqlDataAdapter adpFacturaDet;
        DataTable dtFacturaDet;

        SqlDataAdapter adpCliente;
        DataTable dtCliente;

        SqlDataAdapter adpEmpleado;
        DataTable dtEmpleado;

        SqlDataAdapter adpEstado;
        DataTable dtEstado;

        SqlDataAdapter adpTipoFactura;
        DataTable dtTipoFactura;

        SqlDataAdapter adpOrdenDet;
        DataTable dtOrdenDet;

        SqlDataAdapter adpArticulo;
        DataTable dtArticulo;

        public frmFactura()
        {
            InitializeComponent();
        }

        private void limpiarFactura()
        {
            txtFacturaID.Clear();
            cmbClienteID.SelectedIndex = -1;
            cmbNombreCliente.SelectedIndex = -1;
            cmbEmpleadoID.SelectedIndex = -1;
            cmbNombreEmpleado.SelectedIndex = -1;
            cmbTipoFactura.SelectedIndex = -1;
            cmbNombreTipoFac.SelectedIndex = -1;
            cmbEstadoFactura.SelectedIndex = -1;
            cmbNombreEstadoFac.SelectedIndex = -1;
        }

        private void limpiarFacturaDet()
        {
            txtFacturaID2.Clear();
            cmbArticuloID.SelectedIndex = -1;
            cmbNombreArticulo.SelectedIndex = -1;
            cmbOrdenDetID.SelectedIndex = -1;
            txtCantidad.Clear();
            txtHorasExtras.Clear();
        }

        public frmFactura(SqlConnection cnx)
        {
            InitializeComponent();

            dgvFactura.AllowUserToAddRows = false;
            dgvFactura.AllowUserToDeleteRows = false;
            dgvFactura.ReadOnly = true;
            dgvFactura.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFacturaDet.AllowUserToAddRows = false;
            dgvFacturaDet.AllowUserToDeleteRows = false;
            dgvFacturaDet.ReadOnly = true;
            dgvFacturaDet.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvFacturaDet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturaDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SqlConnection con;

            adpFactura = new SqlDataAdapter();
            dtFactura = new DataTable();

            adpFactura.SelectCommand = new SqlCommand("spSelectFactura", cnx);
            adpFactura.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpFactura.InsertCommand = new SqlCommand("spInsertFactura", cnx);
            adpFactura.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpFactura.InsertCommand.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
            adpFactura.InsertCommand.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            adpFactura.InsertCommand.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            adpFactura.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 8, "Fecha");
            adpFactura.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            adpFactura.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFactura.InsertCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");
            adpFactura.InsertCommand.Parameters["@facturaid"].Direction = ParameterDirection.InputOutput;


            adpFactura.UpdateCommand = new SqlCommand("spUpdateFactura", cnx);
            adpFactura.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpFactura.UpdateCommand.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
            adpFactura.UpdateCommand.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            adpFactura.UpdateCommand.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            adpFactura.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 8, "Fecha");
            adpFactura.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 1, "Tipo");
            adpFactura.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpFactura.UpdateCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");


            adpFacturaDet = new SqlDataAdapter();
            dtFacturaDet = new DataTable();

            adpFacturaDet.SelectCommand = new SqlCommand("spSelectFacturaDetalleMostrarTodas", cnx);
            adpFacturaDet.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpFacturaDet.InsertCommand = new SqlCommand("sqlInsertFacturaDetalle", cnx);
            adpFacturaDet.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpFacturaDet.InsertCommand.Parameters.Add("@facturadetid", SqlDbType.Int, 4, "FacturaDetalleID");
            adpFacturaDet.InsertCommand.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
            adpFacturaDet.InsertCommand.Parameters.Add("@articuloid", SqlDbType.Int, 4, "ArticuloID");
            adpFacturaDet.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpFacturaDet.InsertCommand.Parameters.Add("@ordendetid", SqlDbType.Int, 4,"OrdenDetalleID");
            adpFacturaDet.InsertCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");
            adpFacturaDet.InsertCommand.Parameters.Add("@horasextras", SqlDbType.Int,4, "HorasExtras");

            adpFacturaDet.UpdateCommand = new SqlCommand("spUpdateFacturaDet", cnx);
            adpFacturaDet.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpFacturaDet.UpdateCommand.Parameters.Add("@facturadetid",SqlDbType.Int, 4, "FacturaDetalleID");
            adpFacturaDet.UpdateCommand.Parameters.Add("@facturaid", SqlDbType.Int, 4, "FacturaID");
            adpFacturaDet.UpdateCommand.Parameters.Add("@articuloid", SqlDbType.Int, 4, "ArticuloID");
            adpFacturaDet.UpdateCommand.Parameters.Add("@cantidad",SqlDbType.Int, 4, "Cantidad");
            adpFacturaDet.UpdateCommand.Parameters.Add("@ordendetid", SqlDbType.Int, 4, "OrdenDetalleID");
            adpFacturaDet.UpdateCommand.Parameters.Add("@horasextras", SqlDbType.Int, 4, "HorasExtras");
            adpFacturaDet.UpdateCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            adpFacturaDet.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;

            adpCliente = new SqlDataAdapter();
            dtCliente = new DataTable();

            adpCliente.SelectCommand = new SqlCommand("spSelectClienteParaFactura", cnx);
            adpCliente.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpCliente.Fill(dtCliente);
            cmbClienteID.DataSource = dtCliente;
            cmbClienteID.DisplayMember = "ClienteID";
            cmbClienteID.ValueMember = "ClienteID";

            cmbNombreCliente.DataSource = dtCliente;
            cmbNombreCliente.DisplayMember = "NombreCliente";
            cmbNombreCliente.ValueMember = "ClienteID";

            adpEmpleado = new SqlDataAdapter();
            dtEmpleado = new DataTable();

            adpEmpleado.SelectCommand = new SqlCommand("spSelectEmpleadoParaFactura", cnx);
            adpEmpleado.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpEmpleado.Fill(dtEmpleado);
            cmbEmpleadoID.DataSource = dtEmpleado;
            cmbEmpleadoID.DisplayMember = "EmpleadoID";
            cmbEmpleadoID.ValueMember = "EmpleadoID";
            

            cmbNombreEmpleado.DataSource = dtEmpleado;
            cmbNombreEmpleado.ValueMember = "EmpleadoID";
            cmbNombreEmpleado.DisplayMember = "NombreEmpleado";

            adpEstado = new SqlDataAdapter();
            dtEstado = new DataTable();

            adpEstado.SelectCommand = new SqlCommand("select * from dbo.fEstadoParaFactura()", cnx);

            adpEstado.Fill(dtEstado);
            cmbEstadoFactura.DataSource = dtEstado;
            cmbEstadoFactura.DisplayMember = "Estado";
            cmbEstadoFactura.ValueMember = "Estado";

            cmbNombreEstadoFac.DataSource = dtEstado;
            cmbNombreEstadoFac.DisplayMember = "NombreEstado";
            cmbNombreEstadoFac.ValueMember = "Estado";

            adpTipoFactura = new SqlDataAdapter();
            dtTipoFactura = new DataTable();

            adpTipoFactura.SelectCommand = new SqlCommand("select * from dbo.fTipoFactura()", cnx);

            adpTipoFactura.Fill(dtTipoFactura);
            cmbTipoFactura.DataSource = dtTipoFactura;
            cmbTipoFactura.ValueMember = "Tipo";
            cmbTipoFactura.DisplayMember = "Tipo";

            cmbNombreTipoFac.DataSource = dtTipoFactura;
            cmbNombreTipoFac.ValueMember = "Tipo";
            cmbNombreTipoFac.DisplayMember = "NombreTipo";

            adpArticulo = new SqlDataAdapter();
            dtArticulo = new DataTable();

            adpArticulo.SelectCommand = new SqlCommand("spSelectArticulosParaFactura", cnx);
            adpArticulo.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpArticulo.Fill(dtArticulo);
            cmbArticuloID.DataSource = dtArticulo;
            cmbArticuloID.ValueMember = "ArticuloID";
            cmbArticuloID.DisplayMember = "ArticuloID";

            cmbNombreArticulo.DataSource = dtArticulo;
            cmbNombreArticulo.ValueMember = "ArticuloID";
            cmbNombreArticulo.DisplayMember = "NombreArticulo";

            adpOrdenDet = new SqlDataAdapter();
            dtOrdenDet = new DataTable();

            adpOrdenDet.SelectCommand = new SqlCommand("spSelectOrdenDetParaFactura", cnx);
            adpOrdenDet.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpOrdenDet.Fill(dtOrdenDet);
            cmbOrdenDetID.DataSource = dtOrdenDet;
            cmbOrdenDetID.ValueMember = "OrdenDetalleID";
            cmbOrdenDetID.DisplayMember = "OrdenDetalleID";

            con = cnx;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            txtFacturaID.Enabled = false;
            txtFacturaDetID.Enabled = false;

            cmbEstadoFactura.Enabled =  true;
            cmbNombreEstadoFac.Enabled = true;

            cmbTipoFactura.Enabled = true;
            cmbNombreTipoFac.Enabled = true;

            cmdBorrarDet.Enabled = false;
            cmdBorrar.Enabled = false;

            limpiarFactura();
            limpiarFacturaDet();
            try
            {
                dtFactura = new DataTable();
                adpFactura.Fill(dtFactura);
                dgvFactura.DataSource = dtFactura;

                dtFacturaDet = new DataTable();
                adpFacturaDet.Fill(dtFacturaDet);
                dgvFacturaDet.DataSource = dtFacturaDet;    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertarFac_Click(object sender, EventArgs e)
        {
            
            bool hayerror = false;

            errorProvider1.Clear();

            if (cmbClienteID.SelectedItem == null)
            {
                errorProvider1.SetError(cmbClienteID, "Falta el ID del cliente");
                hayerror = true;
            }
            else if (cmbEmpleadoID.SelectedItem == null)
            {
                errorProvider1.SetError(cmbEmpleadoID, "Falta el ID del empleado");
                hayerror = true;
            }
            else if (dtpFechaFac.Value < DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpFechaFac, "La fecha de la factura no puede ser menor a la fecha actual");
                hayerror = true;
            }
            else if (cmbEstadoFactura.SelectedItem == null)
            {
                errorProvider1.SetError(cmbEstadoFactura, "Falta establecer el estado de la factura");
                hayerror = true;
            }
            else if (cmbTipoFactura.SelectedItem == null)
            {
                errorProvider1.SetError(cmbTipoFactura, "Falta establecer el tipo de factura");
                hayerror = true;
            }


            if (hayerror)
            {
                return;
            }


            DataRow nuevaFila = dtFactura.NewRow();

            nuevaFila["ClienteID"] = cmbClienteID.Text;
            nuevaFila["EmpleadoID"] = cmbEmpleadoID.Text;
            nuevaFila["Fecha"] = dtpFechaFac.Value;
            nuevaFila["Tipo"] = cmbTipoFactura.Text;
            nuevaFila["Estado"] = cmbEstadoFactura.Text;
            nuevaFila["Activo"] = Convert.ToString(chkActivoFac.Checked);

            dtFactura.Rows.Add(nuevaFila);

            try
            {
                adpFactura.Update(dtFactura);
                dtFactura.Clear();
                adpFactura.Fill(dtFactura);
                dgvFactura.Refresh();
                MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    if (ex.Errors[i].Number == 2627)
                    {
                        MessageBox.Show("Los combinacion de Tipo Normal y Estado Pendiente no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Errors[i].Message, ex.Errors[i].Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            cmdBorrar.Enabled = true;
        }

        private void btnLimpiarFac_Click(object sender, EventArgs e)
        {
            limpiarFactura();
            btnInsertarFac.Enabled = true;

            cmbTipoFactura.Enabled = true;
            cmbNombreTipoFac.Enabled = true;
            cmbEstadoFactura.Enabled = true;
            cmbNombreEstadoFac.Enabled = true;

        }

        private void dgvFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbEstadoFactura.Enabled = false;
            cmbNombreEstadoFac.Enabled = false;

            cmbTipoFactura.Enabled = false;
            cmbNombreTipoFac.Enabled = false;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvFactura.Rows[e.RowIndex];

                chkActivoFac.Enabled = true;
                btnInsertarFac.Enabled = false;

                txtFacturaID.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                txtFacturaID2.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                cmbClienteID.SelectedValue = filaSeleccionada.Cells["ClienteID"].Value.ToString();
                cmbEmpleadoID.SelectedValue = filaSeleccionada.Cells["EmpleadoID"].Value.ToString();
                cmbTipoFactura.SelectedValue = filaSeleccionada.Cells["Tipo"].Value.ToString();
                cmbEstadoFactura.SelectedValue = filaSeleccionada.Cells["Estado"].Value.ToString();
                dtpFechaFac.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value.ToString());
                chkActivoFac.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);

                // Obtener el FacturaID de la fila seleccionada
                int facturaID = Convert.ToInt32(dgvFactura.Rows[e.RowIndex].Cells["FacturaID"].Value);

                // Llamar al método para cargar los detalles de la factura
                CargarFacturaDetallePorFacturaID(facturaID);

            }
        }

        private void btnModificarFac_Click(object sender, EventArgs e)
        {
            cmdBorrar.Enabled = false;
            cmbTipoFactura.Enabled = true;
            cmbNombreTipoFac.Enabled = true;
            cmbEstadoFactura.Enabled = true;
            cmbNombreEstadoFac.Enabled = true;

            try
            {
                if (dgvFactura.SelectedRows.Count >= 0)
                {
                    dtFactura.PrimaryKey = new DataColumn[] { dtFactura.Columns["FacturaID"] };

                    DataGridViewRow filaSeleccionada = dgvFactura.SelectedRows[0];

                    DataRow filaDatos = dtFactura.Rows.Find(filaSeleccionada.Cells["FacturaID"].Value);

                    if (filaDatos != null)
                    {
                        filaDatos["ClienteID"] = cmbClienteID.Text;
                        filaDatos["EmpleadoID"] = cmbEmpleadoID.Text;
                        filaDatos["Tipo"] = cmbTipoFactura.SelectedValue;
                        filaDatos["Estado"] = cmbEstadoFactura.SelectedValue;
                        filaDatos["Fecha"] = dtpFechaFac.Value;
                        filaDatos["Activo"] = chkActivoFac.Checked ? 1 : 0;

                        try
                        {
                            adpFactura.Update(dtFactura);
                            dtFactura.Clear();
                            adpFactura.Fill(dtFactura);
                            dgvFactura.Refresh();
                            MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarFactura();
                            chkActivoFac.Enabled = false;
                            btnInsertarFac.Enabled = true;
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
            catch(Exception )
            {
                MessageBox.Show("No se encontró la fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFactura_SelectionChanged(object sender, EventArgs e)
        {
            
           
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool hayerror = false;

            errorProvider2.Clear();

            if (txtFacturaID2.Text.Length == 0)
            {
                errorProvider2.SetError(txtFacturaID2, "Falta el ID de la Factura");
                hayerror = true;
            }
            else if ( cmbArticuloID.Enabled == true && cmbArticuloID.SelectedIndex == -1  && cmbOrdenDetID.Enabled == false  && txtHorasExtras.Enabled==false)
            {
                errorProvider2.SetError(cmbArticuloID, "Ingrese el ID del articulo");
                hayerror = true;
            }
            else if (cmbArticuloID.Enabled == false && txtCantidad.Enabled == false && cmbOrdenDetID.SelectedIndex == -1 && cmbOrdenDetID.Enabled == true)
            {
                errorProvider2.SetError(dtpFechaFac, "Ingrese el ID de la orden");
                hayerror = true;
            }


            if (hayerror)
            {
                return;
            }

            DataRow nuevaFila = dtFacturaDet.NewRow();

            if(cmbArticuloID.SelectedIndex == -1)
            {
                nuevaFila["ArticuloID"] = DBNull.Value;
            }
            else
            {
                nuevaFila["ArticuloID"] = cmbArticuloID.Text;
            }

            if(cmbOrdenDetID.SelectedIndex == -1)
            {
                nuevaFila["OrdenDetalleID"] = DBNull.Value;
            }
            else
            {
                nuevaFila["OrdenDetalleID"] = cmbOrdenDetID.SelectedValue;
            }

            if (txtCantidad.Text.Length == 0 )
            {
                nuevaFila["Cantidad"] = DBNull.Value;
            }
            else
            {
                nuevaFila["Cantidad"] = txtCantidad.Text;
            }

            if (txtHorasExtras.Text.Length == 0)
            {
                nuevaFila["HorasExtras"] = DBNull.Value;
            }
            else
            {
                nuevaFila["HorasExtras"] = txtHorasExtras.Text;
            }

            nuevaFila["FacturaID"] = txtFacturaID2.Text;
            nuevaFila["Activo"] = Convert.ToString(chkActivoFacturaDet.Checked);

            dtFacturaDet.Rows.Add(nuevaFila);

            try
            {
                adpFacturaDet.Update(dtFacturaDet);
                
                adpFacturaDet.Fill(dtFacturaDet);
                dgvFacturaDet.Refresh();
                MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFacturaDetID.Clear();
                cmbArticuloID.SelectedIndex = -1;
                cmbNombreArticulo.SelectedIndex = -1;
                cmbOrdenDetID.SelectedIndex = -1;
                txtCantidad.Clear();
                txtHorasExtras.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmdBorrarDet.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cmdBorrarDet.Enabled = false;
            if (dgvFacturaDet.SelectedRows.Count > 0)
            {
                dtFacturaDet.PrimaryKey = new DataColumn[]{ dtFacturaDet.Columns["FacturaDetalleID"] };

                DataGridViewRow filaSeleccionada = dgvFacturaDet.Rows[0];

                DataRow filaDatos = dtFacturaDet.Rows.Find(filaSeleccionada.Cells["FacturaDetalleID"].Value);

                if (filaDatos != null)
                {


                    filaDatos["ArticuloID"] = cmbArticuloID.SelectedIndex == -1 ? DBNull.Value : (object)cmbArticuloID.Text;
                    filaDatos["OrdenDetalleID"] = cmbOrdenDetID.SelectedIndex == -1 ? DBNull.Value : (object)cmbOrdenDetID.Text;
                    filaDatos["HorasExtras"] = string.IsNullOrWhiteSpace(txtHorasExtras.Text) ? 0 : Convert.ToInt32(txtHorasExtras.Text);
                    filaDatos["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                    filaDatos["Activo"] = chkActivoFacturaDet.Checked ? 1 : 0;

                    try
                    {
                        adpFacturaDet.Update(dtFacturaDet);
                        dtFacturaDet.Clear();
                        CargarFacturaDetallePorFacturaID(Convert.ToInt32(txtFacturaID2.Text));
                        adpFacturaDet.Fill(dtFacturaDet);

                        dgvFacturaDet.Refresh();
                        MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarFacturaDet();

                        txtFacturaID2.Enabled = false;
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

        private void dgvFacturaDet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFacturaDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCantidad.Enabled = false;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvFacturaDet.Rows[e.RowIndex];

                chkActivoFacturaDet.Enabled = true;
                txtFacturaID2.Enabled = true;

                if (filaSeleccionada.Cells["ArticuloID"].Value.ToString() == "")
                {
                    cmbArticuloID.Enabled = false;
                    cmbNombreArticulo.Enabled = false;

                    txtFacturaDetID.Text = filaSeleccionada.Cells["FacturaDetalleID"].Value.ToString();
                    txtFacturaID2.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                    cmbOrdenDetID.Text = filaSeleccionada.Cells["OrdenDetalleID"].Value.ToString();
                    cmbArticuloID.Text = "";
                    cmbNombreArticulo.Text = "";
                    txtCantidad.Text = "1";
                    txtHorasExtras.Text = filaSeleccionada.Cells["HorasExtras"].Value.ToString();
                    chkActivoFacturaDet.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                }
                
                if (filaSeleccionada.Cells["OrdenDetalleID"].Value.ToString() == "")
                {
                    cmbOrdenDetID.Enabled = false;
                    txtFacturaDetID.Text = filaSeleccionada.Cells["FacturaDetalleID"].Value.ToString();
                    txtFacturaID2.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                    cmbArticuloID.Text = filaSeleccionada.Cells["ArticuloID"].Value.ToString();
                    txtCantidad.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();
                    txtHorasExtras.Text = "0";
                    chkActivoFacturaDet.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                    
                }
            }

            


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFacturaDet();
            cmbOrdenDetID.Enabled = true;
            cmbArticuloID.Enabled = true;
            cmbNombreArticulo.Enabled = true;
            txtCantidad.Enabled = true;
            txtHorasExtras.Enabled = true;
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvFactura.SelectedRows.Count > 0)
            {
                // Mostrar un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro que desea quitar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Si el usuario selecciona 'Sí', eliminar la fila
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvFactura.SelectedRows)
                    {
                        dgvFactura.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para quitar.", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmdBorrarDet_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvFacturaDet.SelectedRows.Count > 0)
            {
                // Mostrar un mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro que desea quitar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Si el usuario selecciona 'Sí', eliminar la fila
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvFacturaDet.SelectedRows)
                    {
                        dgvFacturaDet.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para quitar.", "Eliminar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void cmbArticuloID_Click(object sender, EventArgs e)
        {
            cmbOrdenDetID.Enabled = false;
            txtHorasExtras.Enabled = false;
        }

        private void cmbOrdenDetID_Click(object sender, EventArgs e)
        {
            cmbArticuloID.Enabled = false;
            cmbNombreArticulo.Enabled = false;
            txtCantidad.Enabled = false;
        }

        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvFactura.SelectedRows.Count > 0)
                {
                    var filaSeleccionada = dgvFactura.SelectedRows[0];

                    txtFacturaID.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();
                    txtFacturaID2.Text = filaSeleccionada.Cells["FacturaID"].Value.ToString();

                    adpFacturaDet.SelectCommand.Parameters["@facturadetid"].Value = Convert.ToInt32(txtFacturaID2.Text);

                    try
                    {
                        dtFacturaDet.Clear();
                        adpFacturaDet.Fill(dtFacturaDet);
                        dgvFacturaDet.DataSource = dtFacturaDet;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CargarFacturaDetallePorFacturaID(int facturaID)
        {
            try
            {    // Crear instancia de CConexion
                CConexion conexion = new CConexion();

                // Obtener la conexión
                using (SqlConnection con = conexion.EstablecerConexion())
                {

                    using (SqlCommand command = new SqlCommand("spSelectFacturaDetalle", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@facturaid", facturaID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable facturaDetalleTable = new DataTable();
                            adapter.Fill(facturaDetalleTable);

                            dgvFacturaDet.DataSource = facturaDetalleTable;
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Esta factura no contiene detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir del formulario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Dispose();
        }
    }
}
