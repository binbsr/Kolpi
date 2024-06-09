using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;
using Kolpi.Infrastructure.Data;

namespace Kolpi.Infrastructure.Services.AnswerOptions
{
    public class AnswerOptionService: AsyncService<AnswerOption, int>, IAnswerOptionService
    {
        public AnswerOptionService(KolpiDbContext kolpiDbContext): base(kolpiDbContext)
        {
        }
    }
}
