﻿using System;
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
    public partial class frmCompraExistente : Form
    {
        string url = "server=3.128.144.165; DataBase=DB20212000317; User ID = evelyn.sabillon; Password = ES20212000317";
        SqlConnection conexion;
        SqlDataAdapter adpVerArticulo;
        DataTable dtverarticulo;
        DataTable dtayudaprov;
        SqlDataAdapter adpayudaprov;
        public frmCompraExistente()
        {
            InitializeComponent();
            dtayudaprov = new DataTable();
            dtverarticulo = new DataTable();
            conexion = new SqlConnection(url);
            adpVerArticulo = new SqlDataAdapter("spVerArticulosCD", conexion);
            adpVerArticulo.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpayudaprov = new SqlDataAdapter("spAyudaProveedor", conexion);
            adpayudaprov.SelectCommand.CommandType= CommandType.StoredProcedure;    
        }

        private void frmCompraExistente_Load(object sender, EventArgs e)
        {

            ActualizarDataGridView();

        }

        private void dgVerArticuloCD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgVerArticuloCD.Rows[e.RowIndex];


            txtNombreArticulo1.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
            txtBarraArticulo1.Text = filaSeleccionada.Cells["Barra"].Value.ToString();
            txtArticuloid.Text = filaSeleccionada.Cells["ArticuloID"].Value.ToString();
            

        }

        private void btnInsertarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmdInsertarCompra = new SqlCommand("InsertarNuevaCompraExistente", conexion))
                {
                    cmdInsertarCompra.CommandType = CommandType.StoredProcedure;
                
                    double tasaisv = 0.00;

                    switch (cbxTasaArticulo1.SelectedItem.ToString())
                    {
                        case "15%":
                            tasaisv = 0.15;
                            break;
                        case "18%":
                            tasaisv = 0.18;
                            break;
                        default:
                            // Manejo del caso en que no se seleccione una tasa válida.
                            tasaisv = 0.00;
                            break;
                    }

                    cmdInsertarCompra.Parameters.AddWithValue("@ArticuloID", txtArticuloid.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@ProveedorID", txtProveedorIDCompra1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Fecha", txtFechaCompra1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Documento", txtDocumentoArticulo1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Tipo", cbxTipoCompra1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@EstadoCompra", cbxEstado.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@NombreArticulo", txtNombreArticulo1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@BarraArticulo", txtBarraArticulo1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@PrecioArticulo", txtPrecioCompra1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@TasaISV", tasaisv);
                    cmdInsertarCompra.Parameters.AddWithValue("@Cantidad", txtCantidadCD1.Text);
                    cmdInsertarCompra.Parameters.AddWithValue("@Costo", txtCostoCD1.Text);
                    
                    conexion.Open();
                    cmdInsertarCompra.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Compra registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conexion.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarCompraExistente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir sin guardar los cambios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnVerProceedorCompra_Click(object sender, EventArgs e)
        {
            pnlBtnAyuda.Visible = true;
            adpayudaprov.Fill(dtayudaprov);
            dgAyudaProveedor.DataSource = dtayudaprov;
        }

        private void dgAyudaProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)

            
        {

            try
            {
                 DataGridViewRow filaSeleccionadaAyuda = dgAyudaProveedor.Rows[e.RowIndex];
                            txtProveedorIDCompra1.Text = filaSeleccionadaAyuda.Cells["ProveedorID"].Value.ToString();
                            pnlBtnAyuda.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Filas Ordenadas, seleccione un proveedor" , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }

        private void ActualizarDataGridView()
        {
            try
            {
                // Llenar el DataTable con datos actuales
                dtverarticulo.Clear();
                adpVerArticulo.Fill(dtverarticulo);
                dgVerArticuloCD.DataSource = dtverarticulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pnlBtnAyuda_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
