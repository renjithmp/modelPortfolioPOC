using PortfolioService.Model;
using System.Threading.Tasks;

namespace PortfolioService.Repository
{
    public interface ISearchRepository
    {
       SearchResult<StockFull> SearchAsync(string query);
    }
}