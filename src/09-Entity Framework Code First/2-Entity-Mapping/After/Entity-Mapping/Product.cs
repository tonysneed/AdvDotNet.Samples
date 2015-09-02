using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entity_Mapping
{
    [Table("PRODUCT")]
    public class Product
    {
        public int Key { get; set; } // Use custom convention

        [Required, MinLength(4), MaxLength(20)]
        public string ProductName { get; set; }

        [Column("Description", TypeName = "ntext")]
        public string ProductDescription { get; set; }
        public decimal? Price { get; set; } // Make nullable

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public int CategoryKey { get; set; }
        public Category Category { get; set; }
    }
}
