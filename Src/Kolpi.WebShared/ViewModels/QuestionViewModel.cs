using Kolpi.ApplicationCore.Enums;

namespace Kolpi.WebShared.ViewModels;
public class QuestionViewModel
{
    public int Id { get; set; }
    public string Body { get; set; } = default!;
    public string? Status { get; set; } = default!;
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public QuestionType Type { get; set; } = QuestionType.Objective;
    public List<TagViewModel> Tags { get; set; } = default!;
    public List<AnswerOptionViewModel> AnswerOptions { get; set; } = default!;
<<<<<<< HEAD
    public int NumberOfOptions => AnswerOptions?.Count ?? 0;   
=======
    public int NumberOfOptions => AnswerOptions?.Count ?? 0;
   

    
>>>>>>> 0dbbb259ba7e3a346721613526c57050f8aa3fe3
 }
