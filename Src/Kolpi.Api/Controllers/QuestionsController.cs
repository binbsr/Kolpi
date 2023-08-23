using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;
using Kolpi.WebShared.Mapper;
using Kolpi.Infrastructure.Services.Questions;
using Kolpi.Infrastructure.Services.AnswerOptions;
using Kolpi.Infrastructure.Services.Tags;

namespace Kolpi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IAnswerOptionService answerOptionService;
        private readonly ITagService tagService;

        public QuestionsController(
            IQuestionService questionService, 
            IAnswerOptionService answerOptionService,
            ITagService tagService)
        {
            this.questionService = questionService;
            this.answerOptionService = answerOptionService;
            this.tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(string searchText, int pageIndex, int pageSize = 10)
        {
            return await questionService.GetAllAsync(searchText, pageIndex, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await questionService.GetByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(QuestionViewModel questionViewModel)
        {
            try
            {
                Question question = questionViewModel.ToModel();
                question.QuestionStatusId = 1;

                tagService.AttachTags(question.Tags);

                await answerOptionService.AddAsync(question.AnswerOptions, false);
                await questionService.AddAsync(question);
                return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            try
            {
                await questionService.UpdateAsync(question);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
             
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await questionService.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            await questionService.DeleteAsync(id);

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return questionService.GetByIdAsync(id).Result is not null;
        }
    }
}
