using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class TagType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
