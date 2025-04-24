using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractCreatedAt { get; set; }
        public string ContractText { get; set; }
        public string ContractFilePath { get; set; }

        // Navigation properties
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

        public Contract()
        {
            Rentals = new HashSet<Rental>();
            Sales = new HashSet<Sale>();
            ContractCreatedAt = DateTime.Now;
        }
    }
}