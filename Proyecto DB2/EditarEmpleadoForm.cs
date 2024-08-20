using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class EditarEmpleadoForm : Form
    {
        private CConexion conexion;
        private int planillaID;
        private int empleadoID;

        public EditarEmpleadoForm(int planillaID, int empleadoID)
        {
            InitializeComponent();
            conexion = new CConexion();
            this.planillaID = planillaID;
            this.empleadoID = empleadoID;
            this.Load += new EventHandler(EditarEmpleadoForm_Load);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void EditarEmpleadoForm_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleado();
        }

        private void CargarDatosEmpleado()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spObtenerDatosEmpleadoPlanilla", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombreEmpleado.Text = reader["NombreEmpleado"].ToString();
                        txtSueldoBase.Text = reader["SueldoBase"].ToString();
                        txtHorasExtras.Text = reader["HorasExtras"].ToString();
                        txtTarifaHorasExtras.Text = reader["TarifaHorasExtras"].ToString();
                        txtBonos.Text = reader["Bonos"].ToString();
                        txtTasaIHSS.Text = reader["TasaIHSS"].ToString();
                        txtTasaRAP.Text = reader["TasaRAP"].ToString();
                        chkActivo.Checked = Convert.ToBoolean(reader["Activo"]);
                        chkActivo.Enabled = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spPlanillaDetalleUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.Parameters.AddWithValue("@SueldoBase", Convert.ToDouble(txtSueldoBase.Text));
                    cmd.Parameters.AddWithValue("@HorasExtras", Convert.ToInt32(txtHorasExtras.Text));
                    cmd.Parameters.AddWithValue("@TarifaHorasExtras", Convert.ToDouble(txtTarifaHorasExtras.Text));
                    cmd.Parameters.AddWithValue("@Bonos", Convert.ToDouble(txtBonos.Text));
                    cmd.Parameters.AddWithValue("@TasaIHSS", Convert.ToDouble(txtTasaIHSS.Text));
                    cmd.Parameters.AddWithValue("@TasaRAP", Convert.ToDouble(txtTasaRAP.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Datos del empleado actualizados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar los datos del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}