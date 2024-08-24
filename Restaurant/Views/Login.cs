using Microsoft.VisualBasic.ApplicationServices;
using Restaurant.Views;
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

namespace Restaurant
{
    public partial class Login : Form, ILoginView
    {
        //Fields
        //private string user;
        //private string password;

        //Properties
        public string Username {
            get { return txtuser.Text; }
            set { txtuser.Text = value; }
        }
        string ILoginView.Password {
            get { return txtpass.Text; }
            set { txtpass.Text = value; }
        }

        public Login()
        {
            InitializeComponent();
            noshowpass.Hide();
            showpass.Show();
            txtpass.UseSystemPasswordChar = true;

            //activate btnlogin event
            btnlogin.Click += delegate { LoginEvent?.Invoke(this, EventArgs.Empty); };

        }

        //Events

        public event EventHandler LoginEvent;

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtpass.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnlogin.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void showpass_Click_1(object sender, EventArgs e)
        {
            showpass.Hide();
            noshowpass.Show();
            txtpass.UseSystemPasswordChar = false;
        }

        private void noshowpass_Click(object sender, EventArgs e)
        {
            noshowpass.Hide();
            showpass.Show();
            txtpass.UseSystemPasswordChar = true;
        }

        public void HideWindow()
        {
            this.Hide();
        }

        private void btnlogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btntest_Click(object sender, EventArgs e)
        {
            txtuser.Text = "cesar18";
            txtpass.Text = "12345";
            btnlogin.PerformClick();
        }
    }
}

