using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class Question : EditBase
    {
        public string Body { get; set; }
        public List<Tag> Tags  { get; set; }
        public List<AnswerOption> AnswerOptions   { get; set; }

        public QuestionType QuestionType { get; set; }
        public int QuestionTypeId { get; set; }

        public List<ExamPaperQuestion> ExamPaperQuestions { get; set; }
    }
}