using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.AnswerOptions
{
    public interface IAnswerOptionService: IAsyncService<AnswerOption, int>
    {
        Task<List<AnswerOption>> GetOptionsForQuestionAsync(int questionId);
    }
}
