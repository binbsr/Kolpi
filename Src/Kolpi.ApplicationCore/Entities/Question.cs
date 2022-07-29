namespace Kolpi.ApplicationCore.Entities
{
    public class Question : EditBase<int>
    {
        public string Body { get; set; }

        public int QuestionStatusId { get; set; }
        public QuestionStatus QuestionStatus { get; set; }

        public ICollection<Tag> Tags  { get; set; }
        public ICollection<AnswerOption> AnswerOptions   { get; set; }
        public ICollection<ExamPaper> ExamPapers { get; set; }
    }
}
