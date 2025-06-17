using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public string VehicleEngineNumber { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleColor { get; set; }
        public int VehicleMileage { get; set; }
        public string VehicleFuelType { get; set; }
        public string VehicleTransmissionType { get; set; }
        public int VehicleStatusID { get; set; }
        public DateTime? VehicleAcquisitionDate { get; set; }
        public decimal? VehiclePurchasePrice { get; set; }
        public decimal? VehicleSalePrice { get; set; }
        public int? VehicleBranchID { get; set; }
        public int? VehicleClassID { get; set; }
        public DateTime VehicleCreatedAt { get; set; }
        public DateTime? VehicleUpdatedAt { get; set; }

        public virtual VehicleStatus VehicleStatus { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual VehicleClass VehicleClass { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        public Vehicle()
        {
            Rentals = new HashSet<Rental>();
            Maintenances = new HashSet<Maintenance>();
            VehicleMileage = 0;
            VehicleCreatedAt = DateTime.Now;
        }
    }
}