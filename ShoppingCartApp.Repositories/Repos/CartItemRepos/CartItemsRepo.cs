using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos.CartItemRepos
{
    public class CartItemsRepo : GenericRepository<CartItems>, ICartItemsRepo
    {
        private readonly ShoppingCartDBContext _context;
        private readonly IMapper _mapper;
        public CartItemsRepo(ShoppingCartDBContext context, IMemoryCache cache, IMapper mapper) : base(context, cache)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<CartItems>> GetCartItems()
        {
            var data = _context.CartItems.ToListAsync();
            foreach (var item in data.Result)
            {
                item.Products= _context.Products.Where(x => x.Id == item.FKProductId).FirstOrDefault();
            }
            return data;
        }

        public Task<int> GetCartItemsCount()
        {
            var data= _context.CartItems.ToListAsync().Result.Count;
            return Task.FromResult(data);
        }
    }
}
