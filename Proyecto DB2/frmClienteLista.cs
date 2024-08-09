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

            adpCliente = new SqlDataAdapter("spClienteSelect", conexion);
            adpCliente.SelectCommand.CommandType = CommandType.StoredProcedure;

            con = conexion;

        }


        private void frmClienteLista_Load(object sender, EventArgs e)
        {
            try
            {
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
            }
        }
    }
}
