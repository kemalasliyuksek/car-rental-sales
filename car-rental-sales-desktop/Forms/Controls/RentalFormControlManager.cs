using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using Syncfusion.WinForms.DataGrid;

namespace car_rental_sales_desktop.Forms.Controls
{
    // Kiralama formu kontrollerini yönetmek için kullanılan sınıf.
    public class RentalFormControlManager
    {
        // Kiralama kontrolüne (RentalsControl) özel bir referans tutar.
        private RentalsControl _rentalsControl;

        // RentalFormControlManager sınıfının yapıcı metodu.
        // Parametre olarak bir RentalsControl örneği alır ve _rentalsControl alanını başlatır.
        public RentalFormControlManager(RentalsControl rentalsControl)
        {
            // rentalsControl null ise ArgumentNullException fırlatır, değilse _rentalsControl alanına atar.
            _rentalsControl = rentalsControl ?? throw new ArgumentNullException(nameof(rentalsControl));
        }

        // Müşteri bilgilerini formdaki ilgili alanlara yükler.
        // Parametre olarak bir Customer nesnesi alır.
        public void LoadCustomerInfo(Customer customer)
        {
            // Eğer müşteri nesnesi null ise metottan çıkar.
            if (customer == null) return;

            // Müşterinin tam adını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxCustomerFullName.Text = $"{customer.CustomerFirstName} {customer.CustomerLastName}";
            // Müşterinin TC kimlik numarasını ilgili metin kutusuna yazar.
            _rentalsControl.tctBoxNationalID.Text = customer.CustomerNationalID;
            // Müşterinin telefon numarasını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxPhoneNo.Text = customer.CustomerPhone;
            // Müşterinin e-posta adresini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxEmail.Text = customer.CustomerEmail;
            // Müşterinin adresini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxAddress.Text = customer.CustomerAddress;
            // Müşterinin ehliyet numarasını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxLicenseNo.Text = customer.CustomerLicenseNumber;
            // Müşterinin ehliyet sınıfını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxLicenseClass.Text = customer.CustomerLicenseClass;

            // Müşterinin ehliyet tarihini, eğer varsa, tarih seçiciye ayarlar; yoksa minimum tarihi ayarlar.
            _rentalsControl.dtpLicenseDate.Value = customer.CustomerLicenseDate.HasValue ? customer.CustomerLicenseDate.Value : _rentalsControl.dtpLicenseDate.MinDate;
            // Müşterinin doğum tarihini, eğer varsa, tarih seçiciye ayarlar; yoksa minimum tarihi ayarlar.
            _rentalsControl.dtpDateOfBirth.Value = customer.CustomerDateOfBirth.HasValue ? customer.CustomerDateOfBirth.Value : _rentalsControl.dtpDateOfBirth.MinDate;
        }

        // Araç bilgilerini formdaki ilgili alanlara yükler ve kiralama tutarını hesaplamak için bir geri çağırma fonksiyonunu çalıştırır.
        // Parametre olarak bir Vehicle nesnesi ve bir Action (geri çağırma metodu) alır.
        public void LoadVehicleInfo(Vehicle vehicle, Action calculateRentalAmountCallback)
        {
            // Eğer araç nesnesi null ise metottan çıkar.
            if (vehicle == null) return;

            // Aracın plakasını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehiclePlate.Text = vehicle.VehiclePlateNumber;
            // Aracın markasını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleBrand.Text = vehicle.VehicleBrand;
            // Aracın modelini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleModel.Text = vehicle.VehicleModel;
            // Aracın yılını ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleYear.Text = vehicle.VehicleYear.ToString();
            // Aracın rengini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleColor.Text = vehicle.VehicleColor;
            // Aracın yakıt tipini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleFuelType.Text = vehicle.VehicleFuelType;
            // Aracın vites tipini ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleTransmission.Text = vehicle.VehicleTransmissionType;
            // Aracın kilometresini " KM" ekiyle ilgili metin kutusuna yazar.
            _rentalsControl.txtBoxVehicleMileage.Text = $"{vehicle.VehicleMileage} KM";
            // Aracın bulunduğu şubenin adını yazar; şube bilgisi yoksa "Undefined" yazar.
            _rentalsControl.txtBoxVehicleLocation.Text = vehicle.Branch?.BranchName ?? "Undefined";
            // Aracın durumunu yazar; durum bilgisi yoksa "Undefined" yazar.
            _rentalsControl.txtBoxVehicleStatus.Text = vehicle.VehicleStatus?.VehicleStatusName ?? "Undefined";

            // Kiralama başlangıç tarihini mevcut zamana ayarlar.
            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            // Kiralama bitiş tarihini mevcut zamandan bir gün sonrasına ayarlar.
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            // Kiralama başlangıç kilometresini aracın mevcut kilometresi olarak ayarlar.
            _rentalsControl.txtBoxRentalStartMileage.Text = vehicle.VehicleMileage.ToString();

            // Verilen geri çağırma fonksiyonunu (kiralama tutarını hesaplamak için) çalıştırır.
            calculateRentalAmountCallback?.Invoke();
        }

