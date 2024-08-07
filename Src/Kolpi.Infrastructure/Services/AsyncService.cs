﻿using Kolpi.ApplicationCore.Entities;
using Kolpi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Kolpi.ApplicationCore.Services;
public abstract class AsyncService<TEntity, TKey>(KolpiDbContext context) : IAsyncService<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly KolpiDbContext context = context;
    private DbSet<TEntity> entities = context.Set<TEntity>();

    public virtual Task<int> AddAsync(TEntity model, bool commit = true)
    {
        entities.Add(model);            
        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public virtual Task<int> AddAsync(IEnumerable<TEntity> models, bool commit = true)
    {
        entities.AddRange(models);
        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public Task<int> DeleteAsync(TKey id, bool commit = true)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));

        var entityToDelete = entities.SingleOrDefault(m => m.Id!.Equals(id)) ?? throw new Exception($"Deletion: Can't find record with id {id}");
        entities.Remove(entityToDelete);
        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public Task<int> DeleteAsync(IEnumerable<TKey> ids, bool commit = true)
    {
        if (!entities.Any())
        {
            throw new ArgumentNullException(nameof(entities));
        }

        var entitiesToDelete = entities.Where(e => ids.Contains(e.Id));

        entities.RemoveRange(entitiesToDelete);

        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public virtual Task<List<TEntity>> GetAllAsync() => entities.ToListAsync();

    public Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression) => entities.Where(expression).ToListAsync();

    public virtual Task<TEntity?> GetByIdAsync(TKey id) => entities.SingleOrDefaultAsync(o => o.Id!.Equals(id));

    public Task<int> GetTotalCountAsync() => entities.CountAsync();

    public Task<int> UpdateAsync(TEntity model, bool commit = true)
    {
        entities.Update(model);
        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public Task<int> UpdateAsync(IEnumerable<TEntity> models, bool commit = true)
    {
        entities.UpdateRange(models);
        return commit ? CommitAsync() : Task.FromResult(0);
    }

    public Task<int> ExecuteUpdateAsync(
        Expression<Func<TEntity, bool>> condition, 
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> changingProperties)
    {
        var result = entities
                        .Where(condition)
                        .ExecuteUpdateAsync(changingProperties);
        return result;
    }

    public Task<int> CommitAsync()
    {
        var rowsAffectedTask = context.SaveChangesAsync();
        return rowsAffectedTask;
    }
}
