using Kolpi.ApplicationCore.Entities;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.TagTypes
{
    public class TagTypeService : AsyncService<TagType, int>, ITagTypeService
    {
        public TagTypeService(KolpiDbContext dbContext) : base(dbContext)
        { }
    }
}
