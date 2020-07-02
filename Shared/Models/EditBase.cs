using System;

namespace Kolpi.Shared.Models
{
    public class EditBase<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
