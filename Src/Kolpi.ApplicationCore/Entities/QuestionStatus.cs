using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class QuestionStatus : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Details  { get; set; } = string.Empty;

        public ICollection<Question> Questions { get; set; } = default!;
    }
}
