﻿using Kolpi.ApplicationCore.Entities;
using System.Linq.Expressions;

namespace Kolpi.ApplicationCore.Services
{
    public interface IAsyncService<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
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
