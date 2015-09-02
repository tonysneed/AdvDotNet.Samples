using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Entity_Mapping
{
    class MappingContext : DbContext
    {
        // Call base ctor passing database name or connection string name
        public MappingContext()
            : base("EntityMapping")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove key discovery convention
            modelBuilder.Conventions.Remove<KeyDiscoveryConvention>();

            // Configure integer properties named 'Key' to be the entity key
            modelBuilder.Properties<int>()
                .Where(p => p.Name == "Key")
                .Configure(p => p.IsKey());

            // Remove pluralizing table name convention
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        // Entity sets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
