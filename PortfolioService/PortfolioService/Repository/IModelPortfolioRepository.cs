using System.Collections.Generic;

namespace PortfolioService.Services
{
    public interface IModelPortfolioRepository
    {
      List<ModelPortfolio> GetAllModelPortfolios();
        bool AddModelPortfolio(ModelPortfolio modelPortfolio);
    }
}