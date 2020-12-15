using MongoDB.Bson;
using MongoDB.Driver;
using PortfolioService.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        MongoClient _mongoClient;
        IPortfolioManagerConnection _portfolioManagerConnection;
        public SearchRepository(IPortfolioManagerConnection portfolioManagerConnection)
        {
            _portfolioManagerConnection = portfolioManagerConnection;
            _mongoClient = new MongoClient(_portfolioManagerConnection.ConnectionString);
        }
        public SearchResult<StockFull> SearchAsync(string query)
        {
            IMongoDatabase database = _mongoClient.GetDatabase(_portfolioManagerConnection.DatabaseName);
            IMongoCollection<StockFull> collection = database.GetCollection<StockFull>("EquitySnapshot");

            // Created with Studio 3T, the IDE for MongoDB - https://studio3t.com/

            BsonDocument filter = new BsonDocument();
            string queryExpressionStartsWith = "^"+query+".*";
            filter.Add("SYMBOL", new BsonRegularExpression(queryExpressionStartsWith, "i"));


            List<StockFull> stocks = collection.Find(filter).ToList();
            SearchResult<StockFull> result = new SearchResult<StockFull>(stocks);

            //using (var cursor = await collection.FindAsync(filter))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        var batch = cursor.Current;
            //        foreach (BsonDocument document in batch)
            //        {
            //            //Console.WriteLine(document.ToJson());
            //            StockFull stock = document.tockFull>();

                            
            //        }
            //    }
            //}

            return result;


        }
    }
}