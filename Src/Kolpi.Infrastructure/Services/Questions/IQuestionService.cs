using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.Questions
{
    public interface IQuestionService : IAsyncService<Question, int>
    {
        Task<List<Question>> GetAllAsync(int pageIndex, int pageSize);
        Task<List<Question>> GetAllAsync(string searchText, int pageIndex, int pageSize);
        Task<List<string>> GetAllQuestionsBodyAsync();
    }
}
