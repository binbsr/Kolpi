using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    // Join table, EF core does not support many-to-many relationships
    public class ExamPaperQuestion
    {
        public int ExamPaperId  { get; set; }
        public ExamPaper ExamPaper { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
