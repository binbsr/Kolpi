using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class TagType : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;

        public ICollection<Tag> Tags { get; set; } = default!;
    }
}
