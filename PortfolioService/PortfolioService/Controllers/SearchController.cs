using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Model;
using PortfolioService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {

        private ISearchService _searchService; 
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet]
        public ActionResult<List<StockFull>> Search(string query, string type)
        {

            SearchResult<StockFull> searchResult = _searchService.Search(query, type);
            return Ok(searchResult.Results);
        }
    }
}
