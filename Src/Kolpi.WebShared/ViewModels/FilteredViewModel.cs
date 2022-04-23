using System.Collections.Generic;

namespace Kolpi.WebShared.ViewModels
{
    public class FilteredViewModel<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Records { get; set; }
    }
}