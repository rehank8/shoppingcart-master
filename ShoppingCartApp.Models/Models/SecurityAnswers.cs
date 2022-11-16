using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("SecurityAnswers", Schema = "User")]
    public class SecurityAnswers:Entity<string>
    {
        [ForeignKey("SecurityQuestions")]
        public string FKQuestionId { get; set; }
        [ForeignKey("User")]
        public string FKUserId { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR(500)")]
        public string Answers { get; set; }
        public virtual SecurityQuestions SecurityQuestions { get; set; }
        public virtual User User { get; set; }
    }
}
