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
    public partial class SeleccionArticulos : Form
    {
        public int SelectedArticuloID { get; private set; }
        public SeleccionArticulos()
        {
            InitializeComponent();
            CargarTodosArticulos(); 
        }
        private void CargarTodosArticulos()
        {
            try
            {
                CConexion con = new CConexion();
                SqlConnection connection = con.EstablecerConexion();
                SqlCommand cmd = new SqlCommand("LeerTodosArticulos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewArticulo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artículos: " + ex.Message);
            }
        }

        


        private void SeleccionArticulos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulo.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewArticulo.SelectedRows[0];
                SelectedArticuloID = Convert.ToInt32(row.Cells["ArticuloID"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo.");
            }

        }
    }
}
