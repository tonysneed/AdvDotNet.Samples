using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IOAsync.Entities;

namespace IOAsync.Web
{
    public class ProductController : ApiController
    {
        private const int Delay = 4;
        private readonly Database _database = new Database();

        // GET api/product?categoryid=1
        public async Task<IEnumerable<Product>> Get(int categoryId)
        {
            // Simulate latency (non-scalable)
            await Task.Delay(TimeSpan.FromSeconds(Delay));

            var products = (from p in _database.Products
                where p.CategoryId == categoryId
                orderby p.ProductName
                select p).ToArray();
            return products;
        }
    }
}