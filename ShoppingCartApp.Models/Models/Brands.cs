using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("Brands", Schema = "Product")]
    public class Brands:Entity<string>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Name { get; set; }
        [ForeignKey("ProductSubCategory")]
        public string FKSubCategoryId { get; set; }
        [ForeignKey("ProductCategory")]
        public string FKCategoryId { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
