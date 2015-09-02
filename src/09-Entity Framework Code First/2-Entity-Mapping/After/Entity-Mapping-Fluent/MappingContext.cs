using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Entity_Mapping_Fluent
{
    class MappingContext : DbContext
    {
        // Call base ctor passing database name or connection string name
        public MappingContext()
            : base("EntityMappingFluent")
        {
        }

        // Entity sets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
