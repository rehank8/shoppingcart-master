using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.DTO.UserDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Repos.UserRepos
{
    public class UserRepo : GenericRepository<User>, IUserRepo
    {
        private readonly ShoppingCartDBContext _context;
        private readonly IMapper _mapper;
        public UserRepo(ShoppingCartDBContext context, IMemoryCache cache, IMapper mapper) : base(context, cache)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersPaginationEntityDto<UserDTO>> GetPagedUsers(FilterAttributes filterArray, int pagenumber, int pagesize, Expression<Func<User, bool>> predicate, Expression<Func<UserDTO, object>> orderbypredicate, bool orderbyascending = true)
        {
            int skip = (pagenumber - 1) * pagesize;

            string userFilter = string.Empty;
            string addressFilter = string.Empty;
            string emailFilter = string.Empty;

            if (filterArray?.FilterProperties?.Count > 0)
            {
                userFilter = filterArray.FilterProperties.Where(x => x.Key == "Username").FirstOrDefault().Value;
                addressFilter = filterArray.FilterProperties.Where(x => x.Key == "Address").FirstOrDefault().Value;
                emailFilter = filterArray.FilterProperties.Where(x => x.Key == "Email").FirstOrDefault().Value;
            }

            try
            {
                UsersPaginationEntityDto<UserDTO> paginationEntityDto = new UsersPaginationEntityDto<UserDTO>();

                if (orderbyascending)
                {
                    paginationEntityDto.Entities = await dbcontext.Set<User>().Where(predicate).Where(x => (string.IsNullOrEmpty(userFilter) ? true : x.Username.ToLower().Contains(userFilter.ToLower())) && (string.IsNullOrEmpty(addressFilter) ? true : x.Address.ToLower().Contains(addressFilter.ToLower())) && (string.IsNullOrEmpty(emailFilter) ? true : x.EmailId.ToLower().Contains(emailFilter))).Select(x => new UserDTO
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Address = x.Address,
                        EmailId = x.EmailId,
                        IsActive = x.IsActive,
                        IsDelete = x.IsDelete,

                    }).OrderBy(orderbypredicate).Skip(skip).Take(pagesize).AsNoTracking().ToListAsync();
                }
                else
                {
                    paginationEntityDto.Entities = await dbcontext.Set<User>().Where(predicate).Where(x => (string.IsNullOrEmpty(userFilter) ? true : x.Username.ToLower().Contains(userFilter.ToLower())) &&
                    (string.IsNullOrEmpty(addressFilter) ? true : x.Address.ToLower().Contains(addressFilter.ToLower())) && (string.IsNullOrEmpty(emailFilter) ? true : x.EmailId.ToLower().Contains(emailFilter.ToLower()))).Select(x => new UserDTO
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Address = x.Address,
                        EmailId = x.EmailId,
                        IsActive = x.IsActive,
                        IsDelete = x.IsDelete,

                    }).OrderByDescending(orderbypredicate).Skip(skip).Take(pagesize).AsNoTracking().ToListAsync();
                }

                paginationEntityDto.Roles = await dbcontext.Set<Roles>().Where(x => x.IsActive == true && !x.IsDelete).ToListAsync();
                paginationEntityDto.Count = (filterArray?.FilterProperties?.Count > 0) ? paginationEntityDto.Entities.Count() : dbcontext.Set<User>().Where(predicate).Count();
               // paginationEntityDto.Entities = paginationEntityDto.Entities.Skip(skip).Take(pagesize).ToList();

                return paginationEntityDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //public async List<UserDTO> getAllUsers(int pageNo, int pageSize, string sortOrder,string route)
        //{

        //    var validFilter = new PaginationFilter(pageNo, pageSize);
        //    var pagedData = await _context
        //       .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        //       .Take(validFilter.PageSize)
        //       .ToListAsync();
        //    var totalRecords = await context.Customers.CountAsync();
        //    var pagedReponse = PaginationHelper.CreatePagedReponse<Customer>(pagedData, validFilter, totalRecords, uriService, route);
        //    return Ok(pagedReponse);
        //}
    }
}
