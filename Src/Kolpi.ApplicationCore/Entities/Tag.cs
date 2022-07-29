using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class Tag : EditBase<int>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsFinalized { get; set; }

        public int TagTypeId { get; set; }
        public TagType TagType { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
