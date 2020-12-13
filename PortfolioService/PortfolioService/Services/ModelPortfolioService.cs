using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Services
{
    public class ModelPortfolioService : IModelPortfolioService
    {
        public IModelPortfolioRepository _modelPortfolioRepository;
        private ILogger<ModelPortfolioService> _logger;

        public ModelPortfolioService(ILogger<ModelPortfolioService> logger,IModelPortfolioRepository modelPortfolioRepository)
        {
            _logger = logger;
            _modelPortfolioRepository = modelPortfolioRepository;
        }
        public List<ModelPortfolio> GetAllModelPortfolios()
        {

            _logger.LogInformation("get all model portfolios");
            List<ModelPortfolio> modelPortfolios = _modelPortfolioRepository.GetAllModelPortfolios();
            return modelPortfolios;

        }

        public bool AddModelPortfolio(int id,string Name)
        {
            ModelPortfolio modelPortfolio = new ModelPortfolio();
            Dictionary<string, List<Stocks>> rebalancingHistory = new Dictionary<string, List<Stocks>>();
            List<Stocks> stocks = new List<Stocks>();
            stocks.Add(new Stocks() { Id = 1, Name = "stock1" });
            stocks.Add(new Stocks() { Id = 2, Name = "stock2" });
            rebalancingHistory.Add(key: DateTime.Now.ToString(), stocks);
            modelPortfolio.RebalancingHistory = rebalancingHistory;
            modelPortfolio.PortfolioId = id;
            modelPortfolio.Name = Name;
            _logger.LogInformation("get all model portfolios");
            return _modelPortfolioRepository.AddModelPortfolio(modelPortfolio);
            

        }
    }
}
