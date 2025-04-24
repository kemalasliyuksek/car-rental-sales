using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public DateTime RoleCreatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
            RoleCreatedAt = DateTime.Now;
        }
    }
}