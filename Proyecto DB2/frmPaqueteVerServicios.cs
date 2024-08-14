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
    public partial class frmPaqueteVerServicios : Form
    {

        SqlDataAdapter adpServicio;
        DataTable tabServicio;
        SqlConnection con;
        DataRow Fila;

        public DataRow FilaSeleccionada
        {
            get { return Fila; }
        }
        public frmPaqueteVerServicios()
        {
            InitializeComponent();
        }

        public frmPaqueteVerServicios(SqlConnection conexion)
        {
            InitializeComponent();

            adpServicio= new SqlDataAdapter("spPaquetesServiciosActivosSelect", conexion);
            adpServicio.SelectCommand.CommandType = CommandType.StoredProcedure;

            con = conexion;

        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabServicio.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabServicio.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tabServicio.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tabServicio.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tabServicio.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }

            }

        }

        private void frmPaqueteVerServicios_Load(object sender, EventArgs e)
        {
            try
            {
                tabServicio = new DataTable();
                adpServicio.Fill(tabServicio);
                dataGridView1.DataSource = tabServicio;
                dataGridView1.ReadOnly = true;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Fila = tabServicio.DefaultView[dataGridView1.CurrentRow.Index].Row;
                Close();
            }
        }
    }
}
