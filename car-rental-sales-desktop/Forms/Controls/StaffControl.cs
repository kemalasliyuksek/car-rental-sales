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
        private List<Role> _roles;
        private List<Branch> _branches;

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

        // TR: Bu metot, rolleri yükler ve combobox'a atar.
        // EN: This method loads roles and assigns them to the combobox.
        private void LoadRoles()
        {
            try
            {
                _roles = _roleRepository.GetAll();

                // Customer ve Guest rollerini hariç tutuyoruz (sadece personel rolleri)
                var staffRoles = _roles.Where(r => r.RoleName != "Customer" && r.RoleName != "Guest").ToList();

                comboBoxRole.DataSource = staffRoles;
                comboBoxRole.DisplayMember = "RoleName";
                comboBoxRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, şubeleri yükler ve combobox'a atar.
        // EN: This method loads branches and assigns them to the combobox.
        private void LoadBranches()
        {
            try
            {
                _branches = _branchRepository.GetActiveBranches();

                comboBoxBranch.DataSource = _branches;
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şubeler yüklenirken hata oluştu: {ex.Message}",
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

        // TR: Bu metot, kaydet butonuna tıklandığında çalışır.
        // EN: This method runs when the save button is clicked.
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Doğrulama kontrolü
                if (!ValidateInput())
                    return;

                // Kullanıcı adı kontrolü
                if (IsUsernameExists(textBoxUsername.Text.Trim()))
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor. Lütfen farklı bir kullanıcı adı seçin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxUsername.Focus();
                    return;
                }

                // E-posta kontrolü
                if (IsEmailExists(textBoxEmail.Text.Trim()))
                {
                    MessageBox.Show("Bu e-posta adresi zaten kullanılıyor. Lütfen farklı bir e-posta adresi girin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEmail.Focus();
                    return;
                }

                // Yeni kullanıcı oluştur
                var newUser = new User
                {
                    UserFirstName = textBoxFirstName.Text.Trim(),
                    UserLastName = textBoxLastName.Text.Trim(),
                    Username = textBoxUsername.Text.Trim(),
                    UserPassword = textBoxPassword.Text, // Not: Gerçek projede şifre hashlenmelidir
                    UserEmail = textBoxEmail.Text.Trim(),
                    UserPhone = textBoxPhone.Text.Trim(),
                    UserRoleID = (int)comboBoxRole.SelectedValue,
                    UserBranchID = comboBoxBranch.SelectedValue != null ? (int?)comboBoxBranch.SelectedValue : null,
                    UserActive = checkBoxActive.Checked,
                    UserCreatedAt = DateTime.Now
                };

                // Veritabanına kaydet
                int newUserId = _userRepository.Insert(newUser);

                if (newUserId > 0)
                {
                    MessageBox.Show("Personel başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    ClearForm();

                    // Staff listesini yenile
                    LoadStaff();

                    // Staff List sekmesine geç
                    tabControlStaff.SelectedTab = tabPageStaffList;
                }
                else
                {
                    MessageBox.Show("Personel eklenirken bir hata oluştu.", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Personel eklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, temizle butonuna tıklandığında çalışır.
        // EN: This method runs when the clear button is clicked.
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // TR: Bu metot, formu temizler.
        // EN: This method clears the form.
        private void ClearForm()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";

            if (comboBoxRole.DataSource != null && _roles.Count > 0)
                comboBoxRole.SelectedIndex = 0;

            if (comboBoxBranch.DataSource != null && _branches.Count > 0)
                comboBoxBranch.SelectedIndex = 0;

            checkBoxActive.Checked = true;

            textBoxFirstName.Focus();
        }

        // TR: Bu metot, giriş verilerini doğrular.
        // EN: This method validates input data.
        private bool ValidateInput()
        {
            // İsim kontrolü
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("İsim alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }

            // Soyisim kontrolü
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Soyisim alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }

            // Kullanıcı adı kontrolü
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return false;
            }

            // Kullanıcı adı uzunluk kontrolü
            if (textBoxUsername.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kullanıcı adı en az 3 karakter olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return false;
            }

            // Şifre kontrolü
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Şifre alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            // Şifre uzunluk kontrolü
            if (textBoxPassword.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassword.Focus();
                return false;
            }

            // E-posta kontrolü
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("E-posta alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // E-posta format kontrolü
            if (!IsValidEmail(textBoxEmail.Text.Trim()))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            // Telefon kontrolü
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Telefon alanı boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPhone.Focus();
                return false;
            }

            // Rol kontrolü
            if (comboBoxRole.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir rol seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxRole.Focus();
                return false;
            }

            return true;
        }

        // TR: Bu metot, e-posta formatını kontrol eder.
        // EN: This method checks the email format.
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // TR: Bu metot, kullanıcı adının var olup olmadığını kontrol eder.
        // EN: This method checks if the username exists.
        private bool IsUsernameExists(string username)
        {
            try
            {
                var existingUser = _userRepository.GetByUsername(username);
                return existingUser != null;
            }
            catch
            {
                return false;
            }
        }

        // TR: Bu metot, e-posta adresinin var olup olmadığını kontrol eder.
        // EN: This method checks if the email address exists.
        private bool IsEmailExists(string email)
        {
            try
            {
                var allUsers = _userRepository.GetAll();
                return allUsers.Any(u => u.UserEmail.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }
    }
}