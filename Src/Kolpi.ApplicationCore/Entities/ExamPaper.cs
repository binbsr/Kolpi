using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class ExamPaper : EditBase<int>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public List<ExamPaperQuestion> ExamPaperQuestions  { get; set; }
    }
}
