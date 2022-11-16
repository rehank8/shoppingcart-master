using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    public class Products : Entity<string>
    {
        [ForeignKey("ProductSubCategory")]
        public string FKSubCategoryId { get; set; }
        [ForeignKey("ProductCategory")]
        public string FKCategoryId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string ProductName { get; set; }
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Image { get; set; }
        [Required]
        [Column(TypeName = "MONEY")]
        public double Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        [ForeignKey("Brands")]
        public string FKBrandId { get; set; }
        public string Features { get; set; }
        public int Rating { get; set; }
        public string Condition { get; set; }
        public bool IsAvailability { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Brands Brands { get; set; }
    }
}
