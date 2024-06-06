using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;

namespace Kolpi.Admin.Pages.Questions;

public partial class AddSingle
{
    [Inject]
    public HttpClient Http { get; set; }

    [Inject]
    public NotificationService Notification { get; set; }
    
    bool isSaving = false;
    private QuestionViewModel Question = new();

    public async Task OnSave()
    {
        isSaving = true;

        //Task<HttpResponseMessage> saveTask;

        //Question.AnswerOptions = answerOptionViewModels;
        //Question.Tags = tagsSelected;

        //if (Question.Id == default)
        //{
        //    // Adding new
        //    saveTask = Http.PostAsJsonAsync("api/questions", Question);
        //}
        //else
        //{
        //    // Modify existing
        //    saveTask = Http.PutAsJsonAsync($"api/questions/{Question.Id}", Question);
        //}

        //await saveTask.ContinueWith(st =>
        //{
        //    isSaving = false;

        //    var result = st.Result;

        //    if (result.IsSuccessStatusCode)
        //    {
        //        Notification.Notify(
        //           new NotificationMessage
        //           {
        //               Summary = $"Question saved successfully",
        //               Severity = NotificationSeverity.Success,
        //               Duration = 4000
        //           });
        //    }
        //    else
        //    {
        //        Notification.Notify(
        //          new NotificationMessage
        //          {
        //              Summary = $"Error occured while saving question. Problem: {result.ReasonPhrase}",
        //              Severity = NotificationSeverity.Error,
        //              Duration = 4000
        //          });
        //    }
        //});
    }
}
