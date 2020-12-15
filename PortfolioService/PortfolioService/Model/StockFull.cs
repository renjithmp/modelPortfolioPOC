using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Model
{
    [BsonIgnoreExtraElements]
    public class StockFull
    {
        public string SYMBOL { get; set; }
        public string SERIES { get; set; }
        public string OPEN { get; set; }
        public string HIGH { get; set; }
        public string LOW { get; set; }
        public string CLOSE { get; set; }
        public string LAST { get; set; }
        public string PREVCLOSE { get; set; }
        public string TOTTRDQTY { get; set; }
        public string TOTTRDVAL { get; set; }
        public string TIMESTAMP { get; set; }
        public string TOTALTRADES { get; set; }
        public string ISIN { get; set; }
    }
}

