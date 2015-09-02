using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Mapping_Fluent
{
    class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductIdentifier);

            // Table
            ToTable("Product");

            // Required, Max Length
            Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(20);

            // Col Name, Type
            Property(t => t.ProductDescription)
                .HasColumnName("Description")
                .HasColumnType("ntext");
        }
    }
}
