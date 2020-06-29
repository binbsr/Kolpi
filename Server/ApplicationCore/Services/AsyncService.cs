﻿using Kolpi.Server.Data;
using Kolpi.Shared.Models;
using Kolpi.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kolpi.Server.ApplicationCore.Services
{
    public abstract class AsyncService<TEntity, TKey> : IAsyncService<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly KolpiDbContext context;
        private DbSet<TEntity> entities;

        public AsyncService() { }

        public AsyncService(KolpiDbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public Task<int> AddAsync(TEntity model)
        {
            entities.Add(model);
            return context.SaveChangesAsync();
        }

        public Task<int> AddAsync(IEnumerable<TEntity> models)
        {
            entities.AddRange(models);
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var entityToDelete = entities.SingleOrDefault(m => GenericUtility.Compare(m.Id, id));
            entities.Remove(entityToDelete);
            return context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(IEnumerable<TKey> ids)
        {
            if (!entities.Any()) throw new ArgumentNullException(nameof(entities));
            var entitiesToDelete = entities.Where(e => ids.Contains(e.Id));

            entities.RemoveRange(entitiesToDelete);

            return context.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return entities.AsNoTracking()
                .ToListAsync();
        }

        public Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression)
                .ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return entities.AsNoTracking()
                .SingleOrDefaultAsync(o => GenericUtility.Compare(o.Id, id));
        }

        public Task<int> UpdateAsync(TEntity model)
        {
            entities.Update(model);
            return context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(IEnumerable<TEntity> models)
        {
            entities.UpdateRange(models);
            return context.SaveChangesAsync();
        }
    }
}
