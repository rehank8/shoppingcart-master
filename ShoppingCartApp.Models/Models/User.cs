using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("User", Schema = "User")]
    public class User : Entity<string>
    {

        //[ForeignKey("Roles")]
        //[Column(TypeName = "int")]
        //public int FKRoleId { get; set; }
       
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string EmailId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string PhoneNo { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Address { get; set; }


        [Column(TypeName = "VARCHAR(500)")]
        public string IPAddress { get; set; }

        public bool IsSecurityQuestions { get; set; }
        //public virtual Roles Roles { get; set; }

        [ForeignKey("FKRoleId")]
        public Roles Roles { get; set; }
        public int FKRoleId { get; set; }
    }
}
