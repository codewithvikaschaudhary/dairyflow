using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DairyFlow.Data.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity? GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? where = null, int take = 0, int skip = 0);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();

        void Delete(TEntity entity);

    }
}   
