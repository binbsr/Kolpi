using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kolpi.Shared.ViewModels;
using Kolpi.Server.Data;
using Microsoft.EntityFrameworkCore;
using Kolpi.Shared.Mapper;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Kolpi.Shared.Models;

namespace Kolpi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagTypesController : ControllerBase
    {
        private readonly KolpiDbContext kolpiDbContext;
        private readonly ILogger<TagTypesController> logger;

        public TagTypesController(KolpiDbContext kolpiDbContext, ILogger<TagTypesController> logger)
        {
            this.kolpiDbContext = kolpiDbContext;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int pageIndex = 1, int pageSize = 10)
        {
            var tagTypeModels = await kolpiDbContext.TagTypes.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            var tagTypeViewModels = tagTypeModels.ToViewModel();
            return Ok(tagTypeViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var tagTypeModel = await kolpiDbContext.TagTypes.FindAsync(id);

            if (tagTypeModel == null)
                return NotFound();

            var tagTypeViewModel = tagTypeModel.ToViewModel();

            return Ok(tagTypeViewModel);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TagTypeViewModel tagTypeViewModel)
        {
            if (tagTypeViewModel == null || string.IsNullOrWhiteSpace(tagTypeViewModel.Name))
                return BadRequest();

            var tagTypeModel = tagTypeViewModel.ToModel();
            kolpiDbContext.TagTypes.Add(tagTypeModel);
            _ = await kolpiDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = tagTypeModel.Id }, tagTypeModel);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] TagTypeViewModel tagTypeViewModel)
        {
            if (id == default || tagTypeViewModel == null || string.IsNullOrWhiteSpace(tagTypeViewModel.Name))
                return BadRequest();

            var tagTypeModel = tagTypeViewModel.ToModel();
            kolpiDbContext.TagTypes.Update(tagTypeModel);
            _ = await kolpiDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == default)
                return BadRequest();

            var model = kolpiDbContext.TagTypes.Find(id);
            kolpiDbContext.Remove(model);
            _ = await kolpiDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
