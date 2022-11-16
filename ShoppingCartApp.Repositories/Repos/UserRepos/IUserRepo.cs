using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.DTO.UserDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos
{
    public interface IUserRepo : IGenericRepository<User>
    {
        Task<UsersPaginationEntityDto<UserDTO>> GetPagedUsers(FilterAttributes filterArray, int pagenumber, int pagesize, Expression<Func<User, bool>> predicate, Expression<Func<UserDTO, object>> orderbypredicate, bool orderbyascending = true);
        // public List<UserDTO> getAllUsers(int pageNo, int pageSize, string sortOrder,string route);
    }
}
