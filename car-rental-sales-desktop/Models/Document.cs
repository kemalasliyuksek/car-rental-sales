using System;

namespace car_rental_sales_desktop.Models
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string DocumentTransactionType { get; set; }
        public int DocumentTransactionID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentFilePath { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public int DocumentUserID { get; set; }

        // Navigation properties
        public virtual User User { get; set; }

        public Document()
        {
            DocumentUploadDate = DateTime.Now;
        }
    }
}