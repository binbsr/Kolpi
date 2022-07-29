using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class Exam : EditBase<int>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public byte DurationHours { get; set; }
        public string Attendees { get; set; }

        public virtual ICollection<ExamPaper> ExamPapers  { get; set; }
    }
}
