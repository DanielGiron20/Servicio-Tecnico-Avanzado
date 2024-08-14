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
using System.Net.Sockets;

namespace Proyecto_DB2
{
    public partial class frmPaqueteLista : Form
    {
        SqlDataAdapter adpPaquete;
        DataTable tabPaquete;
        SqlConnection con;

        public frmPaqueteLista()
        {
            InitializeComponent();
        }

        public frmPaqueteLista(SqlConnection conexion)
        {
            InitializeComponent();

            adpPaquete = new SqlDataAdapter("spPaqueteSelect", conexion);
            adpPaquete.SelectCommand.CommandType = CommandType.StoredProcedure;

            con = conexion;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPaqueteLista_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOpcion.Items.Add("Todos");
                cmbOpcion.Items.Add("Activos");
                cmbOpcion.Items.Add("Inactivos");

                tabPaquete = new DataTable();
                adpPaquete.Fill(tabPaquete);
                dataGridView1.DataSource = tabPaquete;
                dataGridView1.ReadOnly = true; //solo para leer

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cmdInsertar_Click(object sender, EventArgs e)
        {
            frmPaquete frm = new frmPaquete(con, -1);
            frm.ShowDialog();

            tabPaquete.Clear();
            adpPaquete.Fill(tabPaquete);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int paqueteid = (int)tabPaquete.DefaultView[dataGridView1.CurrentRow.Index]["paqueteid"];
                frmPaquete frm = new frmPaquete(con, paqueteid);
                frm.ShowDialog();

                tabPaquete.Clear();
                adpPaquete.Fill(tabPaquete);

                // Buscar la fila con el mismo paqueteid y seleccionarla
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((int)row.Cells["paqueteid"].Value == paqueteid)
                    {
                        row.Selected = true;
                        dataGridView1.CurrentCell = row.Cells[0]; // Establecer la celda actual para que se muestre
                        break;
                    }
                }
            }

        }

        private void cmdDesactivar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int paqueteid = (int)tabPaquete.DefaultView[dataGridView1.CurrentRow.Index]["paqueteid"];

                if (MessageBox.Show("Desea deshabilitar el Paquete", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("spPaqueteDesactivar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@paqueteid", paqueteid);

                    SqlCommand cmd2 = new SqlCommand("spPaqueteDetalleDesactivar", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@paqueteid", paqueteid);

                    try
                    {
                        // Verificar si la conexión está cerrada antes de abrirla
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Asegurarse de cerrar la conexión si fue abierta en este método
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }

                    tabPaquete.Clear();
                    adpPaquete.Fill(tabPaquete);

                    // Buscar la fila con el mismo clienteid y seleccionarla
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if ((int)row.Cells["paqueteid"].Value == paqueteid)
                        {
                            row.Selected = true;
                            dataGridView1.CurrentCell = row.Cells[0]; // Establecer la celda actual para que se muestre
                            break;
                        }
                    }
                }
            }
        }

        private void cmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string spNombre = "";

                switch (cmbOpcion.SelectedItem.ToString())
                {
                    case "Todos":

                        spNombre = "spPaqueteSelect";
                        break;

                    case "Activos":

                        spNombre = "spPaqueteActivos";
                        break;

                    case "Inactivos":

                        spNombre = "spPaqueteInactivos";
                        break;
                }

                if (!string.IsNullOrEmpty(spNombre))
                {
                    // Configura el SqlDataAdapter con el stored procedure seleccionado
                    adpPaquete = new SqlDataAdapter(spNombre, con);
                    adpPaquete.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Vuelve a llenar el DataTable y asigna los datos al DataGridView
                    tabPaquete.Clear();
                    adpPaquete.Fill(tabPaquete);
                    dataGridView1.DataSource = tabPaquete;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabPaquete.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabPaquete.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tabPaquete.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tabPaquete.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tabPaquete.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }

            }
        }
    }
}
