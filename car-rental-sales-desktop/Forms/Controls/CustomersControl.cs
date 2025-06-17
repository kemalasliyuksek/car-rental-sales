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
    // Bu sınıf, müşteri bilgilerini yönetmek için kullanılan bir kullanıcı arayüzü kontrolüdür.
    // Windows Forms'daki UserControl sınıfından miras alır, bu da onun form üzerine yerleştirilebilen bir bileşen olmasını sağlar.
    public partial class CustomersControl : UserControl
    {
        // Müşteri verilerine erişmek için kullanılan bir depo (repository) nesnesi.
        // Veritabanı işlemleri bu nesne üzerinden yapılır.
        private CustomerRepository _customerRepository;

        // Müşterilerin bir listesini tutar. Bu liste, arayüzde (örneğin bir tabloda) gösterilir.
        private List<Customer> _customerList;

        // Formun düzenleme modunda olup olmadığını belirten bir bayrak (flag).
        // True ise, mevcut bir müşteri düzenleniyor demektir. False ise, yeni bir müşteri ekleniyor demektir.
        private bool _isEditMode = false;

        // Düzenleme modundayken, düzenlenen müşterinin kimliğini (ID) tutar.
        private int _editingCustomerId = 0;

        // CustomersControl sınıfının yapıcı metodu.
        // Bu kontrol oluşturulduğunda ilk çalışan koddur.
        public CustomersControl()
        {
            // Form tasarımcısında oluşturulan bileşenleri (butonlar, metin kutuları vb.) yükler.
            InitializeComponent();
            // Müşteri veritabanı işlemleri için CustomerRepository'den yeni bir örnek oluşturur.
            _customerRepository = new CustomerRepository();

            // Bu kontrol yüklendiğinde (forma eklendiğinde) CustomersControl_Load metodunun çağrılmasını sağlar.
            // 'this.Load' bir olaydır (event), '+=' ise bu olaya bir metot (event handler) ekler.
            this.Load += CustomersControl_Load;
        }

        // Kontrol yüklendiğinde otomatik olarak çağrılan metot.
        // 'sender' parametresi olayı başlatan nesneyi (bu durumda CustomersControl), 'e' ise olayla ilgili verileri içerir.
        private void CustomersControl_Load(object sender, EventArgs e)
        {
            // Müşteri verilerini yükler ve arayüzdeki tabloya doldurur.
            LoadCustomers();
            // Müşteri tipi seçimi için kullanılan ComboBox'ı (açılır liste) ayarlar.
            SetupCustomerTypeComboBox();
        }

        // Veritabanından müşteri listesini çeker ve arayüzdeki veri tablosuna (sfDataGridCustomers) yükler.
        private void LoadCustomers()
        {
            try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır.
            {
                // CustomerRepository aracılığıyla tüm müşterileri alır.
                _customerList = _customerRepository.GetAllCustomers();
                // Alınan müşteri listesini sfDataGridCustomers adlı veri tablosunun veri kaynağı olarak ayarlar.
                // Bu sayede müşteriler tabloda görünür.
                sfDataGridCustomers.DataSource = _customerList;
            }
            catch (Exception ex) // Eğer try bloğunda bir hata oluşursa, catch bloğu çalışır.
            {
                // Hata mesajını kullanıcıya bir mesaj kutusuyla gösterir.
                MessageBox.Show($"Error loading customer data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Müşteri tipi (Bireysel, Kurumsal) seçimi için kullanılan ComboBox'ı hazırlar.
        private void SetupCustomerTypeComboBox()
        {
            // ComboBox'ın mevcut öğelerini temizler.
            cmbCustomerType.Items.Clear();
            // "Individual" (Bireysel) seçeneğini ekler.
            cmbCustomerType.Items.Add("Individual");
            // "Corporate" (Kurumsal) seçeneğini ekler.
            cmbCustomerType.Items.Add("Corporate");
            // Varsayılan olarak ilk seçeneği ("Individual") seçili hale getirir.
            cmbCustomerType.SelectedIndex = 0;
        }

        // Veri tablosunda (sfDataGridCustomers) seçili olan müşteriyi döndürür.
        private Customer GetSelectedCustomer()
        {
            try
            {
                // Eğer tabloda geçerli bir satır seçiliyse (indeks 0'dan büyük veya eşit ve müşteri listesinin boyutundan küçükse)
                if (sfDataGridCustomers.SelectedIndex >= 0 && sfDataGridCustomers.SelectedIndex < _customerList.Count)
                {
                    // Seçili indeksteki müşteriyi _customerList'ten alır ve döndürür.
                    return _customerList[sfDataGridCustomers.SelectedIndex];
                }
                // Eğer hiçbir müşteri seçili değilse veya geçersiz bir seçim varsa null (boş) döndürür.
                return null;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verir ve null döndürür.
                MessageBox.Show($"Error retrieving selected customer: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Müşteri ekleme/düzenleme formundaki tüm giriş alanlarını temizler ve varsayılan değerlere ayarlar.
        private void ClearForm()
        {
            // Metin kutularının içeriğini boşaltır.
            txtCustomerFirstName.Text = "";
            txtCustomerLastName.Text = "";
            txtCustomerNationalID.Text = "";
            txtCustomerLicenseNumber.Text = "";
            txtCustomerLicenseClass.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerAddress.Text = "";

            // Tarih seçicilerin (DateTimePicker) işaretli (Checked) durumunu kaldırır, böylece tarih seçilmemiş olur.
            dtpDateOfBirth.Checked = false;
            dtpLicenseDate.Checked = false;

            // Müşteri tipi ComboBox'ını varsayılan değere ("Individual") ayarlar.
            cmbCustomerType.SelectedIndex = 0;
            // Müşterinin "kullanılabilir" olup olmadığını belirten onay kutusunu (CheckBox) varsayılan olarak işaretli yapar.
            chkCustomerAvailable.Checked = true;

            // Düzenleme modunu kapatır.
            _isEditMode = false;
            // Düzenlenen müşteri ID'sini sıfırlar.
            _editingCustomerId = 0;
            // Form başlığını "Yeni Müşteri Ekle" olarak ayarlar.
            lblCustomerFormTitle.Text = "Add New Customer";
            // Kaydet butonunun metnini "Müşteriyi Kaydet" olarak ayarlar.
            btnSaveCustomer.Text = "Save Customer";
        }

        // Seçilen bir müşterinin bilgilerini müşteri ekleme/düzenleme formundaki alanlara doldurur.
        // 'customer' parametresi, bilgileri forma aktarılacak olan müşteri nesnesidir.
        private void FillFormWithCustomer(Customer customer)
        {
            // Eğer 'customer' nesnesi null (boş) ise, yani geçerli bir müşteri değilse, metottan çıkar.
            if (customer == null) return;

            // Müşteri bilgilerini ilgili metin kutularına atar.
            // '?? ""' ifadesi, eğer müşteri özelliği null ise boş bir string atanmasını sağlar (Null-coalescing operator).
            txtCustomerFirstName.Text = customer.CustomerFirstName ?? "";
            txtCustomerLastName.Text = customer.CustomerLastName ?? "";
            txtCustomerNationalID.Text = customer.CustomerNationalID ?? "";
            txtCustomerLicenseNumber.Text = customer.CustomerLicenseNumber ?? "";
            txtCustomerLicenseClass.Text = customer.CustomerLicenseClass ?? "";
            txtCustomerPhone.Text = customer.CustomerPhone ?? "";
            txtCustomerEmail.Text = customer.CustomerEmail ?? "";
            txtCustomerAddress.Text = customer.CustomerAddress ?? "";
            chkCustomerAvailable.Checked = customer.CustomerAvailable;

            // Müşterinin doğum tarihini ayarlar.
            if (customer.CustomerDateOfBirth.HasValue) // Eğer doğum tarihi varsa (null değilse)
            {
                dtpDateOfBirth.Value = customer.CustomerDateOfBirth.Value; // Tarih seçiciye değeri atar.
                dtpDateOfBirth.Checked = true; // Tarih seçiciyi işaretli yapar.
            }
            else // Eğer doğum tarihi yoksa
            {
                dtpDateOfBirth.Checked = false; // Tarih seçiciyi işaretsiz yapar.
            }

            // Müşterinin ehliyet tarihini ayarlar (doğum tarihi ile aynı mantıkta).
            if (customer.CustomerLicenseDate.HasValue)
            {
                dtpLicenseDate.Value = customer.CustomerLicenseDate.Value;
                dtpLicenseDate.Checked = true;
            }
            else
            {
                dtpLicenseDate.Checked = false;
            }

            // Müşterinin tipini (Bireysel/Kurumsal) ayarlar.
            if (!string.IsNullOrEmpty(customer.CustomerType)) // Eğer müşteri tipi boş veya null değilse
            {
                // Müşteri tipinin ComboBox'taki indeksini bulur.
                int typeIndex = cmbCustomerType.Items.IndexOf(customer.CustomerType);
                // Eğer tip ComboBox'ta bulunursa o indeksi, bulunamazsa varsayılan olarak ilk indeksi (0) seçer.
                cmbCustomerType.SelectedIndex = typeIndex >= 0 ? typeIndex : 0;
            }
            else // Eğer müşteri tipi boş veya null ise
            {
                cmbCustomerType.SelectedIndex = 0; // Varsayılan olarak "Individual" seçer.
            }

            // Formu düzenleme moduna alır.
            _isEditMode = true;
            // Düzenlenen müşterinin ID'sini saklar.
            _editingCustomerId = customer.CustomerID;
            // Form başlığını "Müşteriyi Düzenle" olarak ayarlar.
            lblCustomerFormTitle.Text = "Edit Customer";
            // Kaydet butonunun metnini "Müşteriyi Güncelle" olarak ayarlar.
            btnSaveCustomer.Text = "Update Customer";
        }

        // Müşteri listesini gösteren veri tablosundaki (sfDataGridCustomers) satırların stilini özelleştirmek için kullanılır.
        // Bu metot, Syncfusion DataGrid bileşeninin bir olayı (event) tarafından tetiklenir.
        // 'e' parametresi, satır stiliyle ilgili bilgileri ve ayarları içerir.
        private void SfDataGridCustomers_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Eğer satır tipi varsayılan bir veri satırı ise (başlık satırı veya filtre satırı değilse)
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Satır indeksi çift ise (0, 2, 4, ...)
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White; // Arka plan rengini beyaz yapar.
                else // Satır indeksi tek ise (1, 3, 5, ...)
                    e.Style.BackColor = Color.FromArgb(240, 245, 255); // Arka plan rengini açık mavi bir tona ayarlar (zebra deseni için).
            }
        }

        // "Düzenle" butonuna tıklandığında çağrılan metot.
        private void BtnEditCustomer_Click(object sender, EventArgs e)
        {
            // Veri tablosundan seçili olan müşteriyi alır.
            var selectedCustomer = GetSelectedCustomer();
            // Eğer hiçbir müşteri seçilmemişse
            if (selectedCustomer == null)
            {
                // Kullanıcıya bir uyarı mesajı gösterir.
                MessageBox.Show("Please select a customer to edit.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metottan çıkar.
            }

            // Seçili müşterinin bilgilerini forma doldurur.
            FillFormWithCustomer(selectedCustomer);
            // TabControl'de ikinci sekmeye (Müşteri Ekle/Düzenle sekmesi, indeksi 1) geçer.
            tabControlCustomers.SelectedIndex = 1;
        }

        // "Sil" butonuna tıklandığında çağrılan metot.
        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // Sadece Admin ve Şube Müdürü müşteri silebilir
            if (!CurrentUser.IsAdmin() && !CurrentUser.IsBranchManager())
            {
                MessageBox.Show("You do not have the authority to delete customer. "," Unauthorized Transaction ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Veri tablosundan seçili olan müşteriyi alır.
            var selectedCustomer = GetSelectedCustomer();
            // Eğer hiçbir müşteri seçilmemişse
            if (selectedCustomer == null)
            {
                // Kullanıcıya bir uyarı mesajı gösterir.
                MessageBox.Show("Please select a customer to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metottan çıkar.
            }

            // Kullanıcıdan silme işlemini onaylamasını isteyen bir mesaj kutusu gösterir.
            // Mesaj, müşterinin adını ve işlemin geri alınamayacağını belirtir.
            // Ayrıca, müşteriye ait kiralama ve ödeme kayıtlarının da silineceği uyarısı yapılır.
            var result = MessageBox.Show(
                $"Are you sure you want to delete the customer '{selectedCustomer.FullName}'?\n\n" +
                "This action cannot be undone and will delete all data for this customer.\n" +
                "WARNING: Rental and payment records associated with this customer will also be deleted.",
                "Confirm Customer Deletion",
                MessageBoxButtons.YesNo, // Evet ve Hayır butonları gösterir.
                MessageBoxIcon.Question); // Soru ikonu gösterir.

            // Eğer kullanıcı "Evet" butonuna tıklarsa
            if (result == DialogResult.Yes)
            {
                try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır.
                {
                    // CustomerRepository aracılığıyla seçili müşteriyi ID'sine göre siler.
                    bool success = _customerRepository.Delete(selectedCustomer.CustomerID);
                    // Eğer silme işlemi başarılıysa
                    if (success)
                    {
                        // Başarı mesajı gösterir.
                        MessageBox.Show("Customer deleted successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Müşteri listesini günceller (silinen müşterinin listeden kalkması için).
                        LoadCustomers();
                    }
                    else // Eğer silme işlemi başarısızsa
                    {
                        // Hata mesajı gösterir.
                        MessageBox.Show("An error occurred while deleting the customer.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) // Eğer try bloğunda bir hata oluşursa
                {
                    // Hata mesajını kullanıcıya gösterir.
                    MessageBox.Show($"Error deleting customer: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "Durum Değiştir" (Aktif/Pasif yap) butonuna tıklandığında çağrılan metot.
        private void BtnToggleCustomerStatus_Click(object sender, EventArgs e)
        {
            // Veri tablosundan seçili olan müşteriyi alır.
            var selectedCustomer = GetSelectedCustomer();
            // Eğer hiçbir müşteri seçilmemişse
            if (selectedCustomer == null)
            {
                // Kullanıcıya bir uyarı mesajı gösterir.
                MessageBox.Show("Please select a customer to change status.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metottan çıkar.
            }

            // Müşterinin mevcut durumuna göre (CustomerAvailable özelliği) hedef durumu belirler.
            // Eğer müşteri aktifse "pasif", pasifse "aktif" yapar.
            string statusText = selectedCustomer.CustomerAvailable ? "inactive" : "active";
            // Kullanıcıdan durum değiştirme işlemini onaylamasını isteyen bir mesaj kutusu gösterir.
            var result = MessageBox.Show(
                $"Are you sure you want to make the customer '{selectedCustomer.FullName}' {statusText}?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Eğer kullanıcı "Evet" butonuna tıklarsa
            if (result == DialogResult.Yes)
            {
                try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır.
                {
                    // Müşterinin CustomerAvailable durumunu tersine çevirir (true ise false, false ise true yapar).
                    selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                    // Değiştirilmiş müşteri bilgisini CustomerRepository aracılığıyla veritabanında günceller.
                    bool success = _customerRepository.Update(selectedCustomer);

                    // Eğer güncelleme işlemi başarılıysa
                    if (success)
                    {
                        // Başarı mesajı gösterir.
                        MessageBox.Show($"Customer status successfully changed to {statusText}.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Müşteri listesini günceller (değişen durumu yansıtmak için).
                        LoadCustomers();
                    }
                    else // Eğer güncelleme işlemi başarısızsa
                    {
                        // Hata mesajı gösterir.
                        MessageBox.Show("An error occurred while changing the customer status.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Başarısızlık durumunda yapılan değişikliği geri alır (eski durumuna döndürür).
                        selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                    }
                }
                catch (Exception ex) // Eğer try bloğunda bir hata oluşursa
                {
                    // Hata mesajını kullanıcıya gösterir.
                    MessageBox.Show($"Error changing customer status: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Hata durumunda yapılan değişikliği geri alır (eski durumuna döndürür).
                    selectedCustomer.CustomerAvailable = !selectedCustomer.CustomerAvailable;
                }
            }
        }

        // "Yenile" butonuna tıklandığında çağrılan metot.
        private void BtnRefreshCustomers_Click(object sender, EventArgs e)
        {
            // Müşteri listesini yeniden yükler.
            LoadCustomers();
            // Kullanıcıya listenin yenilendiğine dair bilgi mesajı gösterir.
            MessageBox.Show("Customer list refreshed.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // "Kaydet" (veya düzenleme modunda "Güncelle") butonuna tıklandığında çağrılan metot.
        private void BtnSaveCustomer_Click(object sender, EventArgs e)
        {
            try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır.
            {
                // Gerekli alanların (Ad, Soyad, Telefon) dolu olup olmadığını kontrol eder.
                if (string.IsNullOrEmpty(txtCustomerFirstName.Text) ||
                    string.IsNullOrEmpty(txtCustomerLastName.Text) ||
                    string.IsNullOrEmpty(txtCustomerPhone.Text))
                {
                    // Eğer zorunlu alanlar boşsa, kullanıcıya uyarı mesajı gösterir.
                    MessageBox.Show("Please fill in at least the First Name, Last Name, and Phone fields.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Metottan çıkar.
                }

                // Eğer TC Kimlik No alanı doluysa, geçerliliğini kontrol eder.
                if (!string.IsNullOrEmpty(txtCustomerNationalID.Text))
                {
                    // Girilen TC Kimlik No ile veritabanında başka bir müşteri olup olmadığını kontrol eder.
                    var existingCustomer = _customerRepository.GetByNationalID(txtCustomerNationalID.Text);
                    // Eğer bu TC Kimlik No'ya sahip bir müşteri varsa VE (şu an yeni müşteri ekleniyorsa VEYA düzenleme modunda farklı bir müşteri düzenleniyorsa)
                    if (existingCustomer != null && (!_isEditMode || existingCustomer.CustomerID != _editingCustomerId))
                    {
                        // Kullanıcıya bu TC Kimlik No'nun zaten kullanıldığını belirten bir uyarı mesajı gösterir.
                        MessageBox.Show("This National ID is already used by another customer.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Metottan çıkar.
                    }
                }

                // Eğer Telefon Numarası alanı doluysa, geçerliliğini kontrol eder.
                if (!string.IsNullOrEmpty(txtCustomerPhone.Text))
                {
                    // Girilen telefon numarası ile veritabanında başka bir müşteri olup olmadığını kontrol eder.
                    var existingCustomerByPhone = _customerRepository.GetByPhone(txtCustomerPhone.Text);
                    // Eğer bu telefon numarasına sahip bir müşteri varsa VE (şu an yeni müşteri ekleniyorsa VEYA düzenleme modunda farklı bir müşteri düzenleniyorsa)
                    if (existingCustomerByPhone != null && (!_isEditMode || existingCustomerByPhone.CustomerID != _editingCustomerId))
                    {
                        // Kullanıcıya bu telefon numarasının zaten kullanıldığını belirten bir uyarı mesajı gösterir.
                        MessageBox.Show("This phone number is already used by another customer.",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Metottan çıkar.
                    }
                }

                // Kaydedilecek veya güncellenecek müşteri nesnesini oluşturur/alır.
                Customer customer;
                if (_isEditMode) // Eğer düzenleme modundaysa
                {
                    // Düzenlenen müşteriyi ID'sine göre veritabanından alır.
                    customer = _customerRepository.GetById(_editingCustomerId);
                    // Eğer müşteri bulunamazsa (bir hata sonucu olabilir)
                    if (customer == null)
                    {
                        // Hata mesajı gösterir.
                        MessageBox.Show("Customer to edit not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Metottan çıkar.
                    }
                }
                else // Eğer yeni müşteri ekleme modundaysa
                {
                    // Yeni bir Customer nesnesi oluşturur.
                    customer = new Customer();
                }

                // Formdaki alanlardan alınan bilgilerle müşteri nesnesinin özelliklerini doldurur.
                // Trim() metodu, metinlerin başındaki ve sonundaki boşlukları temizler.
                customer.CustomerFirstName = txtCustomerFirstName.Text.Trim();
                customer.CustomerLastName = txtCustomerLastName.Text.Trim();
                // Eğer TC Kimlik No alanı boşsa null, değilse değerini atar.
                customer.CustomerNationalID = string.IsNullOrEmpty(txtCustomerNationalID.Text) ? null : txtCustomerNationalID.Text.Trim();
                customer.CustomerLicenseNumber = string.IsNullOrEmpty(txtCustomerLicenseNumber.Text) ? null : txtCustomerLicenseNumber.Text.Trim();
                customer.CustomerLicenseClass = string.IsNullOrEmpty(txtCustomerLicenseClass.Text) ? null : txtCustomerLicenseClass.Text.Trim();
                customer.CustomerPhone = txtCustomerPhone.Text.Trim();
                customer.CustomerEmail = string.IsNullOrEmpty(txtCustomerEmail.Text) ? null : txtCustomerEmail.Text.Trim();
                customer.CustomerAddress = string.IsNullOrEmpty(txtCustomerAddress.Text) ? null : txtCustomerAddress.Text.Trim();
                customer.CustomerAvailable = chkCustomerAvailable.Checked;
                // Müşteri tipini ComboBox'tan seçilen değere göre ayarlar. Eğer bir şey seçilmemişse varsayılan olarak "Individual" atar.
                customer.CustomerType = cmbCustomerType.SelectedItem?.ToString() ?? "Individual";

                // Doğum tarihi ve ehliyet tarihlerini ayarlar.
                // Eğer tarih seçici (DateTimePicker) işaretliyse (Checked == true), seçilen tarihi atar; değilse null atar.
                customer.CustomerDateOfBirth = dtpDateOfBirth.Checked ? dtpDateOfBirth.Value : (DateTime?)null;
                customer.CustomerLicenseDate = dtpLicenseDate.Checked ? dtpLicenseDate.Value : (DateTime?)null;

                // Müşteri nesnesini veritabanına kaydeder veya günceller.
                bool success;
                if (_isEditMode) // Düzenleme modundaysa
                {
                    // Müşteriyi günceller.
                    success = _customerRepository.Update(customer);
                }
                else // Yeni müşteri ekleme modundaysa
                {
                    // Yeni müşteriyi ekler ve eklenen müşterinin ID'sini alır.
                    int newCustomerId = _customerRepository.Insert(customer);
                    // Eğer yeni ID 0'dan büyükse işlem başarılıdır.
                    success = newCustomerId > 0;
                }

                // Eğer kaydetme/güncelleme işlemi başarılıysa
                if (success)
                {
                    // Duruma göre (düzenleme veya ekleme) uygun başarı mesajını oluşturur.
                    string message = _isEditMode ? "Customer updated successfully." : "Customer added successfully.";
                    // Başarı mesajını gösterir.
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizler.
                    ClearForm();
                    // Müşteri listesini yeniler.
                    LoadCustomers();
                    // TabControl'de ilk sekmeye (Müşteri Listesi sekmesi, indeksi 0) geçer.
                    tabControlCustomers.SelectedIndex = 0;
                }
                else // Eğer kaydetme/güncelleme işlemi başarısızsa
                {
                    // Duruma göre uygun hata mesajını oluşturur.
                    string message = _isEditMode ? "An error occurred while updating the customer." : "An error occurred while adding the customer.";
                    // Hata mesajını gösterir.
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // Eğer try bloğunda genel bir hata oluşursa
            {
                // Hata mesajını kullanıcıya gösterir.
                MessageBox.Show($"An error occurred during the operation: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "İptal" butonuna tıklandığında çağrılan metot.
        private void BtnCancelCustomer_Click(object sender, EventArgs e)
        {
            // Müşteri ekleme/düzenleme formunu temizler.
            ClearForm();
            // TabControl'de ilk sekmeye (Müşteri Listesi sekmesi, indeksi 0) geçer.
            tabControlCustomers.SelectedIndex = 0;
        }
    }
}