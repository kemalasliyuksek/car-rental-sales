using System;

namespace car_rental_sales_desktop.Models
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public string ErrorID { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ErrorSeverity { get; set; }
        public string ErrorSource { get; set; }
        public string ErrorContent { get; set; }
        public string ErrorUsername { get; set; }
        public string ErrorExceptionType { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorInnerException { get; set; }
        public string ErrorStackTrace { get; set; }

        public ErrorLog()
        {
            ErrorID = Guid.NewGuid().ToString();
            ErrorDate = DateTime.Now;
        }
    }
}