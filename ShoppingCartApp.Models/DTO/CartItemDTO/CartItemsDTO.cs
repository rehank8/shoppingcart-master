using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.CartItemDTO
{
    public class CartItemsDTO : EntityDTO<string>
    {
        public string FKProductId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Products Products { get; set; }
        public CartItems ConvertToModel()
        {
            CartItems cart = new CartItems();
            cart.Id = Id;
            cart.FKProductId = FKProductId;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }
    public class AddCartItemsDTO : AddEntityDto<string>
    {
        public string FKProductId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public CartItems ConvertToModel()
        {
            CartItems cart = new CartItems();
            cart.Id = Guid.NewGuid().ToString();
            cart.FKProductId = FKProductId;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }
    public class UpdateCartItemsDTO : UpdateEntityDtO<string>
    {
        public string FKProductId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public CartItems ConvertToModel()
        {
            CartItems cart = new CartItems();
            cart.Id = Id;
            cart.FKProductId = FKProductId;
            cart.Image = Image;
            cart.Price = Price;
            cart.IsActive = IsActive;
            return cart;
        }
    }
}
