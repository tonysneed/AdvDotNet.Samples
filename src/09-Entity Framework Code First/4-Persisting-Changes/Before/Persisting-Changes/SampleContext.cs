using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persisting_Changes
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("PersistingChanges") { }

        public DbSet<Product> Products { get; set; }
    }
}
