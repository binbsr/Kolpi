using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;
using System.Linq.Dynamic.Core;

namespace Kolpi.Infrastructure.Services.Tags
{
    public class TagService : AsyncService<Tag, int>, ITagService
    {
        private readonly KolpiDbContext dbContext;

        public TagService(KolpiDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<(int Count, List<Tag> Tags)> GetAllAsync(string filter, int skip, int take, string orderBy)
        {
            var query = dbContext.Set<Tag>().Include(t => t.TagType).AsQueryable();
            if (filter is not null and not "")
            {
                query = query.Where(filter);
            }

            if (orderBy is not null and not "")
            {
                query = query.OrderBy(orderBy);
            }

            var count = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();
            return (count, result);
        }

        public override Task<Tag?> GetByIdAsync(int id) => dbContext.Set<Tag>()
            .Include(t => t.TagType)
            .Where(o => o.Id == id).FirstOrDefaultAsync();
        
        public void AttachTags(IEnumerable<Tag> tags)
        {
            dbContext.Tags.AttachRange(tags);
        }
    }
}
