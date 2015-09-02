using System.Collections.Generic;
using IOAsync.Entities;

namespace IOAsync.Web
{
    public class Database
    {
        public List<Category> Categories { get; private set; }
        public List<Product> Products { get; private set; }

        public Database()
        {
            Categories = new List<Category>
            {
                    new Category { CategoryId = 1, CategoryName = "Beverages" },
                    new Category { CategoryId = 2, CategoryName = "Condiments" },
                    new Category { CategoryId = 3, CategoryName = "Confections" },
                    new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                    new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                    new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                    new Category { CategoryId = 7, CategoryName = "Produce" },
                    new Category { CategoryId = 8, CategoryName = "Seafood" },
            };

            Products = new List<Product>
            {
                    new Product { ProductId = 1, ProductName = "Chai", UnitPrice = 21.0000M, Discontinued = false, CategoryId = 1, Category = Categories[0] },
                    new Product { ProductId = 2, ProductName = "Chang", UnitPrice = 20.0000M, Discontinued = false, CategoryId = 1, Category = Categories[0] },
                    new Product { ProductId = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.0000M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", UnitPrice = 22.0000M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix", UnitPrice = 21.3500M, Discontinued = true, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 6, ProductName = "Grandma's Boysenberry Spread", UnitPrice = 27.0000M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears", UnitPrice = 30.0000M, Discontinued = false, CategoryId = 7, Category = Categories[6] },
                    new Product { ProductId = 8, ProductName = "Northwoods Cranberry Sauce", UnitPrice = 40.0000M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 9, ProductName = "Mishi Kobe Niku", UnitPrice = 97.0000M, Discontinued = true, CategoryId = 6, Category = Categories[5] },
                    new Product { ProductId = 10, ProductName = "Ikura", UnitPrice = 31.0000M, Discontinued = false, CategoryId = 8, Category = Categories[7] },
                    new Product { ProductId = 11, ProductName = "Queso Cabrales", UnitPrice = 21.0000M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
                    new Product { ProductId = 12, ProductName = "Queso Manchego La Pastora", UnitPrice = 38.0000M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
                    new Product { ProductId = 13, ProductName = "Konbu", UnitPrice = 6.0000M, Discontinued = false, CategoryId = 8, Category = Categories[7] },
                    new Product { ProductId = 14, ProductName = "Tofu", UnitPrice = 23.2500M, Discontinued = false, CategoryId = 7, Category = Categories[6] },
                    new Product { ProductId = 15, ProductName = "Genen Shouyu", UnitPrice = 15.5000M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 16, ProductName = "Pavlova", UnitPrice = 17.4500M, Discontinued = false, CategoryId = 3, Category = Categories[2] },
                    new Product { ProductId = 17, ProductName = "Alice Mutton", UnitPrice = 39.0000M, Discontinued = true, CategoryId = 6, Category = Categories[5] },
                    new Product { ProductId = 18, ProductName = "Carnarvon Tigers", UnitPrice = 62.5000M, Discontinued = false, CategoryId = 8, Category = Categories[7] },
                    new Product { ProductId = 19, ProductName = "Teatime Chocolate Biscuits", UnitPrice = 9.2000M, Discontinued = false, CategoryId = 3, Category = Categories[2] },
                    new Product { ProductId = 20, ProductName = "Sir Rodney's Marmalade", UnitPrice = 81.0000M, Discontinued = false, CategoryId = 3, Category = Categories[2] },
                    new Product { ProductId = 22, ProductName = "Gustaf's Knäckebröd", UnitPrice = 21.0000M, Discontinued = false, CategoryId = 5, Category = Categories[4] },
                    new Product { ProductId = 33, ProductName = "Geitost", UnitPrice = 2.50M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
                    new Product { ProductId = 41, ProductName = "Jack's New England Clam Chowder", UnitPrice = 9.65M, Discontinued = false, CategoryId = 8, Category = Categories[7] },
                    new Product { ProductId = 42, ProductName = "Singaporean Hokkien Fried Mee", UnitPrice = 14.0000M, Discontinued = true, CategoryId = 5, Category = Categories[4] },
                    new Product { ProductId = 51, ProductName = "Manjimup Dried Apples", UnitPrice = 53.00M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
                    new Product { ProductId = 57, ProductName = "Ravioli Angelo", UnitPrice = 19.50M, Discontinued = false, CategoryId = 5, Category = Categories[4] },
                    new Product { ProductId = 60, ProductName = "Camembert Pierrot", UnitPrice = 34.50M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
                    new Product { ProductId = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", UnitPrice = 21.05M, Discontinued = false, CategoryId = 2, Category = Categories[1] },
                    new Product { ProductId = 72, ProductName = "Mozzarella di Giovanni", UnitPrice = 34.80M, Discontinued = false, CategoryId = 4, Category = Categories[3] },
            };
        }
    }
}