using Kolpi.ApplicationCore.Enums;
using System.Reflection.Emit;

namespace Kolpi.WebShared.ViewModels;
public class QuestionViewModel
{
    public int Label { get; set; }
    public int Id { get; set; }
    public string Body { get; set; } = default!;
    public string? Status { get; set; } = default!;
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public QuestionType Type { get; set; } = QuestionType.Objective;
    public List<TagViewModel> Tags { get; set; } = default!;
    public List<AnswerOptionViewModel> AnswerOptions { get; set; } = default!;
}