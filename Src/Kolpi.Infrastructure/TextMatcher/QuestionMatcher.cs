using F23.StringSimilarity;
using Kolpi.Infrastructure.Services.Questions;

namespace Kolpi.Infrastructure.TextMatcher
{
    public class QuestionMatcher
    {
        private const double MATCHING_THRESHOLD = 0.8;
        private readonly IQuestionService questionService;

        public QuestionMatcher(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        public async Task<List<string>> FindSimilar(string newQuestionBody)
        {
            var oldQuestions = await questionService.GetAllQuestionsBodyAsync();
            if (!oldQuestions.Any())
                return default!;

            // Check for similarity
            var similarQuestions = new List<string>();
            var jw = new JaroWinkler();
            foreach (var oldQuestion in oldQuestions)
            {
                double similarityIndex = jw.Similarity(newQuestionBody, oldQuestion);
                if (similarityIndex >= MATCHING_THRESHOLD)
                    similarQuestions.Add(oldQuestion);
            }

            return similarQuestions;
        }
    }
}
