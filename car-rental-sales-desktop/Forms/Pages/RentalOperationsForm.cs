using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;
using car_rental_sales_desktop.Utils;

namespace car_rental_sales_desktop.Forms
{
    // Kiralama işlemleri formunu temsil eden sınıf
    public partial class RentalOperationsForm : Form
    {
        // Kiralama ID'sini tutan özel bir değişken
        private int _rentalId;
        // Kiralama nesnesini tutan özel bir değişken
        private Rental _rental;
        // Kiralama veritabanı işlemlerini yöneten depo nesnesi
        private RentalRepository _rentalRepository;
        // Müşteri veritabanı işlemlerini yöneten depo nesnesi
        private CustomerRepository _customerRepository;
        // Araç veritabanı işlemlerini yöneten depo nesnesi
        private VehicleRepository _vehicleRepository;
        // Gecikme ücretini tutan özel bir değişken
        private decimal _lateFee = 0;
        // Toplam tutarı tutan özel bir değişken
        private decimal _totalAmount = 0;

        // Formun yapıcı metodu, kiralama ID'si parametre olarak alınır
        public RentalOperationsForm(int rentalId)
        {
            // Form bileşenlerini başlatan metod (Otomatik oluşturulur)
            InitializeComponent();

            // Parametre olarak gelen kiralama ID'sini sınıf değişkenine ata
            _rentalId = rentalId;
            // Kiralama deposu nesnesini oluştur
            _rentalRepository = new RentalRepository();
            // Müşteri deposu nesnesini oluştur
            _customerRepository = new CustomerRepository();
            // Araç deposu nesnesini oluştur
            _vehicleRepository = new VehicleRepository();

            // Form yüklendiğinde çalışacak olayı (RentalOperationsForm_Load metodu) ata
            this.Load += RentalOperationsForm_Load;
            // İade tarihi değiştirildiğinde çalışacak olayı (DtpReturnDate_ValueChanged metodu) ata
            dtpReturnDate.ValueChanged += DtpReturnDate_ValueChanged;
            // İade kilometre değeri değiştirildiğinde çalışacak olayı (NumReturnMileage_ValueChanged metodu) ata
            numReturnMileage.ValueChanged += NumReturnMileage_ValueChanged;
            // İadeyi tamamla butonuna tıklandığında çalışacak olayı (BtnCompleteReturn_Click metodu) ata
            btnCompleteReturn.Click += BtnCompleteReturn_Click;

            // İptal butonuna tıklandığında çalışacak olayı (BtnCancel_Click metodu) ata
            btnCancel.Click += BtnCancel_Click;

            // Formun ESC tuşuna basıldığında iptal butonu gibi davranmasını sağla
            this.CancelButton = btnCancel;
        }

        // Form yüklendiğinde çalışan metod
        private void RentalOperationsForm_Load(object sender, EventArgs e)
        {
            // Kiralama detaylarını yükleyen metodu çağır
            LoadRentalDetails();
        }

