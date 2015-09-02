using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity_Mapping_Fluent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialize database?");
            bool init = Console.ReadLine().ToUpper() == "Y";
            if (init) SeedData();
            ShowData();
        }

        private static void ShowData()
        {
            using (var context = new MappingContext())
            {
                Console.WriteLine("\nCategories:");
                foreach (var c in context.Categories)
                {
                    Console.WriteLine("{0} {1}", c.CategoryIdentifier, c.CategoryName);
                }

                Console.WriteLine("\nProducts:");
                foreach (var p in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.ProductIdentifier, p.ProductName,
                        p.Price, p.Category.CategoryName);
                }
            }
        }

        private static void SeedData()
        {
            using (var context = new MappingContext())
            {
                // Create categories
                var beverages = context.Categories.Add(new Category { CategoryName = "Beverages" });
                var condiments = context.Categories.Add(new Category { CategoryName = "Condiments" });
                var confections = context.Categories.Add(new Category { CategoryName = "Confections" });

                // Create beverages
                context.Products.Add(new Product { ProductName = "Chai", Price = 10, Category = beverages });
                context.Products.Add(new Product { ProductName = "Chang", Price = 20, Category = beverages });
                context.Products.Add(new Product { ProductName = "Ipoh Coffee", Price = 30, Category = beverages });

                // Create condiments
                context.Products.Add(new Product { ProductName = "Aniseed Syrup", Price = 40, Category = condiments });

                // Create confections
                context.Products.Add(new Product { ProductName = "Chocolade", Category = confections });
                context.Products.Add(new Product { ProductName = "Maxilaku", Category = confections });

                // Persist changes
                context.SaveChanges();
            }
        }
    }
}
