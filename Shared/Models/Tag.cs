using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class Tag : EditBase<int>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsFinalized { get; set; }

        public TagType TagType { get; set; }

        public List<QuestionTag> QuestionTags { get; set; }
    }
}
