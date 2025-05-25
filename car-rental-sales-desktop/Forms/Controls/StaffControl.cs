using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
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
        private List<User> _staffList;
        private List<Role> _roleList;
        private List<Branch> _branchList;
        private bool _isEditMode = false;
        private int _editingUserId = 0;

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
            LoadRoles();
            LoadBranches();
        }

        // TR: Bu metot, personel verilerini yükler ve veri tablosuna atar.
        // EN: This method loads the staff data and assigns it to the data table.
        private void LoadStaff()
        {
            try
            {
                _staffList = _userRepository.GetAll();

                foreach (var user in _staffList)
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

                sfDataGridStaff.DataSource = _staffList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Personel verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, rolleri combobox'a yükler.
        // EN: This method loads roles into the combobox.
        private void LoadRoles()
        {
            try
            {
                _roleList = _roleRepository.GetAll();
                cmbRole.DataSource = _roleList;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rol verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, şubeleri combobox'a yükler.
        // EN: This method loads branches into the combobox.
        private void LoadBranches()
        {
            try
            {
                _branchList = _branchRepository.GetActiveBranches();

                // Add "Not Assigned" option
                var branchesWithEmpty = new List<Branch>
                {
                    new Branch { BranchID = 0, BranchName = "Not Assigned" }
                };
                branchesWithEmpty.AddRange(_branchList);

                cmbBranch.DataSource = branchesWithEmpty;
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şube verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, seçili kullanıcıyı döndürür.
        // EN: This method returns the selected user.
        private User GetSelectedUser()
        {
            try
            {
                if (sfDataGridStaff.SelectedIndex >= 0 && sfDataGridStaff.SelectedIndex < _staffList.Count)
                {
                    return _staffList[sfDataGridStaff.SelectedIndex];
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seçili kullanıcı alınırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // TR: Bu metot, form alanlarını temizler.
        // EN: This method clears the form fields.
        private void ClearForm()
        {
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtUsername.Text = "";
            txtUserPassword.Text = "";
            txtUserEmail.Text = "";
            txtUserPhone.Text = "";
            cmbRole.SelectedIndex = -1;
            cmbBranch.SelectedIndex = 0; // "Not Assigned"
            chkUserActive.Checked = true;

            _isEditMode = false;
            _editingUserId = 0;
            lblStaffFormTitle.Text = "Add New Staff";
            btnSaveStaff.Text = "Save Staff";
        }

        // TR: Bu metot, seçili kullanıcının bilgilerini forma doldurur.
        // EN: This method fills the form with the selected user's information.
        private void FillFormWithUser(User user)
        {
            if (user == null) return;

            txtUserFirstName.Text = user.UserFirstName;
            txtUserLastName.Text = user.UserLastName;
            txtUsername.Text = user.Username;
            txtUserPassword.Text = user.UserPassword;
            txtUserEmail.Text = user.UserEmail;
            txtUserPhone.Text = user.UserPhone;
            chkUserActive.Checked = user.UserActive;

            // Set role
            if (user.UserRoleID > 0)
            {
                cmbRole.SelectedValue = user.UserRoleID;
            }
            else
            {
                cmbRole.SelectedIndex = -1;
            }

            // Set branch
            if (user.UserBranchID.HasValue && user.UserBranchID.Value > 0)
            {
                cmbBranch.SelectedValue = user.UserBranchID.Value;
            }
            else
            {
                cmbBranch.SelectedValue = 0; // "Not Assigned"
            }

            _isEditMode = true;
            _editingUserId = user.UserID;
            lblStaffFormTitle.Text = "Edit Staff";
            btnSaveStaff.Text = "Update Staff";
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

        // TR: Düzenle butonu tıklama olayı
        // EN: Edit button click event
        private void BtnEditStaff_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir personel seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithUser(selectedUser);
            tabControlStaff.SelectedIndex = 1; // Switch to Staff Add/Edit tab
        }

        // TR: Sil butonu tıklama olayı
        // EN: Delete button click event
        private void BtnDeleteStaff_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Lütfen silmek için bir personel seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent deleting current user
            if (selectedUser.UserID == CurrentUser.UserID)
            {
                MessageBox.Show("Kendi hesabınızı silemezsiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{selectedUser.FullName}' adlı personeli silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve personelin tüm verilerini silecektir.",
                "Personel Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _userRepository.Delete(selectedUser.UserID);
                    if (success)
                    {
                        MessageBox.Show("Personel başarıyla silindi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaff(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Personel silinirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Personel silinirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Durum değiştir butonu tıklama olayı
        // EN: Toggle status button click event
        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Lütfen durumunu değiştirmek için bir personel seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent deactivating current user
            if (selectedUser.UserID == CurrentUser.UserID && selectedUser.UserActive)
            {
                MessageBox.Show("Kendi hesabınızı pasif hale getiremezsiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusText = selectedUser.UserActive ? "pasif" : "aktif";
            var result = MessageBox.Show(
                $"'{selectedUser.FullName}' adlı personeli {statusText} hale getirmek istediğinizden emin misiniz?",
                "Durum Değiştirme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _userRepository.SetUserStatus(selectedUser.UserID, !selectedUser.UserActive);
                    if (success)
                    {
                        MessageBox.Show($"Personel durumu başarıyla {statusText} hale getirildi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaff(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Personel durumu değiştirilirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Personel durumu değiştirilirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Yenile butonu tıklama olayı
        // EN: Refresh button click event
        private void BtnRefreshStaff_Click(object sender, EventArgs e)
        {
            LoadStaff();
            MessageBox.Show("Personel listesi yenilendi.",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // TR: Kaydet butonu tıklama olayı
        // EN: Save button click event
        private void BtnSaveStaff_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(txtUserFirstName.Text) ||
                    string.IsNullOrEmpty(txtUserLastName.Text) ||
                    string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtUserPassword.Text) ||
                    string.IsNullOrEmpty(txtUserEmail.Text) ||
                    string.IsNullOrEmpty(txtUserPhone.Text) ||
                    cmbRole.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen tüm gerekli alanları doldurun.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if username already exists (for new users or different users)
                var existingUser = _userRepository.GetByUsername(txtUsername.Text);
                if (existingUser != null && (!_isEditMode || existingUser.UserID != _editingUserId))
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kullanılmaktadır.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create or update user object
                User user;
                if (_isEditMode)
                {
                    user = _userRepository.GetById(_editingUserId);
                    if (user == null)
                    {
                        MessageBox.Show("Düzenlenecek kullanıcı bulunamadı.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    user = new User();
                }

                // Fill user object
                user.UserFirstName = txtUserFirstName.Text.Trim();
                user.UserLastName = txtUserLastName.Text.Trim();
                user.Username = txtUsername.Text.Trim();
                user.UserPassword = txtUserPassword.Text;
                user.UserEmail = txtUserEmail.Text.Trim();
                user.UserPhone = txtUserPhone.Text.Trim();
                user.UserRoleID = (int)cmbRole.SelectedValue;
                user.UserBranchID = (int)cmbBranch.SelectedValue == 0 ? null : (int?)cmbBranch.SelectedValue;
                user.UserActive = chkUserActive.Checked;

                // Save to database
                bool success;
                if (_isEditMode)
                {
                    success = _userRepository.Update(user);
                }
                else
                {
                    int newUserId = _userRepository.Insert(user);
                    success = newUserId > 0;
                }

                if (success)
                {
                    string message = _isEditMode ? "Personel başarıyla güncellendi." : "Personel başarıyla eklendi.";
                    MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadStaff(); // Refresh the list
                    tabControlStaff.SelectedIndex = 0; // Switch to Staff List tab
                }
                else
                {
                    string message = _isEditMode ? "Personel güncellenirken bir hata oluştu." : "Personel eklenirken bir hata oluştu.";
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem sırasında hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: İptal butonu tıklama olayı
        // EN: Cancel button click event
        private void BtnCancelStaff_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControlStaff.SelectedIndex = 0; // Switch to Staff List tab
        }
    }
}