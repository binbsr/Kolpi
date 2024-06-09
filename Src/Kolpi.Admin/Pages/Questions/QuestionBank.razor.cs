using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using System.Net.Http.Json;
using Kolpi.WebShared.ViewModels.Question;

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
    IList<QuestionViewModel> selectedQuestions;
    RadzenDataGrid<QuestionViewModel> questionsGrid;
    IEnumerable<int> selectedTags;
    List<TagViewModel> tags;
    IEnumerable<int> selectedStatuses;
    List<QuestionStatusViewModel> statuses;

    bool allowRowSelectOnRowClick = true;

    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        tags = await Http.GetFromJsonAsync<List<TagViewModel>>("api/tags/names") ?? new List<TagViewModel>();
        statuses = await Http.GetFromJsonAsync<List<QuestionStatusViewModel>>("api/questionstatuses") ?? new List<QuestionStatusViewModel>();
        isLoading = false;
    }

    async Task OnSelectedTagsChange(object value)
    {
        if (selectedTags != null && !selectedTags.Any())
        {
            selectedTags = null;
        }

        await questionsGrid.FirstPage();
    }

    async Task OnSelectedStatusesChange(object value)
    {
        if (selectedStatuses != null && !selectedStatuses.Any())
        {
            selectedStatuses = null;
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

        isLoading = false;
    }
    private void AddNewQuestion()
    {
        Navigation.NavigateTo("/question/add");
    }
}
