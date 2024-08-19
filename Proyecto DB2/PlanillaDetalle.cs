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
                    ConfigurarColumnas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los detalles de la planilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarColumnas()
        {
            dgPlanillaDetalle.AllowUserToAddRows = false;
            dgPlanillaDetalle.ReadOnly = false;
            dgPlanillaDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgPlanillaDetalle.Columns.Contains("PlanillaID"))
                dgPlanillaDetalle.Columns["PlanillaID"].ReadOnly = true;
            if (dgPlanillaDetalle.Columns.Contains("EmpleadoID"))
                dgPlanillaDetalle.Columns["EmpleadoID"].ReadOnly = true;
            if (dgPlanillaDetalle.Columns.Contains("NombreEmpleado"))
                dgPlanillaDetalle.Columns["NombreEmpleado"].ReadOnly = true;
            if (dgPlanillaDetalle.Columns.Contains("Activo"))
                dgPlanillaDetalle.Columns["Activo"].ReadOnly = true;

            // Configurar el formato de las columnas editables
            if (dgPlanillaDetalle.Columns.Contains("SueldoBase"))
                dgPlanillaDetalle.Columns["SueldoBase"].DefaultCellStyle.Format = "N2";
            if (dgPlanillaDetalle.Columns.Contains("HorasExtras"))
                dgPlanillaDetalle.Columns["HorasExtras"].DefaultCellStyle.Format = "N0";
            if (dgPlanillaDetalle.Columns.Contains("TarifaHorasExtras"))
                dgPlanillaDetalle.Columns["TarifaHorasExtras"].DefaultCellStyle.Format = "N2";
            if (dgPlanillaDetalle.Columns.Contains("Bonos"))
                dgPlanillaDetalle.Columns["Bonos"].DefaultCellStyle.Format = "N2";
            if (dgPlanillaDetalle.Columns.Contains("TasaIHSS"))
                dgPlanillaDetalle.Columns["TasaIHSS"].DefaultCellStyle.Format = "N2";
            if (dgPlanillaDetalle.Columns.Contains("TasaRAP"))
                dgPlanillaDetalle.Columns["TasaRAP"].DefaultCellStyle.Format = "N2";
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgPlanillaDetalle.CurrentRow != null)
            {
                int empleadoID = Convert.ToInt32(dgPlanillaDetalle.CurrentRow.Cells["EmpleadoID"].Value);
                using (var form = new EditarEmpleadoForm(planillaID, empleadoID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CargarPlanillaDetalle();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    foreach (DataGridViewRow row in dgPlanillaDetalle.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("spPlanillaDetalleUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                        cmd.Parameters.AddWithValue("@EmpleadoID", row.Cells["EmpleadoID"].Value);
                        cmd.Parameters.AddWithValue("@SueldoBase", Convert.ToDouble(row.Cells["SueldoBase"].Value));
                        cmd.Parameters.AddWithValue("@HorasExtras", Convert.ToInt32(row.Cells["HorasExtras"].Value));
                        cmd.Parameters.AddWithValue("@TarifaHorasExtras", Convert.ToDouble(row.Cells["TarifaHorasExtras"].Value));
                        cmd.Parameters.AddWithValue("@Bonos", Convert.ToDouble(row.Cells["Bonos"].Value));
                        cmd.Parameters.AddWithValue("@TasaIHSS", Convert.ToDouble(row.Cells["TasaIHSS"].Value));
                        cmd.Parameters.AddWithValue("@TasaRAP", Convert.ToDouble(row.Cells["TasaRAP"].Value));

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

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            using (var form = new SeleccionarEmpleadoForm(planillaID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CargarPlanillaDetalle();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPlanillaDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgPlanillaDetalle.Columns["SueldoBase"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TarifaHorasExtras"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["Bonos"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TasaIHSS"].Index ||
                e.ColumnIndex == dgPlanillaDetalle.Columns["TasaRAP"].Index)
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out _))
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