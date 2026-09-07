using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace DairyFlow.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DatabaseContext _databaseContext;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public TEntity? GetById(int id)
        {
            var dbSet = _databaseContext.Set<TEntity>();
            if (dbSet == null)
            {
                return null;
            }
            return dbSet.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? where = null, int take = 0, int skip = 0)
        {
            var dbSet = _databaseContext.Set<TEntity>();
            if (_databaseContext == null || dbSet == null)
            {
                return new List<TEntity>().AsQueryable();
            } 
            IQueryable<TEntity> query = dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }
            return take == 0 ? query : query.Skip(skip).Take(take);
        }

        public async Task AddAsync(TEntity entity)
        {
            var dbSet = _databaseContext.Set<TEntity>();
            await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            var dbSet = _databaseContext.Set<TEntity>();
            dbSet.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            if (_databaseContext == null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            return await _databaseContext.SaveChangesAsync();
        }
        public void Delete(TEntity entity)
        {
            var dbSet = _databaseContext.Set<TEntity>();
            dbSet.Remove(entity); 
        }
       

    }
}
