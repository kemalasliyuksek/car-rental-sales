using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using car_rental_sales_desktop.Methods;
using Org.BouncyCastle.Asn1.Cmp;

namespace car_rental_sales_desktop.Forms.Pages
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            BtnEye.MouseDown += BtnEye_MouseDown;
            BtnEye.MouseUp += BtnEye_MouseUp;

            TxtBoxPassword.Text = "Enter your password";
            TxtBoxPassword.PasswordChar = '\0';
            TxtBoxPassword.Enter += TxtBoxPassword_Enter;
            TxtBoxPassword.Leave += TxtBoxPassword_Leave;
            TxtBoxPassword.KeyDown += TextBox_KeyDown;

            TxtBoxUsername.Enter += TxtBoxUsername_Enter;
            TxtBoxUsername.Leave += TxtBoxUsername_Leave;
            TxtBoxUsername.KeyDown += TextBox_KeyDown;

            this.AcceptButton = BtnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginMethods.HandleLogin(TxtBoxUsername, TxtBoxPassword, this);
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("For password reset requests, please contact the administrator. (admin@carrentalsales.com)",
                          "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowSuccess(LoginPage instance, string message)
        {
            instance.lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            instance.lblStatus.Text = message;
        }

        public static void ShowError(LoginPage instance, string message)
        {
            instance.lblStatus.ForeColor = Color.FromArgb(220, 53, 69);
            instance.lblStatus.Text = message;
        }

        private void BtnEye_MouseDown(object sender, MouseEventArgs e)
        {
            BtnEye.IconChar = FontAwesome.Sharp.IconChar.Eye;

            TxtBoxPassword.PasswordChar = '\0';
        }

        private void BtnEye_MouseUp(object sender, MouseEventArgs e)
        {
            BtnEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;

            TxtBoxPassword.PasswordChar = '*';
        }

        private void TxtBoxUsername_Enter(object sender, EventArgs e)
        {
            if (TxtBoxUsername.Text == "Enter your username")
            {
                TxtBoxUsername.Text = "";
            }
        }

        private void TxtBoxUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxUsername.Text))
            {
                TxtBoxUsername.Text = "Enter your username";
            }
        }

        private void TxtBoxPassword_Enter(object sender, EventArgs e)
        {
            if (TxtBoxPassword.Text == "Enter your password")
            {
                TxtBoxPassword.Text = "";
                TxtBoxPassword.PasswordChar = '*';
            }
        }

        private void TxtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxPassword.Text))
            {
                TxtBoxPassword.Text = "Enter your password";
                TxtBoxPassword.PasswordChar = '\0';
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginMethods.HandleLogin(TxtBoxUsername, TxtBoxPassword, this);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
