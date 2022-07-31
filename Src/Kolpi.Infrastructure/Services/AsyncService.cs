using Kolpi.ApplicationCore.Entities;
using Kolpi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kolpi.ApplicationCore.Services
{
    public abstract class AsyncService<TEntity, TKey> : IAsyncService<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly KolpiDbContext context;
        private DbSet<TEntity> entities;
        
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

            var entityToDelete = entities.SingleOrDefault(m => m.Id.Equals(id));
            if (entityToDelete == null)
                throw new Exception($"Deletion: Can't find record with id {id}");

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

        public virtual Task<List<TEntity>> GetAllAsync() => entities.ToListAsync();

        public Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression) => entities.Where(expression).ToListAsync();

        public virtual Task<TEntity?> GetByIdAsync(TKey id) => entities.SingleOrDefaultAsync(o => o.Id.Equals(id));

        public Task<int> GetTotalCountAsync() => entities.CountAsync();

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
