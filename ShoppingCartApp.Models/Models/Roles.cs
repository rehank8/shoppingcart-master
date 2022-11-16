using ShoppingCartApp.Models.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    [Table("Role", Schema = "User")]
    public class Roles
    {

        #region Constants
        public const int ROLENAMELENGTH = 200;
        #endregion

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int PKRoleId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        [StringLength(ROLENAMELENGTH)]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        #endregion
    }
}
