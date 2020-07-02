using Kolpi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.Server.ApplicationCore.Services
{
    public interface ITagService : IAsyncService<Tag, int>
    {
        Task<List<Tag>> GetAllAsync(int pageIndex, int pageSize);
    }
}
