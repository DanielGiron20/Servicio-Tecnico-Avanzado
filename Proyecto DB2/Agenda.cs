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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void CargarFechasConOrdenes()
        {
            List<DateTime> fechasConOrdenes = new List<DateTime>();

            string query = @"
        SELECT DISTINCT CONVERT(DATE, FechaInicio) AS Fecha
        FROM Orden
        WHERE Activo = 1";

            CConexion conexion = new CConexion();
            SqlConnection con = null;
            con = conexion.EstablecerConexion();

            SqlCommand cmd = new SqlCommand(query, con);
               
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    fechasConOrdenes.Add(reader.GetDateTime(0));
                }
            

          
            monthCalendar.BoldedDates = fechasConOrdenes.ToArray();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            DateTime fechaSeleccionada = monthCalendar.SelectionStart;
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");

           
            string query = $@"
        SELECT OrdenID, ClienteID, EmpleadoID, TipoOrden, Duracion, Estado, FechaInicio, FechaFinal, Activo
        FROM Orden
        WHERE CONVERT(DATE, FechaInicio) = '{fechaFormateada}'
           OR CONVERT(DATE, FechaFinal) = '{fechaFormateada}'";


            CConexion conexion = new CConexion();
            SqlConnection con = null;
            SqlDataAdapter da = null;
            con = conexion.EstablecerConexion();
          

           da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                dataGridView1.DataSource = dt;
            
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            CargarFechasConOrdenes();
        }
    }
}
