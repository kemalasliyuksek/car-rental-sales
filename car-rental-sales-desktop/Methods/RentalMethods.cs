using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Methods
{
    public static class RentalMethods
    {
        // Kiralama durumlarını tanımlar: Aktif, Zamanında Tamamlandı, Geç Tamamlandı, Süresi Geçmiş.
        public enum RentalStatus
        {
            Active,
            CompletedOnTime,
            CompletedLate,
            Overdue
        }

        // Bir kiralama işleminin mevcut durumunu döndürür.
        public static RentalStatus GetRentalStatus(Rental rental)
        {
            DateTime today = DateTime.Today; // Bugünün tarihini alır.

            // Kiralama iade tarihi girilmemişse (yani kiralama hala devam ediyorsa)
            if (!rental.RentalReturnDate.HasValue)
            {
                // Kiralama bitiş tarihi bugünden önceyse, kiralama süresi geçmiş demektir.
                if (rental.RentalEndDate.Date < today)
                {
                    return RentalStatus.Overdue;
                }
                // Aksi halde kiralama aktif durumdadır.
                return RentalStatus.Active;
            }

            // Kiralama iade tarihi girilmişse (yani kiralama tamamlanmışsa)
            // İade tarihi, planlanan bitiş tarihinden önce veya aynı gün ise zamanında tamamlanmıştır.
            if (rental.RentalReturnDate.Value.Date <= rental.RentalEndDate.Date)
            {
                return RentalStatus.CompletedOnTime;
            }
            else // İade tarihi, planlanan bitiş tarihinden sonra ise geç tamamlanmıştır.
            {
                return RentalStatus.CompletedLate;
            }
        }

        // Kiralama durumuna göre bir arka plan rengi döndürür.
        public static Color GetStatusColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.LightBlue; // Aktif kiralama için açık mavi.
                case RentalStatus.CompletedOnTime:
                    return Color.LightGreen; // Zamanında tamamlanan kiralama için açık yeşil.
                case RentalStatus.CompletedLate:
                    return Color.Orange; // Geç tamamlanan kiralama için turuncu.
                case RentalStatus.Overdue:
                    return Color.Crimson; // Süresi geçmiş kiralama için koyu kırmızı.
                default:
                    return Color.White; // Tanımsız durum için beyaz.
            }
        }

        // Kiralama durumuna göre bir açıklama metni döndürür.
        public static string GetStatusDescription(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return "Aktif Kiralama";
                case RentalStatus.CompletedOnTime:
                    return "Zamanında Tamamlandı";
                case RentalStatus.CompletedLate:
                    return "Geç Tamamlandı (Cezalı)";
                case RentalStatus.Overdue:
                    return "Süresi Geçmiş";
                default:
                    return "Belirsiz";
            }
        }

        // Kiralama durumuna göre bir metin rengi döndürür.
        public static Color GetStatusTextColor(RentalStatus status)
        {
            switch (status)
            {
                case RentalStatus.Active:
                    return Color.Blue; // Aktif kiralama metni için mavi.
                case RentalStatus.CompletedOnTime:
                    return Color.Green; // Zamanında tamamlanan kiralama metni için yeşil.
                case RentalStatus.CompletedLate:
                    return Color.OrangeRed; // Geç tamamlanan kiralama metni için turuncu-kırmızı.
                case RentalStatus.Overdue:
                    return Color.Red; // Süresi geçmiş kiralama metni için kırmızı.
                default:
                    return Color.Black; // Tanımsız durum metni için siyah.
            }
        }

        // Verilen tam ad (ad ve soyad) ile müşteri listesinde müşteri arar.
        public static Customer FindCustomerByFullName(string fullName, List<Customer> customers)
        {
            // Tam ad boşsa veya müşteri listesi boşsa null döndürür.
            if (string.IsNullOrWhiteSpace(fullName) || customers == null)
                return null;

            // Tam adı boşluklara göre ayırarak ad ve soyad kısımlarını elde eder.
            string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Ad ve soyad en az iki kısımdan oluşmuyorsa null döndürür.
            if (nameParts.Length < 2)
                return null;

            string firstName = nameParts[0]; // İlk kısım ad.
            string lastName = string.Join(" ", nameParts, 1, nameParts.Length - 1); // Geri kalan kısımlar soyad.

            // Müşteri listesinde, ad ve soyadı (büyük/küçük harf duyarsız) eşleşen ilk müşteriyi bulur.
            return customers.Find(c =>
                c.CustomerFirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.CustomerLastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        // Belirli bir müşterinin aktif kiralamalarını kontrol eder ve araç bilgilerini yükler.
        public static List<Rental> CheckCustomerActiveRentals(int customerId, RentalRepository rentalRepository, VehicleRepository vehicleRepository)
        {
            try
            {
                // Tüm aktif kiralamaları alır.
                var activeRentals = rentalRepository.GetActiveRentals();
                // Belirli müşteriye ait aktif kiralamaları filtreler.
                var customerActiveRentals = activeRentals.Where(r => r.RentalCustomerID == customerId).ToList();

                // Müşterinin aktif kiralamalarındaki araç bilgilerini yükler.
                foreach (var rental in customerActiveRentals)
                {
                    // Eğer kiralama nesnesinde araç bilgisi yoksa ve araç ID'si varsa,
                    // araç deposundan araç bilgisini getirir ve kiralama nesnesine atar.
                    if (rental.Vehicle == null && rental.RentalVehicleID > 0)
                    {
                        rental.Vehicle = vehicleRepository.GetById(rental.RentalVehicleID);
                    }
                }
                return customerActiveRentals; // Müşterinin aktif kiralamalarını döndürür.
            }
            catch (Exception ex)
            {
                // Hata oluşursa, hata mesajını konsola yazar ve boş bir liste döndürür.
                System.Diagnostics.Debug.WriteLine($"Error in CheckCustomerActiveRentals: {ex.Message}");
                return new List<Rental>();
            }
        }

        // Verilen plaka numarası ile araç listesinde araç arar.
        public static Vehicle FindVehicleByPlate(string plateNumber, List<Vehicle> vehicles)
        {
            // Plaka numarası boşsa veya araç listesi boşsa null döndürür.
            if (string.IsNullOrWhiteSpace(plateNumber) || vehicles == null)
                return null;

            // Araç listesinde, plaka numarası (büyük/küçük harf duyarsız) eşleşen ilk aracı bulur.
            return vehicles.Find(v =>
                v.VehiclePlateNumber.Equals(plateNumber, StringComparison.OrdinalIgnoreCase));
        }

        // Bir aracın kiralanabilir durumda olup olmadığını kontrol eder.
        public static bool IsVehicleAvailableForRental(Vehicle vehicle, RentalRepository rentalRepository)
        {
            try
            {
                // Araç nesnesi boşsa, araç kiralanamaz.
                if (vehicle == null) return false;

                // Araç durumu "Müsait" (1) veya "Bakımdan Döndü" (4) değilse, araç kiralanamaz.
                // Bu durum ID'leri varsayımsaldır ve sistemdeki tanımlara göre değişebilir.
                if (vehicle.VehicleStatusID != 1 && vehicle.VehicleStatusID != 4)
                {
                    return false;
                }

                // Tüm aktif kiralamaları alır.
                var activeRentals = rentalRepository.GetActiveRentals();
                // Aracın şu anda başka bir aktif kiralamada olup olmadığını kontrol eder.
                bool isCurrentlyRented = activeRentals.Any(r => r.RentalVehicleID == vehicle.VehicleID);

                // Araç başka bir kiralamada değilse kiralanabilir durumdadır.
                return !isCurrentlyRented;
            }
            catch (Exception ex)
            {
                // Hata oluşursa, hata mesajını konsola yazar ve aracın kiralanamaz olduğunu belirtir.
                System.Diagnostics.Debug.WriteLine($"Error in IsVehicleAvailableForRental: {ex.Message}");
                return false;
            }
        }
    }
}