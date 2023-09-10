using Kolpi.ApplicationCore.Enums;

namespace Kolpi.WebShared.ViewModels;
public class QuestionViewModel
{
    public int Id { get; set; }
    public string Body { get; set; } = default!;
    public string? CreatedBy { get; set; }
    public string? Created { get; set; }
    public QuestionType Type { get; set; } = QuestionType.Objective;
    public List<TagViewModel> Tags { get; set; } = default!;
    public List<AnswerOptionViewModel> AnswerOptions { get; set; } = default!;
}