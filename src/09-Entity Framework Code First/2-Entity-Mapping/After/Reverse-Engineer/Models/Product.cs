using System;
using System.Collections.Generic;

namespace Reverse_Engineer.Models
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
