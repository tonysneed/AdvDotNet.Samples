using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Database_Init
{
    class SampleInitializer : DropCreateDatabaseAlways<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            var beverages = context.Categories.Add(new Category()
            {
                CategoryName = "Beverages"
            });
            context.Products.Add(new Product()
            {
                ProductName = "Chai",
                Price = 10M,
                Category = beverages
            });
        }
    }
}
