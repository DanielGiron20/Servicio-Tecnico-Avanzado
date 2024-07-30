using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    internal class CConexion
    {
        private static string servidor = "3.128.144.165";
        private static string bd = "DB20212000317";
        private static string usuario = "Daniel.Giron";
        private static string pw = "DG20222000528";
        private static string puerto = "1433";
        private static string cadena_conexion = $"Data Source={servidor},{puerto};User Id={usuario};Password={pw};Initial Catalog={bd};Persist Security Info=True";

        // Método para establecer la conexión
        public SqlConnection EstablecerConexion()
        {
            SqlConnection con = new SqlConnection(cadena_conexion);
            try
            {
                con.Open();
                MessageBox.Show("Se conectó correctamente a la base de datos");
            }
            catch (SqlException e)
            {
                MessageBox.Show($"No se logró conectar a la base de datos: {e.Message}");
            }
            return con;
        }
    }
}
