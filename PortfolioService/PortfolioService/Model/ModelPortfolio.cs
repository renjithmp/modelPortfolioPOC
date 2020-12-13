using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;

namespace PortfolioService
{
    [BsonIgnoreExtraElements]
    public class ModelPortfolio
    {

        private int modelPortfolioId;
        private string name;
        private string owner;
        private List<Stocks> basketItems;
        private int initialValue;
        private DateTime startDate;
        private List<DateTime> rebalancingDates;
        private Dictionary<string, List<Stocks>> rebalancingHistory;
        public int PortfolioId { get => modelPortfolioId; set => modelPortfolioId = value; }
        public string Name { get => name; set => name = value; }
        public string Owner { get => owner; set => owner = value; }
        public List<Stocks> BasketItems { get => basketItems; set => basketItems = value; }
        public int InitialValue { get => initialValue; set => initialValue = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public List<DateTime> RebalancingDates { get => rebalancingDates; set => rebalancingDates = value; }
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<string, List<Stocks>> RebalancingHistory { get => rebalancingHistory; set => rebalancingHistory = value; }


    }
}