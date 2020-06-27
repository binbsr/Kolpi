using Kolpi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kolpi.Shared.ViewModels;
using Kolpi.Server.Data;
using Microsoft.EntityFrameworkCore;
using Kolpi.Shared.Mapper;

namespace Kolpi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "GK", "Level-1"
        };
        private readonly KolpiDbContext kolpiDbContext;
        private readonly ILogger<TagController> logger;

        public TagController(KolpiDbContext kolpiDbContext, ILogger<TagController> logger)
        {
            this.kolpiDbContext = kolpiDbContext;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<TagViewModel> Get()
        {   
            return Enumerable.Range(0, 11).Select(index => new TagViewModel
            {
                Value = index.ToString(),
                Label = Summaries[index]
            });
        }

        [HttpGet]
        [Route("types")]
        public async Task<IEnumerable<TagTypeViewModel>> GetTagTypes(int pageIndex, int pageSize)
        {
            var tagTypeModels = await kolpiDbContext.TagTypes.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            var tagTypeViewModels = tagTypeModels.ToViewModel();
            return tagTypeViewModels;
        }
    }
}
