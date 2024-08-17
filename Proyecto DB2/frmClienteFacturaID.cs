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

    public partial class frmClienteFacturaID : Form
    {
        SqlConnection con;
        SqlDataAdapter adp;
        DataTable tab;
        public frmClienteFacturaID()
        {
            InitializeComponent();
        }

        public frmClienteFacturaID(SqlConnection conexion)
        {
            InitializeComponent();

            adp = new SqlDataAdapter("select * from vClienteFacturaCreditoID order by ClienteID", conexion);
           

        }

        private void frmClienteFacturaID_Load(object sender, EventArgs e)
        {
            try
            {
                tab = new DataTable();
                adp.Fill(tab);
                dataGridView1.DataSource = tab;

                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtTexto.Text.Length == 0)
            {
                tab.DefaultView.RowFilter = "";
            }
            else
            {
                if (tab.Columns[cmbCampo.Text].DataType == typeof(string))
                {
                    tab.DefaultView.RowFilter = cmbCampo.Text + " like '%" + txtTexto.Text + "%'";
                }
                else
                {
                    int numero;
                    if (int.TryParse(txtTexto.Text, out numero))
                    {
                        tab.DefaultView.RowFilter = cmbCampo.Text + " = " + numero;
                    }
                    else
                    {
                        tab.DefaultView.RowFilter = "1 = 0"; // No coincidirá con nada si el texto no es un número válido
                    }
                }

            }
        }
    }
}
