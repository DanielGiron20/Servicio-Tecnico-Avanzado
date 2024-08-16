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

namespace Proyecto_DB2
{
    public partial class PuestoEmpleado : Form
    {
        private CConexion conexion;
        private SqlDataAdapter adp;
        private DataTable tabPuesto;

        public PuestoEmpleado()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(PuestoEmpleado_Load);
        }

        private void ConfigurarDataAdapter()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp = new SqlDataAdapter("EXEC spPuestoSelect", con);

                    adp.InsertCommand = new SqlCommand("spPuestoInsert", con);
                    adp.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adp.InsertCommand.Parameters.Add("@PuestoID", SqlDbType.Int, 0, "PuestoID");
                    adp.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                    adp.InsertCommand.Parameters.Add("@AreaID", SqlDbType.Int, 0, "AreaID");
                    adp.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit, 1, "Activo");

                    adp.UpdateCommand = new SqlCommand("spPuestoUpdate", con);
                    adp.UpdateCommand.CommandType = CommandType.StoredProcedure;
                    adp.UpdateCommand.Parameters.Add("@PuestoID", SqlDbType.Int, 0, "PuestoID");
                    adp.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                    adp.UpdateCommand.Parameters.Add("@AreaID", SqlDbType.Int, 0, "AreaID");
                    adp.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit, 1, "Activo");

                    adp.DeleteCommand = new SqlCommand("spPuestoDelete", con);
                    adp.DeleteCommand.CommandType = CommandType.StoredProcedure;
                    adp.DeleteCommand.Parameters.Add("@PuestoID", SqlDbType.Int, 0, "PuestoID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el DataAdapter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PuestoEmpleado_Load(object sender, EventArgs e)
        {
            ConfigurarDataAdapter();
            CargarPuestos();
        }

        private void CargarPuestos()
        {
            try
            {
                tabPuesto = new DataTable();
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp.SelectCommand.Connection = con;
                    adp.Fill(tabPuesto);
                }
                dgPuestoEmpleado.DataSource = tabPuesto;

                dgPuestoEmpleado.Columns["PuestoID"].ReadOnly = true;
                dgPuestoEmpleado.Columns["PuestoID"].DefaultCellStyle.BackColor = Color.LightGray;
                dgPuestoEmpleado.Columns["Activo"].DisplayIndex = dgPuestoEmpleado.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DataRow newRow = tabPuesto.NewRow();
            newRow["PuestoID"] = tabPuesto.Rows.Count > 0 ? Convert.ToInt32(tabPuesto.Compute("MAX(PuestoID)", "")) + 1 : 1;
            newRow["Nombre"] = "";
            newRow["AreaID"] = DBNull.Value;
            newRow["Activo"] = true;
            tabPuesto.Rows.Add(newRow);

            dgPuestoEmpleado.CurrentCell = dgPuestoEmpleado.Rows[dgPuestoEmpleado.Rows.Count - 1].Cells["Nombre"];
            dgPuestoEmpleado.BeginEdit(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dgPuestoEmpleado.EndEdit();

                foreach (DataRow row in tabPuesto.Rows)
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

                    int result = adp.Update(tabPuesto);
                    if (result > 0)
                    {
                        MessageBox.Show($"{result} registro(s) guardado(s) con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPuestos();
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
            if (dgPuestoEmpleado.CurrentRow != null)
            {
                dgPuestoEmpleado.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un puesto para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgPuestoEmpleado.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este puesto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgPuestoEmpleado.Rows.RemoveAt(dgPuestoEmpleado.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un puesto para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

