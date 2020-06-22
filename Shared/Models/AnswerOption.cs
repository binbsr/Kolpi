namespace Kolpi.Shared.Models
{
    public class AnswerOption : EditBase
    {
        public string Body { get; set; }
        public bool IsAnswer  { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
