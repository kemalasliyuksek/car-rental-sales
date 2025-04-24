using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceAddress { get; set; }
        public string ServicePhone { get; set; }
        public string ServiceEmail { get; set; }
        public int ServiceAuthorizedPersonID { get; set; }

        // Navigation properties
        public virtual User AuthorizedPerson { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        public Service()
        {
            Maintenances = new HashSet<Maintenance>();
        }
    }
}