        // Formdaki tüm giriş alanlarını temizler.
        public void ClearFormInputs()
        {
            // Müşteri arama metin kutusunu temizler.
            _rentalsControl.txtBoxSearchCustomer.Text = string.Empty;
            // Müşteri tam adı metin kutusunu temizler.
            _rentalsControl.txtBoxCustomerFullName.Text = string.Empty;
            // TC kimlik numarası metin kutusunu temizler.
            _rentalsControl.tctBoxNationalID.Text = string.Empty;
            // Telefon numarası metin kutusunu temizler.
            _rentalsControl.txtBoxPhoneNo.Text = string.Empty;
            // E-posta metin kutusunu temizler.
            _rentalsControl.txtBoxEmail.Text = string.Empty;
            // Adres metin kutusunu temizler.
            _rentalsControl.txtBoxAddress.Text = string.Empty;
            // Ehliyet numarası metin kutusunu temizler.
            _rentalsControl.txtBoxLicenseNo.Text = string.Empty;
            // Ehliyet sınıfı metin kutusunu temizler.
            _rentalsControl.txtBoxLicenseClass.Text = string.Empty;
            // Ehliyet tarihi seçicisini minimum tarihe ayarlar.
            _rentalsControl.dtpLicenseDate.Value = _rentalsControl.dtpLicenseDate.MinDate;
            // Doğum tarihi seçicisini minimum tarihe ayarlar.
            _rentalsControl.dtpDateOfBirth.Value = _rentalsControl.dtpDateOfBirth.MinDate;

            // Araç arama metin kutusunu temizler.
            _rentalsControl.textBoxSearchVehicle.Text = string.Empty;
            // Araç plakası metin kutusunu temizler.
            _rentalsControl.txtBoxVehiclePlate.Text = string.Empty;
            // Araç markası metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleBrand.Text = string.Empty;
            // Araç modeli metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleModel.Text = string.Empty;
            // Araç yılı metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleYear.Text = string.Empty;
            // Araç rengi metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleColor.Text = string.Empty;
            // Araç yakıt tipi metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleFuelType.Text = string.Empty;
            // Araç vites tipi metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleTransmission.Text = string.Empty;
            // Araç kilometresi metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleMileage.Text = string.Empty;
            // Araç konumu metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleLocation.Text = string.Empty;
            // Araç durumu metin kutusunu temizler.
            _rentalsControl.txtBoxVehicleStatus.Text = string.Empty;

            // Kiralama başlangıç tarihini mevcut zamana ayarlar.
            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            // Kiralama bitiş tarihini mevcut zamandan bir gün sonrasına ayarlar.
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            // Kiralama başlangıç kilometresi metin kutusunu temizler.
            _rentalsControl.txtBoxRentalStartMileage.Text = string.Empty;
            // Kiralama bitiş kilometresi metin kutusunu (textBox8) temizler.
            _rentalsControl.textBox8.Text = string.Empty;
            // Kiralama ödeme tipini "Cash" olarak ayarlar.
            _rentalsControl.txtBoxRentalPaymentType.Text = "Cash";
            // Kiralama tutarı metin kutusunu temizler.
            _rentalsControl.txtBoxRentalAmount.Text = string.Empty;
            // Kiralama depozito metin kutusunu temizler.
            _rentalsControl.txtBoxRentalDeposit.Text = string.Empty;
            // Kiralama notu metin kutusunu temizler.
            _rentalsControl.txtBoxRentalNote.Text = string.Empty;

            // Hata yakalama bloğu içinde grid seçimlerini temizler.
            try
            {
                // Kiralama listesi gridindeki seçimleri temizler.
                ClearGridSelections(_rentalsControl.sfDataGridRentals);
                // Son kiralamalar gridindeki seçimleri temizler.
                ClearGridSelections(_rentalsControl.sfDataGridLastRentals);
            }
            catch (Exception ex)
            {
                // Seçim temizleme sırasında bir hata oluşursa, hata mesajını hata ayıklama konsoluna yazar.
                System.Diagnostics.Debug.WriteLine($"Selection clearing failed in FormManager: {ex.Message}");
            }
        }

