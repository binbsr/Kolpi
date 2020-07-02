using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class ExamPaper : EditBase<Guid>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public List<ExamPaperQuestion> ExamPaperQuestions  { get; set; }
    }
}
