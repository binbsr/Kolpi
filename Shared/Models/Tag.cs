namespace Kolpi.Shared.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
