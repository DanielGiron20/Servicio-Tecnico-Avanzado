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

        public ConsultaAreasPuestos()
        {
            InitializeComponent();
            conexion = new CConexion();
            this.Load += new EventHandler(ConsultaAreasPuestos_Load);
        }

        private void ConsultaAreasPuestos_Load(object sender, EventArgs e)
        {
            CargarAreas();
        }

        private void CargarAreas()
        {
            try
            {
                using (SqlConnection con = conexion.EstablecerConexion())
                {
                    adpAreas = new SqlDataAdapter("SELECT AreaID, Nombre FROM Area WHERE Activo = 1", con);
                    tabAreas = new DataTable();
                    adpAreas.Fill(tabAreas);
                    cmbArea.DataSource = tabAreas;
                    cmbArea.DisplayMember = "Nombre";
                    cmbArea.ValueMember = "AreaID";
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
                    dgAreaPuestos.DataSource = tabPuestos;  // Corregido aquí
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedValue != null)
            {
                int areaId = Convert.ToInt32(cmbArea.SelectedValue);
                CargarPuestos(areaId);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}