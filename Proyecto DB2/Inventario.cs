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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            cargarProductos(null);
        }

        public void cargarProductos(bool? activo)
        {
            CConexion conexion = new CConexion();
            SqlConnection con = null;
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {

                con = conexion.EstablecerConexion();


                if (con != null)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerArticulosPorEstado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (activo.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Activo", activo.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Activo", DBNull.Value);
                        }

                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }


                    dataGridView1.DataSource = dt;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los articulos: {ex.Message}");
            }
            finally
            {

                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                if (da != null)
                {
                    da.Dispose();
                }
            }

        }


        private void cmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInsertarArticulos k = new FrmInsertarArticulos(this);
            k.ShowDialog();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void opcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (opcion.SelectedItem.ToString())
            {
                case "Todos":
                    cargarProductos(null);
                    break;
                case "Activos":
                    cargarProductos(true);
                    break;
                case "Inactivos":
                    cargarProductos(false);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                FrmInsertarArticulos formularioIngreso = new FrmInsertarArticulos(this)
                {
                    EsActualizacion = true, 
                    ArticuloID = filaSeleccionada.Cells["ArticuloID"].Value.ToString(),
                    Nombre = filaSeleccionada.Cells["Nombre"].Value.ToString(),
                    Barra = filaSeleccionada.Cells["Barra"].Value.ToString(),
                    Precio = filaSeleccionada.Cells["Precio"].Value.ToString(),
                    TasaIVA = filaSeleccionada.Cells["TasaISV"].Value.ToString(),
                    Existencia = filaSeleccionada.Cells["Existencia"].Value.ToString(),
                  
                  Activo = (filaSeleccionada.Cells["Activo"].Value.ToString() == "True")


            };

                formularioIngreso.ShowDialog();
                cargarProductos(null);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.");
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = (BindingSource)dataGridView1.DataSource;
            string filtro = comboFiltro.SelectedItem.ToString();
            string textoFiltro = txtTexto.Text;

            if (!string.IsNullOrEmpty(textoFiltro))
            {

                if (filtro == "ArticuloID" || filtro == "Precio")
                {
                    bs.Filter = $"CONVERT({filtro}, 'System.String') LIKE '%{textoFiltro}%'";
                }
                else
                {
                    bs.Filter = $"{filtro} LIKE '%{textoFiltro}%'";
                }
            }
            else
            {
                bs.RemoveFilter();
            }


        }
    }
}
