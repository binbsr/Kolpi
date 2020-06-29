using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kolpi.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Kolpi.Shared.Mapper;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Kolpi.Server.ApplicationCore.Services;
using Kolpi.Server.Infrastructure.Logging;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using Kolpi.Shared.Models;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TagTypeViewModel>> Get()
        {
            var tagTypeModels = await tagTypeService.GetAllAsync();
            var tagTypeViewModels = tagTypeModels.ToViewModel();
            return Ok(tagTypeViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var tagTypeModel = await tagTypeService.GetByIdAsync(id);

            if (tagTypeModel == null)
                return NotFound();

            var tagTypeViewModel = tagTypeModel.ToViewModel();

            return Ok(tagTypeViewModel);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] TagTypeViewModel tagTypeViewModel)
        {
            if (id == default || tagTypeViewModel == null || string.IsNullOrWhiteSpace(tagTypeViewModel.Name))
                return BadRequest();

            var tagTypeModel = tagTypeViewModel.ToModel();

            var rowsUpdated = await tagTypeService.UpdateAsync(tagTypeModel);
            if (rowsUpdated <= 0)
                return Problem("Could not modify store.", nameof(tagTypeModel), (int)HttpStatusCode.InternalServerError, "Data Update");

            return Ok();
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
