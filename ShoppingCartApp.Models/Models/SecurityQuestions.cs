using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("SecurityQuestions", Schema = "User")]
    public class SecurityQuestions : Entity<string>
    {
        //[ForeignKey("User")]
        //public string FKUserId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Questions { get; set; }
        //public virtual User User { get; set; }
    }
}