        // Belirtilen SfDataGrid'deki seçimleri temizler.
        // Parametre olarak bir SfDataGrid nesnesi alır.
        private void ClearGridSelections(SfDataGrid grid)
        {
            // Eğer grid nesnesi null değilse işlemleri yapar.
            if (grid != null)
            {
                // Griddeki tüm seçimleri kaldırır.
                grid.ClearSelection();
                // Seçili öğeyi null yapar.
                grid.SelectedItem = null;
                // Seçili indeksi -1 yapar (seçim yok anlamına gelir).
                grid.SelectedIndex = -1;
            }
        }

        // Formdaki kontrol elemanlarının sadece okunabilir olup olmayacağını ayarlar.
        // Parametre olarak bir bool (isReadOnly) değeri alır; true ise sadece okunabilir, false ise düzenlenebilir yapar.
        public void SetFormReadOnly(bool isReadOnly)
        {
            // Müşteri arama metin kutusunun sadece okunabilirliğini ayarlar.
            _rentalsControl.txtBoxSearchCustomer.ReadOnly = isReadOnly;
            // Müşteri yükleme butonunun etkinliğini ayarlar (sadece okunabilir değilse etkin).
            _rentalsControl.btnCustomerLoad.Enabled = !isReadOnly;

            // Araç arama metin kutusunun sadece okunabilirliğini ayarlar.
            _rentalsControl.textBoxSearchVehicle.ReadOnly = isReadOnly;
            // Araç yükleme butonunun etkinliğini ayarlar (sadece okunabilir değilse etkin).
            _rentalsControl.btnVehicleLoad.Enabled = !isReadOnly;

            // Kiralama başlangıç tarihi seçicisinin etkinliğini ayarlar.
            _rentalsControl.dtpRentalStartDate.Enabled = !isReadOnly;
            // Kiralama bitiş tarihi seçicisinin etkinliğini ayarlar.
            _rentalsControl.dtpRentalEndDate.Enabled = !isReadOnly;

            // Kiralama ödeme tipi metin kutusunun etkinliğini ayarlar.
            _rentalsControl.txtBoxRentalPaymentType.Enabled = !isReadOnly;
            // Kiralama notu metin kutusunun sadece okunabilirliğini ayarlar.
            _rentalsControl.txtBoxRentalNote.ReadOnly = isReadOnly;

            // Kiralama ekleme butonunun etkinliğini ayarlar.
            _rentalsControl.btnAddRental.Enabled = !isReadOnly;

            // Eğer form sadece okunabilir ise, kiralama ekleme butonunun arka plan rengini gri yapar.
            if (isReadOnly)
            {
                _rentalsControl.btnAddRental.BackColor = Color.Gray;
            }
            // Değilse, kiralama ekleme butonunun arka plan rengini sistemin varsayılan "HotTrack" rengine ayarlar.
            else
            {
                _rentalsControl.btnAddRental.BackColor = SystemColors.HotTrack;
            }
        }

