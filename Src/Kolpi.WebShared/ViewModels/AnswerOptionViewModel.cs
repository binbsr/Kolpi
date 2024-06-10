using Kolpi.ApplicationCore.Enums;

namespace Kolpi.WebShared.ViewModels;
public class AnswerOptionViewModel
{
    public string Label { get; set; }
    public int Id { get; set; }
    public string Body { get; set; } = string.Empty;
    public bool IsAnswer  { get; set; }
    public AnswerType Type { get; set; } = AnswerType.ShortText;
}
