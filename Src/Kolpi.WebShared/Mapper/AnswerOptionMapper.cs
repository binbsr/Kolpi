using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;

namespace Kolpi.WebShared.Mapper
{
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
    }
}
