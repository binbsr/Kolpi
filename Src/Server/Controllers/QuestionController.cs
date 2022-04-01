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

namespace Kolpi.Server.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> logger;
        private readonly KolpiDbContext kolpiDbContext;

        public QuestionController(ILogger<QuestionController> logger, KolpiDbContext kolpiDbContext)
        {
            this.logger = logger;
            this.kolpiDbContext = kolpiDbContext;
        }

        [HttpPost]
        public void Post([FromBody] QuestionViewModel questionViewModel)
        {

        }
    }
}
