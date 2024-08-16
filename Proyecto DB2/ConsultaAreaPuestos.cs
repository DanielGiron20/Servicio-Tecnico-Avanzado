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
using System.Data.SqlClient;

namespace Proyecto_DB2
{
    public partial class ConsultaAreasPuestos : Form
    {
        private CConexion conexion;
        private SqlDataAdapter adpAreas;
        private SqlDataAdapter adpPuestos;
        private DataTable tabAreas;
        private DataTable tabPuestos;
        private bool isInitializing = true;

        public ConsultaAreasPuestos()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(ConsultaAreasPuestos_Load);
            cmbArea.SelectedIndexChanged += new EventHandler(cmbArea_SelectedIndexChanged);
        }

        private void ConsultaAreasPuestos_Load(object sender, EventArgs e)
        {
            CargarAreas();
            isInitializing = false;
            if (cmbArea.Items.Count > 0)
            {
                cmbArea.SelectedIndex = 0;
                CargarPuestosParaAreaSeleccionada();
            }
        }

        private void CargarAreas()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    string query = "SELECT AreaID, Nombre FROM Area WHERE Activo = 1";
                    adpAreas = new SqlDataAdapter(query, con);
                    tabAreas = new DataTable();
                    adpAreas.Fill(tabAreas);

                    if (tabAreas.Rows.Count > 0)
                    {
                        cmbArea.DataSource = tabAreas;
                        cmbArea.DisplayMember = "Nombre";
                        cmbArea.ValueMember = "AreaID";
                    }
                    else
                    {
                        MessageBox.Show("No hay áreas disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las áreas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPuestos(int areaId)
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adpPuestos = new SqlDataAdapter("EXEC spObtenerPuestosPorArea @AreaID", con);
                    adpPuestos.SelectCommand.Parameters.AddWithValue("@AreaID", areaId);
                    tabPuestos = new DataTable();
                    adpPuestos.Fill(tabPuestos);

                    dgAreaPuestos.DataSource = tabPuestos;
                    dgAreaPuestos.Refresh();

                    if (tabPuestos.Rows.Count == 0)
                    {
                        MessageBox.Show($"No se encontraron puestos para el área seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                CargarPuestosParaAreaSeleccionada();
            }
        }

        private void CargarPuestosParaAreaSeleccionada()
        {
            if (cmbArea.SelectedValue != null && int.TryParse(cmbArea.SelectedValue.ToString(), out int areaId))
            {
                CargarPuestos(areaId);
            }
            else
            {
                dgAreaPuestos.DataSource = null;
                dgAreaPuestos.Refresh();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}