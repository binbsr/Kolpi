using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class Tag : EditBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public bool IsFinalized { get; set; }

        public int TagTypeId { get; set; }
        public TagType TagType { get; set; } = default!;
    }
}
