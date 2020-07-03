using System;

namespace Kolpi.Shared.Models
{
    public class EditBase<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }

        public EditBase<TKey> AddCreatedStamps(string createdBy)
        {
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;
            return this;
        }

        public EditBase<TKey> AddModifiedStamps(string modifiedBy)
        {
            ModifiedBy = modifiedBy;
            ModifiedAt = DateTime.Now;
            return this;
        }
    }
}
