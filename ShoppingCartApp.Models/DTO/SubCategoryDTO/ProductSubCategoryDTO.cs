using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.SubCategoryDTO
{
    public class ProductSubCategoryDTO : EntityDTO<string>
    {
        public string SubCategoryName { get; set; }
        public string FKCategoryId { get; set; }
        public ProductSubCategory ConvertToModel()
        {
            ProductSubCategory cart = new ProductSubCategory();
            cart.Id = Id;
            cart.SubCategoryName = SubCategoryName;
            cart.FKCategoryId = FKCategoryId;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class AddProductSubCategoryDTO : AddEntityDto<string>
    {
        public string SubCategoryName { get; set; }
        public string FKCategoryId { get; set; }
        public ProductSubCategory ConvertToModel()
        {
            ProductSubCategory cart = new ProductSubCategory();
            cart.Id = Id;
            cart.SubCategoryName = SubCategoryName;
            cart.FKCategoryId = FKCategoryId;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class UpdateProductSubCategoryDTO : UpdateEntityDtO<string>
    {
        public string SubCategoryName { get; set; }
        public string FKCategoryId { get; set; }
        public ProductSubCategory ConvertToModel()
        {
            ProductSubCategory cart = new ProductSubCategory();
            cart.Id = Id;
            cart.SubCategoryName = SubCategoryName;
            cart.FKCategoryId = FKCategoryId;
            cart.IsActive = IsActive;
            return cart;
        }
    }
}
