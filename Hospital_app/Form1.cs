using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnLogin.Click += new EventHandler(this.Login);
        }

        private void Login(object sender, EventArgs e)
        {
            if (this.txtUsername.Text == "admin" && this.txtPassword.Text == "admin")
            {
                PatientForm from = new PatientForm();
                from.ShowDialog();
            }
            else
            {
                this.lblError.Text = "Username or password incorrect";
            }
        }
    }
}
