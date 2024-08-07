using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Claims;



namespace Proyecto_DB2
{
    public partial class AreaEmpleado : Form
    {
        private CConexion conexion;
        private SqlDataAdapter adp;
        private DataTable tabArea;

        public AreaEmpleado()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(AreaEmpleado_Load);
        }

        private void ConfigurarDataAdapter()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp = new SqlDataAdapter("EXEC spAreaSelect", con);

                    adp.InsertCommand = new SqlCommand("spAreaInsert", con);
                    adp.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adp.InsertCommand.Parameters.Add("@AreaID", SqlDbType.Int, 0, "AreaID");
                    adp.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                    adp.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit, 1, "Activo");

                    adp.UpdateCommand = new SqlCommand("spAreaUpdate", con);
                    adp.UpdateCommand.CommandType = CommandType.StoredProcedure;
                    adp.UpdateCommand.Parameters.Add("@AreaID", SqlDbType.Int, 0, "AreaID");
                    adp.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                    adp.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit, 1, "Activo");

                    adp.DeleteCommand = new SqlCommand("spAreaDelete", con);
                    adp.DeleteCommand.CommandType = CommandType.StoredProcedure;
                    adp.DeleteCommand.Parameters.Add("@AreaID", SqlDbType.Int, 0, "AreaID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el DataAdapter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AreaEmpleado_Load(object sender, EventArgs e)
        {
            ConfigurarDataAdapter();
            CargarAreas();
        }

        private void CargarAreas()
        {
            try
            {
                tabArea = new DataTable();
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp.SelectCommand.Connection = con;
                    adp.Fill(tabArea);
                }
                dgAreaEmpleado.DataSource = tabArea;

                dgAreaEmpleado.Columns["AreaID"].ReadOnly = true;
                dgAreaEmpleado.Columns["AreaID"].DefaultCellStyle.BackColor = Color.LightGray;
                dgAreaEmpleado.Columns["Activo"].DisplayIndex = dgAreaEmpleado.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las áreas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DataRow newRow = tabArea.NewRow();
            newRow["AreaID"] = tabArea.Rows.Count > 0 ? Convert.ToInt32(tabArea.Compute("MAX(AreaID)", "")) + 1 : 1;
            newRow["Nombre"] = "";
            newRow["Activo"] = true;
            tabArea.Rows.Add(newRow);

            dgAreaEmpleado.CurrentCell = dgAreaEmpleado.Rows[dgAreaEmpleado.Rows.Count - 1].Cells["Nombre"];
            dgAreaEmpleado.BeginEdit(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dgAreaEmpleado.EndEdit();

                foreach (DataRow row in tabArea.Rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        if (string.IsNullOrWhiteSpace(row["Nombre"].ToString()))
                        {
                            MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp.InsertCommand.Connection = con;
                    adp.UpdateCommand.Connection = con;
                    adp.DeleteCommand.Connection = con;

                    int result = adp.Update(tabArea);
                    if (result > 0)
                    {
                        MessageBox.Show($"{result} registro(s) guardado(s) con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAreas();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgAreaEmpleado.CurrentRow != null)
            {
                dgAreaEmpleado.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un área para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgAreaEmpleado.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta área?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgAreaEmpleado.Rows.RemoveAt(dgAreaEmpleado.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un área para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultaAreasPuestos formConsulta = new ConsultaAreasPuestos();
            formConsulta.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}