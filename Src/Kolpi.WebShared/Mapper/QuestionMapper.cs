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
}
