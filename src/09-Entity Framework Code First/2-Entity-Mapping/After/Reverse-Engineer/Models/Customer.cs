using System;
using System.Collections.Generic;

namespace Reverse_Engineer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }

        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
