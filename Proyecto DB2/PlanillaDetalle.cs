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
    public partial class PlanillaDetalle : Form
    {
        private CConexion conexion;
        private int planillaID;

        public PlanillaDetalle(int planillaID)
        {
            InitializeComponent();
            conexion = new CConexion();
            this.planillaID = planillaID;
            this.Load += new EventHandler(PlanillaDetalle_Load);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void PlanillaDetalle_Load(object sender, EventArgs e)
        {
            CargarPlanillaDetalle();
            ActualizarTitulo();
        }

        private void ActualizarTitulo()
        {
            this.Text = $"Detalle de Planilla - ID: {planillaID}";
            lblTitulo.Text = $"Detalle de Planilla - ID: {planillaID}";
        }

        private void CargarPlanillaDetalle()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spPlanillaDetalleSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlanillaID", planillaID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgPlanillaDetalle.DataSource = dt;
                    dgPlanillaDetalle.Columns["PlanillaID"].ReadOnly = true;
                    dgPlanillaDetalle.Columns["EmpleadoID"].ReadOnly = true;
                    if (dgPlanillaDetalle.Columns.Contains("NombreEmpleado"))
                    {
                        dgPlanillaDetalle.Columns["NombreEmpleado"].ReadOnly = true;
                    }
                    dgPlanillaDetalle.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los detalles de la planilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            using (var form = new SeleccionarEmpleadoForm(planillaID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int empleadoID = form.EmpleadoSeleccionadoID;
                    string nombreEmpleado = form.EmpleadoSeleccionadoNombre;

                    using (SqlConnection con = conexion.EstablecerConexion())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("spPlanillaDetalleUpsert", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                            cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                            cmd.Parameters.AddWithValue("@SueldoBase", 0);
                            cmd.Parameters.AddWithValue("@HorasExtras", 0);
                            cmd.Parameters.AddWithValue("@TarifaHorasExtras", 0);
                            cmd.Parameters.AddWithValue("@Bonos", 0);
                            cmd.Parameters.AddWithValue("@TasaIHSS", 0);
                            cmd.Parameters.AddWithValue("@TasaRAP", 0);
                            cmd.Parameters.AddWithValue("@Activo", true);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Empleado agregado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPlanillaDetalle();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al agregar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    foreach (DataGridViewRow row in dgPlanillaDetalle.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("spPlanillaDetalleUpsert", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                        cmd.Parameters.AddWithValue("@EmpleadoID", row.Cells["EmpleadoID"].Value);
                        cmd.Parameters.AddWithValue("@SueldoBase", row.Cells["SueldoBase"].Value);
                        cmd.Parameters.AddWithValue("@HorasExtras", row.Cells["HorasExtras"].Value);
                        cmd.Parameters.AddWithValue("@TarifaHorasExtras", row.Cells["TarifaHorasExtras"].Value);
                        cmd.Parameters.AddWithValue("@Bonos", row.Cells["Bonos"].Value);
                        cmd.Parameters.AddWithValue("@TasaIHSS", row.Cells["TasaIHSS"].Value);
                        cmd.Parameters.AddWithValue("@TasaRAP", row.Cells["TasaRAP"].Value);
                        cmd.Parameters.AddWithValue("@Activo", row.Cells["Activo"].Value);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cambios guardados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPlanillaDetalle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea cancelar los cambios?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CargarPlanillaDetalle();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPlanillaDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgPlanillaDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightYellow;
            }
        }

        private void dgPlanillaDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgPlanillaDetalle.Columns["SueldoBase"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TarifaHorasExtras"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["Bonos"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TasaIHSS"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TasaRAP"].Index)
            {
                if (!float.TryParse(e.FormattedValue.ToString(), out _))
                {
                    e.Cancel = true;
                    MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == dgPlanillaDetalle.Columns["HorasExtras"].Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    e.Cancel = true;
                    MessageBox.Show("Por favor, ingrese un número entero válido para las horas extras.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}