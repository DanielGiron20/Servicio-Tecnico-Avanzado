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

        private SqlConnection con;
        private bool conectado;
        public SqlConnection Con
        {
            get { return con;}
        }

        public bool Conectado
        {
            get { return conectado; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             

             string servidor = server.Text.Trim();
             string bd = bd2.Text.Trim();
             string usuario = user.Text.Trim();
            string pw2 = pw.Text.Trim();
            string puerto = "1433";

            string connectionString = $"Server={servidor};Database={bd};User Id={usuario};Password={pw2};";


            try
            {
                conectado = false;
                con = new SqlConnection(connectionString);
                con.Open();
                conectado = true;
                MessageBox.Show("Se conecto correctamente a la base de datos");
                Dispose();

            }
                catch (SqlException ex)
                {
                    MessageBox.Show("No se logro conectar a la base de datos " + ex.ToString());

                }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
