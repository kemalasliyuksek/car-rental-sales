using System;
using System.Drawing;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using FontAwesome.Sharp;
using car_rental_sales_desktop.Forms.Pages;

namespace car_rental_sales_desktop
{
    public partial class MainPage : Form
    {
        // Fields
        private User _currentUser;
        private IconButton _currentButton;
        private Color _activeButtonColor = Color.FromArgb(0, 120, 109);

        // Constructor
        public MainPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            UpdateUserInfo();

            // Set Dashboard as default view on startup
            ActivateButton(btnDashboard);
            lblPageTitle.Text = "Dashboard";
        }

        // Methods
        private void UpdateUserInfo()
        {
            lblUserName.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            lblUserRole.Text = _currentUser.Role?.RoleName ?? "Unknown Role";
            lblBranchName.Text = _currentUser.Branch?.BranchName ?? "Genel Merkez";
        }

        private void ActivateButton(IconButton button)
        {
            if (_currentButton != null)
            {
                _currentButton.BackColor = Color.FromArgb(51, 51, 76);
                _currentButton.ForeColor = Color.Gainsboro;
                _currentButton.IconColor = Color.Gainsboro;
                _currentButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
            }

            // Highlight the selected button
            button.BackColor = _activeButtonColor;
            button.ForeColor = Color.White;
            button.IconColor = Color.White;
            button.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            _currentButton = button;
        }

        // Button click event handlers
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            lblPageTitle.Text = "Dashboard";
            // Load Dashboard UserControl (you'll create this later)
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCustomers);
            lblPageTitle.Text = "Customers";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            ActivateButton(btnVehicles);
            lblPageTitle.Text = "Vehicles";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            ActivateButton(btnRentals);
            lblPageTitle.Text = "Rentals";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSales);
            lblPageTitle.Text = "Sales";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            ActivateButton(btnMaintenance);
            lblPageTitle.Text = "Maintenance";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ActivateButton(btnStaff);
            lblPageTitle.Text = "Staff";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(btnReports);
            lblPageTitle.Text = "Reports";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSettings);
            lblPageTitle.Text = "Settings";
            MainMethods.LoadUserControl(pnlContent, new UserControl());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                // Clear the current user session
                Utils.CurrentUser.Logout();

            }
        }
    }
}