using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class QuestionStatus : BaseEntity<int>
    {
        public string Name  { get; set; }
        public string Details  { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
