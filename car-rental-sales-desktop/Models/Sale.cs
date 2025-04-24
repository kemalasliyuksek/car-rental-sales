using System;

namespace car_rental_sales_desktop.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int SaleCustomerID { get; set; }
        public int SaleVehicleID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleAmount { get; set; }
        public string SalePaymentType { get; set; }
        public int SaleInstallmentCount { get; set; }
        public DateTime? SaleNotaryDate { get; set; }
        public int? SaleContractID { get; set; }
        public int SaleUserID { get; set; }
        public DateTime SaleCreatedAt { get; set; }
        public DateTime? SaleUpdatedAt { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual User User { get; set; }

        public Sale()
        {
            SaleInstallmentCount = 0;
            SaleCreatedAt = DateTime.Now;
        }
    }
}