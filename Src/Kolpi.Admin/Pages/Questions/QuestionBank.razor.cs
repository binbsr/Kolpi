using Kolpi.WebShared.ViewModels;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using System.Net.Http.Json;

namespace Kolpi.Admin.Pages.Questions;
public partial class QuestionBank
{
    [Inject]
    public HttpClient Http { get; set; }

    private bool isLoading = false;
    private int totalItems = 0;
    RadzenDataFilter<QuestionViewModel> dataFilter;
    IEnumerable<QuestionViewModel> filteredQuestions;
    IEnumerable<QuestionViewModel> questions;
    RadzenDataGrid<QuestionViewModel> questionsGrid;


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        questions = Enumerable.Empty<QuestionViewModel>();
    }

    List<string> titles = new List<string> { "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator" };
    IEnumerable<string> selectedTitles;
    IEnumerable<string> finalSelectedTitles;

    async Task OnSelectedTitlesChange(object value)
    {
        if (selectedTitles != null && !selectedTitles.Any())
        {
            selectedTitles = null;
        }

        await questionsGrid.FirstPage();
    }

    async Task ApplyFilter()
    {
        finalSelectedTitles = selectedTitles;
        await dataFilter.Filter();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await dataFilter.AddFilter(new CompositeFilterDescriptor()
            {
                Property = "Employee.LastName",
                FilterValue = "Buchanan",
                FilterOperator = FilterOperator.Contains
            });
        }
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
}
