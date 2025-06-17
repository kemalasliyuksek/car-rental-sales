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
    public partial class BranchesControl : UserControl
    {
        // Şube verilerine erişmek için kullanılan repository nesnesi
        private BranchRepository _branchRepository;
        // Şubelerin listesini tutar
        private List<Branch> _branchList;
        // Formun düzenleme modunda olup olmadığını belirtir
        private bool _isEditMode = false;
        // Düzenlenmekte olan şubenin kimliğini tutar
        private int _editingBranchId = 0;

        // Kontrolün yapıcı metodu, ilk oluşturulduğunda çalışır
        public BranchesControl()
        {
            InitializeComponent(); // Form bileşenlerini başlatır
            _branchRepository = new BranchRepository(); // Şube repository'sini oluşturur

            this.Load += BranchControl_Load; // Kontrol yüklendiğinde BranchControl_Load metodunu çağırır
        }

        // Kontrol yüklendiğinde çalışan olay metodu
        private void BranchControl_Load(object sender, EventArgs e)
        {
            // Sadece Admin şubeleri yönetebilir
            if (!CurrentUser.IsAdmin())
            {
                MessageBox.Show("You do not have access to this page.", "Unauthorized Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            LoadBranches();
        }

        // Şube verilerini veritabanından yükler ve DataGrid'de gösterir
        private void LoadBranches()
        {
            try
            {
                _branchList = _branchRepository.GetAll(); // Tüm şubeleri veritabanından alır
                sfDataGridBranch.DataSource = _branchList; // DataGrid'e şube listesini atar
            }
            catch (Exception ex)
            {
                // Hata oluşursa kullanıcıya bilgi mesajı gösterir
                MessageBox.Show($"Error loading branch data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataGrid'de seçili olan şubeyi döndürür
        private Branch GetSelectedBranch()
        {
            try
            {
                // DataGrid'de geçerli bir satır seçilmişse ve bu satır şube listesi sınırları içindeyse
                if (sfDataGridBranch.SelectedIndex >= 0 && sfDataGridBranch.SelectedIndex < _branchList.Count)
                {
                    return _branchList[sfDataGridBranch.SelectedIndex]; // Seçili şubeyi döndürür
                }
                return null; // Seçili şube yoksa null döndürür
            }
            catch (Exception ex)
            {
                // Hata oluşursa kullanıcıya bilgi mesajı gösterir
                MessageBox.Show($"Error getting selected branch: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Formdaki giriş alanlarını temizler ve formu başlangıç durumuna getirir
        private void ClearForm()
        {
            txtBranchName.Text = ""; // Şube adı alanını temizler
            txtBranchAddress.Text = ""; // Şube adresi alanını temizler
            txtBranchPhone.Text = ""; // Şube telefon alanını temizler
            txtBranchEmail.Text = ""; // Şube e-posta alanını temizler
            chkBranchActive.Checked = true; // Şube aktiflik durumunu varsayılan olarak işaretli yapar

            _isEditMode = false; // Düzenleme modunu kapatır
            _editingBranchId = 0; // Düzenlenen şube kimliğini sıfırlar
            lblBranchFormTitle.Text = "Add New Branch"; // Form başlığını "Yeni Şube Ekle" olarak ayarlar
            btnSaveBranch.Text = "Save Branch"; // Kaydet butonunun metnini "Şubeyi Kaydet" olarak ayarlar
        }

        // Seçilen şubenin bilgilerini formdaki alanlara doldurur
        private void FillFormWithBranch(Branch branch)
        {
            if (branch == null) return; // Eğer şube nesnesi boşsa işlem yapmaz

            txtBranchName.Text = branch.BranchName; // Şube adını forma yazar
            txtBranchAddress.Text = branch.BranchAddress; // Şube adresini forma yazar
            txtBranchPhone.Text = branch.BranchPhone; // Şube telefonunu forma yazar
            txtBranchEmail.Text = branch.BranchEmail; // Şube e-postasını forma yazar
            chkBranchActive.Checked = branch.BranchActive; // Şube aktiflik durumunu forma yazar

            _isEditMode = true; // Düzenleme modunu açar
            _editingBranchId = branch.BranchID; // Düzenlenen şubenin kimliğini ayarlar
            lblBranchFormTitle.Text = "Edit Branch"; // Form başlığını "Şubeyi Düzenle" olarak ayarlar
            btnSaveBranch.Text = "Update Branch"; // Kaydet butonunun metnini "Şubeyi Güncelle" olarak ayarlar
        }

        // DataGrid'deki satırların stilini (görünümünü) özelleştirir
        private void SfDataGridBranch_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Eğer satır tipi varsayılan veri satırı ise
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Satır indeksi çift ise arka plan rengini beyaz yapar
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                // Satır indeksi tek ise arka plan rengini açık mavi yapar (zebra deseni)
                else
                    e.Style.BackColor = Color.FromArgb(240, 245, 255);
            }
        }

        // "Düzenle" butonuna tıklandığında çalışan olay metodu
        private void BtnEditBranch_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch(); // DataGrid'den seçili şubeyi alır
            if (selectedBranch == null)
            {
                // Eğer şube seçilmemişse kullanıcıya uyarı mesajı gösterir
                MessageBox.Show("Please select a branch to edit.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithBranch(selectedBranch); // Seçili şube bilgileriyle formu doldurur
            tabControlBranch.SelectedIndex = 1; // "Şube Ekle/Düzenle" sekmesine geçer
        }

        // "Sil" butonuna tıklandığında çalışan olay metodu
        private void BtnDeleteBranch_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch(); // DataGrid'den seçili şubeyi alır
            if (selectedBranch == null)
            {
                // Eğer şube seçilmemişse kullanıcıya uyarı mesajı gösterir
                MessageBox.Show("Please select a branch to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mevcut kullanıcının kendi şubesini silmesini engeller
            if (CurrentUser.BranchID.HasValue && selectedBranch.BranchID == CurrentUser.BranchID.Value)
            {
                MessageBox.Show("You cannot delete your own branch.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıya silme işlemini onaylatır
            var result = MessageBox.Show(
                $"Are you sure you want to delete the branch named '{selectedBranch.BranchName}'?\n\n" +
                "This action cannot be undone and will delete all data for the branch.",
                "Confirm Branch Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse silme işlemini gerçekleştirir
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _branchRepository.Delete(selectedBranch.BranchID); // Şubeyi veritabanından siler
                    if (success)
                    {
                        // Başarılı olursa kullanıcıya bilgi mesajı gösterir
                        MessageBox.Show("Branch deleted successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBranches(); // Şube listesini yeniler
                    }
                    else
                    {
                        // Başarısız olursa kullanıcıya hata mesajı gösterir
                        MessageBox.Show("An error occurred while deleting the branch.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hata oluşursa kullanıcıya detaylı hata mesajı gösterir
                    MessageBox.Show($"Error deleting branch: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Durum Değiştir" butonuna tıklandığında çalışan olay metodu
        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch(); // DataGrid'den seçili şubeyi alır
            if (selectedBranch == null)
            {
                // Eğer şube seçilmemişse kullanıcıya uyarı mesajı gösterir
                MessageBox.Show("Please select a branch to change its status.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mevcut kullanıcının kendi şubesini pasif hale getirmesini engeller
            if (CurrentUser.BranchID.HasValue && selectedBranch.BranchID == CurrentUser.BranchID.Value && selectedBranch.BranchActive)
            {
                MessageBox.Show("You cannot deactivate your own branch.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şubenin mevcut durumuna göre onay mesajındaki metni ayarlar
            string statusText = selectedBranch.BranchActive ? "inactive" : "active";
            // Kullanıcıya durum değiştirme işlemini onaylatır
            var result = MessageBox.Show(
                $"Are you sure you want to make the branch '{selectedBranch.BranchName}' {statusText}?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse durum değiştirme işlemini gerçekleştirir
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Şubenin durumunu veritabanında günceller (aktifse pasif, pasifse aktif yapar)
                    bool success = _branchRepository.SetBranchStatus(selectedBranch.BranchID, !selectedBranch.BranchActive);
                    if (success)
                    {
                        // Başarılı olursa kullanıcıya bilgi mesajı gösterir
                        MessageBox.Show($"Branch status successfully changed to {statusText}.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBranches(); // Şube listesini yeniler
                    }
                    else
                    {
                        // Başarısız olursa kullanıcıya hata mesajı gösterir
                        MessageBox.Show("An error occurred while changing the branch status.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hata oluşursa kullanıcıya detaylı hata mesajı gösterir
                    MessageBox.Show($"Error changing branch status: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Yenile" butonuna tıklandığında çalışan olay metodu
        private void BtnRefreshBranch_Click(object sender, EventArgs e)
        {
            LoadBranches(); // Şube listesini yeniden yükler
            // Kullanıcıya listenin yenilendiğine dair bilgi mesajı gösterir
            MessageBox.Show("Branch list refreshed.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // "Kaydet" (veya "Güncelle") butonuna tıklandığında çalışan olay metodu
        private void BtnSaveBranch_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların (Şube Adı, Adres, Telefon) dolu olup olmadığını kontrol eder
                if (string.IsNullOrEmpty(txtBranchName.Text) ||
                    string.IsNullOrEmpty(txtBranchAddress.Text) ||
                    string.IsNullOrEmpty(txtBranchPhone.Text))
                {
                    MessageBox.Show("Please fill in the required fields (Branch Name, Address, Phone).",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Telefon numarasının temel formatını kontrol eder (en az 10 karakter)
                if (txtBranchPhone.Text.Length < 10)
                {
                    MessageBox.Show("Please enter a valid phone number.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // E-posta adresi girilmişse formatının geçerli olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtBranchEmail.Text) && !IsValidEmail(txtBranchEmail.Text))
                {
                    MessageBox.Show("Please enter a valid email address.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Branch branch; // Şube nesnesini tanımlar
                // Eğer düzenleme modundaysa mevcut şubeyi alır
                if (_isEditMode)
                {
                    branch = _branchRepository.GetById(_editingBranchId);
                    if (branch == null)
                    {
                        // Düzenlenecek şube bulunamazsa hata mesajı gösterir
                        MessageBox.Show("The branch to be edited was not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Eğer ekleme modundaysa yeni bir şube nesnesi oluşturur
                else
                {
                    branch = new Branch();
                }

                // Şube nesnesinin özelliklerini formdaki verilerle doldurur
                branch.BranchName = txtBranchName.Text.Trim(); // Baştaki ve sondaki boşlukları temizler
                branch.BranchAddress = txtBranchAddress.Text.Trim();
                branch.BranchPhone = txtBranchPhone.Text.Trim();
                branch.BranchEmail = string.IsNullOrEmpty(txtBranchEmail.Text) ? null : txtBranchEmail.Text.Trim(); // E-posta boşsa null, değilse temizlenmiş halini atar
                branch.BranchActive = chkBranchActive.Checked;

                bool success; // İşlemin başarılı olup olmadığını tutar
                // Düzenleme modundaysa güncelleme işlemini yapar
                if (_isEditMode)
                {
                    success = _branchRepository.Update(branch);
                }
                // Ekleme modundaysa ekleme işlemini yapar
                else
                {
                    int newBranchId = _branchRepository.Insert(branch);
                    success = newBranchId > 0; // Yeni ID 0'dan büyükse başarılıdır
                }

                // İşlem başarılıysa
                if (success)
                {
                    // Duruma göre (ekleme/güncelleme) kullanıcıya bilgi mesajı gösterir
                    string message = _isEditMode ? "Branch updated successfully." : "Branch added successfully.";
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm(); // Formu temizler
                    LoadBranches(); // Şube listesini yeniler
                    tabControlBranch.SelectedIndex = 0; // "Şube Listesi" sekmesine geçer
                }
                // İşlem başarısızsa
                else
                {
                    // Duruma göre (ekleme/güncelleme) kullanıcıya hata mesajı gösterir
                    string message = _isEditMode ? "An error occurred while updating the branch." : "An error occurred while adding the branch.";
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Genel bir hata oluşursa kullanıcıya detaylı hata mesajı gösterir
                MessageBox.Show($"An error occurred during the operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "İptal" butonuna tıklandığında çalışan olay metodu
        private void BtnCancelBranch_Click(object sender, EventArgs e)
        {
            ClearForm(); // Formu temizler
            tabControlBranch.SelectedIndex = 0; // "Şube Listesi" sekmesine geçer
        }

        // Verilen e-posta adresinin formatının geçerli olup olmadığını kontrol eden yardımcı metot
        private bool IsValidEmail(string email)
        {
            try
            {
                // E-posta adresini System.Net.Mail.MailAddress sınıfı ile doğrulamaya çalışır
                var addr = new System.Net.Mail.MailAddress(email);
                // Eğer doğrulama başarılıysa ve adres, verilen e-postayla aynıysa true döner
                return addr.Address == email;
            }
            catch
            {
                // Doğrulama sırasında hata oluşursa (format geçersizse) false döner
                return false;
            }
        }
    }
}