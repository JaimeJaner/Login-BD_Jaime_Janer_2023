using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Login_BD_Jaime_Janer_2023
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            Hide();
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();

            su.Show();
            Hide();
        }

        private void lbl_Bienvenido_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
