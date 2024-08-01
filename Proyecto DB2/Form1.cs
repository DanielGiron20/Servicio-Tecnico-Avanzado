﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            personalizar();
        }

        private void personalizar()
        {
            panel3.Visible = false;
            panel4.Visible = false;  
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

        }

        private void ocultar()
        {
            if(panel3.Visible == true)
            panel3.Visible=false;
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel5.Visible == true)
                panel5.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
            if (panel7.Visible == true)
                panel7.Visible = false;
        }

        private void mostrar(Panel subMenu)
        {
                if(subMenu.Visible == false)
            {
                ocultar();
                subMenu.Visible = true;
            }
                else
                subMenu.Visible = false;    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar(panel3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchildform(new Agenda());
            ocultar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mostrar(panel4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openchildform(new Servicios());
            ocultar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mostrar(panel5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openchildform(new Clientes());
            ocultar();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mostrar(panel6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openchildform(new Compras());
            ocultar();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openchildform(new Empleados());    
            ocultar();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mostrar(panel7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openchildform(new Inventario());
            ocultar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private Form activo = null;
        private void openchildform(Form child)
        {
            if (activo != null)
                activo.Close();
            activo = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel8.Controls.Add(child);
            panel8.Tag = child;
            child.BringToFront();
            child.Show();


        }
    }

}
