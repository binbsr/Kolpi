using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;

namespace Kolpi.WebShared.Mapper;
public static class QuestionMapper
{
    public static Question ToModel(this QuestionViewModel questionViewModel)
    {
        if (questionViewModel is null)
            return default!;

        Question question = new()
        {
            Id = questionViewModel.Id,
            Body = questionViewModel.Body,
            Type = questionViewModel.Type,
            AnswerOptions = questionViewModel.AnswerOptions.ToModel(),
            Tags = questionViewModel.Tags.ToModel()
        };

        return question;
    }

    public static QuestionViewModel ToViewModel(this Question question)
    {
        if (question is null)
            return default!;

        QuestionViewModel questionViewModel = new()
        {
            Id = question.Id,
            Body = question.Body,
            Type = question.Type,
            AnswerOptions = question.AnswerOptions?.ToViewModel() ?? default!,
            Tags = question.Tags?.ToViewModel() ?? default!
        };

        return questionViewModel;
    }

    public static List<QuestionViewModel> ToViewModel(this IEnumerable<Question> questions)
    {
        if (!questions.Any())
            return default!;

        List<QuestionViewModel> questionnModels = new();
        foreach (var model in questions)
        {
            questionnModels.Add(model.ToViewModel());
        }

        return questionnModels;
    }
}
