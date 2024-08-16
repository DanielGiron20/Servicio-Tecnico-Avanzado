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
    public partial class frmClienteLista : Form
    {

        SqlDataAdapter adpCliente;
        DataTable tabCliente;
        SqlConnection con;



        public frmClienteLista()
        {
            InitializeComponent();
        }

        public frmClienteLista(SqlConnection conexion)
        {
            InitializeComponent();

            adpCliente = new SqlDataAdapter("spClienteActivos", conexion);
            adpCliente.SelectCommand.CommandType = CommandType.StoredProcedure;

            con = conexion;

        }


        private void frmClienteLista_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOpcion.Items.Add("Todos");
                cmbOpcion.Items.Add("Activos");
                cmbOpcion.Items.Add("Inactivos");

                tabCliente = new DataTable();
                adpCliente.Fill(tabCliente);
                dataGridView1.DataSource = tabCliente;
                dataGridView1.ReadOnly = true; //solo para leer
                dataGridView1.Columns["Sexo"].Visible = false;
                dataGridView1.Columns["Civil"].Visible = false;
                dataGridView1.Columns["Tipo"].Visible = false;

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
            frmCliente frm = new frmCliente(con, -1);
            frm.ShowDialog();

            tabCliente.Clear();
            adpCliente.Fill(tabCliente);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int clienteid = (int) tabCliente.DefaultView[dataGridView1.CurrentRow.Index]["clienteid"];
                frmCliente frm = new frmCliente(con, clienteid);
                frm.ShowDialog();

                tabCliente.Clear();
                adpCliente.Fill(tabCliente);

                // Buscar la fila con el mismo clienteid y seleccionarla
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((int)row.Cells["clienteid"].Value == clienteid)
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
                int clienteid = (int)tabCliente.DefaultView[dataGridView1.CurrentRow.Index]["clienteid"];

                if (MessageBox.Show("Desea deshabilitar el Cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("spClienteDesactivar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@clienteid", clienteid);

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

                    tabCliente.Clear();
                    adpCliente.Fill(tabCliente);

                    // Buscar la fila con el mismo clienteid y seleccionarla
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if ((int)row.Cells["clienteid"].Value == clienteid)
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

                        spNombre = "spClienteSelect";
                        break;

                    case "Activos":

                        spNombre = "spClienteActivos";
                        break;

                    case "Inactivos":

                        spNombre = "spClienteInactivos";
                        break;
                }

                if (!string.IsNullOrEmpty(spNombre))
                {
                    // Configura el SqlDataAdapter con el stored procedure seleccionado
                    adpCliente = new SqlDataAdapter(spNombre, con);
                    adpCliente.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Vuelve a llenar el DataTable y asigna los datos al DataGridView
                    tabCliente.Clear();
                    adpCliente.Fill(tabCliente);
                    dataGridView1.DataSource = tabCliente;
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
                tabCliente.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabCliente.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tabCliente.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tabCliente.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tabCliente.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }

            }
        }
    }
}
