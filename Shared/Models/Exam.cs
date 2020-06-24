using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class Exam : EditBase
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public byte DurationHours { get; set; }
        public string Attendees { get; set; }

        public virtual List<ExamPaper> ExamPapers  { get; set; }
    }
}
