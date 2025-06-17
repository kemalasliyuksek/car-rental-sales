using System;

namespace car_rental_sales_desktop.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string PaymentTransactionType { get; set; } 
        public int PaymentTransactionID { get; set; }
        public int PaymentCustomerID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public int? PaymentBankID { get; set; }
        public string PaymentNote { get; set; }
        public int PaymentUserID { get; set; }
        public DateTime PaymentCreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual User User { get; set; }

        public Payment()
        {
            PaymentCreatedAt = DateTime.Now;
        }
    }
}