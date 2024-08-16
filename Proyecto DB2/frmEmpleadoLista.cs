using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class frmEmpleadoLista : Form
    {

        SqlDataAdapter adpEmpleado;
        DataTable tabEmpleado;
        SqlConnection con;

        public frmEmpleadoLista()
        {
            InitializeComponent();

        }

        public frmEmpleadoLista(SqlConnection conexion)
        {
            InitializeComponent();

            adpEmpleado = new SqlDataAdapter("spEmpleadoActivos", conexion);
            adpEmpleado.SelectCommand.CommandType = CommandType.StoredProcedure;

            con = conexion;

        }

        private void frmEmpleadoLista_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOpcion.Items.Add("Todos");
                cmbOpcion.Items.Add("Activos");
                cmbOpcion.Items.Add("Inactivos");


                tabEmpleado = new DataTable();
                adpEmpleado.Fill(tabEmpleado);
                dataGridView1.DataSource = tabEmpleado;
                dataGridView1.ReadOnly = true; //solo para leer
                dataGridView1.Columns["Sexo"].Visible = false;

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
            frmEmpleado frm = new frmEmpleado(con, -1);
            frm.ShowDialog();

            tabEmpleado.Clear();
            adpEmpleado.Fill(tabEmpleado);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int empleadoid = (int)tabEmpleado.DefaultView[dataGridView1.CurrentRow.Index]["empleadoid"];
                frmEmpleado frm = new frmEmpleado(con, empleadoid);
                frm.ShowDialog();

                tabEmpleado.Clear();
                adpEmpleado.Fill(tabEmpleado);

                // Buscar la fila con el mismo empleado y seleccionarla
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((int)row.Cells["empleadoid"].Value == empleadoid)
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
                int empleadoid = (int)tabEmpleado.DefaultView[dataGridView1.CurrentRow.Index]["empleadoid"];

                if (MessageBox.Show("Desea deshabilitar el Empleado", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("spEmpleadoDesactivar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empleadoid", empleadoid);

                    try
                    {
                        // Verificar si la conexión está cerrada antes de abrirla
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();
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

                    tabEmpleado.Clear();
                    adpEmpleado.Fill(tabEmpleado);

                    // Buscar la fila con el mismo empleadoid y seleccionarla
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if ((int)row.Cells["empleadoid"].Value == empleadoid)
                        {
                            row.Selected = true;
                            dataGridView1.CurrentCell = row.Cells[0]; // Establecer la celda actual para que se muestre
                            break;
                        }
                    }
                }
            }
        }

        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabEmpleado.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabEmpleado.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tabEmpleado.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tabEmpleado.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tabEmpleado.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
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

                        spNombre = "spEmpleadoSelect";
                        break;

                    case "Activos":

                        spNombre = "spEmpleadoActivos";
                        break;

                    case "Inactivos":

                        spNombre = "spEmpleadoInactivos";
                        break;
                }

                if (!string.IsNullOrEmpty(spNombre))
                {
                    // Configura el SqlDataAdapter con el stored procedure seleccionado
                    adpEmpleado = new SqlDataAdapter(spNombre, con);
                    adpEmpleado.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Vuelve a llenar el DataTable y asigna los datos al DataGridView
                    tabEmpleado.Clear();
                    adpEmpleado.Fill(tabEmpleado);
                    dataGridView1.DataSource = tabEmpleado;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
