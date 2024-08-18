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

    public partial class frmClienteSuscripcion : Form
    {
        SqlConnection con;
        SqlDataAdapter adpSuscripcion;
        DataTable tabSuscripcion;

        public frmClienteSuscripcion()
        {
            InitializeComponent();
        }

        public frmClienteSuscripcion(SqlConnection conexion)
        {
            InitializeComponent();

            adpSuscripcion = new SqlDataAdapter("select * from vSuscripciones", conexion);
            con = conexion;

        }

        private void frmClienteSuscripcion_Load(object sender, EventArgs e)
        {
            try
            {
                tabSuscripcion = new DataTable();
                adpSuscripcion.Fill(tabSuscripcion);
                dataGridView1.DataSource = tabSuscripcion;
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

        private void cmdSalir_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tabSuscripcion.DefaultView.RowFilter = "";
            }
            else
            {
                if (tabSuscripcion.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tabSuscripcion.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tabSuscripcion.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tabSuscripcion.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }

            }
        }
    }
}
