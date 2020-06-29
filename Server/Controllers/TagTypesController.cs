using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kolpi.Shared.ViewModels;
using Kolpi.Shared.Mapper;
using Kolpi.Server.ApplicationCore.Services;
using Kolpi.Server.Infrastructure.Logging;
using System.Net;
using Kolpi.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kolpi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagTypesController : ControllerBase
    {
        private readonly ITagTypeService tagTypeService;
        private readonly IKolpiLogger<TagTypesController> logger;

        public TagTypesController(ITagTypeService tagTypeService, IKolpiLogger<TagTypesController> logger)
        {
            this.tagTypeService = tagTypeService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagTypeViewModel>>> Get()
        {
            var tagTypeModels = await tagTypeService.GetAllAsync();
            var tagTypeViewModels = tagTypeModels.ToViewModel();
            return tagTypeViewModels.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var tagTypeModel = await tagTypeService.GetByIdAsync(id);

            if (tagTypeModel == null)
                return NotFound();

            var tagTypeViewModel = tagTypeModel.ToViewModel();

            return Ok(tagTypeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TagTypeViewModel tagTypeViewModel)
        {
            if (tagTypeViewModel == null || string.IsNullOrWhiteSpace(tagTypeViewModel.Name))
                return BadRequest();

            var tagTypeModel = tagTypeViewModel.ToModel();
            var rowsAdded = await tagTypeService.AddAsync(tagTypeModel);
            if (rowsAdded <= 0)
                return Problem("Could not insert into the store.", nameof(tagTypeModel), (int)HttpStatusCode.InternalServerError, "Data Insert");

            return CreatedAtAction(nameof(Get), new { id = tagTypeModel.Id }, tagTypeModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] TagTypeViewModel tagTypeViewModel)
        {
            if (id == default || tagTypeViewModel == null || string.IsNullOrWhiteSpace(tagTypeViewModel.Name))
                return BadRequest();

            var tagTypeModel = tagTypeViewModel.ToModel();

            var rowsUpdated = await tagTypeService.UpdateAsync(tagTypeModel);
            if (rowsUpdated <= 0)
                return Problem("Could not modify store.", nameof(tagTypeModel), (int)HttpStatusCode.InternalServerError, "Data Update");

            return rowsUpdated;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == default)
                return BadRequest();

            var rowsDeleted = await tagTypeService.DeleteAsync(id);

            if (rowsDeleted <= 0)
                return Problem("Could not delete from store.", nameof(TagType), (int)HttpStatusCode.InternalServerError, "Data Deletion");

            return NoContent();
        }
    }
}
