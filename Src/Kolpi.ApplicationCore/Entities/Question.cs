using System;
using System.Collections.Generic;

namespace Kolpi.ApplicationCore.Entities
{
    public class Question : EditBase<int>
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
