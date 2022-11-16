using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("Category", Schema = "Product")]
    public class ProductCategory : Entity<string>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string CategoryName { get; set; }
    }
}
