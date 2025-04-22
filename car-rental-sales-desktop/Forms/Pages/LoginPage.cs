using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
using car_rental_sales_desktop.Models;

namespace car_rental_sales_desktop.Forms.Pages
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            btnEye.MouseDown += BtnEye_MouseDown;
            btnEye.MouseUp += BtnEye_MouseUp;

            txtPassword.PasswordChar = '\0';
            txtPassword.Enter += TxtBoxPassword_Enter;
            txtPassword.Leave += TxtBoxPassword_Leave;
            txtPassword.KeyDown += TextBox_KeyDown;

            txtUsername.Enter += TxtBoxUsername_Enter;
            txtUsername.Leave += TxtBoxUsername_Leave;
            txtUsername.KeyDown += TextBox_KeyDown;

            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HandleLogin(txtUsername, txtPassword, this);
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            btnEye.IconChar = FontAwesome.Sharp.IconChar.Eye;

            txtPassword.PasswordChar = '\0';
        }

        private void BtnEye_MouseUp(object sender, MouseEventArgs e)
        {
            btnEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;

            txtPassword.PasswordChar = '*';
        }

        private void TxtBoxUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter your username")
            {
                txtUsername.Text = "";
            }
        }

        private void TxtBoxUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = "Enter your username";
            }
        }

        private void TxtBoxPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
            }
        }

        private void TxtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Text = "Enter your password";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleLogin(txtUsername, txtPassword, this);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // TR: Bu metod UserRepository sınıfını kullanarak kullanıcı adı ve şifre ile giriş yapmayı sağlar.
        // EN: This method allows login using username and password by utilizing the UserRepository class.
        public static void HandleLogin(TextBox usernameTextBox, TextBox passwordTextBox, LoginPage loginForm)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            UserRepository userRepository = new UserRepository();
            bool success = userRepository.ValidateLogin(username, password);

            if (success)
            {
                LoginPage.ShowSuccess(loginForm, "Login successful! You are being redirected...");

                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);

                User currentUser = userRepository.GetByUsername(username);
                CurrentUser.SetCurrentUser(currentUser);

                MainPage mainPage = new MainPage();
                mainPage.Show();
                loginForm.Hide();
            }
            else
            {
                LoginPage.ShowError(loginForm, "The username or password is incorrect!");
            }
        }
    }
}
