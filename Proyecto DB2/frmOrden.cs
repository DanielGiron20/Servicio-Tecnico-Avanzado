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
    public partial class frmOrden : Form
    {
        private bool fechaCambiada = false;

        SqlDataAdapter adpOrden;
        DataTable dtOrden;

        SqlDataAdapter adpOrdenDet;
        DataTable dtOrdenDet;

        SqlDataAdapter adpCliente;
        DataTable dtCliente;

        SqlDataAdapter adpEmpleado;
        DataTable dtEmpleado;

        SqlDataAdapter adpEstado;
        DataTable dtEstado;

        SqlDataAdapter adpTipoOrden;
        DataTable dtTipoOrden;

        SqlDataAdapter adpPaquete;
        DataTable dtPaquete;

        SqlDataAdapter adpServicio;
        DataTable dtServicio;

        

        public frmOrden()
        {
            InitializeComponent();

        }

        private void limpiarOrden()
        {
            txtOrdenID.Clear();
            cmbClienteID.SelectedIndex = -1;
            cmbEmpleadoID.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbEstadoNombre.SelectedIndex = -1;
            cmbNombreCliente.SelectedIndex = -1;
            cmbNombreEmpleado.SelectedIndex = -1;
            cmbTipoOrden.SelectedIndex = -1;
            cmbTipoOrdenNombre.SelectedIndex = -1;
            cmbTipoOrden.Enabled = true;
            cmbTipoOrdenNombre.Enabled = true;
        }



        private void limpiarOrdenDet()
        {
            cmbPaqueteId.SelectedIndex = -1;
            cmbServicioID.SelectedIndex = -1;
            cmbNombrePaquete.SelectedIndex = -1;
            cmbNombreServicio.SelectedIndex = -1;
            txtOrdenID2.Clear();
            txtCantidad.Clear();
        }

        public frmOrden(SqlConnection cnx)
        {
            InitializeComponent();

            dgvOrden.AllowUserToAddRows = false;
            dgvOrden.AllowUserToDeleteRows = false;
            dgvOrden.ReadOnly = true;
            dgvOrden.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrdenDet.AllowUserToAddRows = false;
            dgvOrdenDet.AllowUserToDeleteRows = false;
            dgvOrdenDet.ReadOnly = true;
            dgvOrdenDet.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvOrdenDet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbClienteID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombreCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleadoID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombreEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoNombre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoOrdenNombre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaqueteId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicioID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombrePaquete.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombreServicio.DropDownStyle = ComboBoxStyle.DropDownList;

            SqlConnection con;

            adpOrden = new SqlDataAdapter();
            dtOrden = new DataTable();

            adpOrden.SelectCommand = new SqlCommand("spSelectOrden", cnx);
            adpOrden.SelectCommand.CommandType = CommandType.StoredProcedure;


            adpOrden.InsertCommand = new SqlCommand("spInsertarOrden", cnx);
            adpOrden.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpOrden.InsertCommand.Parameters.Add("@ordenid", SqlDbType.Int, 4, "OrdenID");
            adpOrden.InsertCommand.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            adpOrden.InsertCommand.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            adpOrden.InsertCommand.Parameters.Add("@tipoOrden", SqlDbType.VarChar, 1, "TipoOrden");
            adpOrden.InsertCommand.Parameters.Add("@duracion", SqlDbType.Int, 4, "Duracion");
            adpOrden.InsertCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpOrden.InsertCommand.Parameters.Add("@fechaInicio", SqlDbType.DateTime, 8, "FechaInicio");
            adpOrden.InsertCommand.Parameters.Add("@fechaFinal", SqlDbType.DateTime, 8, "FechaFinal");
            adpOrden.InsertCommand.Parameters.Add("@activo", SqlDbType.Int, 1, "Activo");
            adpOrden.InsertCommand.Parameters["@ordenid"].Direction = ParameterDirection.InputOutput;


            adpOrden.UpdateCommand = new SqlCommand("spUpdateOrden", cnx);
            adpOrden.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpOrden.UpdateCommand.Parameters.Add("@ordenid", SqlDbType.Int, 4, "OrdenID");
            adpOrden.UpdateCommand.Parameters.Add("@clienteid", SqlDbType.Int, 4, "ClienteID");
            adpOrden.UpdateCommand.Parameters.Add("@empleadoid", SqlDbType.Int, 4, "EmpleadoID");
            adpOrden.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 1, "Estado");
            adpOrden.UpdateCommand.Parameters.Add("@fechaInicio", SqlDbType.DateTime, 8, "FechaInicio");
            adpOrden.UpdateCommand.Parameters.Add("@fechaFinal", SqlDbType.DateTime, 8, "FechaFinal");
            adpOrden.UpdateCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");


            adpOrdenDet = new SqlDataAdapter();
            dtOrdenDet = new DataTable();

            adpOrdenDet.SelectCommand = new SqlCommand("spSelectOrdenDetalle", cnx);
            adpOrdenDet.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpOrdenDet.SelectCommand.Parameters.Add(new SqlParameter("@ordenid", SqlDbType.Int));

            adpOrdenDet.InsertCommand = new SqlCommand("spInsertOrdenDetalle", cnx);
            adpOrdenDet.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpOrdenDet.InsertCommand.Parameters.Add("@ordendetalleid", SqlDbType.Int, 4, "OrdenDetalleID");
            adpOrdenDet.InsertCommand.Parameters.Add("@paqueteid", SqlDbType.Int, 4, "PaqueteID");
            adpOrdenDet.InsertCommand.Parameters.Add("@servicioid", SqlDbType.Int, 4, "ServicioID");
            adpOrdenDet.InsertCommand.Parameters.Add("@ordenid", SqlDbType.Int, 4, "OrdenID");
            adpOrdenDet.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpOrdenDet.InsertCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            adpOrdenDet.UpdateCommand = new SqlCommand("spUpdateOrdenDetalle", cnx);
            adpOrdenDet.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpOrdenDet.UpdateCommand.Parameters.Add("@ordendetid", SqlDbType.Int, 4, "OrdenDetalleID");
            adpOrdenDet.UpdateCommand.Parameters.Add("@ordenid", SqlDbType.Int, 4, "OrdenID");
            adpOrdenDet.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpOrdenDet.UpdateCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            adpCliente = new SqlDataAdapter();
            dtCliente = new DataTable();

            adpCliente.SelectCommand = new SqlCommand("spSelectClienteParaOrden", cnx);
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

            adpEmpleado.SelectCommand = new SqlCommand("spSelectEmpleadoParaOrden", cnx);
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

            adpEstado.SelectCommand = new SqlCommand("select * from dbo.fEstadoParaOrden()", cnx);

            adpEstado.Fill(dtEstado);
            cmbEstado.DataSource = dtEstado;
            cmbEstado.DisplayMember = "Estado";
            cmbEstado.ValueMember = "Estado";

            cmbEstadoNombre.DataSource = dtEstado;
            cmbEstadoNombre.DisplayMember = "NombreEstado";
            cmbEstadoNombre.ValueMember = "Estado";

            adpTipoOrden = new SqlDataAdapter();
            dtTipoOrden = new DataTable();

            adpTipoOrden.SelectCommand = new SqlCommand("select * from dbo.fTipoOrden()", cnx);

            adpTipoOrden.Fill(dtTipoOrden);
            cmbTipoOrden.DataSource = dtTipoOrden;
            cmbTipoOrden.DisplayMember = "Tipo";
            cmbTipoOrden.ValueMember = "Tipo";

            cmbTipoOrdenNombre.DataSource = dtTipoOrden;
            cmbTipoOrdenNombre.DisplayMember = "NombreTipo";
            cmbTipoOrdenNombre.ValueMember = "Tipo";

            adpPaquete = new SqlDataAdapter();
            dtPaquete = new DataTable();

            adpPaquete.SelectCommand = new SqlCommand("spSelectPaqueteParaOrden", cnx);
            
            adpPaquete.Fill(dtPaquete);
            cmbPaqueteId.DataSource = dtPaquete;
            cmbPaqueteId.DisplayMember = "PaqueteID";
            cmbPaqueteId.ValueMember = "PaqueteID";

            cmbNombrePaquete.DataSource = dtPaquete;
            cmbNombrePaquete.DisplayMember = "NombrePaquete";
            cmbNombrePaquete.ValueMember = "PaqueteID";

            adpServicio = new SqlDataAdapter();
            dtServicio = new DataTable();

            adpServicio.SelectCommand = new SqlCommand("spSelectServicioParaOrden", cnx);

            adpServicio.Fill(dtServicio);
            cmbServicioID.DataSource = dtServicio;
            cmbServicioID.DisplayMember = "ServicioID";
            cmbServicioID.ValueMember = "ServicioID";

            cmbNombreServicio.DataSource = dtServicio;
            cmbNombreServicio.DisplayMember = "NombreServicio";
            cmbNombreServicio.ValueMember = "ServicioID";

            con = cnx;
        }

        private void refrescardgvOrden()
        {

        }

        private void obtenerOrdenes()
        {
            
        }

        private void frmOrden_Load(object sender, EventArgs e)
        {
            limpiarOrden();
            limpiarOrdenDet();

            try
            {
                dtOrden = new DataTable();
                adpOrden.Fill(dtOrden);
                dgvOrden.DataSource = dtOrden;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DataRow nuevaFila = dtOrden.NewRow();

            //nuevaFila["OrdenID"] = txtOrdenID.Text;
            nuevaFila["ClienteID"] = cmbClienteID.Text;
            nuevaFila["EmpleadoID"] = cmbEmpleadoID.Text;
            nuevaFila["TipoOrden"] = cmbTipoOrden.Text;
            nuevaFila["Duracion"] = txtDuracion.Text;
            nuevaFila["Estado"] = cmbEstado.Text;
            nuevaFila["FechaInicio"] = dtpFechaInicio.Value;

            if(fechaCambiada)
            {
                if(MessageBox.Show("¿Seguro que quiere establecer la fecha final ahora?","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nuevaFila["FechaFinal"] = dtpFechaFinal.Value;
                }
            }
            else
            {
                nuevaFila["FechaFinal"] = DBNull.Value;
            }
            
            nuevaFila["Activo"] = Convert.ToString(chkActivo.Checked);

            dtOrden.Rows.Add(nuevaFila);

            try
            {
                adpOrden.Update(dtOrden);
                dtOrden.Clear();
                adpOrden.Fill(dtOrden);
                dgvOrden.Refresh();
                MessageBox.Show("Los datos se insertaron correctamente", "Exito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarOrden();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            fechaCambiada = true;
        }

        private void dgvOrden_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrden.Rows[e.RowIndex];

                chkActivo.Enabled = true;
                cmbTipoOrden.Enabled = false;
                cmbTipoOrdenNombre.Enabled = false;
                btnInsertar.Enabled = false;

                txtOrdenID.Text = filaSeleccionada.Cells["OrdenID"].Value.ToString();
                cmbClienteID.SelectedValue = filaSeleccionada.Cells["ClienteID"].Value.ToString();
                cmbEmpleadoID.SelectedValue = filaSeleccionada.Cells["EmpleadoID"].Value.ToString();
                cmbTipoOrden.SelectedValue = filaSeleccionada.Cells["TipoOrden"].Value.ToString();
                txtDuracion.Text = filaSeleccionada.Cells["Duracion"].Value.ToString();
                cmbEstado.SelectedValue = filaSeleccionada.Cells["Estado"].Value.ToString();
                dtpFechaInicio.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaInicio"].Value.ToString());
                
                if(filaSeleccionada.Cells["FechaFinal"].Value.ToString() != null && filaSeleccionada.Cells["FechaFinal"].Value.ToString() != "")
                {
                    dtpFechaFinal.Value = Convert.ToDateTime(filaSeleccionada.Cells["FechaFinal"].Value.ToString());
                }

                chkActivo.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiarOrden();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvOrden.SelectedRows.Count > 0)
            {
                dtOrden.PrimaryKey = new DataColumn[] { dtOrden.Columns["OrdenID"] };

                DataGridViewRow filaSeleccionada = dgvOrden.SelectedRows[0];

                DataRow filaDatos = dtOrden.Rows.Find(filaSeleccionada.Cells["OrdenID"].Value);

                if(filaDatos != null)
                {
                    filaDatos["ClienteID"] = cmbClienteID.Text;
                    filaDatos["EmpleadoID"] = cmbEmpleadoID.Text;
                    filaDatos["Estado"] = cmbEstado.Text;
                    filaDatos["FechaInicio"] = dtpFechaInicio.Value;
                    filaDatos["FechaFinal"] = dtpFechaFinal.Value;
                    filaDatos["Activo"] = chkActivo.Checked ? 1 : 0;

                    try
                    {
                        adpOrden.Update(dtOrden);
                        dtOrden.Clear();
                        adpOrden.Fill(dtOrden);
                        dgvOrden.Refresh();
                        MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarOrden();
                        chkActivo.Enabled = false;
                        cmbTipoOrden.Enabled = true;
                        cmbTipoOrdenNombre.Enabled = true;
                        btnInsertar.Enabled = true;
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

        private void btnLimpiarOrdenDet_Click(object sender, EventArgs e)
        {
            limpiarOrdenDet();
        }

        private void dgvOrden_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvOrden.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvOrden.SelectedRows[0];

                txtOrdenID.Text = filaSeleccionada.Cells["OrdenID"].Value.ToString();
                txtOrdenID2.Text = filaSeleccionada.Cells["OrdenID"].Value.ToString();

                adpOrdenDet.SelectCommand.Parameters["@ordenid"].Value = Convert.ToInt32(txtOrdenID2.Text);

                try
                {
                    //dtOrdenDet = new DataTable();
                    dtOrdenDet.Clear();
                    adpOrdenDet.Fill(dtOrdenDet);
                    dgvOrdenDet.DataSource = dtOrdenDet;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow nuevaFila = dtOrdenDet.NewRow();

            if(cmbPaqueteId.SelectedIndex == -1)
            {
                nuevaFila["PaqueteID"] = DBNull.Value;
            }
            else
            {
                nuevaFila["PaqueteID"] = cmbPaqueteId.Text;
            }

            if (cmbServicioID.SelectedIndex == -1)
            {
                nuevaFila["ServicioID"] = DBNull.Value;
            }
            else
            {
                nuevaFila["ServicioID"] = cmbServicioID.Text;
            }

            
            nuevaFila["OrdenID"] = txtOrdenID2.Text;
            nuevaFila["Cantidad"] = txtCantidad.Text;
            nuevaFila["Activo"] = Convert.ToString(chkActivoOrdenDet.Checked);

            dtOrdenDet.Rows.Add(nuevaFila);

            try
            {
                adpOrdenDet.Update(dtOrdenDet);
                dtOrdenDet.Clear();
                adpOrdenDet.Fill(dtOrdenDet);
                dgvOrdenDet.Refresh();
                MessageBox.Show("Los datos se insertaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarOrdenDet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgvOrdenDet.SelectedRows.Count > 0)
            {
                dtOrdenDet.PrimaryKey = new DataColumn[] { dtOrdenDet.Columns["OrdenDetalleID"] };

                DataGridViewRow filaSeleccionada = dgvOrdenDet.Rows[0];

                DataRow filaDatos = dtOrdenDet.Rows.Find(filaSeleccionada.Cells["OrdenDetalleID"].Value);

                if(filaDatos != null)
                {
                    if(cmbPaqueteId.SelectedIndex == -1)
                    {
                        filaDatos["PaqueteID"] = DBNull.Value;
                    }
                    else
                    {
                        filaDatos["PaqueteID"] = cmbPaqueteId.Text;
                    }
                    
                    filaDatos["ServicioID"] = cmbServicioID.Text;
                    filaDatos["OrdenID"] = txtOrdenID2.Text;
                    filaDatos["Cantidad"] = txtCantidad.Text;
                    filaDatos["Activo"] = chkActivoOrdenDet.Checked ? 1 : 0;

                    try
                    {
                        adpOrdenDet.Update(dtOrdenDet);
                        dtOrdenDet.Clear();
                        adpOrdenDet.Fill(dtOrdenDet);
                        dgvOrdenDet.Refresh();
                        MessageBox.Show("Los datos se actualizaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarOrdenDet();
                        txtOrdenID2.Enabled = false;
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

        private void dgvOrdenDet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvOrdenDet.Rows[e.RowIndex];

                chkActivoOrdenDet.Enabled = true;
                txtOrdenID2.Enabled = true;

                if (filaSeleccionada.Cells["PaqueteID"].Value.ToString() == "")
                {
                    cmbPaqueteId.Enabled = false;
                    cmbNombrePaquete.Enabled = false;

                    txtOrdenDetId.Text = filaSeleccionada.Cells["OrdenDetalleID"].Value.ToString();
                    cmbServicioID.Text = filaSeleccionada.Cells["ServicioID"].Value.ToString();
                    txtOrdenID2.Text = filaSeleccionada.Cells["OrdenID"].Value.ToString();
                    txtCantidad.Text = filaSeleccionada.Cells["Cantidad"].Value.ToString();
                    chkActivoOrdenDet.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                }
                else if(filaSeleccionada.Cells["ServicioID"].Value.ToString() == "")
                {
                    txtCantidad.Enabled = false;
                    cmbPaqueteId.Enabled = false;
                    cmbNombrePaquete.Enabled = false;

                    txtOrdenID2.Text = filaSeleccionada.Cells["OrdenID"].Value.ToString();
                    
                    chkActivoOrdenDet.Checked = Convert.ToBoolean(filaSeleccionada.Cells["Activo"].Value);
                }

            }
        }
    }
}
