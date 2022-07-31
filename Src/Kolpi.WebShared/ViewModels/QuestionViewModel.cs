using Kolpi.ApplicationCore.Enums;

namespace Kolpi.WebShared.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public List<TagViewModel> Tags { get; set; } = default!;
        public List<AnswerOptionViewModel> AnswerOptions { get; set; } = default!;
        public QuestionType QuestionType { get; set; }
    }
}