using Kolpi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kolpi.Server.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(TKey id);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);

        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        void Delete(TKey id);
        void Delete(IEnumerable<TKey> ids);
    }
}
