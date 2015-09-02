using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FromScratch
{
    class SampleContext : DbContext
    {
        // Not needed - EF will use DbConfiguration class automatically
        //static SampleContext()
        //{
        //    DbConfiguration.SetConfiguration(new SampleConfiguration());
        //}

        // Call base ctor passing database name or connection string name
        public SampleContext() 
            : base("name=SampleContext") //base("HelloCodeFirst")
        {
            // Enable lazy loading
            Configuration.LazyLoadingEnabled = true;
        }

        // Entity sets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
