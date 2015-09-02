using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Database_Init
{
    class SampleContext : DbContext
    {
        // TODO: Set database initializer in a static ctor

        // Specify database name to use default connection factory
        public SampleContext() : base("DatabaseInit") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
