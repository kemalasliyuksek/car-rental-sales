using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace car_rental_sales_desktop.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int UserRoleID { get; set; }
        public int? UserBranchID { get; set; }
        public DateTime? UserLastLogin { get; set; }
        public bool UserActive { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public DateTime? UserUpdatedAt { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<RentalNote> RentalNotes { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Service> ServicesAuthorized { get; set; }

        public User()
        {
            Rentals = new HashSet<Rental>();
            Sales = new HashSet<Sale>();
            Payments = new HashSet<Payment>();
            RentalNotes = new HashSet<RentalNote>();
            Maintenances = new HashSet<Maintenance>();
            Documents = new HashSet<Document>();
            ServicesAuthorized = new HashSet<Service>();
            UserActive = true;
            UserCreatedAt = DateTime.Now;
        }

        // Helper property to get full name
        public string FullName
        {
            get { return $"{UserFirstName} {UserLastName}"; }
        }
    }
}