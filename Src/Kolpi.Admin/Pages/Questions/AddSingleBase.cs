using Kolpi.ApplicationCore.Enums;
using Kolpi.WebShared.ViewModels;
using System.Net.Http.Json;

namespace Kolpi.Admin.Pages.Questions
{
    public class AddSingleBase
    {

        protected override async Task OnInitializedAsync()
        {
            questions.Add(new QuestionViewModel
            {
                Type = QuestionType.Objective,  // This should now be recognized
                AnswerOptions = new List<AnswerOptionViewModel> { new(), new(), new(), new() }
            });

            var result = await Http.GetFromJsonAsync<TagsMetaViewModel>($"api/tags?take=999999") ?? new TagsMetaViewModel();
            Tags = result.Records;
        }
    }
}