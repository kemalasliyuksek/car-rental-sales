using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int RentalCustomerID { get; set; }
        public int RentalVehicleID { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public DateTime? RentalReturnDate { get; set; }
        public int RentalStartKm { get; set; }
        public int? RentalEndKm { get; set; }
        public decimal RentalAmount { get; set; }
        public decimal? RentalDepositAmount { get; set; }
        public string RentalPaymentType { get; set; }
        public int? RentalNoteID { get; set; }
        public int? RentalContractID { get; set; }
        public int RentalUserID { get; set; }
        public DateTime RentalCreatedAt { get; set; }
        public DateTime? RentalUpdatedAt { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual RentalNote Note { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<RentalNote> RentalNotes { get; set; }

        public Rental()
        {
            RentalNotes = new HashSet<RentalNote>();
            RentalCreatedAt = DateTime.Now;
        }

        // Helper method to calculate rental duration in days
        public int CalculateDurationInDays()
        {
            return (RentalEndDate - RentalStartDate).Days + 1;
        }
    }
}