using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Reverse_Engineer.Models.Mapping;

namespace Reverse_Engineer.Models
{
    public partial class NorthwindSlimContext : DbContext
    {
        static NorthwindSlimContext()
        {
            Database.SetInitializer<NorthwindSlimContext>(null);
        }

        public NorthwindSlimContext()
            : base("Name=NorthwindSlimContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
