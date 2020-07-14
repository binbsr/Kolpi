using Kolpi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kolpi.Server.ApplicationCore.Services
{
    public interface IAsyncService<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> GetTotalCountAsync();

        Task<int> AddAsync(TEntity entity);
        Task<int> AddAsync(IEnumerable<TEntity> entities);

        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(IEnumerable<TEntity> entities);

        Task<int> DeleteAsync(TKey id);
        Task<int> DeleteAsync(IEnumerable<TKey> ids);
    }
}
