using Kolpi.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.ApplicationCore.Services
{
    public interface ITagService : IAsyncService<Tag, int>
    {
        Task<List<Tag>> GetAllAsync(int pageIndex, int pageSize);
        Task<List<Tag>> GetAllAsync(string searchText, int pageIndex, int pageSize);
    }
}
