using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Database_Init
{
    class SampleContext : DbContext
    {
        // Set database initializer in a static ctor
        static SampleContext()
        {
            // Built-In initializers
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SampleContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SampleContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());
            //Database.SetInitializer(new NullDatabaseInitializer<SampleContext>());

            // Custom initializer
            Database.SetInitializer(new SampleInitializer());
        }

        // Specify database name to use default connection factory
        public SampleContext() : base("DatabaseInit") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
