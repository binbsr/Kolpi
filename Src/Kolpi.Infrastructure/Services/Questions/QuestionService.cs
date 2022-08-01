using Kolpi.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Kolpi.Infrastructure.Data;
using Kolpi.ApplicationCore.Services;

namespace Kolpi.Infrastructure.Services.Questions
{
    public class QuestionService : AsyncService<Question, int>, IQuestionService
    {
        private readonly KolpiDbContext dbContext;

        public QuestionService(KolpiDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<Question>> GetAllAsync(int pageIndex, int pageSize)
        {
            int skipCount = pageIndex * pageSize;

            var results = dbContext.Set<Question>()
                .Include(t => t.AnswerOptions)
                .Skip(skipCount)
                .Take(pageSize)
                .OrderBy(x => x.Body)
                .ToListAsync();
            return results;
        }

        public Task<List<Question>> GetAllAsync(string searchText, int pageIndex, int pageSize)
        {
            int skipCount = pageIndex * pageSize;

            return dbContext.Set<Question>()
                .Where(t => EF.Functions.Like(t.Body, $"%{searchText}%"))
                .Include(t => t.AnswerOptions)
                .Skip(skipCount)
                .Take(pageSize)
                .OrderBy(x => x.Body)
                .ToListAsync();
        }

        public Task<List<string>> GetAllQuestionsBodyAsync() => dbContext.Set<Question>().Select(x => x.Body).ToListAsync();

        public override Task<Question?> GetByIdAsync(int id) => dbContext.Set<Question>()
                .Include(t => t.AnswerOptions)
                .Where(o => o.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
