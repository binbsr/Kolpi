using System.Collections.Generic;

namespace Kolpi.Shared.ViewModels
{
    public class FilteredViewModel<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Records { get; set; }
    }
}