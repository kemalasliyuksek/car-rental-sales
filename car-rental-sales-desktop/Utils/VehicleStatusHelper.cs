using System;
using System.Drawing;

namespace car_rental_sales_desktop.Utils
{
    // Araç durumlarıyla ilgili yardımcı metotları ve sabitleri içeren statik bir sınıftır.
    public static class VehicleStatusHelper
    {
        // Araç durumlarını temsil eden sabit (değiştirilemez) tam sayı değerleri.
        public const int Available = 1; // Araç müsait durumda.
        public const int ForSale = 2; // Araç satılık durumda.
        public const int Sold = 3; // Araç satılmış durumda.
        public const int ForRent = 4; // Araç kiralanabilir durumda.
        public const int Rented = 5; // Araç kiralanmış durumda.
        public const int Reserved = 6; // Araç rezerve edilmiş durumda.
        public const int ReservationExpired = 7; // Aracın rezervasyon süresi dolmuş.
        public const int Service = 8; // Araç serviste.
        public const int Faulty = 9; // Araç arızalı.
        public const int Maintenance = 10; // Araç bakımda.

        // Belirtilen durum ID'sinin, aracın kiralanabilir olup olmadığını kontrol eder.
        // statusId: Kontrol edilecek araç durum ID'si.
        // Geriye, araç kiralanabilirse true, değilse false döner.
        public static bool IsAvailableForRent(int statusId)
        {
            // Durum ID'si 'Available' (Müsait) veya 'ForRent' (Kiralanabilir) ise araç kiralanabilir demektir.
            return statusId == Available || statusId == ForRent;
        }

        // Belirtilen durum ID'sine karşılık gelen durum adını Türkçe olarak döndürür.
        // statusId: Durum adı alınacak araç durum ID'si.
        // Geriye, durum ID'sine karşılık gelen Türkçe durumu string olarak döner. Bilinmeyen bir ID için "Bilinmiyor" döner.
        public static string GetStatusName(int statusId)
        {
            switch (statusId) // Durum ID'sine göre seçim yapılır.
            {
                case Available: return "Müsait"; // Durum 1 ise "Müsait"
                case ForSale: return "Satılık"; // Durum 2 ise "Satılık"
                case Sold: return "Satıldı"; // Durum 3 ise "Satıldı"
                case ForRent: return "Kiralanabilir"; // Durum 4 ise "Kiralanabilir"
                case Rented: return "Kirada"; // Durum 5 ise "Kirada"
                case Reserved: return "Rezerve"; // Durum 6 ise "Rezerve"
                case ReservationExpired: return "Rezervasyon Süresi Doldu"; // Durum 7 ise "Rezervasyon Süresi Doldu"
                case Service: return "Serviste"; // Durum 8 ise "Serviste"
                case Faulty: return "Arızalı"; // Durum 9 ise "Arızalı"
                case Maintenance: return "Bakımda"; // Durum 10 ise "Bakımda"
                default: return "Bilinmiyor"; // Yukarıdaki durumların hiçbiri değilse "Bilinmiyor"
            }
        }

        // Belirtilen durum ID'sine karşılık gelen bir renk döndürür. Bu renk, kullanıcı arayüzünde durumları görsel olarak ayırt etmek için kullanılabilir.
        // statusId: Renk alınacak araç durum ID'si.
        // Geriye, durum ID'sine karşılık gelen System.Drawing.Color nesnesini döner. Bilinmeyen bir ID için varsayılan olarak beyaz renk döner.
        public static System.Drawing.Color GetStatusColor(int statusId)
        {
            switch (statusId) // Durum ID'sine göre seçim yapılır.
            {
                case Available: // Durum "Müsait" ise
                case ForRent:   // veya "Kiralanabilir" ise
                    return System.Drawing.Color.LightGreen; // Açık Yeşil renk döndür.
                case Rented:    // Durum "Kirada" ise
                case Reserved:  // veya "Rezerve" ise
                    return System.Drawing.Color.LightCoral; // Açık Koral renk döndür.
                case Maintenance: // Durum "Bakımda" ise
                case Service:     // veya "Serviste" ise
                    return System.Drawing.Color.LightYellow; // Açık Sarı renk döndür.
                case Faulty: // Durum "Arızalı" ise
                    return System.Drawing.Color.LightPink; // Açık Pembe renk döndür.
                case ForSale: // Durum "Satılık" ise
                    return System.Drawing.Color.LightBlue; // Açık Mavi renk döndür.
                case Sold: // Durum "Satıldı" ise
                    return System.Drawing.Color.LightGray; // Açık Gri renk döndür.
                default: // Yukarıdaki durumların hiçbiri değilse
                    return System.Drawing.Color.White; // Beyaz renk döndür.
            }
        }
    }
}