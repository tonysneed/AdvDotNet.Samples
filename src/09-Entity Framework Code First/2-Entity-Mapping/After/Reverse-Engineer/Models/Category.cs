using System;
using System.Collections.Generic;

namespace Reverse_Engineer.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
