using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reverse_Engineer.Models;

namespace Reverse_Engineer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindSlimContext())
            {
                Console.WriteLine("Categories:");
                foreach (var category in context.Categories)
                {
                    Console.WriteLine("{0} {1}", 
                        category.CategoryId, category.CategoryName);
                }

                Console.WriteLine("\nProducts:");
                foreach (var product in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        product.ProductId, product.ProductName,
                        product.UnitPrice, product.Category.CategoryName);
                }
            }
        }
    }
}
