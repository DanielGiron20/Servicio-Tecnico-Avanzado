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
        public int EmpleadoSeleccionadoID { get; private set; }
        public string EmpleadoSeleccionadoNombre { get; private set; }
        private int planillaID;
        public SeleccionarEmpleadoForm(int planillaID)
        {
            InitializeComponent();
            conexion = new CConexion();
            this.planillaID = planillaID;
            this.Load += new EventHandler(SeleccionarEmpleadoForm_Load);
        }
        private void SeleccionarEmpleadoForm_Load(object sender, EventArgs e)
        {
            CargarEmpleadosDisponibles();
        }
        private void CargarEmpleadosDisponibles()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    string query = @"SELECT e.EmpleadoID, e.Nombre 
                                     FROM Empleado e 
                                     WHERE e.Activo = 1 AND e.EmpleadoID NOT IN 
                                     (SELECT EmpleadoID FROM PlanillaDetalle WHERE PlanillaID = @PlanillaID)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PlanillaID", planillaID);
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        dgEmpleados.DataSource = dt;
                        dgEmpleados.Columns["EmpleadoID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgEmpleados.CurrentRow != null)
            {
                EmpleadoSeleccionadoID = Convert.ToInt32(dgEmpleados.CurrentRow.Cells["EmpleadoID"].Value);
                EmpleadoSeleccionadoNombre = dgEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}