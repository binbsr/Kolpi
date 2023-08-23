namespace Kolpi.ApplicationCore.Entities;
public class AnswerOption : EditBase<int>
{
    public string Body { get; set; } = string.Empty;
    public bool IsAnswer  { get; set; }

    public Question Question { get; set; } = default!;
    public int QuestionId { get; set; }
}
