using System;

namespace car_rental_sales_desktop.Utils
{
    public static class VehicleStatusHelper
    {
        public const int Available = 1;
        public const int ForSale = 2;
        public const int Sold = 3;
        public const int ForRent = 4;
        public const int Rented = 5;
        public const int Reserved = 6;
        public const int ReservationExpired = 7;
        public const int Service = 8;
        public const int Faulty = 9;
        public const int Maintenance = 10;

        public static bool IsAvailableForRent(int statusId)
        {
            return statusId == Available || statusId == ForRent;
        }

        public static string GetStatusName(int statusId)
        {
            switch (statusId)
            {
                case Available: return "Müsait";
                case ForSale: return "Satılık";
                case Sold: return "Satıldı";
                case ForRent: return "Kiralanabilir";
                case Rented: return "Kirada";
                case Reserved: return "Rezerve";
                case ReservationExpired: return "Rezervasyon Süresi Doldu";
                case Service: return "Serviste";
                case Faulty: return "Arızalı";
                case Maintenance: return "Bakımda";
                default: return "Bilinmiyor";
            }
        }

        public static System.Drawing.Color GetStatusColor(int statusId)
        {
            switch (statusId)
            {
                case Available:
                case ForRent:
                    return System.Drawing.Color.LightGreen;
                case Rented:
                case Reserved:
                    return System.Drawing.Color.LightCoral;
                case Maintenance:
                case Service:
                    return System.Drawing.Color.LightYellow;
                case Faulty:
                    return System.Drawing.Color.LightPink;
                case ForSale:
                    return System.Drawing.Color.LightBlue;
                case Sold:
                    return System.Drawing.Color.LightGray;
                default:
                    return System.Drawing.Color.White;
            }
        }
    }
}