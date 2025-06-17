using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace car_rental_sales_desktop.Forms.Controls
{
    // Onaylama işlemlerini yöneten kullanıcı kontrolünü temsil eder.
    public partial class ConfirmationsControl : UserControl
    {
        // Kiralama işlemleri için depo (repository) nesnesi.
        private RentalRepository _rentalRepository;
        // Müşteri işlemleri için depo (repository) nesnesi.
        private CustomerRepository _customerRepository;
        // Araç işlemleri için depo (repository) nesnesi.
        private VehicleRepository _vehicleRepository;
        // Kullanıcı işlemleri için depo (repository) nesnesi.
        private UserRepository _userRepository;
        // Onay bekleyen kiralamaların listesini tutar.
        private List<Rental> _pendingRentals;

        // ConfirmationsControl sınıfının yapıcı metodu.
        public ConfirmationsControl()
        {
            // Bileşenleri başlatır (tasarımcı tarafından oluşturulan kod).
            InitializeComponent();

            // Depo (repository) nesnelerini oluşturur.
            _rentalRepository = new RentalRepository();
            _customerRepository = new CustomerRepository();
            _vehicleRepository = new VehicleRepository();
            _userRepository = new UserRepository();

            // Kontrol yüklendiğinde çalışacak olayı (event) tanımlar.
            this.Load += ConfirmationsControl_Load;
        }

        // Kontrol yüklendiğinde tetiklenen olay metodu.
        private void ConfirmationsControl_Load(object sender, EventArgs e)
        {
            // Onaylama yetkisi kontrolü
            if (!CurrentUser.CanPerformAction("approve_rentals"))
            {
                MessageBox.Show("You do not have the authority to approve rental.", "Unauthorized Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            LoadPendingRentals();
        }

        // Onay bekleyen kiralamaları veritabanından yükler ve DataGrid'e bağlar.
        private void LoadPendingRentals()
        {
            try
            {
                // RentalRepository üzerinden onay bekleyen kiralamaları alır.
                _pendingRentals = _rentalRepository.GetPendingRentals();

                // Her bir kiralama için müşteri, araç ve kullanıcı bilgilerini yükler (eğer eksikse).
                foreach (var rental in _pendingRentals)
                {
                    // Eğer kiralama nesnesinde müşteri bilgisi yoksa ve müşteri ID'si varsa, müşteri bilgisini yükler.
                    if (rental.Customer == null && rental.RentalCustomerID > 0)
                        rental.Customer = _customerRepository.GetById(rental.RentalCustomerID);

                    // Eğer kiralama nesnesinde araç bilgisi yoksa ve araç ID'si varsa, araç bilgisini yükler.
                    if (rental.Vehicle == null && rental.RentalVehicleID > 0)
                        rental.Vehicle = _vehicleRepository.GetById(rental.RentalVehicleID);

                    // Eğer kiralama nesnesinde kullanıcı bilgisi yoksa ve kullanıcı ID'si varsa, kullanıcı bilgisini yükler.
                    if (rental.User == null && rental.RentalUserID > 0)
                        rental.User = _userRepository.GetById(rental.RentalUserID);
                }

                // DataGrid'in veri kaynağını onay bekleyen kiralamalar listesi olarak ayarlar.
                sfDataGridPending.DataSource = _pendingRentals;
                // İstatistikleri günceller (onay bekleyen ve bugün oluşturulan kiralama sayıları).
                UpdateStats();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi mesajı gösterir.
                MessageBox.Show($"Error loading pending rentals: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Onay bekleyen ve bugün oluşturulan kiralama sayılarını günceller.
        private void UpdateStats()
        {
            // Onay bekleyen kiralama sayısını etikete yazar.
            lblPendingCount.Text = $"Pending Approval: {_pendingRentals.Count}";
            // Bugün oluşturulan kiralama sayısını etikete yazar.
            lblTodayCount.Text = $"Created Today: {_pendingRentals.Count(r => r.RentalCreatedAt.Date == DateTime.Today)}";
        }

        // "Onayla" butonuna tıklandığında tetiklenen olay metodu.
        private void btnApprove_Click(object sender, EventArgs e)
        {
            // DataGrid'den seçili olan kiralama nesnesini alır.
            var selectedRental = sfDataGridPending.SelectedItem as Rental;
            // Eğer hiçbir kiralama seçilmemişse, kullanıcıyı uyarır ve işlemi sonlandırır.
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental to approve.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiralama onay formunu (RentalApprovalForm) seçili kiralama ile açar.
            var approvalForm = new RentalApprovalForm(selectedRental);
            // Onay formu "OK" sonucuyla kapatılırsa (yani onay işlemi başarılıysa).
            if (approvalForm.ShowDialog() == DialogResult.OK)
            {
                // Onay bekleyen kiralamaları yeniden yükler.
                LoadPendingRentals();
                // Kullanıcıya başarılı onay mesajı gösterir.
                MessageBox.Show("Rental approved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // "Reddet" butonuna tıklandığında tetiklenen olay metodu.
        private void btnReject_Click(object sender, EventArgs e)
        {
            // DataGrid'den seçili olan kiralama nesnesini alır.
            var selectedRental = sfDataGridPending.SelectedItem as Rental;
            // Eğer hiçbir kiralama seçilmemişse, kullanıcıyı uyarır ve işlemi sonlandırır.
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental to reject.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıya kiralama reddetme işlemini onaylaması için bir mesaj kutusu gösterir.
            var result = MessageBox.Show(
                $"Rental ID: {selectedRental.RentalID} will be rejected. Are you sure?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı "Evet" seçeneğini seçerse.
            if (result == DialogResult.Yes)
            {
                // Kiralama durumunu "Rejected" (Reddedildi) olarak günceller.
                if (_rentalRepository.UpdateRentalStatus(selectedRental.RentalID, "Rejected"))
                {
                    // Aracın durumunu tekrar "Müsait" (1) olarak günceller.
                    _vehicleRepository.UpdateVehicleStatus(selectedRental.RentalVehicleID, 1); // Assuming 1 means "Available"

                    // Onay bekleyen kiralamaları yeniden yükler.
                    LoadPendingRentals();
                    // Kullanıcıya kiralama reddedildi bilgisi mesajı gösterir.
                    MessageBox.Show("Rental rejected.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // "Yenile" butonuna tıklandığında tetiklenen olay metodu.
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Onay bekleyen kiralamaları yeniden yükler.
            LoadPendingRentals();
        }

        // DataGrid'deki satırların stilini sorgulayan olay metodu (satır renklendirmesi için).
        private void sfDataGridPending_QueryRowStyle(object sender, QueryRowStyleEventArgs e)
        {
            // Eğer satır tipi varsayılan satır ise (başlık veya filtre satırı değilse).
            if (e.RowType == RowType.DefaultRow)
            {
                // Çift sıralı satırların arka plan rengini beyaz yapar.
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.White;
                // Tek sıralı satırların arka plan rengini açık mavi yapar.
                else
                    e.Style.BackColor = Color.FromArgb(245, 248, 255);
            }
        }
    }
}