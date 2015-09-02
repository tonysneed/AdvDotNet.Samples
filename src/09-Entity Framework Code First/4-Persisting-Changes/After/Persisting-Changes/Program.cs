using System;
using System.Collections.Generic;
using System.Linq;

namespace Persisting_Changes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SampleContext())
            {
                // Log SQL to the console
                context.Database.Log = Console.Write;

                // Prompt user for product name and price
                Console.WriteLine("Product Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Price:");
                decimal price = decimal.Parse(Console.ReadLine());

                // Create a new product
                var product = new Product
                {
                    ProductName = name,
                    Price = price
                };

                // Insert new product
                context.Products.Add(product);

                // Persist changes
                context.SaveChanges();

                // Print product to the console
                Console.WriteLine("{0} {1} {2}", product.Id, 
                    product.ProductName, product.Price);

                // Prompt user to increase price
                Console.WriteLine("Press Enter to increase price");
                Console.ReadLine();

                // Increase product price
                product.Price++;

                // Save price increase
                context.SaveChanges();

                // Print product to the console
                Console.WriteLine("{0} {1} {2}", product.Id,
                    product.ProductName, product.Price);

                // Prompt to delete product
                Console.WriteLine("Press Enter to delete product");
                Console.ReadLine();

                // Remove the product
                context.Products.Remove(product);

                // Save product deletion
                context.SaveChanges();
            }
        }
    }
}
