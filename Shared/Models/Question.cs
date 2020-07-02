using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class Question : EditBase<Guid>
    {
        public string Body { get; set; }

        public int QuestionStatusId { get; set; }
        public QuestionStatus QuestionStatus { get; set; }

        public List<Tag> Tags  { get; set; }
        public List<AnswerOption> AnswerOptions   { get; set; }
        public List<ExamPaperQuestion> ExamPaperQuestions { get; set; }
        public List<QuestionTag> QuestionTags { get; set; }
    }
}
