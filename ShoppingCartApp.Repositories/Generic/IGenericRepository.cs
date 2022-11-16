using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Repositories.Generic
{
    public interface IGenericRepository<Entity>
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<IEnumerable<Entity>> GetAllBy(Expression<Func<Entity, bool>> predicate);
        Task<Entity> Find<TParmeter>(TParmeter id);
        Task<Entity> FindAsNoTracking<TParameter>(TParameter id);
        Task<Entity> GetBy(Expression<Func<Entity, bool>> predicate);
        Task<PaginationEntityDto<Entity>> GetPaged(int pagenumber, int pagesize);
        Task<PaginationEntityDto<Entity>> GetPaged(int pagenumber, int pagesize, Expression<Func<Entity, bool>> predicate, Expression<Func<Entity, object>> orderbypredicate, bool orderbyascending = true);
        Task<Entity> Add(Entity entity, string userid);
        Task Update(Entity entity);
        Task Update(Entity entity, string entityid, string userid, bool isdelete);
        Task Delete<T>(T id, string userid);
    }

    public class GenericRepository<Entity> : IGenericRepository<Entity>, IDisposable where Entity : class
    {
        protected ShoppingCartDBContext dbcontext;
        protected DbSet<Entity> dbset;
        protected readonly IMemoryCache cache;

        public GenericRepository(ShoppingCartDBContext dbcontext, IMemoryCache _cache)
        {
            this.dbcontext = dbcontext;
            this.dbset = dbcontext.Set<Entity>();
            cache = _cache;
        }
        public virtual async Task<Entity> Add(Entity entity, string userid)
        {
            try
            {
                await dbset.AddAsync(entity);
                await dbcontext.SaveChangesAsync();
                cache.Remove(nameof(Entity));
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task Delete<T>(T id, string userid)
        {
            try
            {
                var res = await this.Find<T>(id);
                if (res != null)
                {
                    dbset.Remove(res);
                    await dbcontext.SaveChangesAsync();
                    cache.Remove(nameof(Entity));
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<Entity> Find<TParmeter>(TParmeter id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual async Task<Entity> FindAsNoTracking<TParmeter>(TParmeter id)
        {
            var entity = await dbset.FindAsync(id);
            dbcontext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            try
            {
                IEnumerable<Entity> entities = null;
                if (!cache.TryGetValue(nameof(Entity), out entities))
                {
                    entities = await dbset.AsNoTracking().ToListAsync();
                    cache.Set(nameof(Entity), entities);
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<Entity>> GetAllBy(Expression<Func<Entity, bool>> predicate)
        {
            try
            {
                return await dbset.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Entity> GetBy(Expression<Func<Entity, bool>> predicate)
        {
           try
            {
                return await dbset.AsNoTracking().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task Update(Entity entity)
        {
            try
            {
                dbset.Update(entity);
                await dbcontext.SaveChangesAsync();
                cache.Remove(nameof(Entity));
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task Update(Entity entity, string entityid, string userid, bool isdelete)
        {
            try
            {
                var oldEntity = await FindAsNoTracking(entityid);
                dbset.Update(entity);
                await dbcontext.SaveChangesAsync();
                cache.Remove(nameof(Entity));
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async virtual Task<PaginationEntityDto<Entity>> GetPaged(int pagenumber, int pagesize)
        {
            int skip = (pagenumber - 1) * pagesize;

            try
            {
                PaginationEntityDto<Entity> paginationEntityDto = new PaginationEntityDto<Entity>();
                paginationEntityDto.Count = await dbset.AsNoTracking().CountAsync();
                paginationEntityDto.Entities = await dbset.AsNoTracking().Skip(skip).Take(pagesize).ToListAsync();

                return paginationEntityDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        ///  Pagination
        /// </summary>
        /// <param name="pagenumber">Page Number required for pagination</param>
        /// <param name="pagesize"> page size (Number of rows required in the data grid)</param>
        /// <param name="wherepredicate">Condition to get the required data</param>
        /// <param name="orderbypredicate">condition to get order by</param>
        /// <param name="orderbyascending">bool value to get the data by an order </param>
        /// <returns></returns>

        public async virtual Task<PaginationEntityDto<Entity>> GetPaged(int pagenumber, int pagesize, Expression<Func<Entity, bool>> wherepredicate, Expression<Func<Entity, object>> orderbypredicate, bool orderbyascending = true)
        {
            int skip = (pagenumber - 1) * pagesize;

            try
            {
                PaginationEntityDto<Entity> paginationEntityDto = new PaginationEntityDto<Entity>();
                paginationEntityDto.Count = await dbset.Where(wherepredicate).AsNoTracking().CountAsync();

                if (orderbyascending)
                {
                    paginationEntityDto.Entities = await dbset.AsNoTracking().Where(wherepredicate).OrderBy(orderbypredicate).AsNoTracking().Skip(skip).Take(pagesize).ToListAsync();
                }
                else
                {
                    paginationEntityDto.Entities = await dbset.AsNoTracking().Where(wherepredicate).OrderByDescending(orderbypredicate).AsNoTracking().Skip(skip).Take(pagesize).ToListAsync();
                }


                return paginationEntityDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
