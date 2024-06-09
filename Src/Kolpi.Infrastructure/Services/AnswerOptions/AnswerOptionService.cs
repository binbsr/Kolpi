using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;
using Kolpi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kolpi.Infrastructure.Services.AnswerOptions
{
    public class AnswerOptionService: AsyncService<AnswerOption, int>, IAnswerOptionService
    {
        private readonly KolpiDbContext _kolpiDbContext;
        public AnswerOptionService(KolpiDbContext kolpiDbContext) : base(kolpiDbContext)
        {
            _kolpiDbContext = kolpiDbContext;
        }

        public async Task<List<AnswerOption>> GetOptionsForQuestionAsync(int questionId)
        {
                 return await _kolpiDbContext.AnswerOptions
                 .Where(ao => ao.QuestionId == questionId)
                 .ToListAsync();
        }
    }
}
