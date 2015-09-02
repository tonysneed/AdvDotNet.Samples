using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // Entity sets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
