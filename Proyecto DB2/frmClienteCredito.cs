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
    public partial class frmClienteCredito : Form
    {
        public frmClienteCredito()
        {
            InitializeComponent();
        }

        public frmClienteCredito(SqlConnection conexion)
        {
            InitializeComponent();
        }

        private void frmClienteCredito_Load(object sender, EventArgs e)
        {

        }
    }
}
