using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolpi.Infrastructure.Data;

namespace Kolpi.ApplicationCore.Services
{
    public class TagTypeService : AsyncService<TagType, int>, ITagTypeService
    {
        public TagTypeService(KolpiDbContext dbContext) : base(dbContext)
        { }
    }
}
