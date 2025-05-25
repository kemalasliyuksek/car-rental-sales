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
    public partial class CustomersControl : UserControl
    {
        private CustomerRepository _customerRepository;
        private List<Customer> _customerList;
        private bool _isEditMode = false;
        private int _editingCustomerId = 0;

        public CustomersControl()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();

            this.Load += CustomersControl_Load;
        }

        private void CustomersControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetupCustomerTypeComboBox();
        }

        // TR: Bu metot, müşteri verilerini yüklemek için kullanılır.
        // EN: This method is used to load customer data.
        private void LoadCustomers()
        {
            try
            {
                _customerList = _customerRepository.GetAllCustomers();
                sfDataGridCustomers.DataSource = _customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri verileri yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TR: Bu metot, müşteri tipi combobox'ını ayarlar.
        // EN: This method sets up the customer type combobox.
        private void SetupCustomerTypeComboBox()
        {
            cmbCustomerType.Items.Clear();
            cmbCustomerType.Items.Add("Individual");
            cmbCustomerType.Items.Add("Corporate");
            cmbCustomerType.SelectedIndex = 0; // Default to Individual
        }

        // TR: Bu metot, seçili müşteriyi döndürür.
        // EN: This method returns the selected customer.
        private Customer GetSelectedCustomer()
        {
            try
            {
                if (sfDataGridCustomers.SelectedIndex >= 0 && sfDataGridCustomers.SelectedIndex < _customerList.Count)
                {
                    return _customerList[sfDataGridCustomers.SelectedIndex];
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seçili müşteri alınırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // TR: Bu metot, form alanlarını temizler.
        // EN: This method clears the form fields.
        private void ClearForm()
        {
            txtCustomerFirstName.Text = "";
            txtCustomerLastName.Text = "";
            txtCustomerNationalID.Text = "";
            txtCustomerLicenseNumber.Text = "";
            txtCustomerLicenseClass.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerAddress.Text = "";
            dtpDateOfBirth.Checked = false;
            dtpLicenseDate.Checked = false;
            cmbCustomerType.SelectedIndex = 0; // Individual
            chkCustomerAvailable.Checked = true;

            _isEditMode = false;
            _editingCustomerId = 0;
            lblCustomerFormTitle.Text = "Add New Customer";
            btnSaveCustomer.Text = "Save Customer";
        }

        // TR: Bu metot, seçili müşterinin bilgilerini forma doldurur.
        // EN: This method fills the form with the selected customer's information.
        private void FillFormWithCustomer(Customer customer)
        {
            if (customer == null) return;

            txtCustomerFirstName.Text = customer.CustomerFirstName ?? "";
            txtCustomerLastName.Text = customer.CustomerLastName ?? "";
            txtCustomerNationalID.Text = customer.CustomerNationalID ?? "";
            txtCustomerLicenseNumber.Text = customer.CustomerLicenseNumber ?? "";
            txtCustomerLicenseClass.Text = customer.CustomerLicenseClass ?? "";
            txtCustomerPhone.Text = customer.CustomerPhone ?? "";
            txtCustomerEmail.Text = customer.CustomerEmail ?? "";
            txtCustomerAddress.Text = customer.CustomerAddress ?? "";
            chkCustomerAvailable.Checked = customer.CustomerAvailable;

            // Set date of birth
            if (customer.CustomerDateOfBirth.HasValue)
            {
                dtpDateOfBirth.Value = customer.CustomerDateOfBirth.Value;
                dtpDateOfBirth.Checked = true;
            }
            else
            {
                dtpDateOfBirth.Checked = false;
            }

            // Set license date
            if (customer.CustomerLicenseDate.HasValue)
            {
                dtpLicenseDate.Value = customer.CustomerLicenseDate.Value;
                dtpLicenseDate.Checked = true;
            }
            else
            {
                dtpLicenseDate.Checked = false;
            }

            // Set customer type
            if (!string.IsNullOrEmpty(customer.CustomerType))
            {
                int typeIndex = cmbCustomerType.Items.IndexOf(customer.CustomerType);
                cmbCustomerType.SelectedIndex = typeIndex >= 0 ? typeIndex : 0;
            }
            else
            {
                cmbCustomerType.SelectedIndex = 0; // Individual
            }

            _isEditMode = true;
            _editingCustomerId = customer.CustomerID;
            lblCustomerFormTitle.Text = "Edit Customer";
            btnSaveCustomer.Text = "Update Customer";
        }

        // TR: Bu metot, veri tablosundaki satırların stilini özelleştirir.
        // EN: This method customizes the style of the rows in the data table.
        private void SfDataGridCustomers_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
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
        private void BtnEditCustomer_Click(object sender, EventArgs e)
        {
            var selectedCustomer = GetSelectedCustomer();
            if (selectedCustomer == null)
            {
                MessageBox.Show("Lütfen düzenlemek için bir müşteri seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FillFormWithCustomer(selectedCustomer);
            tabControlCustomers.SelectedIndex = 1; // Switch to Customer Add/Edit tab
        }

        // TR: Sil butonu tıklama olayı
        // EN: Delete button click event
        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var selectedCustomer = GetSelectedCustomer();
            if (selectedCustomer == null)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{selectedCustomer.FullName}' adlı müşteriyi silmek istediğinizden emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve müşterinin tüm verilerini silecektir.\n" +
                "UYARI: Müşteriye ait kiralama ve ödeme kayıtları da silinecektir.",
                "Müşteri Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _customerRepository.Delete(selectedCustomer.CustomerID);
                    if (success)
                    {
                        MessageBox.Show("Müşteri başarıyla silindi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Müşteri silinirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Müşteri silinirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TR: Durum değiştir butonu tıklama olayı
        // EN: Toggle status button click event
        private void BtnToggleCustomerStatus_Click(object sender, EventArgs e)
        {
            var selectedCustomer = GetSelectedCustomer();
            if (selectedCustomer == null)
            {
                MessageBox.Show("Lütfen durumunu değiştirmek için bir müşteri seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusText = selectedCustomer.CustomerAvailable ? "pasif" : "aktif";
            var result = MessageBox.Show(
                $"'{selectedCustomer.FullName}' adlı müşteriyi {statusText} hale getirmek istediğinizden emin misiniz?",
                "Durum Değiştirme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Update customer status
                    selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                    bool success = _customerRepository.Update(selectedCustomer);

                    if (success)
                    {
                        MessageBox.Show($"Müşteri durumu başarıyla {statusText} hale getirildi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Müşteri durumu değiştirilirken bir hata oluştu.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Revert the change
                        selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Müşteri durumu değiştirilirken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Revert the change
                    selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                }
            }
        }

        // TR: Yenile butonu tıklama olayı
        // EN: Refresh button click event
        private void BtnRefreshCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            MessageBox.Show("Müşteri listesi yenilendi.",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // TR: Kaydet butonu tıklama olayı
        // EN: Save button click event
        private void BtnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(txtCustomerFirstName.Text) ||
                    string.IsNullOrEmpty(txtCustomerLastName.Text) ||
                    string.IsNullOrEmpty(txtCustomerPhone.Text))
                {
                    MessageBox.Show("Lütfen en az Ad, Soyad ve Telefon alanlarını doldurun.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate National ID if provided
                if (!string.IsNullOrEmpty(txtCustomerNationalID.Text))
                {
                    // Check if national ID already exists (for new customers or different customers)
                    var existingCustomer = _customerRepository.GetByNationalID(txtCustomerNationalID.Text);
                    if (existingCustomer != null && (!_isEditMode || existingCustomer.CustomerID != _editingCustomerId))
                    {
                        MessageBox.Show("Bu TC Kimlik No zaten başka bir müşteri tarafından kullanılmaktadır.",
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Validate phone number
                if (!string.IsNullOrEmpty(txtCustomerPhone.Text))
                {
                    var existingCustomerByPhone = _customerRepository.GetByPhone(txtCustomerPhone.Text);
                    if (existingCustomerByPhone != null && (!_isEditMode || existingCustomerByPhone.CustomerID != _editingCustomerId))
                    {
                        MessageBox.Show("Bu telefon numarası zaten başka bir müşteri tarafından kullanılmaktadır.",
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Create or update customer object
                Customer customer;
                if (_isEditMode)
                {
                    customer = _customerRepository.GetById(_editingCustomerId);
                    if (customer == null)
                    {
                        MessageBox.Show("Düzenlenecek müşteri bulunamadı.",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    customer = new Customer();
                }

                // Fill customer object
                customer.CustomerFirstName = txtCustomerFirstName.Text.Trim();
                customer.CustomerLastName = txtCustomerLastName.Text.Trim();
                customer.CustomerNationalID = string.IsNullOrEmpty(txtCustomerNationalID.Text) ? null : txtCustomerNationalID.Text.Trim();
                customer.CustomerLicenseNumber = string.IsNullOrEmpty(txtCustomerLicenseNumber.Text) ? null : txtCustomerLicenseNumber.Text.Trim();
                customer.CustomerLicenseClass = string.IsNullOrEmpty(txtCustomerLicenseClass.Text) ? null : txtCustomerLicenseClass.Text.Trim();
                customer.CustomerPhone = txtCustomerPhone.Text.Trim();
                customer.CustomerEmail = string.IsNullOrEmpty(txtCustomerEmail.Text) ? null : txtCustomerEmail.Text.Trim();
                customer.CustomerAddress = string.IsNullOrEmpty(txtCustomerAddress.Text) ? null : txtCustomerAddress.Text.Trim();
                customer.CustomerAvailable = chkCustomerAvailable.Checked;
                customer.CustomerType = cmbCustomerType.SelectedItem?.ToString() ?? "Individual";

                // Set dates
                customer.CustomerDateOfBirth = dtpDateOfBirth.Checked ? dtpDateOfBirth.Value : (DateTime?)null;
                customer.CustomerLicenseDate = dtpLicenseDate.Checked ? dtpLicenseDate.Value : (DateTime?)null;

                // Save to database
                bool success;
                if (_isEditMode)
                {
                    success = _customerRepository.Update(customer);
                }
                else
                {
                    int newCustomerId = _customerRepository.Insert(customer);
                    success = newCustomerId > 0;
                }

                if (success)
                {
                    string message = _isEditMode ? "Müşteri başarıyla güncellendi." : "Müşteri başarıyla eklendi.";
                    MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadCustomers(); // Refresh the list
                    tabControlCustomers.SelectedIndex = 0; // Switch to Customers List tab
                }
                else
                {
                    string message = _isEditMode ? "Müşteri güncellenirken bir hata oluştu." : "Müşteri eklenirken bir hata oluştu.";
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
        private void BtnCancelCustomer_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControlCustomers.SelectedIndex = 0; // Switch to Customers List tab
        }
    }
}