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
    }
}
