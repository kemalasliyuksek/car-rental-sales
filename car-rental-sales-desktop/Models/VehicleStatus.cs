using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class VehicleStatus
    {
        public int VehicleStatusID { get; set; }
        public string VehicleStatusName { get; set; }
        public string VehicleStatusDescription { get; set; }
        public DateTime VehicleStatusCreatedAt { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public VehicleStatus()
        {
            Vehicles = new HashSet<Vehicle>();
            VehicleStatusName = "Available";
            VehicleStatusCreatedAt = DateTime.Now;
        }
    }
}