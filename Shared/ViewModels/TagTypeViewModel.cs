using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kolpi.Shared.ViewModels
{
    public class TagTypeViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("TagTpye Name")]
        [MinLength(2), Required]
        public string Name { get; set; }

        [DisplayName("Summary")]
        [MinLength(5), Required]
        public string Details { get; set; }

        [DisplayName("Color Code")]
        public string ColorCode { get; set; }
    }
}
