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
    // Kullanıcı arayüzünde personel yönetimi ile ilgili işlemleri gerçekleştiren kontrolü temsil eder.
    public partial class StaffControl : UserControl
    {
        // Veritabanındaki kullanıcı (personel) işlemleri için repository.
        private UserRepository _userRepository;
        // Veritabanındaki rol işlemleri için repository.
        private RoleRepository _roleRepository;
        // Veritabanındaki şube işlemleri için repository.
        private BranchRepository _branchRepository;
        // Personel listesini tutar.
        private List<User> _staffList;
        // Rol listesini tutar.
        private List<Role> _roleList;
        // Şube listesini tutar.
        private List<Branch> _branchList;
        // Formun düzenleme modunda olup olmadığını belirtir.
        private bool _isEditMode = false;
        // Düzenlenen kullanıcının kimliğini tutar.
        private int _editingUserId = 0;

        // StaffControl sınıfının yapıcı metodu.
        // Gerekli repository nesnelerini başlatır ve Load olayını bağlar.
        public StaffControl()
        {
            InitializeComponent(); // Form bileşenlerini başlatır.
            _userRepository = new UserRepository(); // Kullanıcı repository'sini oluşturur.
            _roleRepository = new RoleRepository(); // Rol repository'sini oluşturur.
            _branchRepository = new BranchRepository(); // Şube repository'sini oluşturur.

            // Kontrol yüklendiğinde StaffControl_Load metodunu çağırır.
            this.Load += StaffControl_Load;
        }

        // StaffControl yüklendiğinde çağrılan metot.
        // Personel, rol ve şube verilerini yükler.
        private void StaffControl_Load(object sender, EventArgs e)
        {
            // Admin ve Şube Müdürü personel yönetebilir
            if (!CurrentUser.CanPerformAction("manage_staff"))
            {
                MessageBox.Show("You do not have access to this page.", "Unauthorized Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            LoadStaff();
            LoadRoles();
            LoadBranches();

            // Şube müdürü sadece kendi şubesindeki personeli görebilir
            if (CurrentUser.IsBranchManager() && CurrentUser.BranchID.HasValue)
            {
                _staffList = _staffList.Where(s => s.UserBranchID == CurrentUser.BranchID.Value).ToList();
                sfDataGridStaff.DataSource = _staffList;

                // Şube seçimini sadece kendi şubesi olarak sabitle
                cmbBranch.SelectedValue = CurrentUser.BranchID.Value;
                cmbBranch.Enabled = false;
            }
        }

        // Personel verilerini veritabanından yükler ve DataGrid'e bağlar.
        private void LoadStaff()
        {
            try
            {
                // Tüm personelleri veritabanından alır.
                _staffList = _userRepository.GetAll();

                // Her bir personel için rol ve şube bilgilerini yükler.
                foreach (var user in _staffList)
                {
                    if (user.UserRoleID > 0)
                    {
                        // Kullanıcının rolünü ID'sine göre bulur.
                        user.Role = _roleRepository.GetById(user.UserRoleID);
                    }
                    else
                    {
                        // Rol atanmamışsa varsayılan bir rol nesnesi oluşturur.
                        user.Role = new Role { RoleName = "Unassigned" };
                    }

                    if (user.UserBranchID.HasValue && user.UserBranchID.Value > 0)
                    {
                        // Kullanıcının şubesini ID'sine göre bulur.
                        user.Branch = _branchRepository.GetById(user.UserBranchID.Value);
                    }
                    else
                    {
                        // Şube atanmamışsa varsayılan bir şube nesnesi oluşturur.
                        user.Branch = new Branch { BranchName = "Unassigned" };
                    }
                }

                // Personel listesini DataGrid'e veri kaynağı olarak atar.
                sfDataGridStaff.DataSource = _staffList;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading staff data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Rolleri veritabanından yükler ve ComboBox'a bağlar.
        private void LoadRoles()
        {
            try
            {
                // Tüm rolleri veritabanından alır.
                _roleList = _roleRepository.GetAll();
                // Rol listesini ComboBox'a veri kaynağı olarak atar.
                cmbRole.DataSource = _roleList;
                // ComboBox'ta gösterilecek alan adını belirler (Rol Adı).
                cmbRole.DisplayMember = "RoleName";
                // ComboBox'ta değer olarak kullanılacak alan adını belirler (Rol ID).
                cmbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading role data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Şubeleri veritabanından yükler ve ComboBox'a bağlar.
        // "Atanmamış" seçeneğini de ekler.
        private void LoadBranches()
        {
            try
            {
                // Aktif şubeleri veritabanından alır.
                _branchList = _branchRepository.GetActiveBranches();

                // ComboBox için "Atanmamış" seçeneğini içeren yeni bir liste oluşturur.
                var branchesWithEmpty = new List<Branch>
                {
                    new Branch { BranchID = 0, BranchName = "Unassigned" } // Varsayılan "Atanmamış" seçeneği.
                };
                // Mevcut şube listesini bu yeni listeye ekler.
                branchesWithEmpty.AddRange(_branchList);

                // Şube listesini ComboBox'a veri kaynağı olarak atar.
                cmbBranch.DataSource = branchesWithEmpty;
                // ComboBox'ta gösterilecek alan adını belirler (Şube Adı).
                cmbBranch.DisplayMember = "BranchName";
                // ComboBox'ta değer olarak kullanılacak alan adını belirler (Şube ID).
                cmbBranch.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading branch data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataGrid'de seçili olan personeli döndürür.
        private User GetSelectedUser()
        {
            try
            {
                // DataGrid'de geçerli bir satır seçilmişse ve bu satır personel listesi sınırları içindeyse,
                // seçili personeli döndürür.
                if (sfDataGridStaff.SelectedIndex >= 0 && sfDataGridStaff.SelectedIndex < _staffList.Count)
                {
                    return _staffList[sfDataGridStaff.SelectedIndex];
                }
                // Seçili personel yoksa null döndürür.
                return null;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error retrieving selected user: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Personel ekleme/düzenleme formundaki alanları temizler.
        // Formu yeni personel ekleme moduna ayarlar.
        private void ClearForm()
        {
            // Metin kutularını temizler.
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtUsername.Text = "";
            txtUserPassword.Text = "";
            txtUserEmail.Text = "";
            txtUserPhone.Text = "";
            // Rol ComboBox'ında seçimi kaldırır.
            cmbRole.SelectedIndex = -1;
            // Şube ComboBox'ını "Atanmamış" olarak ayarlar.
            cmbBranch.SelectedValue = 0; // "Atanmamış" seçeneğinin ID'si 0 olarak kabul edilir.
            // Kullanıcı aktif mi kontrol kutusunu işaretler.
            chkUserActive.Checked = true;

            // Düzenleme modunu kapatır.
            _isEditMode = false;
            // Düzenlenen kullanıcı ID'sini sıfırlar.
            _editingUserId = 0;
            // Form başlığını "Yeni Personel Ekle" olarak ayarlar.
            lblStaffFormTitle.Text = "Add New Staff";
            // Kaydet butonunun metnini "Personeli Kaydet" olarak ayarlar.
            btnSaveStaff.Text = "Save Staff";
        }

        // Seçili personelin bilgilerini personel ekleme/düzenleme formundaki alanlara doldurur.
        // Formu düzenleme moduna ayarlar.
        private void FillFormWithUser(User user)
        {
            // Eğer kullanıcı nesnesi null ise metottan çıkar.
            if (user == null) return;

            // Kullanıcı bilgilerini ilgili metin kutularına doldurur.
            txtUserFirstName.Text = user.UserFirstName;
            txtUserLastName.Text = user.UserLastName;
            txtUsername.Text = user.Username;
            txtUserPassword.Text = user.UserPassword; // Şifre alanı genellikle güvenlik nedeniyle doldurulmaz veya farklı yönetilir.
            txtUserEmail.Text = user.UserEmail;
            txtUserPhone.Text = user.UserPhone;
            chkUserActive.Checked = user.UserActive;

            // Kullanıcının rolünü ComboBox'ta seçer.
            if (user.UserRoleID > 0)
            {
                cmbRole.SelectedValue = user.UserRoleID;
            }
            else
            {
                // Rol atanmamışsa ComboBox'ta seçimi kaldırır.
                cmbRole.SelectedIndex = -1;
            }

            // Kullanıcının şubesini ComboBox'ta seçer.
            if (user.UserBranchID.HasValue && user.UserBranchID.Value > 0)
            {
                cmbBranch.SelectedValue = user.UserBranchID.Value;
            }
            else
            {
                // Şube atanmamışsa "Atanmamış" seçeneğini seçer.
                cmbBranch.SelectedValue = 0;
            }

            // Düzenleme modunu açar.
            _isEditMode = true;
            // Düzenlenen kullanıcı ID'sini ayarlar.
            _editingUserId = user.UserID;
            // Form başlığını "Personeli Düzenle" olarak ayarlar.
            lblStaffFormTitle.Text = "Edit Staff";
            // Kaydet butonunun metnini "Personeli Güncelle" olarak ayarlar.
            btnSaveStaff.Text = "Update Staff";
        }

        // DataGrid'deki satırların stilini özelleştirmek için kullanılan olay metodu.
        // Satırları dönüşümlü olarak farklı arka plan renkleriyle boyar.
        private void SfDataGridStaff_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Sadece veri satırları için stil uygular.
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Çift sıralı satırların arka planını beyaz yapar.
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                // Tek sıralı satırların arka planını açık mavi yapar.
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255);
            }
        }

        // "Düzenle" butonuna tıklandığında çağrılan olay metodu.
        // Seçili personelin bilgilerini forma yükler ve düzenleme sekmesine geçer.
        private void BtnEditStaff_Click(object sender, EventArgs e)
        {
            // DataGrid'den seçili personeli alır.
            var selectedUser = GetSelectedUser();
            // Eğer personel seçilmemişse uyarı mesajı gösterir ve metottan çıkar.
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a staff member to edit.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili personelin bilgilerini forma doldurur.
            FillFormWithUser(selectedUser);
            // Personel Ekle/Düzenle sekmesine geçer (TabControl'deki ikinci sekme).
            tabControlStaff.SelectedIndex = 1;
        }

        // "Sil" butonuna tıklandığında çağrılan olay metodu.
        // Seçili personeli silmeden önce onay ister.
        private void BtnDeleteStaff_Click(object sender, EventArgs e)
        {
            // DataGrid'den seçili personeli alır.
            var selectedUser = GetSelectedUser();
            // Eğer personel seçilmemişse uyarı mesajı gösterir ve metottan çıkar.
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a staff member to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcının kendi hesabını silmesini engeller.
            if (selectedUser.UserID == CurrentUser.UserID) // CurrentUser, o an giriş yapmış kullanıcıyı temsil eder.
            {
                MessageBox.Show("You cannot delete your own account.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Silme işlemi için kullanıcıdan onay alır.
            var result = MessageBox.Show(
                $"Are you sure you want to delete the staff member '{selectedUser.FullName}'?\n\n" +
                "This action cannot be undone and will delete all data for this staff member.",
                "Confirm Staff Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse silme işlemini gerçekleştirir.
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Personeli veritabanından siler.
                    bool success = _userRepository.Delete(selectedUser.UserID);
                    if (success)
                    {
                        // Başarılı olursa bilgi mesajı gösterir ve personel listesini yeniler.
                        MessageBox.Show("Staff member deleted successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaff();
                    }
                    else
                    {
                        // Başarısız olursa hata mesajı gösterir.
                        MessageBox.Show("An error occurred while deleting the staff member.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                    MessageBox.Show($"An error occurred while deleting the staff member: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Durum Değiştir" butonuna tıklandığında çağrılan olay metodu.
        // Seçili personelin aktif/pasif durumunu değiştirir.
        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            // DataGrid'den seçili personeli alır.
            var selectedUser = GetSelectedUser();
            // Eğer personel seçilmemişse uyarı mesajı gösterir ve metottan çıkar.
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a staff member to change their status.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcının kendi hesabını pasif hale getirmesini engeller.
            if (selectedUser.UserID == CurrentUser.UserID && selectedUser.UserActive)
            {
                MessageBox.Show("You cannot deactivate your own account.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Değiştirilecek durumu belirler (aktif ise pasif, pasif ise aktif).
            string statusText = selectedUser.UserActive ? "inactive" : "active";
            // Durum değiştirme işlemi için kullanıcıdan onay alır.
            var result = MessageBox.Show(
                $"Are you sure you want to make the staff member '{selectedUser.FullName}' {statusText}?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse durum değiştirme işlemini gerçekleştirir.
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Personelin durumunu veritabanında günceller.
                    bool success = _userRepository.SetUserStatus(selectedUser.UserID, !selectedUser.UserActive);
                    if (success)
                    {
                        // Başarılı olursa bilgi mesajı gösterir ve personel listesini yeniler.
                        MessageBox.Show($"Staff member status successfully changed to {statusText}.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaff();
                    }
                    else
                    {
                        // Başarısız olursa hata mesajı gösterir.
                        MessageBox.Show("An error occurred while changing the staff member's status.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                    MessageBox.Show($"An error occurred while changing the staff member's status: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Yenile" butonuna tıklandığında çağrılan olay metodu.
        // Personel listesini yeniden yükler.
        private void BtnRefreshStaff_Click(object sender, EventArgs e)
        {
            LoadStaff(); // Personel verilerini yeniden yükler.
            MessageBox.Show("Staff list refreshed.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // "Kaydet" (veya "Güncelle") butonuna tıklandığında çağrılan olay metodu.
        // Formdaki bilgileri kullanarak yeni personel ekler veya mevcut personeli günceller.
        private void BtnSaveStaff_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder.
                if (string.IsNullOrEmpty(txtUserFirstName.Text) ||
                    string.IsNullOrEmpty(txtUserLastName.Text) ||
                    string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtUserPassword.Text) || // Yeni kullanıcı eklerken veya şifre değiştirilirken şifre zorunludur.
                    string.IsNullOrEmpty(txtUserEmail.Text) ||
                    string.IsNullOrEmpty(txtUserPhone.Text) ||
                    cmbRole.SelectedValue == null) // Rol seçimi zorunludur.
                {
                    MessageBox.Show("Please fill in all required fields.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcı adının mevcut olup olmadığını kontrol eder.
                // Yeni kullanıcı eklerken veya farklı bir kullanıcı için kullanıcı adı değiştirilirken bu kontrol yapılır.
                var existingUser = _userRepository.GetByUsername(txtUsername.Text.Trim());
                if (existingUser != null && (!_isEditMode || existingUser.UserID != _editingUserId))
                {
                    MessageBox.Show("This username is already in use.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // User nesnesini oluşturur veya günceller.
                User user;
                if (_isEditMode) // Düzenleme modundaysa mevcut kullanıcıyı alır.
                {
                    user = _userRepository.GetById(_editingUserId);
                    if (user == null)
                    {
                        MessageBox.Show("The user to be edited was not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // Yeni personel ekleme modundaysa yeni bir User nesnesi oluşturur.
                {
                    user = new User();
                }

                // User nesnesinin alanlarını formdaki değerlerle doldurur.
                user.UserFirstName = txtUserFirstName.Text.Trim();
                user.UserLastName = txtUserLastName.Text.Trim();
                user.Username = txtUsername.Text.Trim();
                user.UserPassword = txtUserPassword.Text; // Şifre olduğu gibi alınır, hash'leme işlemi repository katmanında yapılabilir.
                user.UserEmail = txtUserEmail.Text.Trim();
                user.UserPhone = txtUserPhone.Text.Trim();
                user.UserRoleID = (int)cmbRole.SelectedValue;
                // Şube ID'si 0 ise (yani "Atanmamış" seçiliyse) null olarak ayarlanır, değilse seçili değer atanır.
                user.UserBranchID = (int)cmbBranch.SelectedValue == 0 ? null : (int?)cmbBranch.SelectedValue;
                user.UserActive = chkUserActive.Checked;

                // Veritabanına kaydeder (ekler veya günceller).
                bool success;
                if (_isEditMode)
                {
                    success = _userRepository.Update(user); // Kullanıcıyı günceller.
                }
                else
                {
                    int newUserId = _userRepository.Insert(user); // Yeni kullanıcı ekler.
                    success = newUserId > 0; // Ekleme başarılıysa ID 0'dan büyük olur.
                }

                if (success)
                {
                    // Başarılı olursa duruma göre mesaj gösterir.
                    string message = _isEditMode ? "Staff member updated successfully." : "Staff member added successfully.";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm(); // Formu temizler.
                    LoadStaff(); // Personel listesini yeniler.
                    tabControlStaff.SelectedIndex = 0; // Personel Listesi sekmesine geçer.
                }
                else
                {
                    // Başarısız olursa duruma göre hata mesajı gösterir.
                    string message = _isEditMode ? "An error occurred while updating the staff member." : "An error occurred while adding the staff member.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Genel bir hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"An error occurred during the operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "İptal" butonuna tıklandığında çağrılan olay metodu.
        // Formu temizler ve personel listesi sekmesine geri döner.
        private void BtnCancelStaff_Click(object sender, EventArgs e)
        {
            ClearForm(); // Formu temizler.
            tabControlStaff.SelectedIndex = 0; // Personel Listesi sekmesine geçer.
        }
    }
}