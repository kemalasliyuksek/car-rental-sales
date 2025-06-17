using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;

namespace car_rental_sales_desktop.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchPhone { get; set; }
        public string BranchEmail { get; set; }
        public bool BranchActive { get; set; }
        public DateTime BranchCreatedAt { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Branch()
        {
            Vehicles = new HashSet<Vehicle>();
            Users = new HashSet<User>();
            BranchActive = true;
            BranchCreatedAt = DateTime.Now;
        }
    }
}