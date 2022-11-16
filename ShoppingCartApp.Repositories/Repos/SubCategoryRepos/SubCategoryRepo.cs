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

namespace ShoppingCartApp.Repositories.Repos.SubCategoryRepos
{
   public class SubCategoryRepo : GenericRepository<ProductSubCategory>, ISubCategoryRepo
    {
        private readonly ShoppingCartDBContext _context;
        private readonly IMapper _mapper;
        public SubCategoryRepo(ShoppingCartDBContext context, IMemoryCache cache, IMapper mapper) : base(context, cache)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<ProductSubCategory>> GetAllSubCategoriesById(string id)
        {
            return _context.ProductSubCategory.Where(x => x.FKCategoryId == id).ToListAsync();
        }
    }
}
