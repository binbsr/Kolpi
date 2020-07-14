/*
Let's not do scores
We will label every user as: xxQ xxOA xxSA xxR
Where Q = Questions, OA = Objective Answers, SA = Subjective Answers and R = Reviews

Example: 23Q 08OA 13SA 47R
Hover titles:   23 Questions Added
                8 Objective Answers Added
                13 Subjective Answers Added
                47 Review Made
*/

namespace Kolpi.Shared.Models
{
    public class PrivilegeLookup
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Details { get; set; }
        public int QuestionsCount { get; set; }
        public int SubjectiveAnswersCount { get; set; }
        public int ObjectiveAnswersCount { get; set; }
        public int ReviewsCount { get; set; }
    }
}
