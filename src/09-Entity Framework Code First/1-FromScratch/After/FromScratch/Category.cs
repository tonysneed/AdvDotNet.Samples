using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromScratch
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; } // virtual for lazy loading
    }
}
