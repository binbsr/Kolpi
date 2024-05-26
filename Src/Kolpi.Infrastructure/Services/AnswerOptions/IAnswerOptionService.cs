using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kolpi.Infrastructure.Services.AnswerOptions
{
    public interface IAnswerOptionService: IAsyncService<AnswerOption, int>
    {
        Task<List<AnswerOption>> GetOptionsForQuestionAsync(int questionId);
    }
}
