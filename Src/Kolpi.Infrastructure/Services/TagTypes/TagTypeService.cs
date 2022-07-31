using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
