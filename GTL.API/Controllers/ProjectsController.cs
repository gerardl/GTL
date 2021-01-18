using GTL.Lib.Services;
using GTL.Lib.ViewModels;
using GTL.Lib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IPortfolioService portfolioService, ILogger<ProjectsController> logger)
        {
            _portfolioService = portfolioService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectViewModel>> Get()
        {
            return (await _portfolioService.GetProjects()).ToViewModel();
        }
    }
}
