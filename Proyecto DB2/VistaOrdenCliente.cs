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
    public partial class VistaOrdenCliente : Form
    {

        SqlDataAdapter adpOrdenCliente;
        DataTable dtOrdenCliente;

        public VistaOrdenCliente()
        {
            InitializeComponent();
        }

        public VistaOrdenCliente(SqlConnection cnx)
        {
            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusqueda.SelectedIndex = 0;

            adpOrdenCliente = new SqlDataAdapter();
            dtOrdenCliente = new DataTable();

            adpOrdenCliente.SelectCommand = new SqlCommand("select * from dbo.fObtenerOrdenes()", cnx);

            adpOrdenCliente.Fill(dtOrdenCliente);
            dataGridView1.DataSource = dtOrdenCliente;
        }



        private void VistaOrdenCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if(txtBusqueda.Text.Length == 0)
            {
                dtOrdenCliente.DefaultView.RowFilter = "";
            }
            else
            {
                dtOrdenCliente.DefaultView.RowFilter = cmbBusqueda.Text + " like '%"+ txtBusqueda.Text + "%'";
            }
        }
    }
}
