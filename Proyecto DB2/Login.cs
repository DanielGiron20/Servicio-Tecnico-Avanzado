using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Proyecto_DB2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

             string servidor = server.Text.Trim();
             string bd = bd2.Text.Trim();
             string usuario = user.Text.Trim();
            string pw2 = pw.Text.Trim();
            string puerto = "1433";

            string connectionString = $"Server={servidor};Database={bd};User Id={usuario};Password={pw2};";


            try
            {
                using (SqlConnection conx = new SqlConnection(connectionString))
                {
                    conx.Open();
                    MessageBox.Show("Se conecto correctamente a la base de datos");
                }

                
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();

                CConexion conexion = new CConexion();
                conexion.EstablecerConexion();

            }
                catch (SqlException ex)
                {
                    MessageBox.Show("No se logro conectar a la base de datos " + ex.ToString());

                }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
