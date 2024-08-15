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
    public partial class frmPaquete : Form
    {
        
        SqlConnection con;
        SqlParameter prmPaqueteDetalle;
        SqlDataAdapter adpPaquete;
        SqlDataAdapter adpPaqueteDetalle;

        DataSet dsTablas;

        public frmPaquete()
        {
            InitializeComponent();
        }

        public frmPaquete(SqlConnection conexion, int paqueteid)
        {
            InitializeComponent();

            prmPaqueteDetalle = new SqlParameter();
            prmPaqueteDetalle.ParameterName = "@paqueteid";
            prmPaqueteDetalle.Value = 0;

            adpPaquete = new SqlDataAdapter("spPaqueteSelect", conexion);
            adpPaquete.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpPaquete.SelectCommand.Parameters.AddWithValue("@paqueteid", paqueteid);

            adpPaquete.InsertCommand = comando("spPaqueteInsert", conexion);
            adpPaquete.UpdateCommand = comando("spPaqueteUpdate", conexion);

            adpPaqueteDetalle = new SqlDataAdapter("spPaqueteDetalleSelect", conexion);
            adpPaqueteDetalle.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpPaqueteDetalle.SelectCommand.Parameters.AddWithValue("@paqueteid", paqueteid);

            adpPaqueteDetalle.InsertCommand = new SqlCommand("spPaqueteDetalleInsert", conexion);
            adpPaqueteDetalle.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpPaqueteDetalle.InsertCommand.Parameters.Add(prmPaqueteDetalle);
            adpPaqueteDetalle.InsertCommand.Parameters.Add("@servicioid", SqlDbType.Int, 4, "ServicioID");
            adpPaqueteDetalle.InsertCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            adpPaqueteDetalle.UpdateCommand = new SqlCommand("spPaqueteDetalleUpdate", conexion);
            adpPaqueteDetalle.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpPaqueteDetalle.UpdateCommand.Parameters.Add("@paqueteid", SqlDbType.Int, 4, "PaqueteID");  //parametro enviado como un objeto 
            adpPaqueteDetalle.UpdateCommand.Parameters.Add("@servicioid", SqlDbType.Int, 4, "ServicioID");
            adpPaqueteDetalle.UpdateCommand.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            con = conexion;
        }

        private SqlCommand comando(String sql, SqlConnection cnx)
        {
            //Metodo para evitar escirbir el command type  y setear parametros
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@paqueteid", SqlDbType.Int, 4, "PaqueteID");
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100, "Descripcion");
            cmd.Parameters.Add("@preciomensual", SqlDbType.Float, 8, "PrecioMensual");
            cmd.Parameters.Add("@cantidadhoras", SqlDbType.Int, 4, "CantidadHoras");
            cmd.Parameters.Add("@tarifahoraextra", SqlDbType.Float, 8, "TarifaHoraExtra");
            cmd.Parameters.Add("@activo", SqlDbType.Bit, 1, "Activo");

            return cmd;
        }

        private void frmPaquete_Load(object sender, EventArgs e)
        {
            try
            {
                
                dgPaqueteDetalle.AllowUserToAddRows = false;
                dgPaqueteDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                txtPaqueteID.Enabled = true;
                dsTablas = new DataSet();

                dsTablas.Tables.Add("Paquete"); //agregar las tablas y colocando los nombres
                dsTablas.Tables.Add("PaqueteDetalle");

                adpPaquete.Fill(dsTablas.Tables["Paquete"]); //El resultado del Fill queda en el dataset y dentro del dataset se agrega a un datatable segun el nombre del datatable o el indice
                adpPaqueteDetalle.Fill(dsTablas.Tables["PaqueteDetalle"]);

                if (dsTablas.Tables["Paquete"].Rows.Count == 0)  //se usan los mismos metodos de un datatablle
                {
                    dsTablas.Tables["Paquete"].Rows.Add();
                    cmdEliminar.Enabled = false;
                    txtPaqueteID.Enabled = false;
                }
                else
                {
                    txtPaqueteID.Enabled = false;
                    txtPaqueteID.Text = dsTablas.Tables["Paquete"].Rows[0]["paqueteid"].ToString();
                    txtNombre.Text = dsTablas.Tables["Paquete"].Rows[0]["nombre"].ToString();
                    txtDescripcion.Text = dsTablas.Tables["Paquete"].Rows[0]["descripcion"].ToString();
                    txtPrecioMensual.Text = dsTablas.Tables["Paquete"].Rows[0]["preciomensual"].ToString();
                    txtCantidadHoras.Text = dsTablas.Tables["Paquete"].Rows[0]["cantidadhoras"].ToString();
                    txtTarifaHoraExtra.Text = dsTablas.Tables["Paquete"].Rows[0]["tarifahoraextra"].ToString();
                    chkActivo.Checked = (bool)dsTablas.Tables["Paquete"].Rows[0]["activo"];

                }

                dgPaqueteDetalle.DataSource = dsTablas.Tables["PaqueteDetalle"];
                dgPaqueteDetalle.Columns["paqueteid"].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgPaqueteDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            String col = dgPaqueteDetalle.Columns[e.ColumnIndex].Name.ToLower();

            if (col == "servicioid")
            {
                if (e.FormattedValue.ToString().Length > 0) //esta propiedad es el texto que se acaba de insertar o editar
                {
                    SqlDataAdapter adpServicio = new SqlDataAdapter("spPaquetesServiciosActivosSelect " + e.FormattedValue, con);   //Concatenando la sentencia con
                    DataTable tabServicio = new DataTable();
                    adpServicio.Fill(tabServicio);

                    if (tabServicio.Rows.Count == 0) //El servicio viene vacio
                    {
                        MessageBox.Show("El servicio no existe o no esta activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;  //Esto hace que no permita ingresar el dato y no pueda salir de la celda hasta que se cambie.
                    }
                    else
                    {
                        dsTablas.Tables["PaqueteDetalle"].DefaultView[e.RowIndex]["Nombre"] = tabServicio.Rows[0]["Nombre"].ToString();
                        dgPaqueteDetalle.Refresh();
                    }

                }
            }

            if (col == "activo")
            {
                if (e.FormattedValue.ToString().Length > 0)
                {
                    bool activo = Boolean.Parse(e.FormattedValue.ToString());
                    if (activo == false )
                    {
                        MessageBox.Show("Marque la casilla de Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void cmdGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool errores = false;
                errorProvider1.Clear();

                if (txtNombre.Text.Length == 0)
                {
                    errorProvider1.SetError(txtNombre, "Falta el nombre del paquete");
                    errores = true;

                }

                if (txtDescripcion.Text.Length == 0)
                {
                    errorProvider1.SetError(txtDescripcion, "Falta la descripcion del paquete");
                    errores = true;
                }


                if (txtPrecioMensual.Text.Length == 0)
                {
                    errorProvider1.SetError(txtPrecioMensual, "Falta el precio del paquete");
                    errores = true;
                }
                else
                {
                    if (!float.TryParse(txtPrecioMensual.Text, out float precioMensual))
                    {
                        errorProvider1.SetError(txtPrecioMensual, "El precio mensual debe ser un número válido");
                        errores = true;
                    }
                    else if (precioMensual < 0)
                    {
                        errorProvider1.SetError(txtPrecioMensual, "El precio mensual no puede ser negativo");
                        errores = true;
                    }
                }


                if (txtCantidadHoras.Text.Length == 0)
                {
                    errorProvider1.SetError(txtCantidadHoras, "Falta las horas de soporte del paquete");
                    errores = true;
                }
                else
                {
                    if (!int.TryParse(txtCantidadHoras.Text, out int cantidadHoras))
                    {
                        errorProvider1.SetError(txtCantidadHoras, "La cantidad de horas debe ser un número válido");
                        errores = true;
                    }
                    else if (cantidadHoras < 0)
                    {
                        errorProvider1.SetError(txtCantidadHoras, "La cantidad de horas no puede ser negativa");
                        errores = true;
                    }
                }


                if (txtTarifaHoraExtra.Text.Length == 0)
                {
                    errorProvider1.SetError(txtTarifaHoraExtra, "Falta la tarifa por horas extra");
                    errores = true;
                }
                else
                {
                    if (!float.TryParse(txtTarifaHoraExtra.Text, out float tarifaHoraExtra))
                    {
                        errorProvider1.SetError(txtTarifaHoraExtra, "La tarifa por horas extra debe ser un número válido");
                        errores = true;
                    }
                    else if (tarifaHoraExtra < 0)
                    {
                        errorProvider1.SetError(txtTarifaHoraExtra, "La tarifa por horas extra no puede ser negativa");
                        errores = true;
                    }
                }


                if (chkActivo.Checked == false)
                {
                    errorProvider1.SetError(chkActivo, "Marque la casilla de activo");
                }

                foreach (DataGridViewRow row in dgPaqueteDetalle.Rows)
                {
                    var cellValue = row.Cells["activo"].Value;

                    // Comprobar si el valor es nulo o no es un booleano válido
                    if (cellValue == null || !(cellValue is bool) || !(bool)cellValue)
                    {
                        errores = true;
                        MessageBox.Show("Todas las filas deben tener la columna 'Activo' marcada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

                if (!errores)
                {
                    try
                    {
                        if (MessageBox.Show("Desea guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int paqueteId;

                            if (string.IsNullOrEmpty(txtPaqueteID.Text)) // Inserción
                            {
                                // Insertar el paquete y obtener el nuevo PaqueteID
                                paqueteId = InsertarPaquete();
                                txtPaqueteID.Text = paqueteId.ToString();
                            }
                            else // Actualización
                            {
                                paqueteId = int.Parse(txtPaqueteID.Text);

                                // Actualizar el paquete en el DataSet
                                dsTablas.Tables["Paquete"].Rows[0]["nombre"] = txtNombre.Text;
                                dsTablas.Tables["Paquete"].Rows[0]["descripcion"] = txtDescripcion.Text;
                                dsTablas.Tables["Paquete"].Rows[0]["preciomensual"] = txtPrecioMensual.Text;
                                dsTablas.Tables["Paquete"].Rows[0]["cantidadhoras"] = txtCantidadHoras.Text;
                                dsTablas.Tables["Paquete"].Rows[0]["tarifahoraextra"] = txtTarifaHoraExtra.Text;
                                dsTablas.Tables["Paquete"].Rows[0]["activo"] = chkActivo.Checked;

                                adpPaquete.Update(dsTablas.Tables["Paquete"]);
                            }


                            //dsTablas.Tables["Paquete"].Rows[0]["paqueteid"] = txtPaqueteID.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["nombre"] = txtNombre.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["descripcion"] = txtDescripcion.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["preciomensual"] = txtPrecioMensual.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["cantidadhoras"] = txtCantidadHoras.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["tarifahoraextra"] = txtTarifaHoraExtra.Text;
                            dsTablas.Tables["Paquete"].Rows[0]["activo"] = chkActivo.Checked;



                            //adpPaquete.Update(dsTablas.Tables["Paquete"]);
                            prmPaqueteDetalle.Value = txtPaqueteID.Text;
                            adpPaqueteDetalle.Update(dsTablas.Tables["PaqueteDetalle"]);

                            Close();

                            if (dgPaqueteDetalle.Rows.Count > 0)
                            {
                                int lastRowIndex = dgPaqueteDetalle.Rows.Count - 1;
                                dgPaqueteDetalle.CurrentCell = dgPaqueteDetalle.Rows[lastRowIndex].Cells[1]; // Puedes ajustar el índice de la columna si es necesario
                                dgPaqueteDetalle.Rows[lastRowIndex].Selected = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    if (ex.Errors[i].Number == 2627)
                    {
                        MessageBox.Show("Los nombres de paquetes y los servicios en detalle deben ser unicos, validar estos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Errors[i].Number == 515)
                    {
                        MessageBox.Show("Por favor validar que el campo activo en el detalle este marcado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Errors[i].Message, ex.Errors[i].Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdVerServicios_Click(object sender, EventArgs e)
        {
            try
            { 
                frmPaqueteVerServicios frm = new frmPaqueteVerServicios(con);
                frm.ShowDialog();
                if (frm.FilaSeleccionada != null)
                {
                    DataRow row = dsTablas.Tables["PaqueteDetalle"].NewRow();
                    
                    row["servicioid"] = frm.FilaSeleccionada["servicioid"];
                    row["nombre"] = frm.FilaSeleccionada["nombre"];
                    row["activo"] = true;

                    dsTablas.Tables["PaqueteDetalle"].Rows.Add(row);
                    dgPaqueteDetalle.DataSource = dsTablas.Tables["PaqueteDetalle"];
                    dgPaqueteDetalle.Refresh();
                }
                else
                {
                    MessageBox.Show("No se seleccionó ningún servicio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dgPaqueteDetalle.SelectedRows.Count > 0)
            {
                object paqueteIdObj = dsTablas.Tables["PaqueteDetalle"].DefaultView[dgPaqueteDetalle.CurrentRow.Index]["paqueteid"];
                object servicioIdObj = dsTablas.Tables["PaqueteDetalle"].DefaultView[dgPaqueteDetalle.CurrentRow.Index]["servicioid"];

                if (int.TryParse(paqueteIdObj?.ToString(), out int paqueteid) &&
                    int.TryParse(servicioIdObj?.ToString(), out int servicioid))
                {
                    if (MessageBox.Show("Desea Eliminar el Servicio", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open(); // Abre la conexión si está cerrada
                            }

                            SqlCommand cmd = new SqlCommand("spPaqueteDetalleDelete", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@paqueteid", paqueteid);
                            cmd.Parameters.AddWithValue("@servicioid", servicioid);

                            
                            cmd.ExecuteNonQuery();
                            

                            // Limpia y vuelve a llenar el DataTable
                            dsTablas.Tables["PaqueteDetalle"].Clear();
                            adpPaqueteDetalle.Fill(dsTablas.Tables["PaqueteDetalle"]);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Error al eliminar el servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID del paquete o servicio no válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila de servicio para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int InsertarPaquete()
        {
            String connectionString = "Server=3.128.144.165; DataBase=DB20212000317; User ID=evelyn.sabillon; Password=ES20212000317";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spPaqueteInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de salida para capturar el PaqueteID
                    SqlParameter outputIdParam = new SqlParameter("@paqueteid", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    // Otros parámetros de entrada
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@preciomensual", float.Parse(txtPrecioMensual.Text));
                    cmd.Parameters.AddWithValue("@cantidadhoras", int.Parse(txtCantidadHoras.Text));
                    cmd.Parameters.AddWithValue("@activo", chkActivo.Checked);
                    cmd.Parameters.AddWithValue("@tarifahoraextra", float.Parse(txtTarifaHoraExtra.Text));

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener el valor del PaqueteID generado
                    return (int)outputIdParam.Value;
                }
            }
        }

    }
}