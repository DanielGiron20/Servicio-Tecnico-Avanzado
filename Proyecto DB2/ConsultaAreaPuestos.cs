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
            txtBuscar.TextChanged += new EventHandler(txtBuscar_TextChanged);
            this.StartPosition = FormStartPosition.CenterScreen;
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
                    string query = @"
                        SELECT a.AreaID, a.Nombre, COUNT(e.EmpleadoID) AS CantidadEmpleados 
                        FROM Area a
                        LEFT JOIN Puesto p ON a.AreaID = p.AreaID
                        LEFT JOIN Empleado e ON p.PuestoID = e.PuestoID
                        WHERE a.Activo = 1
                        GROUP BY a.AreaID, a.Nombre";

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
                    string query = @"
                        SELECT P.PuestoID, P.Nombre AS NombrePuesto, 
                               COUNT(E.EmpleadoID) AS CantidadEmpleados
                        FROM Puesto P
                        LEFT JOIN Empleado E ON P.PuestoID = E.PuestoID
                        WHERE P.AreaID = @AreaID AND P.Activo = 1
                        GROUP BY P.PuestoID, P.Nombre";

                    adpPuestos = new SqlDataAdapter(query, con);
                    adpPuestos.SelectCommand.Parameters.AddWithValue("@AreaID", areaId);
                    tabPuestos = new DataTable();
                    adpPuestos.Fill(tabPuestos);

                    dgAreaPuestos.DataSource = tabPuestos;
                    dgAreaPuestos.AutoResizeColumns();

                    if (tabPuestos.Rows.Count == 0)
                    {
                        MessageBox.Show($"No se encontraron puestos para el área seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    AplicarFiltro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los puestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing && cmbArea.SelectedValue != null)
            {
                CargarPuestosParaAreaSeleccionada();
            }
        }

        private void CargarPuestosParaAreaSeleccionada()
        {
            if (cmbArea.SelectedValue != null)
            {
                int areaId = Convert.ToInt32(cmbArea.SelectedValue);
                CargarPuestos(areaId);
                MostrarInformacionArea();
            }
        }

        private void MostrarInformacionArea()
        {
            if (cmbArea.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbArea.SelectedItem;
                string nombreArea = row["Nombre"].ToString();
                int cantidadEmpleados = Convert.ToInt32(row["CantidadEmpleados"]);
                lblInfoArea.Text = $"Área: {nombreArea} - Empleados: {cantidadEmpleados}";
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (tabPuestos != null)
            {
                string filtro = txtBuscar.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(filtro))
                {
                    tabPuestos.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    tabPuestos.DefaultView.RowFilter = $"NombrePuesto LIKE '%{filtro}%' OR " +
                                                       $"CONVERT(CantidadEmpleados, System.String) LIKE '%{filtro}%'";
                }
                ActualizarEstadisticas();
            }
        }

        private void ActualizarEstadisticas()
        {
            int totalPuestos = tabPuestos.DefaultView.Count;
            int totalEmpleados = 0;
            foreach (DataRowView row in tabPuestos.DefaultView)
            {
                totalEmpleados += Convert.ToInt32(row["CantidadEmpleados"]);
            }
            lblEstadisticas.Text = $"Total Puestos: {totalPuestos}, Total Empleados: {totalEmpleados}";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}