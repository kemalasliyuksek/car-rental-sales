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

        // TR: Bu metot, personel verilerini yükler ve veri tablosuna atar.
        // EN: This method loads the staff data and assigns it to the data table.
        private void LoadStaff()
        {
            try
            {
                List<User> staff = _userRepository.GetAll();

                foreach (var user in staff)
                {
                    if (user.UserRoleID > 0)
                    {
                        user.Role = _roleRepository.GetById(user.UserRoleID);
                    }
                    else
                    {
                        user.Role = new Role { RoleName = "Not Assigned" };
                    }

                    if (user.UserBranchID.HasValue && user.UserBranchID.Value > 0)
                    {
                        user.Branch = _branchRepository.GetById(user.UserBranchID.Value);
                    }
                    else
                    {
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

        // TR: Bu metot, veri tablosundaki satırların stilini özelleştirir.
        // EN: This method customizes the style of the rows in the data table.
        private void SfDataGridStaff_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Açık mavi tonu
            }
        }

    }
}