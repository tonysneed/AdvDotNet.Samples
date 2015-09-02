using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IOAsync.Entities;

namespace IOAsync.Web
{
    public class CategoryController : ApiController
    {
        private const int Delay = 4;
        private readonly Database _database = new Database();

        // GET api/category
        public IEnumerable<Category> Get()
        {
            // Simulate latency (non-scalable)
            Task.Delay(TimeSpan.FromSeconds(Delay)).Wait();

            var categories = (from c in _database.Categories
                orderby c.CategoryName
                select c).ToArray();
            return categories;
        }
    }
}