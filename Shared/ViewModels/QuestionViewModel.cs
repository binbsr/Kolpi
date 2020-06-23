using Kolpi.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Kolpi.Shared.ViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public List<TagViewModel> Tags  { get; set; }
        public List<AnswerOptionViewModel> AnswerOptions   { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}