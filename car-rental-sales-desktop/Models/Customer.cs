using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerNationalID { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }
        public string CustomerLicenseNumber { get; set; }
        public string CustomerLicenseClass { get; set; }
        public DateTime? CustomerLicenseDate { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CustomerRegistrationDate { get; set; }
        public bool CustomerAvailable { get; set; }
        public string CustomerType { get; set; }
        public DateTime? CustomerUpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public Customer()
        {
            Rentals = new HashSet<Rental>();
            Sales = new HashSet<Sale>();
            Payments = new HashSet<Payment>();
            CustomerRegistrationDate = DateTime.Now;
            CustomerAvailable = true;
            CustomerType = "Individual";
        }

        // Helper property to get full name
        public string FullName
        {
            get { return $"{CustomerFirstName} {CustomerLastName}"; }
        }
    }
}