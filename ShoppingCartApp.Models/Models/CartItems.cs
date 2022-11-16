using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    public class CartItems : Entity<string>
    {
        //[Required]
        //[Column(TypeName = "VARCHAR(500)")]
        //public string CartItemName { get; set; }
        [ForeignKey("User")]
        public string FKUserId { get; set; }
        [ForeignKey("Products")]
        public string FKProductId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Image { get; set; }
        [Required]
        [Column(TypeName = "MONEY")]
        public double Price { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int ItemsCount { get; set; }
        public virtual User User { get; set; }
        public virtual Products Products { get; set; }
    }
}
