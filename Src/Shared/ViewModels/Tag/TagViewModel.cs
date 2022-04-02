using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kolpi.Shared.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [MinLength(2), Required]
        public string Name { get; set; }        
        
        [MinLength(5), Required]
        public string Details { get; set; }
        public bool IsFinalized { get; set; }

        public int TagTypeId { get; set; }
        
        [DisplayName("Type"), Required]
        public string TagTypeName { get; set; }

        [DisplayName("Color Code")]
        public string TagColorCode { get; set; }

        [DisplayName("Created")]
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        [DisplayName("Modified")]
        public string ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
