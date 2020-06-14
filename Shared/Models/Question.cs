using System;
using System.Collections.Generic;

public class Question
{
    public string Id { get; set; }
    public string Body { get; set; }
    public List<Tag> Tags  { get; set; }
    public List<AnswerOption> AnswerOptions   { get; set; }
    public DateTime DateCreated { get; set; }

}
