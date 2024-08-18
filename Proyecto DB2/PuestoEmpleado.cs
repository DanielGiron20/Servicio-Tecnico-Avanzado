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
    public partial class PuestoEmpleado : Form
    {
        private CConexion conexion;
        private SqlDataAdapter adp;
        private DataTable tabPuesto;
        private int ultimoID = 0;

        public PuestoEmpleado()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(PuestoEmpleado_Load);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ConfigurarDataAdapter()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp = new SqlDataAdapter(@"SELECT p.PuestoID, p.Nombre, p.AreaID, a.Nombre AS AreaNombre, p.Activo 
                                               FROM Puesto p 
                                               INNER JOIN Area a ON p.AreaID = a.AreaID", con);

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
            ConfigurarComboBox();
            CargarPuestos("Todos");
            ConfigurarDataGridView();
        }

        private void ConfigurarComboBox()
        {
            cmbVerPuestos.Items.Clear();
            cmbVerPuestos.Items.Add("Todos");
            cmbVerPuestos.Items.Add("Activos");
            cmbVerPuestos.Items.Add("Inactivos");
            cmbVerPuestos.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {
            dgPuestoEmpleado.AllowUserToAddRows = false;
            dgPuestoEmpleado.ReadOnly = true;
        }

        private void CargarPuestos(string filtro)
        {
            try
            {
                tabPuesto = new DataTable();
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    string query = @"SELECT p.PuestoID, p.Nombre, p.AreaID, a.Nombre AS AreaNombre, p.Activo 
                                     FROM Puesto p 
                                     INNER JOIN Area a ON p.AreaID = a.AreaID";

                    if (filtro == "Activos")
                        query += " WHERE p.Activo = 1";
                    else if (filtro == "Inactivos")
                        query += " WHERE p.Activo = 0";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            tabPuesto.Load(reader);
                        }
                    }
                }
                dgPuestoEmpleado.DataSource = tabPuesto;

                dgPuestoEmpleado.Columns["PuestoID"].ReadOnly = true;
                dgPuestoEmpleado.Columns["PuestoID"].DefaultCellStyle.BackColor = Color.LightGray;
                dgPuestoEmpleado.Columns["Activo"].DisplayIndex = dgPuestoEmpleado.Columns.Count - 1;

                dgPuestoEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (tabPuesto.Rows.Count > 0)
                {
                    ultimoID = tabPuesto.AsEnumerable().Max(row => row.Field<int>("PuestoID"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (frmEditarPuesto formNuevo = new frmEditarPuesto(conexion, 0, "", 0, true))
            {
                if (formNuevo.ShowDialog() == DialogResult.OK)
                {
                    ultimoID++;
                    DataRow newRow = tabPuesto.NewRow();
                    newRow["PuestoID"] = ultimoID;
                    newRow["Nombre"] = formNuevo.NombrePuesto;
                    newRow["AreaID"] = formNuevo.AreaID;
                    newRow["AreaNombre"] = formNuevo.AreaNombre;
                    newRow["Activo"] = formNuevo.Activo;
                    tabPuesto.Rows.Add(newRow);
                    dgPuestoEmpleado.Refresh();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adp.InsertCommand.Connection = con;
                    adp.UpdateCommand.Connection = con;
                    adp.DeleteCommand.Connection = con;
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            adp.InsertCommand.Transaction = transaction;
                            adp.UpdateCommand.Transaction = transaction;
                            adp.DeleteCommand.Transaction = transaction;

                            int result = adp.Update(tabPuesto);
                            transaction.Commit();

                            if (result > 0)
                            {
                                MessageBox.Show($"{result} registro(s) guardado(s) con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarPuestos(cmbVerPuestos.SelectedItem.ToString());

                            }
                            else
                            {
                                MessageBox.Show("No se realizaron cambios en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error al guardar los cambios: {ex.Message}", ex);
                        }
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
            if (dgPuestoEmpleado.CurrentRow != null)
            {
                int puestoId = Convert.ToInt32(dgPuestoEmpleado.CurrentRow.Cells["PuestoID"].Value);
                string nombre = dgPuestoEmpleado.CurrentRow.Cells["Nombre"].Value.ToString();
                int areaId = Convert.ToInt32(dgPuestoEmpleado.CurrentRow.Cells["AreaID"].Value);
                bool activo = Convert.ToBoolean(dgPuestoEmpleado.CurrentRow.Cells["Activo"].Value);
                using (frmEditarPuesto formEditar = new frmEditarPuesto(conexion, puestoId, nombre, areaId, activo))
                {
                    if (formEditar.ShowDialog() == DialogResult.OK)
                    {
                        dgPuestoEmpleado.CurrentRow.Cells["Nombre"].Value = formEditar.NombrePuesto;
                        dgPuestoEmpleado.CurrentRow.Cells["AreaID"].Value = formEditar.AreaID;
                        dgPuestoEmpleado.CurrentRow.Cells["AreaNombre"].Value = formEditar.AreaNombre;
                        dgPuestoEmpleado.CurrentRow.Cells["Activo"].Value = formEditar.Activo;
                        dgPuestoEmpleado.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un puesto para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgPuestoEmpleado.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este puesto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dgPuestoEmpleado.CurrentRow.Index;
                    dgPuestoEmpleado.Rows.RemoveAt(rowIndex);
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

        private void cmbVerPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVerPuestos.SelectedItem != null)
            {
                CargarPuestos(cmbVerPuestos.SelectedItem.ToString());
            }
        }
    }

    internal class frmEditarPuesto : Form
    {
        private CConexion conexion;
        private int puestoId;
        private TextBox txtNombre;
        private ComboBox cmbArea;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblNombre;
        private Label lblArea;

        public string NombrePuesto { get; private set; }
        public int AreaID { get; private set; }
        public string AreaNombre { get; private set; }
        public bool Activo { get; private set; }

        public frmEditarPuesto(CConexion conexion, int puestoId, string nombre, int areaId, bool activo)
        {
            this.conexion = conexion;
            this.puestoId = puestoId;
            InitializeComponent();
            CargarAreas();
            txtNombre.Text = nombre;
            cmbArea.SelectedValue = areaId;
            chkActivo.Checked = activo;
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.cmbArea = new ComboBox();
            this.chkActivo = new CheckBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.lblNombre = new Label();
            this.lblArea = new Label();

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(12, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(50, 13);
            this.lblNombre.Text = "Nombre:";

            this.txtNombre.Location = new Point(70, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(250, 20);

            this.lblArea.AutoSize = true;
            this.lblArea.Location = new Point(12, 45);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new Size(32, 13);

            this.lblArea.Text = "Área:";

            this.cmbArea.Location = new Point(70, 42);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new Size(250, 21);
            this.cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;

            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new Point(70, 70);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new Size(56, 17);
            this.chkActivo.Text = "Activo";

            this.btnGuardar.Location = new Point(70, 100);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(100, 23);
            this.btnGuardar.Text = "Guardar";

            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);

            this.btnCancelar.Location = new Point(180, 100);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(100, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);

            this.ClientSize = new Size(340, 140);
            this.ClientSize = new Size(340, 140);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmEditarPuesto";
            this.Text = puestoId == 0 ? "Nuevo Puesto" : "Editar Puesto";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = this.btnGuardar;
            this.CancelButton = this.btnCancelar;
        }
        private void CargarAreas()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT AreaID, Nombre FROM Area WHERE Activo = 1", con))
                    {
                        using (SqlDataAdapter adpAreas = new SqlDataAdapter(cmd))
                        {
                            DataTable tabAreas = new DataTable();
                            adpAreas.Fill(tabAreas);
                            cmbArea.DataSource = tabAreas;
                            cmbArea.DisplayMember = "Nombre";
                            cmbArea.ValueMember = "AreaID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las áreas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del puesto no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbArea.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NombrePuesto = txtNombre.Text;
            AreaID = Convert.ToInt32(cmbArea.SelectedValue);
            AreaNombre = cmbArea.Text;
            Activo = chkActivo.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}