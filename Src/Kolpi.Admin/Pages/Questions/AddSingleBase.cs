using Kolpi.ApplicationCore.Enums;
using Kolpi.WebShared.ViewModels;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Kolpi.Admin.Pages.Questions
{
    public class AddSingleBase : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        protected List<QuestionViewModel> questions = new List<QuestionViewModel>();
        protected List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();

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