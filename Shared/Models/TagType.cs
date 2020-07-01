using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class TagType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string ColorCode { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
