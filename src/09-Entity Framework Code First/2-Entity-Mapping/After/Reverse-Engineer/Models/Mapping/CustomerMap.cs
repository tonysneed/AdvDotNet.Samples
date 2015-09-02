using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Reverse_Engineer.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.CustomerId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.ContactName)
                .HasMaxLength(30);

            this.Property(t => t.City)
                .HasMaxLength(15);

            this.Property(t => t.Country)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
        }
    }
}
