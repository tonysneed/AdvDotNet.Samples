using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Mapping_Fluent
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            HasKey(t => t.CategoryIdentifier);

            // Singluar table name
            ToTable("Category");

            // Required, Max Length
            Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
