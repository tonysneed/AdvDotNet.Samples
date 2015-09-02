using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Reverse_Engineer.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
        }
    }
}
