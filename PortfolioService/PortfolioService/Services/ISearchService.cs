using PortfolioService.Model;

namespace PortfolioService.Services
{
    public interface ISearchService
    {
        SearchResult<StockFull> Search(string query, string type);
    }
}