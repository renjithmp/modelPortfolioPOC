using MongoDB.Driver;
using PortfolioService.Model;
using System.Collections.Generic;

namespace PortfolioService.Services
{
    public class MongoModelPortfolioRepository:IModelPortfolioRepository
    {
        MongoClient _mongoClient;
        IPortfolioManagerConnection _portfolioManagerConnection;
        public MongoModelPortfolioRepository(IPortfolioManagerConnection portfolioManagerConnection)
        {
            _portfolioManagerConnection = portfolioManagerConnection;
            _mongoClient = new MongoClient(_portfolioManagerConnection.ConnectionString);
        }

      public List<ModelPortfolio> GetAllModelPortfolios()
        {

            IMongoDatabase modelPortfolioDB= _mongoClient.GetDatabase(_portfolioManagerConnection.DatabaseName);
            IMongoCollection<ModelPortfolio> modelPortfolioMongoCollection = modelPortfolioDB.GetCollection<ModelPortfolio>(_portfolioManagerConnection.ModelPortfolioCollectionName);
            return modelPortfolioMongoCollection.Find(x=> true).ToList();

        }

        public bool AddModelPortfolio(ModelPortfolio modelPortfolio)
        {

            IMongoDatabase modelPortfolioDB = _mongoClient.GetDatabase(_portfolioManagerConnection.DatabaseName);
            IMongoCollection<ModelPortfolio> modelPortfolioMongoCollection = modelPortfolioDB.GetCollection<ModelPortfolio>(_portfolioManagerConnection.ModelPortfolioCollectionName);           
            modelPortfolioMongoCollection.InsertOne(modelPortfolio);
            return true;


        }
    }
}