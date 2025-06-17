using car_rental_sales_desktop.Methods;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    // Kiralama işlemlerini yöneten kullanıcı kontrolünü temsil eder.
    public partial class RentalsControl : UserControl
    {
        // Kiralama veritabanı işlemleri için depo (repository) nesnesi.
        private RentalRepository _rentalRepository;
        // Müşteri veritabanı işlemleri için depo nesnesi.
        private CustomerRepository _customerRepository;
        // Araç veritabanı işlemleri için depo nesnesi.
        private VehicleRepository _vehicleRepository;
        // Kullanıcı veritabanı işlemleri için depo nesnesi.
        private UserRepository _userRepository;
        // Müşteri listesini tutar.
        private List<Customer> _customers;
        // Araç listesini tutar.
        private List<Vehicle> _vehicles;

        // Kiralama formu elemanlarını yönetmek için yardımcı sınıf nesnesi.
        private RentalFormControlManager _formManager;

        // RentalsControl sınıfının yapıcı metodu. Kontrol ilk oluşturulduğunda çalışır.
        public RentalsControl()
        {
            // Formun görsel bileşenlerini başlatır.
            InitializeComponent();

            // Depo nesnelerini oluşturur.
            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            // Form yöneticisi nesnesini oluşturur.
            _formManager = new RentalFormControlManager(this);

            // Kontrol yüklendiğinde çalışacak olayı (event) RentalsControl_Load metoduna bağlar.
            this.Load += RentalsControl_Load;
            // Müşteri yükleme butonu tıklandığında çalışacak olayı BtnCustomerLoad_Click metoduna bağlar.
            btnCustomerLoad.Click += BtnCustomerLoad_Click;
            // Araç yükleme butonu tıklandığında çalışacak olayı BtnVehicleLoad_Click metoduna bağlar.
            btnVehicleLoad.Click += BtnVehicleLoad_Click;

            // Kiralama başlangıç tarihi değiştirildiğinde çalışacak olayı DtpRentalStartDate_ValueChanged metoduna bağlar.
            dtpRentalStartDate.ValueChanged += DtpRentalStartDate_ValueChanged;
            // Kiralama bitiş tarihi değiştirildiğinde çalışacak olayı DtpRentalEndDate_ValueChanged metoduna bağlar.
            dtpRentalEndDate.ValueChanged += DtpRentalEndDate_ValueChanged;

            // Son kiralamalar tablosunda bir hücreye çift tıklandığında çalışacak olayı SfDataGridLastRentals_CellDoubleClick metoduna bağlar.
            sfDataGridLastRentals.CellDoubleClick += SfDataGridLastRentals_CellDoubleClick;
            // Kiralamalar tablosunda bir hücreye çift tıklandığında çalışacak olayı SfDataGridRentals_CellDoubleClick metoduna bağlar.
            sfDataGridRentals.CellDoubleClick += SfDataGridRentals_CellDoubleClick;
            // Kiralama gösterme butonu tıklandığında çalışacak olayı BtnShowRental_Click metoduna bağlar.
            btnShowRental.Click += BtnShowRental_Click;

            // Form yöneticisi aracılığıyla formun varsayılan ayarlarını başlatır.
            _formManager.InitializeFormDefaults();

            // Son kiralamalar tablosunun satır stillerini sorgulamak için olayı SfDataGridLastRentals_QueryRowStyle metoduna bağlar.
            sfDataGridLastRentals.QueryRowStyle += SfDataGridLastRentals_QueryRowStyle;
            // Kiralamalar tablosunun satır stillerini sorgulamak için olayı SfDataGridRentals_QueryRowStyle metoduna bağlar.
            sfDataGridRentals.QueryRowStyle += SfDataGridRentals_QueryRowStyle;
        }

        // Kiralamalar (sfDataGridRentals) tablosundaki bir hücreye çift tıklandığında tetiklenir.
        private void SfDataGridRentals_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            // Tıklanan satırın geçerli bir veri satırı olup olmadığını kontrol eder.
            if (e.DataRow != null && e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Tıklanan satırdaki kiralama verisini alır.
                var rentalClickedInRentalsGrid = e.DataRow.RowData as Rental;
                if (rentalClickedInRentalsGrid != null)
                {
                    // Tıklanan kiralamanın "Son Kiralamalar" tablosunda olup olmadığını kontrol eder.
                    var matchInLastRentalsGrid = (sfDataGridLastRentals.DataSource as List<Rental>)
                        ?.FirstOrDefault(r => r.RentalID == rentalClickedInRentalsGrid.RentalID);

                    if (matchInLastRentalsGrid != null)
                    {
                        // Eğer kiralama "Son Kiralamalar" tablosunda varsa, o tablodaki öğeyi seçer.
                        sfDataGridLastRentals.SelectedItem = matchInLastRentalsGrid;
                        sfDataGridRentals.SelectedItem = null;
                    }
                    else
                    {
                        // Eğer kiralama sadece "Kiralamalar" tablosunda varsa, o tablodaki öğeyi seçer.
                        sfDataGridRentals.SelectedItem = rentalClickedInRentalsGrid;
                        sfDataGridLastRentals.SelectedItem = null;
                    }

                    // "Kiralama Ekle/Düzenle" sekmesine geçer.
                    if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
                    {
                        parentTabControl.SelectedTab = tabPageRentalAdd;
                    }

                    // Seçilen kiralama bilgilerini forma yükler.
                    LoadSelectedRental();
                }
            }
        }

        // RentalsControl yüklendiğinde çalışacak metot.
        private void RentalsControl_Load(object sender, EventArgs e)
        {
            // Kiralama yetkisi kontrolü
            if (!CurrentUser.CanPerformAction("manage_rentals"))
            {
                MessageBox.Show("You do not have authority for rental transactions.", "Unauthorized Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            LoadRentals();
            LoadCustomersForAutoComplete();
            LoadVehiclesForAutoComplete();

            dtpRentalStartDate.MinDate = DateTime.Today;
            dtpRentalEndDate.MinDate = DateTime.Today.AddDays(1);

            // Şube müdürü ve personel sadece kendi şubelerindeki araçları kiralayabilir
            if ((CurrentUser.IsBranchManager() || CurrentUser.IsStaff()) && CurrentUser.BranchID.HasValue)
            {
                _vehicles = _vehicles.Where(v => v.VehicleBranchID == CurrentUser.BranchID.Value).ToList();
                LoadVehiclesForAutoComplete(); // Listeyi yeniden yükle
            }
        }

        // Veritabanından kiralama kayıtlarını yükler ve ilgili tablolara (DataGrid) bağlar.
        private void LoadRentals()
        {
            try
            {
                // Tüm kiralamaları alır ve sadece "Approved" (Onaylı) olanları filtreler.
                List<Rental> rentals = _rentalRepository.GetAll()
                    .Where(r => r.RentalStatus == "Approved")
                    .ToList();

                // Her bir kiralama için müşteri, araç ve kullanıcı bilgilerini, eğer eksikse, veritabanından yükler.
                foreach (var rental in rentals)
                {
                    if (rental.RentalCustomerID > 0 && rental.Customer == null)
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);
                    if (rental.RentalVehicleID > 0 && rental.Vehicle == null)
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);
                    if (rental.RentalUserID > 0 && rental.User == null)
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                }
                // Kiralamalar tablosuna (sfDataGridRentals) verileri yükler.
                sfDataGridRentals.DataSource = rentals;
                // Son kiralamalar tablosuna (sfDataGridLastRentals) verileri oluşturulma tarihine göre tersten sıralayarak yükler.
                sfDataGridLastRentals.DataSource = rentals.OrderByDescending(r => r.RentalCreatedAt).ToList();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading rental data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiralamalar (sfDataGridRentals) tablosundaki satırların stilini dinamik olarak ayarlar.
        private void SfDataGridRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Satırın bir veri satırı olup olmadığını kontrol eder.
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Satırdaki kiralama verisini alır.
                var rental = e.RowData as Rental;
                if (rental != null)
                {
                    // Kiralama durumunu alır.
                    RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(rental);
                    // Duruma göre satırın arka plan rengini ayarlar.
                    e.Style.BackColor = RentalMethods.GetStatusColor(status);
                    // Duruma göre satırın yazı rengini ayarlar (gecikmişse beyaz, değilse siyah).
                    e.Style.TextColor = (status == RentalMethods.RentalStatus.Overdue) ? Color.White : Color.Black;
                    // Yazı tipini kalın yapar.
                    e.Style.Font.Bold = true;
                }
                else
                {
                    // Kiralama verisi yoksa, varsayılan alternatif satır renklerini ayarlar.
                    e.Style.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 245, 255);
                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = false;
                }
            }
        }

        // Son kiralamalar (sfDataGridLastRentals) tablosundaki satırların stilini dinamik olarak ayarlar.
        private void SfDataGridLastRentals_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            // Satırın bir veri satırı olup olmadığını kontrol eder.
            if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Satırdaki kiralama verisini alır.
                var rental = e.RowData as Rental;
                if (rental != null)
                {
                    // Kiralama durumunu alır.
                    RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(rental);
                    // Duruma göre satırın arka plan rengini ayarlar.
                    e.Style.BackColor = RentalMethods.GetStatusColor(status);
                    // Duruma göre satırın yazı rengini ayarlar (gecikmişse beyaz, değilse siyah).
                    e.Style.TextColor = (status == RentalMethods.RentalStatus.Overdue) ? Color.White : Color.Black;
                    // Yazı tipini kalın yapar.
                    e.Style.Font.Bold = true;
                }
                else
                {
                    // Kiralama verisi yoksa, varsayılan alternatif satır renklerini ayarlar.
                    e.Style.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 245, 255);
                    e.Style.TextColor = Color.Black;
                    e.Style.Font.Bold = false;
                }
            }
        }

        #region Customer Operations

        // Müşteri arama kutusu için otomatik tamamlama listesini yükler.
        private void LoadCustomersForAutoComplete()
        {
            try
            {
                // Aktif müşterileri veritabanından alır.
                _customers = _customerRepository.GetActiveCustomers();
                // Otomatik tamamlama için bir string koleksiyonu oluşturur.
                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
                // Her bir müşterinin adını ve soyadını koleksiyona ekler.
                foreach (var customer in _customers)
                {
                    autoCompleteSource.Add($"{customer.CustomerFirstName} {customer.CustomerLastName}");
                }
                // Müşteri arama metin kutusunun otomatik tamamlama kaynağını ve modunu ayarlar.
                txtBoxSearchCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxSearchCustomer.AutoCompleteCustomSource = autoCompleteSource;
                txtBoxSearchCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "Müşteri Yükle" butonu tıklandığında çalışır.
        private void BtnCustomerLoad_Click(object sender, EventArgs e)
        {
            // Arama metin kutusundaki metni alır ve boşlukları temizler.
            string searchText = txtBoxSearchCustomer.Text.Trim();
            // Arama metni boşsa uyarı verir ve işlemi sonlandırır.
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please select a customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Girilen metne göre müşteriyi bulur.
            Customer selectedCustomer = RentalMethods.FindCustomerByFullName(searchText, _customers);

            // Müşteri bulunursa işlemlere devam eder.
            if (selectedCustomer != null)
            {
                // Seçilen müşterinin aktif kiralamalarını kontrol eder.
                var customerActiveRentals = RentalMethods.CheckCustomerActiveRentals(selectedCustomer.CustomerID, _rentalRepository, _vehicleRepository);
                // Müşterinin aktif kiralaması varsa kullanıcıyı uyarır.
                if (customerActiveRentals.Count > 0)
                {
                    // Aktif kiralamaların ilk üçünü ve toplam sayısını içeren bir bilgi mesajı oluşturur.
                    string activeRentalInfo = string.Join("\n", customerActiveRentals.Take(3)
                        .Select(r => $"• Plate: {r.Vehicle?.VehiclePlateNumber ?? "Unknown"} - End Date: {r.RentalEndDate:dd.MM.yyyy}"));
                    if (customerActiveRentals.Count > 3) activeRentalInfo += $"\n• ... and {customerActiveRentals.Count - 3} more rentals";

                    // Kullanıcıya aktif kiralamalar hakkında bilgi verir ve yeni kiralama yapmak isteyip istemediğini sorar.
                    DialogResult result = MessageBox.Show($"WARNING: This customer has {customerActiveRentals.Count} active rental(s):\n\n{activeRentalInfo}\n\nDo you want to create a new rental?",
                        "Active Rental Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    // Kullanıcı "Hayır" derse, arama kutusunu temizler ve işlemi sonlandırır.
                    if (result == DialogResult.No)
                    {
                        txtBoxSearchCustomer.Text = string.Empty;
                        return;
                    }
                }
                // Seçilen müşteri bilgilerini forma yükler.
                _formManager.LoadCustomerInfo(selectedCustomer);
                // İlerleme durumu mesajını günceller. Aktif kiralama varsa uyarı rengiyle, yoksa başarı rengiyle gösterir.
                _formManager.UpdateProgressWarning(customerActiveRentals.Any() ? $"Customer loaded. ATTENTION: {customerActiveRentals.Count} active rental(s)!" : "Customer information loaded successfully.",
                                                  customerActiveRentals.Any() ? Color.OrangeRed : Color.Green);
            }
            else
            {
                // Müşteri bulunamazsa uyarı verir.
                MessageBox.Show("Customer not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Vehicle Operations

        // Araç arama kutusu için otomatik tamamlama listesini yükler.
        private void LoadVehiclesForAutoComplete()
        {
            try
            {
                // Durumu "Mevcut" (1) veya "Bakımda" (4) olan tüm araçları alır.
                _vehicles = _vehicleRepository.GetAll().Where(v => v.VehicleStatusID == 1 || v.VehicleStatusID == 4).ToList();
                // Aktif kiralamalardaki araç ID'lerini bir HashSet'e alır.
                var rentedVehicleIds = _rentalRepository.GetActiveRentals().Select(r => r.RentalVehicleID).ToHashSet();
                // Henüz kiralanmamış araçları filtreler.
                _vehicles = _vehicles.Where(v => !rentedVehicleIds.Contains(v.VehicleID)).ToList();

                // Otomatik tamamlama için bir string koleksiyonu oluşturur.
                AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
                // Her bir aracın plaka numarasını koleksiyona ekler.
                foreach (var vehicle in _vehicles) autoCompleteSource.Add(vehicle.VehiclePlateNumber);
                // Araç arama metin kutusunun otomatik tamamlama kaynağını ve modunu ayarlar.
                textBoxSearchVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxSearchVehicle.AutoCompleteCustomSource = autoCompleteSource;
                textBoxSearchVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading vehicle data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "Araç Yükle" butonu tıklandığında çalışır.
        private void BtnVehicleLoad_Click(object sender, EventArgs e)
        {
            // Arama metin kutusundaki metni alır ve boşlukları temizler.
            string searchText = textBoxSearchVehicle.Text.Trim();
            // Arama metni boşsa uyarı verir ve işlemi sonlandırır.
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please select a vehicle.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Girilen plakaya göre aracı bulur.
            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(searchText, _vehicles);

            // Araç bulunursa işlemlere devam eder.
            if (selectedVehicle != null)
            {
                // Aracın kiralamaya uygun olup olmadığını kontrol eder.
                if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
                {
                    // Araç uygun değilse uyarı verir, otomatik tamamlama listesini yeniler ve arama kutusunu temizler.
                    MessageBox.Show($"Vehicle ({selectedVehicle.VehiclePlateNumber}) is not available for rental. Status: {selectedVehicle.VehicleStatus?.VehicleStatusName ?? "Unknown"}.",
                        "Vehicle Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadVehiclesForAutoComplete();
                    textBoxSearchVehicle.Text = string.Empty;
                    return;
                }
                // Seçilen araç bilgilerini forma yükler ve kiralama tutarını hesaplar.
                _formManager.LoadVehicleInfo(selectedVehicle, CalculateRentalAmount);
                // İlerleme durumu mesajını başarı rengiyle günceller.
                _formManager.UpdateProgressWarning("Vehicle information loaded successfully.", Color.Green);
            }
            else
            {
                // Araç bulunamazsa veya uygun değilse uyarı verir ve otomatik tamamlama listesini yeniler.
                MessageBox.Show("Vehicle not found or not available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadVehiclesForAutoComplete();
            }
        }
        #endregion

        #region Rental Calculations

        // Kiralama tutarını hesaplar.
        public void CalculateRentalAmount()
        {
            // Araç plaka metin kutusu boşsa işlemi sonlandırır.
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text)) return;
            // Plakaya göre aracı bulur.
            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);
            // Araç bulunamazsa veya araç sınıf ID'si yoksa işlemi sonlandırır.
            if (selectedVehicle == null || !selectedVehicle.VehicleClassID.HasValue) return;

            // Varsayılan kiralama süresini 1 gün olarak ayarlar.
            int days = 1;
            // Bitiş tarihi başlangıç tarihinden büyük veya eşitse gün farkını hesaplar.
            if (dtpRentalEndDate.Value.Date >= dtpRentalStartDate.Value.Date)
            {
                days = (dtpRentalEndDate.Value.Date - dtpRentalStartDate.Value.Date).Days + 1;
            }
            else
            {
                // Bitiş tarihi başlangıçtan küçükse, bitiş tarihini başlangıçtan bir gün sonrasına ayarlar.
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
                days = 1;
            }

            // Araç sınıfı deposunu oluşturur.
            var classRepository = new VehicleClassRepository();
            // Aracın sınıfına göre günlük kiralama fiyatını alır.
            decimal dailyRate = classRepository.GetRentalPrice(selectedVehicle.VehicleClassID.Value, RentalType.Daily);
            // Toplam kiralama tutarını hesaplar.
            decimal totalAmount = dailyRate * days;
            // Kiralama tutarı metin kutusunu formatlı olarak günceller.
            txtBoxRentalAmount.Text = totalAmount.ToString("N2") + " ₺";
            // Depozito tutarı metin kutusunu (toplam tutarın %50'si) formatlı olarak günceller.
            txtBoxRentalDeposit.Text = (totalAmount * 0.5m).ToString("N2") + " ₺";
        }

        // Kiralama başlangıç tarihi değiştirildiğinde çalışır.
        private void DtpRentalStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Bitiş tarihi başlangıç tarihinden küçükse, bitiş tarihinin minimum değerini ve değerini günceller.
            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
                dtpRentalEndDate.Value = dtpRentalStartDate.Value.AddDays(1);
            }
            else
            {
                // Bitiş tarihinin minimum değerini günceller.
                dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
            }
            // Kiralama tutarını yeniden hesaplar.
            CalculateRentalAmount();
        }

        // Kiralama bitiş tarihi değiştirildiğinde çalışır.
        private void DtpRentalEndDate_ValueChanged(object sender, EventArgs e)
        {
            // Bitiş tarihi başlangıç tarihinden küçükse (bu durum MinDate ayarı nedeniyle normalde oluşmaz).
            if (dtpRentalEndDate.Value < dtpRentalStartDate.Value)
            {
                // Bu durumun oluşmaması gerekir çünkü MinDate ayarlanıyor.
            }
            // Kiralama tutarını yeniden hesaplar.
            CalculateRentalAmount();
        }
        #endregion

        // Formdaki giriş alanlarını temizler.
        private void ClearForm()
        {
            // Form yöneticisi aracılığıyla girişleri temizler.
            _formManager.ClearFormInputs();
            // Formu düzenlenebilir hale getirir.
            _formManager.SetFormReadOnly(false);
            // İlerleme durumu mesajını günceller.
            _formManager.UpdateProgressWarning("Form cleared.", Color.Blue);
        }

        // Kiralama formunun geçerliliğini kontrol eder.
        private bool ValidateRentalForm()
        {
            // Müşteri adı boşsa uyarı verir ve false döner.
            if (string.IsNullOrEmpty(txtBoxCustomerFullName.Text))
            {
                _formManager.UpdateProgressWarning("Please select a customer.", Color.Red);
                txtBoxSearchCustomer.Focus(); return false;
            }
            // Araç plakası boşsa uyarı verir ve false döner.
            if (string.IsNullOrEmpty(txtBoxVehiclePlate.Text))
            {
                _formManager.UpdateProgressWarning("Please select a vehicle.", Color.Red);
                textBoxSearchVehicle.Focus(); return false;
            }

            // Seçilen müşterinin geçerli olup olmadığını kontrol eder.
            Customer selectedCustomer = RentalMethods.FindCustomerByFullName(txtBoxCustomerFullName.Text, _customers);
            if (selectedCustomer == null)
            {
                _formManager.UpdateProgressWarning("Selected customer is not valid.", Color.Red);
                txtBoxSearchCustomer.Focus(); return false;
            }

            // Seçilen aracın geçerli olup olmadığını kontrol eder.
            Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);
            if (selectedVehicle == null)
            {
                _formManager.UpdateProgressWarning("Selected vehicle is not valid.", Color.Red);
                textBoxSearchVehicle.Focus(); return false;
            }

            // Aracın kiralamaya uygun olup olmadığını kontrol eder.
            if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
            {
                _formManager.UpdateProgressWarning("Vehicle is not available for rental.", Color.Red);
                LoadVehiclesForAutoComplete();
                textBoxSearchVehicle.Text = string.Empty;
                txtBoxVehiclePlate.Text = string.Empty;
                return false;
            }

            // Bitiş tarihinin başlangıç tarihinden önce olup olmadığını kontrol eder.
            if (dtpRentalEndDate.Value.Date < dtpRentalStartDate.Value.Date)
            {
                _formManager.UpdateProgressWarning("End date cannot be before start date.", Color.Red);
                dtpRentalEndDate.Focus(); return false;
            }

            // Kiralama tutarının geçerli olup olmadığını kontrol eder.
            if (string.IsNullOrEmpty(txtBoxRentalAmount.Text) || !decimal.TryParse(txtBoxRentalAmount.Text.Replace("₺", "").Trim(), out _))
            {
                _formManager.UpdateProgressWarning("Rental amount is invalid.", Color.Red); return false;
            }
            // Başlangıç kilometresinin girilip girilmediğini ve geçerli olup olmadığını kontrol eder.
            if (string.IsNullOrEmpty(txtBoxRentalStartMileage.Text) || !int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out _))
            {
                _formManager.UpdateProgressWarning("Start mileage must be entered.", Color.Red);
                txtBoxRentalStartMileage.Focus(); return false;
            }
            // Ödeme türünün girilip girilmediğini kontrol eder.
            if (string.IsNullOrEmpty(txtBoxRentalPaymentType.Text))
            {
                _formManager.UpdateProgressWarning("Payment type must be entered.", Color.Red);
                txtBoxRentalPaymentType.Focus(); return false;
            }

            // Müşterinin aktif kiralamalarını son bir kez kontrol eder.
            var customerActiveRentals = RentalMethods.CheckCustomerActiveRentals(selectedCustomer.CustomerID, _rentalRepository, _vehicleRepository);
            if (customerActiveRentals.Count > 0)
            {
                // Kullanıcıya aktif kiralamalar hakkında bilgi verir ve devam etmek isteyip istemediğini sorar.
                DialogResult result = MessageBox.Show($"Final check: Customer has {customerActiveRentals.Count} active rental(s). Continue?",
                    "Active Rental Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kullanıcı "Hayır" derse, işlemi iptal eder ve false döner.
                if (result == DialogResult.No)
                {
                    _formManager.UpdateProgressWarning("Rental cancelled.", Color.Blue);
                    return false;
                }
            }
            // Tüm kontrollerden geçerse true döner.
            return true;
        }

        // Yeni bir kiralama kaydı oluşturur.
        private void CreateRental()
        {
            try
            {
                // Formdan seçilen müşteri ve aracı alır.
                Customer selectedCustomer = RentalMethods.FindCustomerByFullName(txtBoxCustomerFullName.Text, _customers);
                Vehicle selectedVehicle = RentalMethods.FindVehicleByPlate(txtBoxVehiclePlate.Text, _vehicles);

                // Müşteri veya araç bulunamazsa uyarı verir ve işlemi sonlandırır.
                if (selectedCustomer == null || selectedVehicle == null)
                {
                    _formManager.UpdateProgressWarning("Customer or vehicle not found.", Color.Red); return;
                }
                // Araç kiralamaya uygun değilse uyarı verir, formu günceller ve işlemi sonlandırır.
                if (!RentalMethods.IsVehicleAvailableForRental(selectedVehicle, _rentalRepository))
                {
                    _formManager.UpdateProgressWarning("Vehicle not available, operation cancelled.", Color.Red);
                    LoadVehiclesForAutoComplete();
                    textBoxSearchVehicle.Text = string.Empty;
                    txtBoxVehiclePlate.Text = string.Empty;
                    return;
                }

                // Kiralama tutarı ve başlangıç kilometresi formatlarını kontrol eder.
                if (!decimal.TryParse(txtBoxRentalAmount.Text.Replace("₺", "").Trim(), out decimal rentalAmount) ||
                    !int.TryParse(txtBoxRentalStartMileage.Text.Replace("KM", "").Trim(), out int startKm))
                {
                    _formManager.UpdateProgressWarning("Amount or KM format is invalid.", Color.Red); return;
                }
                // Depozito tutarını alır (varsa).
                decimal? depositAmount = null;
                if (decimal.TryParse(txtBoxRentalDeposit.Text.Replace("₺", "").Trim(), out decimal deposit))
                {
                    depositAmount = deposit;
                }

                // Yeni kiralama nesnesini oluşturur.
                Rental newRental = new Rental
                {
                    RentalCustomerID = selectedCustomer.CustomerID,
                    RentalVehicleID = selectedVehicle.VehicleID,
                    RentalStartDate = dtpRentalStartDate.Value,
                    RentalEndDate = dtpRentalEndDate.Value,
                    RentalStartKm = startKm,
                    RentalAmount = rentalAmount,
                    RentalDepositAmount = depositAmount,
                    RentalPaymentType = txtBoxRentalPaymentType.Text,
                    RentalStatus = "Pending", // Kiralama durumu "Onay Bekliyor" olarak ayarlanır.
                    RentalUserID = Utils.CurrentUser.UserID,
                    RentalCreatedAt = DateTime.Now
                };

                // Kiralama notu varsa notuyla birlikte, yoksa notsuz olarak kiralamayı veritabanına ekler.
                int rentalId = string.IsNullOrEmpty(txtBoxRentalNote.Text.Trim())
            ? _rentalRepository.Insert(newRental)
            : _rentalRepository.CreateRentalWithNote(newRental, txtBoxRentalNote.Text.Trim());

                // Kiralama başarıyla oluşturulduysa.
                if (rentalId > 0)
                {
                    // İlerleme durumu mesajını günceller ve kullanıcıya bilgi verir.
                    _formManager.UpdateProgressWarning($"Rental ID {rentalId} created and PENDING APPROVAL!", Color.Orange);
                    MessageBox.Show("Rental has been sent to the approval process. It will be active after customer and authorized signatures.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kiralama listesini ve araç otomatik tamamlama listesini yeniler.
                    LoadRentals();
                    LoadVehiclesForAutoComplete();
                    // Formu temizler.
                    ClearForm();
                }
                else
                {
                    // Kiralama oluşturulamazsa uyarı verir.
                    _formManager.UpdateProgressWarning("Rental could not be created.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda ilerleme durumu mesajını günceller.
                _formManager.UpdateProgressWarning($"Rental error: {ex.Message}", Color.Red);
            }
        }

        // "Kiralama Ekle" butonu tıklandığında çalışır.
        private void btnAddRental_Click(object sender, EventArgs e)
        {
            // Form geçerliyse kiralama oluşturma işlemini başlatır.
            if (ValidateRentalForm())
            {
                CreateRental();
            }
        }

        // "Formu Temizle" butonu tıklandığında çalışır.
        private void btnClearRentalForm_Click(object sender, EventArgs e)
        {
            // Formu temizler.
            ClearForm();
            // İlerleme durumu mesajını günceller.
            _formManager.UpdateProgressWarning("Form cleared. Ready for new rental entry.", Color.Blue);
        }

        // Son kiralamalar (sfDataGridLastRentals) tablosundaki bir hücreye çift tıklandığında tetiklenir.
        private void SfDataGridLastRentals_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            // Tıklanan satırın geçerli bir veri satırı olup olmadığını kontrol eder.
            if (e.DataRow != null && e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                // Tıklanan satırdaki kiralama verisini alır.
                var rentalClickedInLastRentalsGrid = e.DataRow.RowData as Rental;
                if (rentalClickedInLastRentalsGrid != null)
                {
                    // "Son Kiralamalar" tablosundaki öğeyi seçer.
                    sfDataGridLastRentals.SelectedItem = rentalClickedInLastRentalsGrid;
                    // Diğer tablodaki seçimi temizler.
                    sfDataGridRentals.SelectedItem = null;

                    // "Kiralama Ekle/Düzenle" sekmesine geçer.
                    if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
                    {
                        parentTabControl.SelectedTab = tabPageRentalAdd;
                    }

                    // Seçilen kiralama bilgilerini forma yükler.
                    LoadSelectedRental();
                }
            }
        }

        // "Kiralama Göster" butonu tıklandığında çalışır.
        private void BtnShowRental_Click(object sender, EventArgs e)
        {
            // Seçili kiralama bilgilerini forma yükler.
            LoadSelectedRental();
            // "Kiralama Ekle/Düzenle" sekmesine geçer.
            if (tabPageRentalAdd != null && tabPageRentalAdd.Parent is TabControlAdv parentTabControl)
            {
                parentTabControl.SelectedTab = tabPageRentalAdd;
            }
        }

        // Seçilen bir kiralama kaydının detaylarını forma yükler.
        private void LoadSelectedRental()
        {
            try
            {
                // Öncelikle "Son Kiralamalar" tablosundan, eğer orada seçili değilse "Kiralamalar" tablosundan seçili kiralamayı alır.
                Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental ?? sfDataGridRentals.SelectedItem as Rental;
                // Seçili bir kiralama yoksa uyarı verir ve işlemi sonlandırır.
                if (selectedRental == null)
                {
                    MessageBox.Show("Please select a rental from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Formdaki giriş alanlarını temizler.
                _formManager.ClearFormInputs();

                // Seçilen kiralamanın müşteri bilgisini, eğer ID'si varsa, veritabanından yükler.
                if (selectedRental.RentalCustomerID > 0)
                {
                    selectedRental.Customer = _customerRepository.GetById(selectedRental.RentalCustomerID);
                }
                else
                {
                    selectedRental.Customer = null;
                }

                // Seçilen kiralamanın araç bilgisini, eğer ID'si varsa, veritabanından yükler.
                if (selectedRental.RentalVehicleID > 0)
                {
                    selectedRental.Vehicle = _vehicleRepository.GetById(selectedRental.RentalVehicleID);
                }
                else
                {
                    selectedRental.Vehicle = null;
                }

                // Seçilen kiralamanın notlarını, eğer kiralama ID'si varsa, veritabanından yükler.
                List<RentalNote> notes = (selectedRental.RentalID > 0) ? _rentalRepository.GetNotes(selectedRental.RentalID) : new List<RentalNote>();

                // Tarih seçicilerin (DateTimePicker) minimum tarih ayarlarını geçici olarak saklar.
                DateTime originalMinDateStart = dtpRentalStartDate.MinDate;
                DateTime originalMinDateEnd = dtpRentalEndDate.MinDate;
                try
                {
                    // Tarih seçicilerin minimum tarihlerini en düşük olası değere ayarlar (geçmiş tarihli kiralamaları gösterebilmek için).
                    dtpRentalStartDate.MinDate = DateTimePicker.MinimumDateTime;
                    dtpRentalEndDate.MinDate = DateTimePicker.MinimumDateTime;

                    // Seçilen kiralama detaylarını ve notlarını forma yükler, kiralama tutarını hesaplar.
                    _formManager.PopulateSelectedRentalDetails(selectedRental, notes, CalculateRentalAmount);
                }
                finally
                {
                    // Kiralama henüz iade edilmemişse, tarih seçicilerin minimum tarihlerini bugüne ayarlar.
                    if (!selectedRental.RentalReturnDate.HasValue)
                    {
                        dtpRentalStartDate.MinDate = DateTime.Today;
                        dtpRentalEndDate.MinDate = dtpRentalStartDate.Value.AddDays(1);
                    }
                    else
                    {
                        // Kiralama iade edilmişse, orijinal minimum tarih ayarlarını geri yükler.
                        dtpRentalStartDate.MinDate = originalMinDateStart;
                        dtpRentalEndDate.MinDate = originalMinDateEnd;
                    }
                }

                // Formu sadece okunabilir moda alır.
                _formManager.SetFormReadOnly(true);
                // Kiralama durumunu alır.
                RentalMethods.RentalStatus status = RentalMethods.GetRentalStatus(selectedRental);
                // İlerleme durumu mesajını kiralama durumu ve rengiyle günceller.
                _formManager.UpdateProgressWarning($"Rental Status: {RentalMethods.GetStatusDescription(status)}", RentalMethods.GetStatusTextColor(status));
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading rental information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // "Kiralama İşlemleri" butonu tıklandığında çalışır.
        private void btnRentalOperations_Click(object sender, EventArgs e)
        {
            // Seçili kiralamayı alır.
            Rental selectedRental = sfDataGridLastRentals.SelectedItem as Rental ?? sfDataGridRentals.SelectedItem as Rental;
            // Seçili bir kiralama yoksa uyarı verir ve işlemi sonlandırır.
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental for the operation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiralama işlemleri formunu oluşturur ve seçili kiralama ID'si ile başlatır.
            RentalOperationsForm operationsForm = new RentalOperationsForm(selectedRental.RentalID);
            // Kiralama işlemleri formunu diyalog olarak gösterir.
            DialogResult result = operationsForm.ShowDialog(this);

            // İşlemler formu "OK" ile kapatıldıysa (yani bir işlem yapıldıysa).
            if (result == DialogResult.OK)
            {
                // Kiralama listesini ve araç otomatik tamamlama listesini yeniler.
                LoadRentals();
                LoadVehiclesForAutoComplete();

                // İşlem yapılan kiralamanın güncel halini veritabanından alır.
                var refreshedRental = _rentalRepository.GetById(selectedRental.RentalID);
                if (refreshedRental != null)
                {
                    // Güncellenmiş kiralamayı tablolarda yeniden seçmeye çalışır.
                    var rentalInLastRentalsGrid = (sfDataGridLastRentals.DataSource as List<Rental>)?.FirstOrDefault(r => r.RentalID == refreshedRental.RentalID);
                    if (rentalInLastRentalsGrid != null) sfDataGridLastRentals.SelectedItem = rentalInLastRentalsGrid;

                    var rentalInRentalsGrid = (sfDataGridRentals.DataSource as List<Rental>)?.FirstOrDefault(r => r.RentalID == refreshedRental.RentalID);
                    if (rentalInRentalsGrid != null) sfDataGridRentals.SelectedItem = rentalInRentalsGrid;

                    // Eğer orijinal seçili öğe (veya güncellenmiş hali) hala gösterilmek isteniyorsa.
                    if ((sfDataGridLastRentals.SelectedItem as Rental)?.RentalID == refreshedRental.RentalID ||
                         (sfDataGridRentals.SelectedItem as Rental)?.RentalID == refreshedRental.RentalID)
                    {
                        // Seçili kiralama bilgilerini yeniden yükler.
                        LoadSelectedRental();
                    }
                    else
                    {
                        // Formu temizler (veya bulunan güncellenmiş kiralamayı seçip yükler).
                        ClearForm();
                    }
                }
                else
                {
                    // Güncellenmiş kiralama bulunamazsa formu temizler.
                    ClearForm();
                }
                // İlerleme durumu mesajını günceller.
                _formManager.UpdateProgressWarning("Rental operations completed. Data refreshed.", Color.Blue);
            }
        }
    }
}