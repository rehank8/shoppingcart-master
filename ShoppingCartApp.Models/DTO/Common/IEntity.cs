using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCartApp.Models.DTO.Common
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        bool IsActive { get; set; }
    }

    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public bool IsDelete { get; set; } = false;
    }
}
