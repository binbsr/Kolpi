using Kolpi.ApplicationCore.Entities;
using Kolpi.ApplicationCore.Services;
using Kolpi.Infrastructure.Data;

namespace Kolpi.Infrastructure.Services.Questions;
public class QuestionStatusService: AsyncService<QuestionStatus, int>
{
    private readonly KolpiDbContext dbContext;

    public QuestionStatusService(KolpiDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
