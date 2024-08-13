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
using static System.Collections.Specialized.BitVector32;

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

        public frmPaquete(SqlConnection conexion, int paqueteid )         {
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
            adpPaqueteDetalle.InsertCommand.Parameters.Add(prmPaqueteDetalle);  //parametro enviado como un objeto 
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
                txtPaqueteID.Enabled = false;
                dsTablas = new DataSet();

                dsTablas.Tables.Add("Paquete"); //agregar las tablas y colocando los nombres
                dsTablas.Tables.Add("PaqueteDetalle");

                adpPaquete.Fill(dsTablas.Tables["Paquete"]); //El resultado del Fill queda en el dataset y dentro del dataset se agrega a un datatable segun el nombre del datatable o el indice
                adpPaqueteDetalle.Fill(dsTablas.Tables["PaqueteDetalle"]);

                if (dsTablas.Tables["Paquete"].Rows.Count == 0)  //se usan los mismos metodos de un datatablle
                {
                    dsTablas.Tables["Paquete"].Rows.Add();
                    

                }
                else
                {
                    txtPaqueteID.Text = dsTablas.Tables["Paquete"].Rows[0]["paqueteid"].ToString();
                    txtNombre.Text = dsTablas.Tables["Paquete"].Rows[0]["nombre"].ToString();
                    txtDescripcion.Text = dsTablas.Tables["Paquete"].Rows[0]["descripcion"].ToString();
                    txtPrecioMensual.Text = dsTablas.Tables["Paquete"].Rows[0]["preciomensual"].ToString();
                    txtCantidadHoras.Text = dsTablas.Tables["Paquete"].Rows[0]["cantidadhoras"].ToString();
                    txtTarifaHoraExtra.Text = dsTablas.Tables["Paquete"].Rows[0]["tarifahoraextra"].ToString();
                    chkActivo.Checked = (bool)dsTablas.Tables["Paquete"].Rows[0]["activo"];

                }

                dgPaqueteDetalle.DataSource = dsTablas.Tables["PaqueteDetalle"];

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

                if (!float.TryParse(txtPrecioMensual.Text, out _))
                {
                    errorProvider1.SetError(txtPrecioMensual, "El precio mensual debe ser un número, no una letra");
                    errores = true;
                }

                if (float.Parse(txtPrecioMensual.Text) < 0)
                {
                    errorProvider1.SetError(txtPrecioMensual, "El precio mensual no puede ser un número negativo");
                    errores = true;
                }


                if (txtCantidadHoras.Text.Length == 0)
                {
                    errorProvider1.SetError(txtCantidadHoras, "Falta las horas de soporte del paquete");
                    errores = true;
                }

                if (!float.TryParse(txtCantidadHoras.Text, out _))
                {
                    errorProvider1.SetError(txtCantidadHoras, "Las horas de soporte deben ser numeros");
                    errores = true;
                }

                if (float.Parse(txtCantidadHoras.Text) < 0)
                {
                    errorProvider1.SetError(txtCantidadHoras, "Las horas de soporte no pueden ser un número negativo");
                    errores = true;
                }

                if (txtTarifaHoraExtra.Text.Length == 0)
                {
                    errorProvider1.SetError(txtTarifaHoraExtra, "Falta la tarifa por horas extra");
                    errores = true;
                }

                if (!float.TryParse(txtTarifaHoraExtra.Text, out _))
                {
                    errorProvider1.SetError(txtTarifaHoraExtra, "La tarifa por horas extra debe ser un numero");
                    errores = true;
                }

                if (float.Parse(txtTarifaHoraExtra.Text) < 0)
                {
                    errorProvider1.SetError(txtTarifaHoraExtra, "La tarifa por horas extra no puede ser un número negativo");
                    errores = true;
                }



                if (chkActivo.Checked == false)
                {
                    errorProvider1.SetError(chkActivo, "Marque la casilla de activo");

                }


                if (!errores)
                {
                    if (MessageBox.Show("Desea guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        dsTablas.Tables["Paquete"].Rows[0]["paqueteid"] = txtPaqueteID.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["nombre"] = txtNombre.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["descripcion"] = txtDescripcion.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["preciomensual"] = txtPrecioMensual.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["cantidadhoras"] = txtCantidadHoras.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["tarifahoraextra"] = txtTarifaHoraExtra.Text;
                        dsTablas.Tables["Paquete"].Rows[0]["activo"] = chkActivo.Checked;

                        prmPaqueteDetalle.Value = txtPaqueteID.Text;

                        adpPaquete.Update(dsTablas.Tables["Paquete"]);
                        adpPaqueteDetalle.Update(dsTablas.Tables["PaqueteDetalle"]);

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
                        MessageBox.Show("Los nombres de paquetes  deben ser unicos, validar este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Errors[i].Message, ex.Errors[i].Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
