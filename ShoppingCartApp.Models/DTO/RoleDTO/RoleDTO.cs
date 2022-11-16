using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCartApp.Models.DTO.RoleDTO
{
    public class RoleDTO : EntityDTO<string>
    {
        public string RoleName { get; set; }
    }

    public class AddRoleDTO : AddEntityDto<string>
    {
        [Required]
        [StringLength(Roles.ROLENAMELENGTH)]
        public string RoleName { get; set; }

      
    }

    public class UpdateRoleDTO : UpdateEntityDtO<string>
    {
        [Required]
        [StringLength(Roles.ROLENAMELENGTH)]
        public string RoleName { get; set; }
    }
}
