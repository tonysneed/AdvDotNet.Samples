using System;
using System.Collections.Generic;

namespace Reverse_Engineer.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
