using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.CartItemDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos.CartItemRepos;
using ShoppingCartApp.Repositories.Repos.ProductsRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : BaseAPIController<CartItems,
        CartItemsDTO, CartItemsDTO,
        AddCartItemsDTO,
        UpdateCartItemsDTO>
    {
        private readonly ICartItemsRepo cartItemsRepo;
        public CartItemsController(ICartItemsRepo cartItemsRepo, IProductsRepo prodRepo, IMapper mapper) : base(mapper, cartItemsRepo)
        {
            this.cartItemsRepo = cartItemsRepo;
        }

        [HttpGet("getallcartitems")]
        public async Task<ActionResult<IList<CartItemsDTO>>> GetAllCartItems()
        {
            try
            {
                var products = await cartItemsRepo.GetCartItems();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getcartcount")]
        public async Task<ActionResult> GetCartCount()
        {
            try
            {
                var count = await cartItemsRepo.GetCartItemsCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("additemstocart")]
        public async Task<ActionResult> AddCartItems([FromBody]AddCartItemsDTO cartItems)
        {
            try
            {
                await cartItemsRepo.Add(cartItems.ConvertToModel(), "1234abcde");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
