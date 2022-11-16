using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos.CartItemRepos
{
    public interface ICartItemsRepo: IGenericRepository<CartItems>
    {
        Task<int> GetCartItemsCount();
        Task<List<CartItems>> GetCartItems();
    }
}
