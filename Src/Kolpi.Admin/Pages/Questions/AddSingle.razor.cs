
﻿using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Kolpi.ApplicationCore.Enums;  //  to resolve QuestionType reference

namespace Kolpi.Admin.Pages.Questions
{


    public partial class AddSingle : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NotificationService Notification { get; set; }

        private List<QuestionViewModel> questions = new List<QuestionViewModel>();
        private List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
        private bool isSaving;


        private QuestionViewModel Question = new();




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

        private void AddNewQuestion()
        {
            questions.Add(new QuestionViewModel
            {
                Type = QuestionType.Objective,  // This should now be recognized
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

        private List<TagViewModel> tagsSelected = new();

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


