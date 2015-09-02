using System;
using System.Collections.Generic;
using System.Linq;

namespace Database_Init
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SampleContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories)
                {
                    Console.WriteLine("{0} {1}",
                        category.Id, category.CategoryName);
                }

                Console.WriteLine("\nProducts:");
                foreach (var product in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        product.Id, product.ProductName,
                        product.Price.ToString("C"),
                        product.Category.CategoryName);
                }
            }
        }
    }
}
