using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    public class BuyerPurchaseTransactions : Entity<string>
    {
        [ForeignKey("User")]
        public string FKUserId { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DatePurchased { get; set; }
        [Required]
        [Column(TypeName = "INT")]
        public int PurchaseAmount { get; set; }
        public virtual User User { get; set; }
    }
}
