using System;

namespace car_rental_sales_desktop.Models
{
    public class Maintenance
    {
        public int MaintenanceID { get; set; }
        public int MaintenanceVehicleID { get; set; }
        public DateTime MaintenanceStartDate { get; set; }
        public DateTime? MaintenanceEndDate { get; set; }
        public string MaintenanceType { get; set; }
        public string MaintenanceNote { get; set; }
        public decimal MaintenanceCost { get; set; }
        public int? MaintenanceServiceID { get; set; }
        public int MaintenanceUserID { get; set; }
        public DateTime MaintenanceCreatedAt { get; set; }
        public DateTime? MaintenanceUpdatedAt { get; set; }

        // Navigation properties
        public virtual Vehicle Vehicle { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }

        public Maintenance()
        {
            MaintenanceCreatedAt = DateTime.Now;
        }
    }
}