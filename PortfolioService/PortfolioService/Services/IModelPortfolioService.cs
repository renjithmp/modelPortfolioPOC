using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Services
{
    public interface IModelPortfolioService
    {
        List<ModelPortfolio> GetAllModelPortfolios();
        bool AddModelPortfolio(int id, string name);
    }
}
