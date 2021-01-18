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
    public class TagsController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ILogger<TagsController> _logger;

        public TagsController(IPortfolioService portfolioService, ILogger<TagsController> logger)
        {
            _portfolioService = portfolioService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TagViewModel>> Get()
        {
            return (await _portfolioService.GetTags()).ToViewModel();
        }
    }
}
