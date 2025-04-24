using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Bank
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string BankDescription { get; set; }

        // Navigation properties
        public virtual ICollection<Payment> Payments { get; set; }

        public Bank()
        {
            Payments = new HashSet<Payment>();
        }
    }
}