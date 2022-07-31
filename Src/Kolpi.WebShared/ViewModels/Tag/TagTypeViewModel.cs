using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kolpi.WebShared.ViewModels
{
    public class TagTypeViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("Tagtpye Name")]
        [MinLength(2), Required]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Details")]
        [MinLength(5), Required]
        public string Details { get; set; } = string.Empty;

        [DisplayName("Color Code")]
        public string ColorCode { get; set; } = string.Empty;
    }
}
