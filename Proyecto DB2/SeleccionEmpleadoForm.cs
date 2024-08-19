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
    public partial class SeleccionarEmpleadoForm : Form
    {
        private CConexion conexion;
        private int planillaID;
        public int EmpleadoSeleccionadoID { get; private set; }
        public string EmpleadoSeleccionadoNombre { get; private set; }

        public SeleccionarEmpleadoForm(int planillaID)
        {
            InitializeComponent();
            conexion = new CConexion();
            this.planillaID = planillaID;
            this.Load += new EventHandler(SeleccionarEmpleadoForm_Load);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void SeleccionarEmpleadoForm_Load(object sender, EventArgs e)
        {
            CargarEmpleadosDisponibles();
        }

        private void CargarEmpleadosDisponibles()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spObtenerEmpleadosDisponibles", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlanillaID", planillaID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgEmpleadosDisponibles.DataSource = dt;
                    ConfigurarColumnas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los empleados disponibles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarColumnas()
        {
            dgEmpleadosDisponibles.Columns["EmpleadoID"].Visible = false;
            dgEmpleadosDisponibles.Columns["Nombre"].HeaderText = "Nombre del Empleado";
            dgEmpleadosDisponibles.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgEmpleadosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgEmpleadosDisponibles.MultiSelect = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgEmpleadosDisponibles.SelectedRows.Count > 0)
            {
                EmpleadoSeleccionadoID = Convert.ToInt32(dgEmpleadosDisponibles.SelectedRows[0].Cells["EmpleadoID"].Value);
                EmpleadoSeleccionadoNombre = dgEmpleadosDisponibles.SelectedRows[0].Cells["Nombre"].Value.ToString();

                AgregarEmpleadoAPlanilla();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado para agregar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AgregarEmpleadoAPlanilla()
        {
            using (SqlConnection con = conexion.EstablecerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spPlanillaDetalleUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                    cmd.Parameters.AddWithValue("@EmpleadoID", EmpleadoSeleccionadoID);
                    cmd.Parameters.AddWithValue("@SueldoBase", 0.0);
                    cmd.Parameters.AddWithValue("@HorasExtras", 0);
                    cmd.Parameters.AddWithValue("@TarifaHorasExtras", 0.0);
                    cmd.Parameters.AddWithValue("@Bonos", 0.0);
                    cmd.Parameters.AddWithValue("@TasaIHSS", 0.0);
                    cmd.Parameters.AddWithValue("@TasaRAP", 0.0);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Empleado agregado a la planilla con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el empleado a la planilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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