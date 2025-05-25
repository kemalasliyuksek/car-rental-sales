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
        private BranchRepository _branchRepository;
        private List<Branch> _branchList;
        private bool _isEditMode = false;
        private int _editingBranchId = 0;

        public BranchesControl()
        {
            InitializeComponent();
            _branchRepository = new BranchRepository();

            this.Load += BranchControl_Load;
        }

        private void BranchControl_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        // TR: Bu metot, şube verilerini yükler ve veri tablosuna atar.
        // EN: This method loads the branch data and assigns it to the data table.
        private void LoadBranches()
        {
            try
            {
                _branchList = _branchRepository.GetAll();
                sfDataGridBranch.DataSource = _branchList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şube verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, seçili şubeyi döndürür.
        // EN: This method returns the selected branch.
        private Branch GetSelectedBranch()
        {
            try
            {
                if (sfDataGridBranch.SelectedIndex >= 0 && sfDataGridBranch.SelectedIndex < _branchList.Count)
                {
                    return _branchList[sfDataGridBranch.SelectedIndex];
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seçili şube alınırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // TR: Bu metot, form alanlarını temizler.
        // EN: This method clears the form fields.
        private void ClearForm()
        {
            txtBranchName.Text = "";
            txtBranchAddress.Text = "";
            txtBranchPhone.Text = "";
            txtBranchEmail.Text = "";
            chkBranchActive.Checked = true;

            _isEditMode = false;
            _editingBranchId = 0;
            lblBranchFormTitle.Text = "Add New Branch";
            btnSaveBranch.Text = "Save Branch";
        }

        // TR: Bu metot, seçili şubenin bilgilerini forma doldurur.
        // EN: This method fills the form with the selected branch's information.
        private void FillFormWithBranch(Branch branch)
        {
            if (branch == null) return;

            txtBranchName.Text = branch.BranchName;
            txtBranchAddress.Text = branch.BranchAddress;
            txtBranchPhone.Text = branch.BranchPhone;
            txtBranchEmail.Text = branch.BranchEmail;
            chkBranchActive.Checked = branch.BranchActive;

            _isEditMode = true;
            _editingBranchId = branch.BranchID;
            lblBranchFormTitle.Text = "Edit Branch";
            btnSaveBranch.Text = "Update Branch";
        }

        // TR: Bu metot, veri tablosundaki satırların stilini özelleştirir.
        // EN: This method customizes the style of the rows in the data table.
        private void SfDataGridBranch_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
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
        private void BtnEditBranch_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch();
            if (selectedBranch == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir şube seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithBranch(selectedBranch);
            tabControlBranch.SelectedIndex = 1; // Switch to Branch Add/Edit tab
        }

        // TR: Sil butonu tıklama olayı
        // EN: Delete button click event
        private void BtnDeleteBranch_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch();
            if (selectedBranch == null)
            {
                MessageBox.Show("Lütfen silmek için bir şube seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if current user's branch
            if (CurrentUser.BranchID.HasValue && selectedBranch.BranchID == CurrentUser.BranchID.Value)
            {
                MessageBox.Show("Kendi şubenizi silemezsiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{selectedBranch.BranchName}' adlı şubeyi silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve şubenin tüm verilerini silecektir.",
                "Şube Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _branchRepository.Delete(selectedBranch.BranchID);
                    if (success)
                    {
                        MessageBox.Show("Şube başarıyla silindi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBranches(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Şube silinirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Şube silinirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Durum değiştir butonu tıklama olayı
        // EN: Toggle status button click event
        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            var selectedBranch = GetSelectedBranch();
            if (selectedBranch == null)
            {
                MessageBox.Show("Lütfen durumunu değiştirmek için bir şube seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent deactivating current user's branch
            if (CurrentUser.BranchID.HasValue && selectedBranch.BranchID == CurrentUser.BranchID.Value && selectedBranch.BranchActive)
            {
                MessageBox.Show("Kendi şubenizi pasif hale getiremezsiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusText = selectedBranch.BranchActive ? "pasif" : "aktif";
            var result = MessageBox.Show(
                $"'{selectedBranch.BranchName}' adlı şubeyi {statusText} hale getirmek istediğinizden emin misiniz?",
                "Durum Değiştirme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _branchRepository.SetBranchStatus(selectedBranch.BranchID, !selectedBranch.BranchActive);
                    if (success)
                    {
                        MessageBox.Show($"Şube durumu başarıyla {statusText} hale getirildi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBranches(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Şube durumu değiştirilirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Şube durumu değiştirilirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Yenile butonu tıklama olayı
        // EN: Refresh button click event
        private void BtnRefreshBranch_Click(object sender, EventArgs e)
        {
            LoadBranches();
            MessageBox.Show("Şube listesi yenilendi.",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // TR: Kaydet butonu tıklama olayı
        // EN: Save button click event
        private void BtnSaveBranch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(txtBranchName.Text) ||
                    string.IsNullOrEmpty(txtBranchAddress.Text) ||
                    string.IsNullOrEmpty(txtBranchPhone.Text))
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun (Şube Adı, Adres, Telefon).",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate phone number format (basic validation)
                if (txtBranchPhone.Text.Length < 10)
                {
                    MessageBox.Show("Lütfen geçerli bir telefon numarası girin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format if provided
                if (!string.IsNullOrEmpty(txtBranchEmail.Text) && !IsValidEmail(txtBranchEmail.Text))
                {
                    MessageBox.Show("Lütfen geçerli bir e-posta adresi girin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create or update branch object
                Branch branch;
                if (_isEditMode)
                {
                    branch = _branchRepository.GetById(_editingBranchId);
                    if (branch == null)
                    {
                        MessageBox.Show("Düzenlenecek şube bulunamadı.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    branch = new Branch();
                }

                // Fill branch object
                branch.BranchName = txtBranchName.Text.Trim();
                branch.BranchAddress = txtBranchAddress.Text.Trim();
                branch.BranchPhone = txtBranchPhone.Text.Trim();
                branch.BranchEmail = string.IsNullOrEmpty(txtBranchEmail.Text) ? null : txtBranchEmail.Text.Trim();
                branch.BranchActive = chkBranchActive.Checked;

                // Save to database
                bool success;
                if (_isEditMode)
                {
                    success = _branchRepository.Update(branch);
                }
                else
                {
                    int newBranchId = _branchRepository.Insert(branch);
                    success = newBranchId > 0;
                }

                if (success)
                {
                    string message = _isEditMode ? "Şube başarıyla güncellendi." : "Şube başarıyla eklendi.";
                    MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadBranches(); // Refresh the list
                    tabControlBranch.SelectedIndex = 0; // Switch to Branch List tab
                }
                else
                {
                    string message = _isEditMode ? "Şube güncellenirken bir hata oluştu." : "Şube eklenirken bir hata oluştu.";
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
        private void BtnCancelBranch_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControlBranch.SelectedIndex = 0; // Switch to Branch List tab
        }

        // TR: E-posta formatını kontrol eden yardımcı metot
        // EN: Helper method to validate email format
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
    }
}