﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; } 
        public ICollection<Order> Orders { get; set; }
    }

}
