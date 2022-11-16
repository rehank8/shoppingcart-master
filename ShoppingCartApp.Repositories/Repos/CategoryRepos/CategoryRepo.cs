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

namespace ShoppingCartApp.Repositories.Repos.CategoryRepos
{
   public class CategoryRepo : GenericRepository<ProductCategory>, ICategoryRepo
    {
        private readonly ShoppingCartDBContext _context;
        private readonly IMapper _mapper;
        public CategoryRepo(ShoppingCartDBContext context, IMemoryCache cache, IMapper mapper) : base(context, cache)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<ProductCategory>> GetAllCategoriesandSubCat()
        {
            var cat = _context.ProductCategory.Where(x => x.IsActive == true);
            return cat.ToListAsync();
            //throw new NotImplementedException();
        }

        public Task<List<ProductSubCategory>> GetAllSubCategories()
        {
            var subcat = _context.ProductSubCategory.Where(x => x.IsActive == true);
            return subcat.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
