using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.ProductDTO
{
    public class ProductsDTO : EntityDTO<string>
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Products ConvertToModel()
        {
            Products cart = new Products();
            cart.Id = Id;
            cart.ProductName = ProductName;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class AddProductsDTO : AddEntityDto<string>
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Products ConvertToModel()
        {
            Products cart = new Products();
            cart.Id = Guid.NewGuid().ToString();
            cart.ProductName = ProductName;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }

    public class UpdateProductsDTO : UpdateEntityDtO<string>
    {
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Products ConvertToModel()
        {
            Products cart = new Products();
            cart.Id = Id;
            cart.ProductName = ProductName;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }
}
