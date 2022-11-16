using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    public class PaymentDetails : Entity<string>
    {
        [ForeignKey("User")]
        public string FKUserId { get; set; }
        [ForeignKey("Products")]
        public string FKProductId { get; set; }
        public int Amount { get; set; }
    }
}
