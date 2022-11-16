using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos.SubCategoryRepos
{
   public interface ISubCategoryRepo : IGenericRepository<ProductSubCategory>
    {
        Task<List<ProductSubCategory>> GetAllSubCategoriesById(string id);
    }
}
