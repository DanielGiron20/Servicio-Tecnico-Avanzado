using Proyecto_DB2;
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
    public partial class Planilla : Form
    {
        private CConexion conexion;

        public Planilla()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(Planilla_Load);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Planilla_Load(object sender, EventArgs e)
        {
            CargarPlanillas();
        }

        private void CargarPlanillas()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spPlanillaSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgPlanilla.DataSource = dt;
                    dgPlanilla.Columns["PlanillaID"].ReadOnly = true;
                    dgPlanilla.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las planillas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spPlanillaInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Periodo", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = true;

                    SqlParameter outputParameter = new SqlParameter("@PlanillaID", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    cmd.ExecuteNonQuery();

                    int newPlanillaID = Convert.ToInt32(cmd.Parameters["@PlanillaID"].Value);

                    MessageBox.Show($"Nueva planilla creada con éxito. ID: {newPlanillaID}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPlanillas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear nueva planilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    foreach (DataGridViewRow row in dgPlanilla.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("spPlanillaUpdate", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PlanillaID", row.Cells["PlanillaID"].Value);
                        cmd.Parameters.AddWithValue("@Periodo", row.Cells["Periodo"].Value);
                        cmd.Parameters.AddWithValue("@Activo", row.Cells["Activo"].Value);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cambios guardados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPlanillas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgPlanilla.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta planilla?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = conexion.EstablecerConexion())
                    {
                        try
                        {
                            int planillaID = Convert.ToInt32(dgPlanilla.CurrentRow.Cells["PlanillaID"].Value);

                            SqlCommand cmd = new SqlCommand("spPlanillaDelete", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PlanillaID", planillaID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Planilla eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPlanillas();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la planilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una planilla para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgPlanilla.CurrentRow != null)
            {
                int planillaID = Convert.ToInt32(dgPlanilla.CurrentRow.Cells["PlanillaID"].Value);
                PlanillaDetalle formDetalle = new PlanillaDetalle(planillaID);
                formDetalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una planilla para ver sus detalles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}