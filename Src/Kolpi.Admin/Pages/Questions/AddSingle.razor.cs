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

    private QuestionViewModel Question = new();
    List<AnswerOptionViewModel> answerOptionViewModels = new() { new(), new(), new(), new() };
    private List<TagViewModel> Tags { get; set; } = default!;
    List<TagViewModel> tagsSelected = new();
    bool isSaving = false;

    protected override async Task OnInitializedAsync()
    {
        var result = await Http.GetFromJsonAsync<TagsFilteredViewModel>($"api/tags?take=999999") ?? new TagsFilteredViewModel();
        Tags = result.Records;
    }

    public void AddNewOption()
    {
        answerOptionViewModels.Add(new());
    }

    public void DeleteAnsOption(AnswerOptionViewModel answerOptionViewModel)
    {
        answerOptionViewModels.Remove(answerOptionViewModel);
    }

    public async Task OnSave()
    {
        isSaving = true;

        Task<HttpResponseMessage> saveTask;

        Question.AnswerOptions = answerOptionViewModels;
        Question.Tags = tagsSelected;

        if (Question.Id == default)
        {
            // Adding new
            saveTask = Http.PostAsJsonAsync("api/questions", Question);
        }
        else
        {
            // Modify existing
            saveTask = Http.PutAsJsonAsync($"api/questions/{Question.Id}", Question);
        }

        await saveTask.ContinueWith(st =>
        {
            isSaving = false;

            var result = st.Result;

            if (result.IsSuccessStatusCode)
            {
                Notification.Notify(
                   new NotificationMessage
                   {
                       Summary = $"Question saved successfully",
                       Severity = NotificationSeverity.Success,
                       Duration = 4000
                   });
            }
            else
            {
                Notification.Notify(
                  new NotificationMessage
                  {
                      Summary = $"Error occured while saving question. Problem: {result.ReasonPhrase}",
                      Severity = NotificationSeverity.Error,
                      Duration = 4000
                  });
            }
        });
    }


    public async Task<IEnumerable<TagViewModel>> Search(string value)
    {
        List<TagViewModel> emptyModel = new();

        if (string.IsNullOrWhiteSpace(value))
            return emptyModel;

        Tags = await Http.GetFromJsonAsync<List<TagViewModel>>($"api/tags?searchText={value}") ?? emptyModel;
        return Tags;
    }

    public void OnInput(string body)
    {

    }
}
