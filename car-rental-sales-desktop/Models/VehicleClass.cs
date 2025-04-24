using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class VehicleClass
    {
        public int VehicleClassID { get; set; }
        public string VehicleClassName { get; set; }
        public string VehicleClassDescription { get; set; }
        public DateTime VehicleClassCreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<RentalPrice> RentalPrices { get; set; }

        public VehicleClass()
        {
            Vehicles = new HashSet<Vehicle>();
            RentalPrices = new HashSet<RentalPrice>();
            VehicleClassCreatedAt = DateTime.Now;
        }
    }
}