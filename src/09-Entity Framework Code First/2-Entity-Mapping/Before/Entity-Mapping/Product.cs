using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Mapping
{
    public class Product
    {
        public int Key { get; set; } // Use custom convention
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; } // Make nullable
        public int CategoryKey { get; set; }
        public Category Category { get; set; }
    }
}
