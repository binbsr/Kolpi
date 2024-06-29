using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using System.Net.Http.Json;
using Kolpi.WebShared.ViewModels.Question;

namespace Kolpi.Client.Pages.Questions;
public partial class QuestionBank
{
    [Inject]
    public HttpClient Http { get; set; } = default!;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    private bool isLoading = false;
    private int totalItems = 0;
    List<QuestionGetViewModel> questions = default!;
    IList<QuestionGetViewModel>? selectedQuestions = default!;
    RadzenDataGrid<QuestionGetViewModel> questionsGrid = default!;
    IEnumerable<int>? selectedTags = default!;
    IEnumerable<int>? selectedSecondTags = default!;
    List<TagDropdownViewModel> tags = default!;
    IEnumerable<int>? selectedStatuses = default!;
    List<QuestionStatusViewModel> statuses = default!;

    bool allowRowSelectOnRowClick = true;

    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        tags = await Http.GetFromJsonAsync<List<TagDropdownViewModel>>("api/tags/dropdownitems") ?? [];
        statuses = await Http.GetFromJsonAsync<List<QuestionStatusViewModel>>("api/questionstatuses") ?? [];
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
    async Task OnSelectedSecondTagsChange(object value)
    {
        if (selectedSecondTags != null && !selectedSecondTags.Any())
        {
            selectedSecondTags = null;
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

    async Task FilterCleared()
    {
        selectedTags = null!;
        selectedSecondTags = null!;
        await questionsGrid.FirstPage();
    }

    async Task LoadData(LoadDataArgs args)
    {
        isLoading = true;

        string url = $"api/questions?filter={args.Filter}&skip={args.Skip ?? 0}&take={args.Top ?? 10}&orderBy={args.OrderBy}";
        var result = await Http.GetFromJsonAsync<QuestionsMetaViewModel>(url) ?? new();

        totalItems = result.TotalCount;
        questions = result.Records;
       
        isLoading = false;
    }

    private void AddNewQuestion()
    {
        Navigation.NavigateTo("/questions/add");
    }
}
