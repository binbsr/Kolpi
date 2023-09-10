using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Kolpi.Admin.Pages.Questions;
public partial class QuestionBank
{
    [Inject]
    public HttpClient Http { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    private bool isLoading = false;
    private int totalItems = 0;
    List<QuestionViewModel> questions;
    RadzenDataGrid<QuestionViewModel> questionsGrid;
    IEnumerable<string> selectedTags;
    List<string> tags;

    async Task OnSelectedTagsChange(object value)
    {
        if (selectedTags != null && !selectedTags.Any())
        {
            selectedTags = null;
        }

        await questionsGrid.FirstPage();
    }

    async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;

        string url = $"api/questions?filter={args.Filter}&skip={args.Skip.Value}&take={args.Top.Value}&orderBy={args.OrderBy}";
        var result = await Http.GetFromJsonAsync<QuestionsMetaViewModel>(url) ?? new QuestionsMetaViewModel();

        totalItems = result.TotalCount;
        questions = result.Records;

        tags = await Http.GetFromJsonAsync<List<string>>("api/tags/names") ?? new List<string>();

        isLoading = false;
    }

    private void AddNewQuestion()
    {
        Navigation.NavigateTo("/question/add");
    }
}
