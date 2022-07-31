using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.Infrastructure.Services.TagTypes
{
    public interface ITagTypeService : IAsyncService<TagType, int>
    {

    }
}
