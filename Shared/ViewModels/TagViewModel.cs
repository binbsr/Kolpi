using System;
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
        
        [DisplayName("Tag Type")]
        public string TagTypeName { get; set; }

        [DisplayName("Tag Color")]
        public string TagColorCode { get; set; }

        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Modified At")]
        public DateTime ModifiedAt { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
