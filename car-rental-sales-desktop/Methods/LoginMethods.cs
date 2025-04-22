using car_rental_sales_desktop.Utils;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using car_rental_sales_desktop.Forms.Pages;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Methods
{
    internal class LoginMethods
    {

        // Bu metod kullanıcı adı ve şifreyi alır, veritabanında doğrular ve kullanıcıyı giriş yapmış olarak işaretler.
        public static bool ValidateLogin(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return false;

                string query = @"SELECT UserID FROM Users 
                               WHERE Username = @Username AND Password = @Password LIMIT 1";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    DatabaseHelper.CreateParameter("@Username", username),
                    DatabaseHelper.CreateParameter("@Password", password)
                };

                DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

                return result.Rows.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 
        public static void HandleLogin(TextBox usernameTextBox, TextBox passwordTextBox, LoginPage loginForm)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                LoginPage.ShowError(loginForm, "The username field cannot be left blank!");
                usernameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                LoginPage.ShowError(loginForm, "The password field cannot be left blank!");
                passwordTextBox.Focus();
                return;
            }

            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            bool success = ValidateLogin(username, password);

            if (success)
            {
                LoginPage.ShowSuccess(loginForm, "Login successful! You are being redirected...");

                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);

                UserRepository userRepository = new UserRepository();
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
