using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    public partial class StaffControl : UserControl
    {
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private BranchRepository _branchRepository;

        public StaffControl()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _branchRepository = new BranchRepository();

            this.Load += StaffControl_Load;
        }

        private void StaffControl_Load(object sender, EventArgs e)
        {
            LoadStaff();
        }

        private void LoadStaff()
        {
            try
            {
                // Get all users (staff members)
                List<User> staff = _userRepository.GetAll();

                // For each staff member, load their role and branch
                foreach (var user in staff)
                {
                    // Always load the role information for proper display
                    if (user.UserRoleID > 0)
                    {
                        user.Role = _roleRepository.GetById(user.UserRoleID);
                    }
                    else
                    {
                        // Create an empty role object to avoid null reference exceptions
                        user.Role = new Role { RoleName = "Not Assigned" };
                    }

                    // Always load the branch information for proper display
                    if (user.UserBranchID.HasValue && user.UserBranchID.Value > 0)
                    {
                        user.Branch = _branchRepository.GetById(user.UserBranchID.Value);
                    }
                    else
                    {
                        // Create an empty branch object to avoid null reference exceptions
                        user.Branch = new Branch { BranchName = "Not Assigned" };
                    }
                }

                sfDataGridStaff.DataSource = staff;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Personel verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}