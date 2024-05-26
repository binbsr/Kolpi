using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;

namespace Kolpi.WebShared.Mapper;
public static class AnswerOptionMapper
{
    public static AnswerOption ToModel(this AnswerOptionViewModel answerOptionViewModel)
    {
        if (answerOptionViewModel is null)
            return default!;
        AnswerOption answerOption = new()
        {
            Id = answerOptionViewModel.Id,
            IsAnswer = answerOptionViewModel.IsAnswer,
            Type = answerOptionViewModel.Type,
            Body = answerOptionViewModel.Body
        };

        return answerOption;
    }

    public static List<AnswerOption> ToModel(this IEnumerable<AnswerOptionViewModel> answerOptionViewModels)
    {
        if (!answerOptionViewModels.Any())
            return default!;

        List<AnswerOption> answerOptionModels = new();
        foreach (var model in answerOptionViewModels)
        {
            answerOptionModels.Add(model.ToModel());
        }

        return answerOptionModels;
    }

    public static AnswerOptionViewModel ToViewModel(this AnswerOption answerOption)
    {
        if (answerOption is null)
            return default!;

        AnswerOptionViewModel answerOptionViewModel = new()
        {
            Id = answerOption.Id,
            IsAnswer = answerOption.IsAnswer,
            Type = answerOption.Type,
            Body = answerOption.Body
        };

        return answerOptionViewModel;
    }

    public static List<AnswerOptionViewModel> ToViewModel(this IEnumerable<AnswerOption> answerOptions)
    {
        if(!answerOptions.Any())
            return default!;

        List<AnswerOptionViewModel> answerOptionViewModels = new();
        foreach (var model in answerOptions)
        {
            answerOptionViewModels.Add(model.ToViewModel());
        }

        return answerOptionViewModels;
    }
}
