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
    public partial class IngresarServicios : Form
    {

       

        private Servicios _servicios;
        public IngresarServicios(Servicios servicios)
        {
            InitializeComponent();
            _servicios = servicios;
            CargarProximoID();
        }


        public bool EsActualizacion { get; set; }
        public string ServicioID
        {
            get { return txtServicioID.Text; }
            set { txtServicioID.Text = value; }
        }

        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }

        public string Descripcion
        {
            get { return txtDescripcion.Text; }
            set { txtDescripcion.Text = value; }
        }

        public string Precio
        {
            get { return txtPrecio.Text; }
            set { txtPrecio.Text = value; }
        }

        public string TasaIVA
        {
            get { return cmbTasa.SelectedItem.ToString(); }
            set { cmbTasa.SelectedItem = value; }
        }

        public string Duracion
        {
            get { return txtDuracion.Text; }
            set { txtDuracion.Text = value; }
        }

        public string Activo
        {
            get { return cmbActivo.SelectedItem.ToString(); }
            set { cmbActivo.SelectedItem = value; }
        }

        public void SetServicioID(int servicioID)
        {
            txtServicioID.Text = servicioID.ToString();
           
        }

        private void CargarProximoID()
        {
            try
            {
               
                CConexion conexion = new CConexion();
                SqlConnection con = conexion.EstablecerConexion();

               
                SqlCommand cmd = new SqlCommand("sp_ObtenerProximoID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tabla", "Servicio");
                cmd.Parameters.AddWithValue("@ColumnaID", "ServicioID");

               
                SqlParameter parametroID = new SqlParameter("@ProximoID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parametroID);

                cmd.ExecuteNonQuery();

                int proximoID = (int)parametroID.Value;
                txtServicioID.Text = proximoID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el próximo ID: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int servicioID;
            if (int.TryParse(txtServicioID.Text, out servicioID))
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                float tasaIVA = float.Parse(cmbTasa.SelectedItem.ToString());
                int duracion = int.Parse(txtDuracion.Text);
                bool activo = cmbActivo.SelectedItem.ToString() == "Si";

                CConexion conexion = new CConexion();
                SqlConnection con = conexion.EstablecerConexion();

                try
                {
                    SqlCommand cmd;

                    if (EsActualizacion)
                    {
                        cmd = new SqlCommand("spActualizarServicio", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@ServicioID", servicioID);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaIVA", tasaIVA);
                        cmd.Parameters.AddWithValue("@Duracion", duracion);
                        cmd.Parameters.AddWithValue("@Activo", activo ? 1 : 0);
                    }
                    else
                    {
                        cmd = new SqlCommand("sp_InsertarServicios2", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaIVA", tasaIVA);
                        cmd.Parameters.AddWithValue("@Duracion", duracion);
                        cmd.Parameters.AddWithValue("@Activo", activo ? 1 : 0);
                    }

                    cmd.ExecuteNonQuery();
                    _servicios.ActualizarDataGridView();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el servicio: {ex.Message}");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

                MessageBox.Show("Operación completada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("ID de servicio inválido.");
            }
        }

        private void IngresarServicios_Load(object sender, EventArgs e)
        {
            if (EsActualizacion)
            {
               
                txtServicioID.Text = ServicioID;
                txtNombre.Text = Nombre;
                txtDescripcion.Text = Descripcion;
                txtPrecio.Text = Precio;
                cmbTasa.SelectedItem = TasaIVA;
                txtDuracion.Text = Duracion;
                cmbActivo.SelectedItem = Activo;
            }
        }
    }
}
