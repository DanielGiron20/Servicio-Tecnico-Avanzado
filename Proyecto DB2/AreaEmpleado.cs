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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ConfigurarDataAdapter()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp = new SqlDataAdapter("EXEC spAreaSelectTodas", con);

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
            ConfigurarComboBox();
            CargarAreas("Todas");
        }

        private void ConfigurarComboBox()
        {
            cmbVerAreas.Items.Add("Todas");
            cmbVerAreas.Items.Add("Activas");
            cmbVerAreas.Items.Add("Inactivas");
            cmbVerAreas.SelectedIndex = 0;
        }

        private void CargarAreas(string filtro)
        {
            try
            {
                tabArea = new DataTable();
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    string spName = "spAreaSelectTodas";
                    switch (filtro)
                    {
                        case "Activas":
                            spName = "spAreaSelectActivas";
                            break;
                        case "Inactivas":
                            spName = "spAreaSelectInactivas";
                            break;
                    }

                    adp.SelectCommand = new SqlCommand(spName, con);
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adp.Fill(tabArea);
                }
                dgAreaEmpleado.DataSource = tabArea;

                dgAreaEmpleado.Columns["AreaID"].ReadOnly = true;
                dgAreaEmpleado.Columns["AreaID"].DefaultCellStyle.BackColor = Color.LightGray;
                dgAreaEmpleado.Columns["Activo"].DisplayIndex = dgAreaEmpleado.Columns.Count - 1;

                dgAreaEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                    if (row.RowState != DataRowState.Unchanged && row.RowState != DataRowState.Deleted)
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
                        CargarAreas(cmbVerAreas.SelectedItem.ToString());
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgAreaEmpleado.CurrentRow != null)
            {
                int areaId = Convert.ToInt32(dgAreaEmpleado.CurrentRow.Cells["AreaID"].Value);
                string nombre = dgAreaEmpleado.CurrentRow.Cells["Nombre"].Value.ToString();
                bool activo = Convert.ToBoolean(dgAreaEmpleado.CurrentRow.Cells["Activo"].Value);

                using (frmEditarArea formEditar = new frmEditarArea(conexion, areaId, nombre, activo))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        CargarAreas(cmbVerAreas.SelectedItem.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un área para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgAreaEmpleado.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta área?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dgAreaEmpleado.CurrentRow.Index;
                    tabArea.Rows[rowIndex].Delete();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un área para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (ConsultaAreasPuestos formConsulta = new ConsultaAreasPuestos())
            {
                formConsulta.ShowDialog(this);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbVerAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAreas(cmbVerAreas.SelectedItem.ToString());
        }
    }

    internal class frmEditarArea : Form
    {
        private CConexion conexion;
        private int areaId;
        private TextBox txtNombre;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;

        public frmEditarArea(CConexion conexion, int areaId, string nombre, bool activo)
        {
            this.conexion = conexion;
            this.areaId = areaId;
            InitializeComponent();
            txtNombre.Text = nombre;
            chkActivo.Checked = activo;
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.chkActivo = new CheckBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();

            this.txtNombre.Location = new Point(12, 12);
            this.chkActivo.Location = new Point(12, 40);
            this.btnGuardar.Location = new Point(12, 70);
            this.btnCancelar.Location = new Point(100, 70);

            this.chkActivo.Text = "Activo";
            this.btnGuardar.Text = "Guardar";
            this.btnCancelar.Text = "Cancelar";

            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            this.Text = "Editar Área";
            this.Size = new Size(250, 150);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = conexion.EstablecerConexion();
                SqlCommand cmd = new SqlCommand("spAreaUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AreaID", areaId);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Activo", chkActivo.Checked);

                cmd.ExecuteNonQuery();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el área: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
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