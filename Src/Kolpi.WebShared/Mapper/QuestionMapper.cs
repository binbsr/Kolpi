using Kolpi.ApplicationCore.Entities;
using Kolpi.Shared.Extentions;
using Kolpi.WebShared.ViewModels;

namespace Kolpi.WebShared.Mapper;
public static class QuestionMapper
{
    public static Question ToModel(this QuestionAddViewModel questionViewModel)
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

    public static QuestionAddViewModel ToAddViewModel(this Question question)
    {
        if (question is null)
            return default!;

        QuestionAddViewModel questionViewModel = new()
        {
            Id = question.Id,
            Body = question.Body,
            Type = question.Type,
            Status = question.QuestionStatus?.Name ?? "N/A",
            CreatedBy = question.CreatedBy ?? "N/A",
            CreatedAt = question.CreatedAt,
            AnswerOptions = question.AnswerOptions?.ToViewModel() ?? default!,
            Tags = question.Tags?.ToViewModel() ?? default!
        };

        return questionViewModel;
    }

    public static QuestionGetViewModel ToGetViewModel(this Question question)
    {
        if (question is null)
            return default!;

        QuestionGetViewModel questionViewModel = new()
        {
            Id = question.Id,
            Body = question.Body,
            Type = question.Type,
            Status = question.QuestionStatus?.Name ?? "N/A",
            CreatedBy = question.CreatedBy ?? "N/A",
            CreatedAt = question.CreatedAt,
            TotalOptions = question.AnswerOptions?.Count ?? 0,
            Answers = question.AnswerOptions?.Where(x => x.IsAnswer).Count() ?? 0,
            Tags = question.Tags?.Select(x => new TagDropdownViewModel { Id = x.Id, Name = x.Name, ColorCode = x.TagType?.ColorCode ?? "" }) ?? []
        };

        return questionViewModel;
    }

    public static List<QuestionAddViewModel> ToViewModel(this IEnumerable<Question> questions)
    {
        if (!questions.Any())
            return default!;

        List<QuestionAddViewModel> questionnModels = new();
        foreach (var model in questions)
        {
            questionnModels.Add(model.ToAddViewModel());
        }

        return questionnModels;
    }

    public static List<QuestionGetViewModel> ToGetViewModel(this IEnumerable<Question> questions)
    {
        if (!questions.Any())
            return default!;

        List<QuestionGetViewModel> questionnModels = new();
        foreach (var model in questions)
        {
            questionnModels.Add(model.ToGetViewModel());
        }

        return questionnModels;
    }

    public static List<Question> ToModel(this IEnumerable<QuestionAddViewModel> questionViewModels)
    {
        if (!questionViewModels.Any())
            return default!;

        List<Question> questions = new();
        foreach (var questionViewModel in questionViewModels)
        {
            questions.Add(questionViewModel.ToModel());
        }

        return questions;
    }
}
