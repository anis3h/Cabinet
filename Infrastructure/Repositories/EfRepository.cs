using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly CabinetContext _dbContext;
        T entity;
        public EfRepository(CabinetContext dbContext)
        {
            _dbContext = dbContext;
            DbInitializer.Initialize(dbContext);
        }

       

        //public T GetSingleBySpec(ISpecification<T> spec)
        //{
        //    return List(spec).FirstOrDefault();
        //}


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

     

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

      

        public async Task<T> AddAsync(T entity)
        {
            entity.InsertDate = DateTime.Now;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

       
        public async Task UpdateAsync(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

     
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
