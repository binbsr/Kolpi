using Kolpi.Server.Data;
using Kolpi.Shared.Models;
using Kolpi.Shared.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kolpi.Server.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly KolpiDbContext context;
        private DbSet<TEntity> entities;

        public Repository(KolpiDbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public void Add(TEntity model)
        {
            entities.Add(model);
        }

        public void Add(IEnumerable<TEntity> models)
        {
            entities.AddRange(models);
        }

        public void Delete(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var entityToDelete = entities.SingleOrDefault(m => GenericUtility.Compare(m.Id, id));
            entities.Remove(entityToDelete);
        }

        public void Delete(IEnumerable<TKey> ids)
        {
            if (!entities.Any()) throw new ArgumentNullException(nameof(entities));
            var entitiesToDelete = entities.Where(e => ids.Contains(e.Id));

            entities.RemoveRange(entitiesToDelete);
        }

        public IQueryable<TEntity> GetAll()
        {
            return entities.AsNoTracking();
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(TKey id)
        {
            return entities.AsNoTracking()
                .SingleOrDefaultAsync(o => GenericUtility.Compare(o.Id, id)); 
        }

        public void Update(TEntity model)
        {
            entities.Update(model);
        }

        public void Update(IEnumerable<TEntity> models)
        {
            entities.UpdateRange(models);
        }
    }
}
