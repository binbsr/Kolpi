using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.Tags;
public interface ITagService : IAsyncService<Tag, int>
{
    Task<(int Count, List<Tag> Tags)> GetAllAsync(string filter, int skip, int take, string orderBy);
}
