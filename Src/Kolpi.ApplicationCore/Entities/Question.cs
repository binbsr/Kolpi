using Kolpi.ApplicationCore.Enums;

namespace Kolpi.ApplicationCore.Entities;
public class Question : EditBase<int>
{
    public string Body { get; set; } = string.Empty;
    public QuestionType Type { get; set; } = QuestionType.Objective;

    public int QuestionStatusId { get; set; }
    public QuestionStatus QuestionStatus { get; set; } = default!;
    public ICollection<Tag> Tags  { get; set; } = default!;
    public ICollection<AnswerOption> AnswerOptions   { get; set; } = default!;
    public ICollection<ExamPaper>? ExamPapers { get; set; } = default!;
}                                                      
