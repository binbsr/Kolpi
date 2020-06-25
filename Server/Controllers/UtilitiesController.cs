using Kolpi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kolpi.Shared.ViewModels;

namespace Kolpi.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilitiesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "GK", "Level-1"
        };

        private readonly ILogger<UtilitiesController> logger;

        public UtilitiesController(ILogger<UtilitiesController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("gettags")]
        public IEnumerable<TagViewModel> GetTags()
        {   
            return Enumerable.Range(0, 11).Select(index => new TagViewModel
            {
                Value = index.ToString(),
                Label = Summaries[index]
            });
        }
    }
}
