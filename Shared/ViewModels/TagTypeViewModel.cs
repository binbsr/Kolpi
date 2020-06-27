using System.ComponentModel;

namespace Kolpi.Shared.ViewModels
{
    public class TagTypeViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("Tag-Tpye Name")]
        public string Name { get; set; }

        [DisplayName("Summary")]
        public string Details { get; set; }
    }
}
