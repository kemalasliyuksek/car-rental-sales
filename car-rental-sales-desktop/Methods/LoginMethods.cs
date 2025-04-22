using System;
using System.Windows.Forms;

using car_rental_sales_desktop.Forms.Pages;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Methods
{
    internal class LoginMethods
    {
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