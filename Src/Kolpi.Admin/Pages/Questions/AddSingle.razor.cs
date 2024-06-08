//using Kolpi.WebShared.ViewModels;
//using Microsoft.AspNetCore.Components;
//using Radzen;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using Kolpi.ApplicationCore.Enums;

//namespace Kolpi.Admin.Pages.Questions
//{
//    public partial class AddSingle : ComponentBase
//    {
//        [Inject]
//        public HttpClient Http { get; set; } = default!;

//        [Inject]
//        public NotificationService Notification { get; set; } = default!;

//        private List<QuestionViewModel> questions = new();
//        private List<TagViewModel> Tags { get; set; } = new();
//        private List<TagViewModel> tagsSelected = new();
//        private bool isSaving;

//        protected override async Task OnInitializedAsync()
//        {
//            AddNewQuestion();
//            var result = await Http.GetFromJsonAsync<TagsMetaViewModel>("api/tags?take=999999") ?? new TagsMetaViewModel();
//            Tags = result.Records;
//        }

//        private void AddNewQuestion()
//        {
//            questions.Add(new QuestionViewModel
//            {
//                Type = QuestionType.Objective,
//                AnswerOptions = new List<AnswerOptionViewModel> { new(), new(), new(), new() }
//            });
//        }

//        private void RemoveQuestion(QuestionViewModel question)
//        {
//            questions.Remove(question);
//        }

//        private async Task OnSave()
//        {
//            isSaving = true;

//            foreach (var question in questions)
//            {
//                question.Tags = tagsSelected;
//                var response = question.Id == default
//                    ? await Http.PostAsJsonAsync("api/questions", question)
//                    : await Http.PutAsJsonAsync($"api/questions/{question.Id}", question);

//                if (response.IsSuccessStatusCode)
//                {
//                    Notification.Notify(new NotificationMessage
//                    {
//                        Summary = $"Question {question.Id} saved successfully",
//                        Severity = NotificationSeverity.Success,
//                        Duration = 4000
//                    });
//                }
//                else
//                {
//                    Notification.Notify(new NotificationMessage
//                    {
//                        Summary = $"Error saving question {question.Id}: {response.ReasonPhrase}",
//                        Severity = NotificationSeverity.Error,
//                        Duration = 4000
//                    });
//                }
//            }

//            isSaving = false;
//        }

//        public async Task<IEnumerable<TagViewModel>> Search(string value)
//        {
//            if (string.IsNullOrWhiteSpace(value))
//                return new List<TagViewModel>();

//            Tags = await Http.GetFromJsonAsync<List<TagViewModel>>($"api/tags?searchText={value}") ?? new List<TagViewModel>();
//            return Tags;
//        }

//        public void AddNewOption(QuestionViewModel question)
//        {
//            question.AnswerOptions.Add(new AnswerOptionViewModel());
//        }

//        public void DeleteAnsOption(QuestionViewModel question, AnswerOptionViewModel option)
//        {
//            question.AnswerOptions.Remove(option);
//        }
//    }
//}

using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Kolpi.ApplicationCore.Enums;

namespace Kolpi.Admin.Pages.Questions
{
    public partial class AddSingle : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; } = default!;

        [Inject]
        public NotificationService Notification { get; set; } = default!;

        private List<QuestionViewModel> questions = new();
        private List<TagViewModel> Tags { get; set; } = new();
        private List<TagViewModel> tagsSelected = new();
        private bool isSaving;

        protected override async Task OnInitializedAsync()
        {
            AddNewQuestion();
            var result = await Http.GetFromJsonAsync<TagsMetaViewModel>("api/tags?take=999999") ?? new TagsMetaViewModel();
            Tags = result.Records;
        }

        private void AddNewQuestion()
        {
            questions.Add(new QuestionViewModel
            {
                Type = QuestionType.Objective,
                AnswerOptions = new List<AnswerOptionViewModel> { new(), new(), new(), new() }
            });
        }

        private void RemoveQuestion(QuestionViewModel question)
        {
            questions.Remove(question);
        }

        private async Task OnSave()
        {
            isSaving = true;

            foreach (var question in questions)
            {
                question.Tags = tagsSelected;
                var response = question.Id == default
                    ? await Http.PostAsJsonAsync("api/questions", question)
                    : await Http.PutAsJsonAsync($"api/questions/{question.Id}", question);

                if (response.IsSuccessStatusCode)
                {
                    Notification.Notify(new NotificationMessage
                    {
                        Summary = $"Question {question.Id} saved successfully",
                        Severity = NotificationSeverity.Success,
                        Duration = 4000
                    });
                }
                else
                {
                    Notification.Notify(new NotificationMessage
                    {
                        Summary = $"Error saving question {question.Id}: {response.ReasonPhrase}",
                        Severity = NotificationSeverity.Error,
                        Duration = 4000
                    });
                }
            }

            isSaving = false;
        }

        public async Task<IEnumerable<TagViewModel>> Search(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<TagViewModel>();

            Tags = await Http.GetFromJsonAsync<List<TagViewModel>>($"api/tags?searchText={value}") ?? new List<TagViewModel>();
            return Tags;
        }

        public void AddNewOption(QuestionViewModel question)
        {
            question.AnswerOptions.Add(new AnswerOptionViewModel());
        }

        public void DeleteAnsOption(QuestionViewModel question, AnswerOptionViewModel option)
        {
            question.AnswerOptions.Remove(option);
        }
    }
}
