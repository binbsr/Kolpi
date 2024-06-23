using Kolpi.ApplicationCore.Entities;
using Kolpi.Infrastructure.Services.Questions;
using Kolpi.WebShared.Mapper;
using Kolpi.WebShared.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolpi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionStatusesController : ControllerBase
{
    private readonly QuestionStatusService questionStatusService;

    public QuestionStatusesController(QuestionStatusService questionStatusService)
    {
        this.questionStatusService = questionStatusService;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionStatusViewModel>>> Get()
    {
        try
        {
            var statuses = await questionStatusService.GetAllAsync();
            var statusViewModels = statuses.ToViewModel();
            return Ok(statusViewModels);
        }
        catch (Exception e)
        {
            return Problem(e.StackTrace);
        }
    }
}
