namespace Kolpi.WebShared.ViewModels;
public class MetaViewModel<T> where T : class
{
    public int TotalCount { get; set; }
    public List<T> Records { get; set; } = default!;
}