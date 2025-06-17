using System;

namespace car_rental_sales_desktop.Models
{
    public enum RentalType
    {
        Hourly,
        Daily,
        Weekly,
        Monthly
    }

    public class RentalPrice
    {
        public int RentalPriceID { get; set; }
        public int VehicleClassID { get; set; }
        public RentalType RentalType { get; set; }
        public decimal RentPrice { get; set; }
        public DateTime RentalPriceCreatedAt { get; set; }

        public virtual VehicleClass VehicleClass { get; set; }

        public RentalPrice()
        {
            RentalPriceCreatedAt = DateTime.Now;
        }
    }
}