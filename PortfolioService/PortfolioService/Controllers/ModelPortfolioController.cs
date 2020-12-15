using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioService.Model;
using PortfolioService.Services;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelPortfolioController : ControllerBase
    {


        private IModelPortfolioService _modelPortfolioService;
        private readonly ILogger<ModelPortfolioController> _logger;

        public ModelPortfolioController(ILogger<ModelPortfolioController> logger,IModelPortfolioService modelPortfolioService)
        {
            _logger = logger;
            _modelPortfolioService = modelPortfolioService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(string name, [FromQuery
            ]List<StockBasket> baskets)
        {
            _modelPortfolioService.AddModelPortfolio(name,baskets,DateTime.Now);
            return Ok("item created");
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ModelPortfolio>),(int) HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            try { 
            return Ok(_modelPortfolioService.GetAllModelPortfolios());
            }
            catch

            {
                return NotFound();
            }
        }
    }
}
