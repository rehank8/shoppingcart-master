using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("SubCategory", Schema = "Product")]
    public class ProductSubCategory : Entity<string>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string SubCategoryName { get; set; }
        [ForeignKey("ProductCategory")]
        public string FKCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
