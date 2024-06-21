using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolpi.ApplicationCore.Entities;
using Kolpi.WebShared.ViewModels;
using Kolpi.WebShared.Mapper;
using Kolpi.Infrastructure.Services.Questions;
using Kolpi.Infrastructure.Services.AnswerOptions;
using Kolpi.Infrastructure.Services.Tags;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

namespace Kolpi.Api.Controllers;

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
    public async Task<ActionResult<QuestionsMetaViewModel>> GetQuestions([FromQuery] string filter = "",
        int skip = 0, int take = 10, string orderBy = "")
    {
        try
        {
            var (count, questions) = await questionService.GetAllAsync(filter, skip, take, orderBy);
            var questionViewModels = questions.ToViewModel();
            int totalCount = count;
            return new QuestionsMetaViewModel { TotalCount = totalCount, Records = questionViewModels };
        }
        catch (Exception e)
        {
            return Problem(e.StackTrace);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionViewModel>> GetQuestion(int id)
    {
        var question = await questionService.GetByIdAsync(id);

        if (question is null)
        {
            return NotFound();
        }

        return question.ToViewModel();
    }

    [HttpPost]
    public async Task<IActionResult> PostQuestions(List<QuestionViewModel> questionViewModels)
    {
        if (questionViewModels == null || !questionViewModels.Any())
            return BadRequest("No questions supplied to save.");
        try
        {
            List<Question> questions = questionViewModels.ToModel();

            foreach(Question question in questions)
            {
                question.QuestionStatusId = 1;

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "N/A";
                question.AddCreatedStamps(userId);

                // Inform EF that these tags selected already exists and not changed at all else EF will try to insert
                tagService.AttachTags(question.Tags);

                // Just add answer options to EF
                await answerOptionService.AddAsync(question.AnswerOptions, false);

                // Add question model to EF and commit all changes made to conext so far (UoW)
                await questionService.AddAsync(question, false);                
            }

            var rowsAffected =await questionService.CommitAsync();

            return Created("", rowsAffected);
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
