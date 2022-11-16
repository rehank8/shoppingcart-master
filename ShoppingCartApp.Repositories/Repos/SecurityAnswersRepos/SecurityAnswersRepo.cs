using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Repositories.Repos
{
    public class SecurityAnswersRepo : GenericRepository<SecurityAnswers>, ISecurityAnswersRepo
    {
        private readonly ShoppingCartDBContext _context;
        private readonly IMapper _mapper;
        public SecurityAnswersRepo(ShoppingCartDBContext context, IMemoryCache cache, IMapper mapper) : base(context, cache)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
