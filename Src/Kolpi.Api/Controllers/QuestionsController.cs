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

namespace Kolpi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
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

        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(QuestionViewModel questionViewModel)
        {
            Question question; 
            try
            {
                question = questionViewModel.ToModel();

                question.QuestionStatusId = 1;

                
                await questionService.AddAsync(question);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
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
