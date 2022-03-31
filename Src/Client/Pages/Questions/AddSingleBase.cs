// using Blazored.TextEditor;
// using Kolpi.Shared.Enums;
// using Kolpi.Shared.ViewModels;
// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Net.Http.Json;
// using System.Threading.Tasks;

// namespace Kolpi.Client.Pages.Questions
// {
//     public class AddSingleBase : ComponentBase
//     {
//         [Inject]
//         private HttpClient Http { get; set; }
        
//         public BlazoredTextEditor questionEditor;
//         public string questionBody;
//         public string questionType = "1";
//         public QuestionViewModel question = new QuestionViewModel { AnswerOptions = new List<AnswerOptionViewModel>() };
//         public string optionCount = "1";
//         public TagViewModel[] tags;

//         public async Task SaveQuestion()
//         {
//             question.Body = await this.questionEditor.GetHTML();
//             question.QuestionType = QuestionType.Objective;
//             question.Tags = new List<TagViewModel>();

//             var result = await Http.PostAsJsonAsync("api/question", question);
//         }

//         public void AddAnsOption()
//         {
//             for (int i = 1; i <= int.Parse(optionCount); i++)
//             {
//                 question.AnswerOptions.Add(new AnswerOptionViewModel { IsAnswer = false, Body = string.Empty });
//             }
//         }

//         public void DeleteAnsOption(AnswerOptionViewModel item)
//         {
//             question.AnswerOptions.Remove(item);
//         }
//     }
// }
