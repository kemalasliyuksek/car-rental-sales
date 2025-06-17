using System;

namespace car_rental_sales_desktop.Models
{
    public class RentalNote
    {
        public int RentalNoteID { get; set; }
        public int RentalID { get; set; }
        public string RentalNoteText { get; set; }
        public DateTime RentalNoteCreatedAt { get; set; }
        public int RentalNoteUserID { get; set; }

        public virtual Rental Rental { get; set; }
        public virtual User User { get; set; }

        public RentalNote()
        {
            RentalNoteCreatedAt = DateTime.Now;
        }
    }
}