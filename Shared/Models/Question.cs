using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public List<Tag> Tags  { get; set; }
        public List<AnswerOption> AnswerOptions   { get; set; }
        public QuestionType QuestionType { get; set; }
        public DateTime DateCreated { get; set; }

    }
}