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

            if (string.IsNullOrEmpty(bd))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


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
                for( int i = 0; i < ex.Errors.Count; i++)
                {
                    if(ex.Errors[i].Number == 18456)
                    {
                        MessageBox.Show("El usuario o contraseña es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (ex.Errors[i].Number == 4060)
                    {
                        MessageBox.Show("El nombre de la base de datos es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (ex.Errors[i].Number == 53)
                    {
                        MessageBox.Show("Error de Comunicacion con el servidor " + server.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else if(ex.Errors[i].Number == 2)
                    {
                        MessageBox.Show("Nombre o direccion del servidor incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        MessageBox.Show("No se logro conectar a la base de datos " + ex.ToString());
                    }
                }

            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
