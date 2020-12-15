using PortfolioService.Model;
using PortfolioService.Repository;

namespace PortfolioService.Services
{
    public class SearchService : ISearchService
    {
        public ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;

        }
        public SearchResult<StockFull> Search(string query, string type)
        {
            return _searchRepository.SearchAsync(query);
        }
    }
}