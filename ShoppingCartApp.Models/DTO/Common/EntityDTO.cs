using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCartApp.Models.DTO.Common
{
    public class EntityDTO<TEntity>
    {
        public TEntity Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class AddEntityDto<TEntity>
    {
        public TEntity Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }

    public class UpdateEntityDtO<TEntity>
    {
        [Required]
        public TEntity Id { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }

    public class PaginationEntityDto<TEntity>
    {
        public List<TEntity> Entities { get; set; }

        public int Count { get; set; }

    }

    public class UsersPaginationEntityDto<TEntity>
    {
        public List<TEntity> Entities { get; set; }

        public int Count { get; set; }
        public List<Roles> Roles { get; set; }

    }
    public class FilterAttributes
    {
        public Dictionary<string, string> FilterProperties { get; set; }
    }
}
