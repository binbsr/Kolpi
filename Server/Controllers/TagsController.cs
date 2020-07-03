﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kolpi.Shared.ViewModels;
using Kolpi.Shared.Mapper;
using System.Net;
using Kolpi.Server.ApplicationCore.Services;
using Kolpi.Shared.Models;
using System.Security.Claims;

namespace Kolpi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly ILogger<TagsController> logger;

        public TagsController(ITagService tagService, ILogger<TagsController> logger)
        {
            this.tagService = tagService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagViewModel>>> Get([FromQuery] int pageIndex = 1, int pageSize = 10)
        {
            var tagModels = await tagService.GetAllAsync(pageIndex, pageSize);
            var tagViewModels = tagModels.ToViewModel();
            return Ok(tagViewModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagViewModel>> Get([FromRoute] int id)
        {
            var tagTypeModel = await tagService.GetByIdAsync(id);

            if (tagTypeModel == null)
                return NotFound();

            var tagTypeViewModel = tagTypeModel.ToViewModel();

            return Ok(tagTypeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TagViewModel tagViewModel)
        {
            if (tagViewModel == null || string.IsNullOrWhiteSpace(tagViewModel.Name))
                return BadRequest();

            var tagModel = tagViewModel.ToModel();

            // Get userid creating this tag
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            tagModel.AddCreatedStamps(userId);

            var rowsAdded = await tagService.AddAsync(tagModel);
            
            if (rowsAdded <= 0)
                return Problem("Could not insert into the store.", nameof(Tag), (int)HttpStatusCode.InternalServerError, "Data Insert");

            return CreatedAtAction(nameof(Get), new { id = tagModel.Id }, tagModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put([FromBody] TagViewModel tagViewModel)
        {
            if (tagViewModel == null || tagViewModel.Id == default)
                return BadRequest();

            var tagModel = tagViewModel.ToModel();

            var rowsUpdated = await tagService.UpdateAsync(tagModel);
            if (rowsUpdated <= 0)
                return Problem("Could not modify store.", nameof(Tag), (int)HttpStatusCode.InternalServerError, "Data Update");

            return Ok(rowsUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == default)
                return BadRequest();

            var rowsDeleted = await tagService.DeleteAsync(id);

            if (rowsDeleted <= 0)
                return Problem("Could not delete from store.", nameof(Tag), (int)HttpStatusCode.InternalServerError, "Data Deletion");

            return NoContent();
        }
    }
}
