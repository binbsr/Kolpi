using Kolpi.Server.Data;
using Kolpi.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.Server.ApplicationCore.Services
{
    public class TagTypeService : AsyncService<TagType, int>, ITagTypeService
    {
        public TagTypeService(KolpiDbContext dbContext) : base(dbContext)
        { }
    }
}
