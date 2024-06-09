using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.Questions
{
    public interface IQuestionService : IAsyncService<Question, int>
    {
        Task<(int Count, List<Question> Questions)> GetAllAsync(string filter, int skip, int take, string orderBy);
        Task<List<string>> GetAllQuestionsBodyAsync();
        Task<Question?> GetByIdAsync(int id);
    }
}
