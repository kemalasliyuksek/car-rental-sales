using System;
using System.Drawing;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Forms
{
    // Kiralama onay formunu temsil eden sınıf.
    public partial class RentalApprovalForm : Form
    {
        private Rental _rental; // Üzerinde işlem yapılacak kiralama nesnesi.
        private RentalRepository _rentalRepository; // Kiralama veritabanı işlemleri için depo.

        // RentalApprovalForm sınıfının yapıcı metodu.
        // Parametre olarak bir kiralama nesnesi alır.
        public RentalApprovalForm(Rental rental)
        {
            InitializeComponent(); // Formun bileşenlerini başlatır (Windows Forms tarafından otomatik oluşturulur).
            _rental = rental; // Parametre olarak gelen kiralama nesnesini sınıfın özel alanına atar.
            _rentalRepository = new RentalRepository(); // Kiralama işlemleri için yeni bir depo nesnesi oluşturur.

            LoadRentalInfo(); // Kiralama bilgilerini forma yükler.
        }

        // Kiralama bilgilerini formdaki ilgili etiketlere yükleyen metod.
        private void LoadRentalInfo()
        {
            // Kiralama ID'sini etikete yazar.
            lblRentalId.Text = $"Kiralama ID: {_rental.RentalID}";
            // Müşteri adını ve soyadını etikete yazar. Müşteri bilgisi yoksa "Bilinmiyor" yazar.
            lblCustomerName.Text = $"Müşteri: {_rental.Customer?.FullName ?? "Bilinmiyor"}";
            // Araç plakasını, markasını ve modelini etikete yazar. Araç bilgisi yoksa "Bilinmiyor" yazar.
            lblVehicle.Text = $"Araç: {_rental.Vehicle?.VehiclePlateNumber ?? "Bilinmiyor"} - {_rental.Vehicle?.VehicleBrand} {_rental.Vehicle?.VehicleModel}";
            // Kiralama tutarını formatlı bir şekilde (N2: iki ondalık basamak) etikete yazar.
            lblAmount.Text = $"Tutar: {_rental.RentalAmount:N2} ₺";
            // Kiralama başlangıç ve bitiş tarihlerini formatlı bir şekilde (dd.MM.yyyy) etikete yazar.
            lblDates.Text = $"Tarih: {_rental.RentalStartDate:dd.MM.yyyy} - {_rental.RentalEndDate:dd.MM.yyyy}";
            // Kiralama işlemini yapan yetkili personel adını ve soyadını etikete yazar. Yetkili bilgisi yoksa "Bilinmiyor" yazar.
            lblStaff.Text = $"Yetkili: {_rental.User?.FullName ?? "Bilinmiyor"}";
        }

        // "Onayla" butonuna tıklandığında çalışan olay yöneticisi.
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Yetkili personel adı soyadı kontrolü.
            string staffFullName = txtStaffName.Text.Trim(); // Yetkili adı metin kutusundaki değeri alır ve başındaki/sonundaki boşlukları temizler.
            // Yetkili adı soyadı boş ise uyarı mesajı gösterir ve işlemi sonlandırır.
            if (string.IsNullOrEmpty(staffFullName))
            {
                MessageBox.Show("Lütfen yetkili adı soyadı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metoddan çıkar.
            }

            // Girilen yetkili adı soyadı, kiralama kaydındaki yetkili adı soyadı ile eşleşmiyorsa (büyük/küçük harf duyarsız) hata mesajı gösterir.
            if (!staffFullName.Equals(_rental.User?.FullName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Yetkili adı soyadı eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffName.Focus(); // Yetkili adı metin kutusuna odaklanır.
                return; // Metoddan çıkar.
            }

            // Müşteri adı soyadı kontrolü.
            string customerFullName = txtCustomerName.Text.Trim(); // Müşteri adı metin kutusundaki değeri alır ve başındaki/sonundaki boşlukları temizler.
            // Müşteri adı soyadı boş ise uyarı mesajı gösterir ve işlemi sonlandırır.
            if (string.IsNullOrEmpty(customerFullName))
            {
                MessageBox.Show("Lütfen müşteri adı soyadı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metoddan çıkar.
            }

            // Girilen müşteri adı soyadı, kiralama kaydındaki müşteri adı soyadı ile eşleşmiyorsa (büyük/küçük harf duyarsız) hata mesajı gösterir.
            if (!customerFullName.Equals(_rental.Customer?.FullName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Müşteri adı soyadı eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerName.Focus(); // Müşteri adı metin kutusuna odaklanır.
                return; // Metoddan çıkar.
            }

            // Kullanıcıya kiralama sözleşmesinin onaylanacağına dair bir onay mesajı gösterir.
            var result = MessageBox.Show(
                "Kiralama sözleşmesi onaylanacak. Emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı "Evet" butonuna tıklarsa onaylama işlemini gerçekleştirir.
            if (result == DialogResult.Yes)
            {
                // Kiralama durumunu "Approved" (Onaylandı) olarak günceller.
                if (_rentalRepository.UpdateRentalStatus(_rental.RentalID, "Approved"))
                {
                    // Araç durumunu güncellemek için VehicleRepository örneği oluşturulur.
                    var vehicleRepo = new VehicleRepository();
                    // İlgili aracın durumunu "Rented" (Kirada) olarak günceller (3 ID'si Kirada durumunu temsil ediyor varsayılır).
                    vehicleRepo.UpdateVehicleStatus(_rental.RentalVehicleID, 3);

                    this.DialogResult = DialogResult.OK; // Formun kapanma sonucunu OK (Başarılı) olarak ayarlar.
                    this.Close(); // Formu kapatır.
                }
                else
                {
                    // Kiralama durumu güncellenemezse hata mesajı gösterir.
                    MessageBox.Show("Onaylama işlemi başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // "İptal" butonuna tıklandığında çalışan olay yöneticisi.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Formun kapanma sonucunu Cancel (İptal) olarak ayarlar.
            this.Close(); // Formu kapatır.
        }
    }
}