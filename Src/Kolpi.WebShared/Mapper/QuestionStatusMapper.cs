using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels.Question;

namespace Kolpi.WebShared.Mapper;
public static class QuestionStatusMapper
{
    public static QuestionStatusViewModel ToViewModel(this QuestionStatus questionStatus)
    {
        if (questionStatus is null)
            return new();

        QuestionStatusViewModel questionStatusViewModel = new()
        {
            Id = questionStatus.Id,
            Name = questionStatus.Name
        };

        return questionStatusViewModel;
    }

    public static List<QuestionStatusViewModel> ToViewModel(this IEnumerable<QuestionStatus> questionStatuses)
    {
        if (!questionStatuses.Any())
            return new();

        List<QuestionStatusViewModel> questionStatusModels = new();
        foreach (var model in questionStatuses)
        {
            questionStatusModels.Add(model.ToViewModel());
        }

        return questionStatusModels;
    }
}
