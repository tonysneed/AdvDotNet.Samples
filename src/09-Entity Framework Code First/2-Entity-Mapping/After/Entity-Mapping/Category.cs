using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entity_Mapping
{
    [Table("CATEGORY")]
    public class Category
    {
        public int Key { get; set; } // Use custom convention
        public string CategoryName { get; set; }
    }
}
