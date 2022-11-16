using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.DTO.SubCategoryDTO;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.CategoryDTO
{
    public class ProductCategoryDTO : EntityDTO<string>
    {
        public string CategoryName { get; set; }
        public List<ProductSubCategoryDTO> SubCategories { get; set; }
        public ProductCategory ConvertToModel()
        {
            ProductCategory cart = new ProductCategory();
            cart.Id = Id;
            cart.CategoryName = CategoryName;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class AddProductCategoryDTO : AddEntityDto<string>
    {
        public string CategoryName { get; set; }
        public ProductCategory ConvertToModel()
        {
            ProductCategory cart = new ProductCategory();
            cart.Id = Id;
            cart.CategoryName = CategoryName;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class UpdateProductCategoryDTO : UpdateEntityDtO<string>
    {
        public string CategoryName { get; set; }
        public ProductCategory ConvertToModel()
        {
            ProductCategory cart = new ProductCategory();
            cart.Id = Id;
            cart.CategoryName = CategoryName;
            cart.IsActive = IsActive;
            return cart;
        }
    }
}