        // Kiralama detaylarını yükleyen metod
        private void LoadRentalDetails()
        {
            try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır
            {
                // Veritabanından kiralama ID'sine göre kiralama bilgilerini getir
                _rental = _rentalRepository.GetById(_rentalId);

                // Eğer kiralama bilgisi bulunamazsa
                if (_rental == null)
                {
                    // Kullanıcıya hata mesajı göster
                    MessageBox.Show("Rental information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Formu kapat
                    this.Close();
                    // Metodun devam etmesini engelle
                    return;
                }

                // Eğer kiralama nesnesinde müşteri bilgisi yoksa ve müşteri ID'si varsa
                if (_rental.Customer == null && _rental.RentalCustomerID > 0)
                {
                    // Müşteri ID'sine göre müşteri bilgisini veritabanından getir ve kiralama nesnesine ata
                    _rental.Customer = _customerRepository.GetById(_rental.RentalCustomerID);
                }

                // Eğer kiralama nesnesinde araç bilgisi yoksa ve araç ID'si varsa
                if (_rental.Vehicle == null && _rental.RentalVehicleID > 0)
                {
                    // Araç ID'sine göre araç bilgisini veritabanından getir ve kiralama nesnesine ata
                    _rental.Vehicle = _vehicleRepository.GetById(_rental.RentalVehicleID);
                }

                // Formdaki ilgili etiketlere kiralama bilgilerini yazdır
                lblRentalID.Text = _rental.RentalID.ToString(); // Kiralama ID'si
                lblCustomerName.Text = _rental.Customer?.FullName ?? "Unknown Customer"; // Müşteri adı (Null ise "Bilinmeyen Müşteri" yaz)
                lblVehicleInfo.Text = _rental.Vehicle?.VehiclePlateNumber ?? "Unknown Vehicle"; // Araç plakası (Null ise "Bilinmeyen Araç" yaz)
                lblStartDate.Text = _rental.RentalStartDate.ToString("dd.MM.yyyy"); // Kiralama başlangıç tarihi
                lblEndDate.Text = _rental.RentalEndDate.ToString("dd.MM.yyyy"); // Kiralama bitiş tarihi
                lblStartMileage.Text = _rental.RentalStartKm.ToString() + " KM"; // Başlangıç kilometresi
                lblAmount.Text = _rental.RentalAmount.ToString("N2") + " ₺"; // Kiralama tutarı

                // İade tarihi seçicisinin varsayılan değerini bugünün tarihi yap
                dtpReturnDate.Value = DateTime.Now;
                // İade kilometre değerini, başlangıç kilometresi olarak ayarla
                numReturnMileage.Value = _rental.RentalStartKm;
                // İade kilometre değerinin minimum değerini, başlangıç kilometresi olarak ayarla (daha düşük olamaz)
                numReturnMileage.Minimum = _rental.RentalStartKm;

                // Eğer kiralama ID'si geçerliyse (0'dan büyükse)
                if (_rental.RentalID > 0)
                {
                    // Kiralama notlarını veritabanından getir
                    List<RentalNote> notes = _rentalRepository.GetNotes(_rental.RentalID);
                    // Eğer notlar varsa ve sayısı 0'dan fazlaysa
                    if (notes != null && notes.Count > 0)
                    {
                        // İlk notu kiralama notu metin kutusuna yaz
                        txtRentalNote.Text = notes[0].RentalNoteText;

                        // Eğer birden fazla not varsa
                        if (notes.Count > 1)
                        {
                            // Önceki notları belirtmek için bir başlık ekle
                            txtRentalNote.Text += Environment.NewLine + Environment.NewLine + "Previous notes:";
                            // Diğer notları döngü ile metin kutusuna ekle
                            for (int i = 1; i < notes.Count; i++)
                            {
                                txtRentalNote.Text += Environment.NewLine +
                                    $"[{notes[i].RentalNoteCreatedAt:dd.MM.yyyy HH:mm}] {notes[i].RentalNoteText}"; // Notun tarihi ve metni
                            }
                        }
                    }
                }

                // Eğer kiralama iade tarihi doluysa (yani araç iade edilmişse)
                if (_rental.RentalReturnDate.HasValue)
                {
                    // Durum etiketini "Bu kiralama zaten iade edilmiş." olarak ayarla
                    lblStatus.Text = "This rental has already been returned.";
                    // Durum etiketinin yazı rengini mavi yap
                    lblStatus.ForeColor = Color.Blue;

                    // İade tarihi ve kilometre giriş alanlarını devre dışı bırak
                    dtpReturnDate.Enabled = false;
                    numReturnMileage.Enabled = false;
                    // İadeyi tamamla butonunu devre dışı bırak
                    btnCompleteReturn.Enabled = false;

                    // İadeyi tamamla butonunun metnini "Notu Kaydet" olarak değiştir
                    btnCompleteReturn.Text = "Save Note";
                    // İadeyi tamamla butonunu tekrar aktif et (sadece not kaydetmek için)
                    btnCompleteReturn.Enabled = true;
                    // Butonun arka plan rengini değiştir
                    btnCompleteReturn.BackColor = System.Drawing.Color.DodgerBlue;

                    // İade tarihi ve kilometre bilgilerini ilgili etiketlere yaz
                    lblReturnDateInfo.Text = _rental.RentalReturnDate.Value.ToString("dd.MM.yyyy");
                    lblReturnMileageInfo.Text = _rental.RentalEndKm.ToString() + " KM";

                    // İade tarihi seçicisinin değerini, kaydedilmiş iade tarihi yap
                    dtpReturnDate.Value = _rental.RentalReturnDate.Value;

                    // Eğer iade kilometresi doluysa
                    if (_rental.RentalEndKm.HasValue)
                    {
                        // İade kilometre giriş alanının değerini, kaydedilmiş iade kilometresi yap
                        numReturnMileage.Value = _rental.RentalEndKm.Value;
                        // Kullanılan kilometre farkını hesapla
                        int mileageDifference = _rental.RentalEndKm.Value - _rental.RentalStartKm;
                        // Kilometre bilgi etiketini güncelle
                        lblMileageInfo.Text = $"Distance used: {mileageDifference} KM";
                    }
                    else
                    {
                        // Kilometre bilgi etiketini "Kullanılan mesafe: 0 KM" olarak ayarla
                        lblMileageInfo.Text = "Distance used: 0 KM";
                    }

                    // İade detaylarını hesapla (gecikme ücreti vb.)
                    CalculateReturnDetails();
                }
                else // Eğer araç henüz iade edilmemişse
                {
                    // Durum etiketini "Bu kiralama aktif ve iade edilebilir." olarak ayarla
                    lblStatus.Text = "This rental is active and can be returned.";
                    // Durum etiketinin yazı rengini yeşil yap
                    lblStatus.ForeColor = Color.Green;

                    // İade detaylarını hesapla
                    CalculateReturnDetails();
                }
            }
            catch (Exception ex) // Hata yakalanırsa
            {
                // Kullanıcıya hata mesajı göster
                MessageBox.Show($"Error loading rental details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İade detaylarını (gecikme ücreti, toplam tutar vb.) hesaplayan metod
        private void CalculateReturnDetails()
        {
            try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır
            {
                // Formdaki iade tarihi seçicisinden iade tarihini al
                DateTime returnDate = dtpReturnDate.Value;
                // Formdaki iade kilometre girişinden iade kilometresini al
                int returnMileage = (int)numReturnMileage.Value;

                // Gecikme ücretini sıfırla
                _lateFee = 0;
                // Eğer iade tarihi, kiralama bitiş tarihinden sonraysa (araç geç iade edildiyse)
                if (returnDate > _rental.RentalEndDate)
                {
                    // Gecikme gün sayısını hesapla (sadece tarih kısmını dikkate alarak)
                    int lateDays = (returnDate.Date - _rental.RentalEndDate.Date).Days;

                    // Toplam kiralama gün sayısını hesapla
                    int rentalDays = (_rental.RentalEndDate.Date - _rental.RentalStartDate.Date).Days + 1;
                    // Günlük kiralama ücretini hesapla
                    decimal dailyRate = _rental.RentalAmount / rentalDays;

                    // Gecikme ücretini hesapla (günlük ücret * gecikme günü * 1.5 katsayısı)
                    _lateFee = lateDays * dailyRate * 1.5m;

                    // Gecikme ücreti etiketini güncelle
                    lblLateFee.Text = _lateFee.ToString("N2") + " ₺";
                    // Gecikme gün sayısı etiketini güncelle
                    lblLateDays.Text = lateDays.ToString() + " days late";
                    // Gecikme ücreti panelini görünür yap
                    pnlLateFee.Visible = true;
                }
                else // Araç zamanında veya erken iade edildiyse
                {
                    // Gecikme ücreti etiketini "0.00 ₺" olarak ayarla
                    lblLateFee.Text = "0.00 ₺";
                    // Gecikme gün sayısı etiketini "0 gün (zamanında)" olarak ayarla
                    lblLateDays.Text = "0 days (on time)";
                    // Gecikme ücreti panelini gizle
                    pnlLateFee.Visible = false;
                }

                // Toplam tutarı hesapla (kiralama tutarı + gecikme ücreti)
                _totalAmount = _rental.RentalAmount + _lateFee;
                // Toplam tutar etiketini güncelle
                lblTotalAmount.Text = _totalAmount.ToString("N2") + " ₺";

                // Kullanılan kilometre farkını hesapla
                int mileageDifference = returnMileage - _rental.RentalStartKm;
                // Kilometre bilgi etiketini güncelle
                lblMileageInfo.Text = $"Distance used: {mileageDifference} KM";
            }
            catch (Exception ex) // Hata yakalanırsa
            {
                // Kullanıcıya hata mesajı göster
                MessageBox.Show($"Error calculating return details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İade tarihi seçicisinin değeri değiştiğinde çalışan metod
        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            // İade detaylarını yeniden hesapla
            CalculateReturnDetails();
        }

        // İade kilometre girişinin değeri değiştiğinde çalışan metod
        private void NumReturnMileage_ValueChanged(object sender, EventArgs e)
        {
            // İade detaylarını yeniden hesapla
            CalculateReturnDetails();
        }

        // "İadeyi Tamamla" veya "Notu Kaydet" butonuna tıklandığında çalışan metod
        private void BtnCompleteReturn_Click(object sender, EventArgs e)
        {
            try // Hata oluşma ihtimaline karşı try-catch bloğu kullanılır
            {
                // Eğer kiralama zaten iade edilmişse (yani buton "Notu Kaydet" modundaysa)
                if (_rental.RentalReturnDate.HasValue)
                {
                    // Kiralama notu metin kutusundaki metni al (başındaki ve sonundaki boşlukları silerek)
                    string noteText = txtRentalNote.Text.Trim();
                    // Eğer not metni boş değilse
                    if (!string.IsNullOrEmpty(noteText))
                    {
                        // Notu veritabanına ekle
                        bool noteSuccess = _rentalRepository.AddNote(_rental.RentalID, noteText, CurrentUser.UserID);

                        // Eğer not ekleme başarılıysa
                        if (noteSuccess)
                        {
                            // Kullanıcıya başarı mesajı göster
                            MessageBox.Show(
                                "Note successfully added to rental.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Formun kapanma sonucunu OK olarak ayarla (işlem başarılı)
                            this.DialogResult = DialogResult.OK;
                        }
                        else // Not ekleme başarısızsa
                        {
                            // Kullanıcıya hata mesajı göster
                            MessageBox.Show(
                                "An error occurred while saving the note.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else // Not metni boşsa
                    {
                        // Kullanıcıya uyarı mesajı göster
                        MessageBox.Show(
                            "Please enter a note or click cancel.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    // Metodun devam etmesini engelle (iade işlemi yapılmayacak)
                    return;
                }

                // Araç iade edilmemişse, kullanıcıya iade işlemini onaylamasını sor
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to complete the return for this rental?",
                    "Confirm Return",
                    MessageBoxButtons.YesNo, // Evet ve Hayır butonları
                    MessageBoxIcon.Question); // Soru ikonu

                // Eğer kullanıcı "Hayır" derse
                if (result == DialogResult.No)
                    // Metoddan çık (işlemi iptal et)
                    return;

                // Formdaki iade tarihi seçicisinden iade tarihini al
                DateTime returnDate = dtpReturnDate.Value;
                // Formdaki iade kilometre girişinden iade kilometresini al
                int returnMileage = (int)numReturnMileage.Value;

                // Kiralama iade işlemini veritabanında gerçekleştir
                bool success = _rentalRepository.ProcessReturn(_rental.RentalID, returnDate, returnMileage);

                // Eğer iade işlemi başarılıysa
                if (success)
                {
                    // Eğer gecikme ücreti varsa
                    if (_lateFee > 0)
                    {
                        // Gecikme ücreti için bir ödeme nesnesi oluştur
                        Payment lateFeePayment = new Payment
                        {
                            PaymentTransactionType = "Rental", // Ödeme işlem tipi: Kiralama
                            PaymentTransactionID = _rental.RentalID, // İlgili kiralama ID'si
                            PaymentCustomerID = _rental.RentalCustomerID, // Müşteri ID'si
                            PaymentAmount = _lateFee, // Ödeme tutarı (gecikme ücreti)
                            PaymentDate = returnDate, // Ödeme tarihi (iade tarihi)
                            PaymentType = "Late Fee", // Ödeme tipi: Gecikme Ücreti
                            PaymentNote = $"Late fee for Rental ID {_rental.RentalID}", // Ödeme notu
                            PaymentUserID = CurrentUser.UserID // İşlemi yapan kullanıcı ID'si
                        };

                        // Ödeme deposu nesnesini oluştur
                        var paymentRepository = new PaymentRepository();
                        // Gecikme ücreti ödemesini veritabanına ekle
                        paymentRepository.Insert(lateFeePayment);
                    }

                    // Kiralama notu metin kutusundaki metni al
                    string noteText = txtRentalNote.Text.Trim();
                    // Eğer not metni boş değilse
                    if (!string.IsNullOrEmpty(noteText))
                    {
                        // Notu veritabanına ekle
                        _rentalRepository.AddNote(_rental.RentalID, noteText, CurrentUser.UserID);
                    }

                    // Kullanıcıya başarı mesajı göster
                    MessageBox.Show(
                        "Rental return processed successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Formun kapanma sonucunu OK olarak ayarla (işlem başarılı)
                    this.DialogResult = DialogResult.OK;
                }
                else // İade işlemi başarısızsa
                {
                    // Kullanıcıya hata mesajı göster
                    MessageBox.Show(
                        "An error occurred while processing the rental return.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // Hata yakalanırsa
            {
                // Kullanıcıya genel bir hata mesajı göster
                MessageBox.Show($"An error occurred during the operation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // İptal butonuna tıklandığında çalışan metod
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Formun kapanma sonucunu Cancel olarak ayarla (işlem iptal edildi)
            this.DialogResult = DialogResult.Cancel;
        }
    }
}