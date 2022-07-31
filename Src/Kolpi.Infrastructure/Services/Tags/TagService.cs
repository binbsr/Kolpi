﻿using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.Tags
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
            int skipCount = pageIndex * pageSize;

            var results = dbContext.Set<Tag>()
                .Include(t => t.TagType)
                .Skip(skipCount)
                .Take(pageSize)
                .OrderBy(x => x.Name)
                .ToListAsync();
            return results;
        }

        public Task<List<Tag>> GetAllAsync(string searchText, int pageIndex, int pageSize)
        {
            int skipCount = pageIndex * pageSize;

            return dbContext.Set<Tag>()
                .Where(t => EF.Functions.Like(t.Name, $"%{searchText}%"))
                .Include(t => t.TagType)
                .Skip(skipCount)
                .Take(pageSize)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override Task<Tag?> GetByIdAsync(int id) => dbContext.Set<Tag>()
            .Include(t => t.TagType)
            .Where(o => o.Id == id).FirstOrDefaultAsync();
    }
}