        // Seçilen bir kiralama kaydının detaylarını forma yükler.
        // Parametre olarak bir Rental nesnesi, bir RentalNote listesi ve bir Action (geri çağırma metodu) alır.
        public void PopulateSelectedRentalDetails(Rental rental, List<RentalNote> notes, Action calculateRentalAmountCallback)
        {
            // Eğer kiralama kaydının müşterisi varsa, müşteri bilgilerini yükler.
            if (rental.Customer != null)
            {
                LoadCustomerInfo(rental.Customer);
                // Müşteri arama metin kutusuna müşterinin tam adını yazar.
                _rentalsControl.txtBoxSearchCustomer.Text = $"{rental.Customer.CustomerFirstName} {rental.Customer.CustomerLastName}";
            }

            // Eğer kiralama kaydının aracı varsa, araç bilgilerini yükler.
            if (rental.Vehicle != null)
            {
                LoadVehicleInfo(rental.Vehicle, calculateRentalAmountCallback);
                // Araç arama metin kutusuna aracın plakasını yazar.
                _rentalsControl.textBoxSearchVehicle.Text = rental.Vehicle.VehiclePlateNumber;
            }

            // Kiralama başlangıç tarihini ayarlar.
            _rentalsControl.dtpRentalStartDate.Value = rental.RentalStartDate;
            // Kiralama bitiş tarihini ayarlar.
            _rentalsControl.dtpRentalEndDate.Value = rental.RentalEndDate;

            // Kiralama başlangıç kilometresini ayarlar.
            _rentalsControl.txtBoxRentalStartMileage.Text = rental.RentalStartKm.ToString();
            // Kiralama bitiş kilometresini, eğer varsa, ayarlar; yoksa boş bırakır.
            _rentalsControl.textBox8.Text = rental.RentalEndKm.HasValue ? rental.RentalEndKm.Value.ToString() : string.Empty;
            // Kiralama ödeme tipini ayarlar.
            _rentalsControl.txtBoxRentalPaymentType.Text = rental.RentalPaymentType;
            // Kiralama tutarını para birimi formatında (N2) ve " ₺" simgesiyle ayarlar.
            _rentalsControl.txtBoxRentalAmount.Text = rental.RentalAmount.ToString("N2") + " ₺";
            // Kiralama depozito tutarını, eğer varsa, para birimi formatında (N2) ve " ₺" simgesiyle ayarlar; yoksa boş bırakır.
            _rentalsControl.txtBoxRentalDeposit.Text = rental.RentalDepositAmount.HasValue ? rental.RentalDepositAmount.Value.ToString("N2") + " ₺" : string.Empty;

            // Eğer kiralama notları varsa ve en az bir not içeriyorsa, notları birleştirip ilgili metin kutusuna yazar.
            if (notes != null && notes.Any())
            {
                _rentalsControl.txtBoxRentalNote.Text = string.Join(Environment.NewLine, notes.Select(n => n.RentalNoteText));
            }
        }

        // İlerleme durumu uyarı mesajını ve rengini günceller.
        // Parametre olarak bir mesaj (string) ve bir renk (Color) alır.
        public void UpdateProgressWarning(string message, Color color)
        {
            // Eğer ilerleme uyarı etiketi (lblProgressWarning) null değilse işlemleri yapar.
            if (_rentalsControl.lblProgressWarning != null)
            {
                // Etiketin metnini verilen mesajla günceller.
                _rentalsControl.lblProgressWarning.Text = message;
                // Etiketin yazı rengini verilen renkle günceller.
                _rentalsControl.lblProgressWarning.ForeColor = color;
            }
        }

        // Formdaki bazı kontrol elemanlarını varsayılan değerlerine başlatır.
        public void InitializeFormDefaults()
        {
            // Ehliyet tarihi seçicisini minimum tarihe ayarlar.
            _rentalsControl.dtpLicenseDate.Value = _rentalsControl.dtpLicenseDate.MinDate;
            // Doğum tarihi seçicisini minimum tarihe ayarlar.
            _rentalsControl.dtpDateOfBirth.Value = _rentalsControl.dtpDateOfBirth.MinDate;
            // Kiralama başlangıç tarihini mevcut zamana ayarlar.
            _rentalsControl.dtpRentalStartDate.Value = DateTime.Now;
            // Kiralama bitiş tarihini mevcut zamandan bir gün sonrasına ayarlar.
            _rentalsControl.dtpRentalEndDate.Value = DateTime.Now.AddDays(1);
            // Kiralama ödeme tipini "Cash" olarak ayarlar.
            _rentalsControl.txtBoxRentalPaymentType.Text = "Cash";
        }
    }
}