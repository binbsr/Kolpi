using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;
using System.Linq.Dynamic.Core;

namespace Kolpi.Infrastructure.Services.Questions;
public class QuestionService(KolpiDbContext dbContext) : AsyncService<Question, int>(dbContext), IQuestionService
{
    private readonly KolpiDbContext dbContext = dbContext;

    public async Task<(int Count, List<Question> Questions)> GetAllAsync(string filter, int skip, int take, string orderBy)
    {
        var query = dbContext.Set<Question>()
            .Include(t => t.Tags)
            .Include(s => s.QuestionStatus)
            .Include(x => x.AnswerOptions)
            .OrderByDescending(x => x.CreatedAt)
            .AsQueryable();        
        
        if (filter is not null and not "")
        {
            query = query.Where(filter);
        }

        if (orderBy is not null and not "")
        {
            query = query.OrderBy(orderBy);
        }

        var count = await query.CountAsync();
        var result = await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        return (count, result);
    }

    public Task<List<string>> GetAllQuestionsBodyAsync() => dbContext.Set<Question>().Select(x => x.Body).ToListAsync();

    public override Task<Question?> GetByIdAsync(int id) => dbContext.Set<Question>()
            .Include(t => t.AnswerOptions)
            .Where(o => o.Id == id).FirstOrDefaultAsync();

    //public override Task<int> AddAsync(Question model, bool commit = true)
    //{
    //    var questionTags = model.Tags.Select(x => new QuestionTag { QuestionId = model.Id, TagId = x.Id });
    //    dbContext.QuestionTags.AddRange(questionTags);

    //    return base.AddAsync(model, commit);
    //}
}
