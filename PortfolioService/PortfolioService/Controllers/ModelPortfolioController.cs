using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioService.Services;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelPortfolioController : ControllerBase
    {


        private IModelPortfolioService _modelPortfolioService;
        private readonly ILogger<WeatherForecastController> _logger;

        public ModelPortfolioController(ILogger<WeatherForecastController> logger,IModelPortfolioService modelPortfolioService)
        {
            _logger = logger;
            _modelPortfolioService = modelPortfolioService;
        }

        [HttpPost]
        public void Add(int id,string name)
        {
            _modelPortfolioService.AddModelPortfolio(id, name);
        }

        [HttpGet]
        public List<ModelPortfolio> Get()
        {
            return _modelPortfolioService.GetAllModelPortfolios();
        }
    }
}
