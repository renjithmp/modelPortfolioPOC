using Microsoft.Extensions.Logging;
using PortfolioService.Model;
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

        public bool AddModelPortfolio(string Name,List<StockBasket> basketItems,DateTime startDate)
        {
            ModelPortfolio modelPortfolio = new ModelPortfolio();
            modelPortfolio.BasketItems = basketItems;
            modelPortfolio.StartDate = startDate;
            Dictionary<string, List<StockBasket>> rebalancingHistory = new Dictionary<string, List<StockBasket>>();
            List<StockBasket> stocks = new List<StockBasket>();
            Stock stock1 = new Stock() { Id = 1, Name = "stock1" };
            Stock stock2 = new Stock() { Id = 2, Name = "stock2" };
            stocks.Add(item: new StockBasket() { Quantity=10, Stock=stock1 });
            stocks.Add(item: new StockBasket() { Quantity = 2, Stock = stock2 });
            //stocks.Add(new StockBasket() { Id = 2, Name = "stock2" });
            rebalancingHistory.Add(key: DateTime.Now.ToString(), stocks);
            modelPortfolio.RebalancingHistory = rebalancingHistory;
            modelPortfolio.PortfolioId = Guid.NewGuid().ToString();
            modelPortfolio.Name = Name;
            _logger.LogInformation("get all model portfolios");
            return _modelPortfolioRepository.AddModelPortfolio(modelPortfolio);
            

        }
    }
}
