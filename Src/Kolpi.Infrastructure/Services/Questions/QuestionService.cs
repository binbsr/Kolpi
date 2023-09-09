using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;
using System.Linq.Dynamic.Core;

namespace Kolpi.Infrastructure.Services.Questions;
public class QuestionService : AsyncService<Question, int>, IQuestionService
{
    private readonly KolpiDbContext dbContext;

    public QuestionService(KolpiDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<(int Count, List<Question> Questions)> GetAllAsync(string filter, int skip, int take, string orderBy)
    {
        var query = dbContext.Set<Question>().Include(t => t.Tags).AsQueryable();
        if (filter is not null and not "")
        {
            query = query.Where(filter);
        }

        if (orderBy is not null and not "")
        {
            query = query.OrderBy(orderBy);
        }

        var count = await query.CountAsync();
        var result = await query.Skip(skip).Take(take).ToListAsync();
        return (count, result);
    }

    public Task<List<string>> GetAllQuestionsBodyAsync() => dbContext.Set<Question>().Select(x => x.Body).ToListAsync();

    public override Task<Question?> GetByIdAsync(int id) => dbContext.Set<Question>()
            .Include(t => t.AnswerOptions)
            .Where(o => o.Id.Equals(id)).FirstOrDefaultAsync();
}
