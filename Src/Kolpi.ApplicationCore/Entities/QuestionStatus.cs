using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class QuestionStatus : BaseEntity<int>
    {
        public string Name  { get; set; }
        public string Details  { get; set; }

        public List<Question> Questions { get; set; }
    }
}
