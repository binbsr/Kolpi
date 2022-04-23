using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolpi.Infrastructure.Data;

namespace Kolpi.ApplicationCore.Services
{
    public class TagService : AsyncService<Tag, int>, ITagService
    {
        private readonly KolpiDbContext dbContext;

        public TagService(KolpiDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Tag>> GetAllAsync(int pageIndex, int pageSize)
        {
            int skipCount = (pageIndex - 1) * pageSize;

            return dbContext.Set<Tag>()
                .Include(t => t.TagType)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<List<Tag>> GetAllAsync(string searchText, int pageIndex, int pageSize)
        {
            int skipCount = (pageIndex - 1) * pageSize;

            return dbContext.Set<Tag>()
                .Where(t => EF.Functions.Like(t.Name, $"%{searchText}%"))
                .Include(t => t.TagType)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();
        }

        public override Task<Tag> GetByIdAsync(int id)
        {
            return dbContext.Set<Tag>()
                .Include(t => t.TagType)
                .SingleOrDefaultAsync(o => o.Id.Equals(id));
        }
    }
}
