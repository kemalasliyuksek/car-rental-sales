using car_rental_sales_desktop.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Pages
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Utils.CurrentUser.FullName;
            lblUserRole.Text = Utils.CurrentUser.RoleName;
            lblBranchName.Text = Utils.CurrentUser.BranchName;

            ResetButtons();
            SetActiveButton(btnMainPage);

            pnlContent.Controls.Clear();
            var mainPageControl = new MainPageControl();
            mainPageControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(mainPageControl);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Utils.CurrentUser.Logout();
                this.Close();
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
            }
        }

        private void ResetButtons()
        {
            foreach (Control control in pnlSideMenu.Controls)
            {
                if (control is FontAwesome.Sharp.IconButton)
                {
                    control.BackColor = Color.FromArgb(49, 76, 143);
                    control.ForeColor = Color.White;
                }
            }
        }

        private void SetActiveButton(object button)
        {
            if (button != null)
            {
                ((FontAwesome.Sharp.IconButton)button).BackColor = Color.FromArgb(73, 113, 194);

                ((FontAwesome.Sharp.IconButton)button).ForeColor = Color.White;

                iconCurrentPage.IconChar = ((FontAwesome.Sharp.IconButton)button).IconChar;
                lblPageTitle.Text = ((FontAwesome.Sharp.IconButton)button).Text.Trim();
            }
        }


        // MainPage UserControl
        private void btnMainPage_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var mainPageControl = new MainPageControl();
            mainPageControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(mainPageControl);

        }

        // Dashboard UserControl
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var dashboardControl = new DashboardControl();
            dashboardControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dashboardControl);
        }

        // Customers UserControl
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var customersControl = new CustomersControl();
            customersControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(customersControl);
        }

        // Vehicles UserControl
        private void btnVehicles_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var vehiclesControl = new VehiclesControl();
            vehiclesControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(vehiclesControl);
        }

        // Rentals UserControl
        private void btnRentals_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var rentalsControl = new RentalsControl();
            rentalsControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(rentalsControl);
        }

        // Sales UserControl
        private void btnSales_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var salesControl = new SalesControl();
            salesControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(salesControl);
        }

        // Branches UserControl
        private void btnBranches_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var branchesControl = new BranchesControl();
            branchesControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(branchesControl);
        }

        // Staff UserControl
        private void btnStaff_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var staffControl = new StaffControl();
            staffControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(staffControl);
        }

        // Reports UserControl
        private void btnReports_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var reportsControl = new ReportsControl();
            reportsControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(reportsControl);
        }

        // Service UserControl
        private void btnService_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var serviceControl = new ServiceControl();
            serviceControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(serviceControl);
        }

        // Settings UserControl
        private void btnSettings_Click(object sender, EventArgs e)
        {
            ResetButtons();
            SetActiveButton(sender);

            pnlContent.Controls.Clear();
            var settingsControl = new SettingsControl();
            settingsControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(settingsControl);
        }
    }
}
