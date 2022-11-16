using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("SubCategoryTypes", Schema = "Product")]
    public class ProductSubCategoryTypes : Entity<string>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string SubCategoryTypeName { get; set; }
        [ForeignKey("ProductSubCategory")]
        public string FKSubCategoryId { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
    }
}
