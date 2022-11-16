using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos.CategoryRepos
{
    public interface ICategoryRepo : IGenericRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetAllCategoriesandSubCat();
        Task<List<ProductSubCategory>> GetAllSubCategories();
    }
}
