using System;
using System.Collections.Generic;
using System.Linq;

namespace FromScratch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialize database?");
            bool init = Console.ReadLine().ToUpper() == "Y";
            if (init) SeedData();
            Console.WriteLine("Query database?");
            bool query = Console.ReadLine().ToUpper() == "Y";
            if (query) QueryData();
            Console.WriteLine("Lazy loading?");
            bool lazy = Console.ReadLine().ToUpper() == "Y";
            if (lazy) LazyLoading();
        }

        private static void SeedData()
        {
            using (var context = new SampleContext())
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
                context.Products.Add(new Product { ProductName = "Chocolade", Price = 50, Category = confections });
                context.Products.Add(new Product { ProductName = "Maxilaku", Price = 60, Category = confections });

                // Persist changes
                context.SaveChanges();
            }
        }

        private static void QueryData()
        {
            using (var context = new SampleContext())
            {
                // Get categories
                var categories = context.Categories.OrderBy(c => c.CategoryName);
                foreach (var category in categories)
                {
                    Console.WriteLine("{0} {1}", category.Id, category.CategoryName);
                }

                // Get products by category
                Console.WriteLine("\nCategory Id:");
                var categoryId = int.Parse(Console.ReadLine());
                var products = from p in context.Products
                               where p.CategoryId == categoryId
                               orderby p.ProductName
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine("{0} {1} {2}",
                        product.Id, product.ProductName, product.Price.ToString("C"));
                }
            }
        }

        private static void LazyLoading()
        {
            using (var context = new SampleContext())
            {
                // Log SQL to the console
                context.Database.Log = Console.Write;

                // Get category and related products
                Console.WriteLine("Category Id:");
                var categoryId = int.Parse(Console.ReadLine());
                var category = context.Categories.Single(c => c.Id == categoryId);
                foreach (var product1 in category.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        product1.Id, product1.ProductName, product1.Price.ToString("C"), 
                        product1.Category.CategoryName);
                }

                // Get product and related category
                Console.WriteLine("Product Id:");
                var productId = int.Parse(Console.ReadLine());
                var product2 = context.Products.Single(p => p.Id == productId);
                Console.WriteLine("{0} {1} {2} {3}",
                    product2.Id, product2.ProductName, product2.Price.ToString("C"),
                    product2.Category.CategoryName);
            }
        }
    }
}
