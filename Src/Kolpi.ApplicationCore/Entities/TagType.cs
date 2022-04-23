using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class TagType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string ColorCode { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
