using Kolpi.ApplicationCore.Enums;

namespace Kolpi.WebShared.ViewModels;
public class QuestionGetViewModel
{
    public int Id { get; set; }
    public string Body { get; set; } = "";
    public string? Status { get; set; } = "";
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public QuestionType Type { get; set; } = QuestionType.Objective;
    public string[] Tags { get; set; } = [];
    public int TotalOptions { get; set; }
    public int Answers { get; set; }
}