using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Mapping_Fluent
{
    public class Product
    {
        public int ProductIdentifier { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public int CategoryIdentifier { get; set; }
        public Category Category { get; set; }
    }
}
