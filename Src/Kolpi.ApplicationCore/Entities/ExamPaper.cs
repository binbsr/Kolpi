namespace Kolpi.ApplicationCore.Entities
{
    public class ExamPaper : EditBase<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public ICollection<Question> Questions  { get; set; } = default!;
    }
}
