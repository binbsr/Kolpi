namespace Kolpi.ApplicationCore.Entities
{
    public class Exam : EditBase<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime StartsAt { get; set; }
        public byte DurationHours { get; set; }
        public string Attendees { get; set; } = string.Empty;

        public virtual ICollection<ExamPaper> ExamPapers  { get; set; } = default!;
    }
}
