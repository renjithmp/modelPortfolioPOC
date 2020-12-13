using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Model
{
    public class PortfolioManagerConnection:IPortfolioManagerConnection
    {
        private string modelPortfolioCollectionName;
        private string connectionString;
        private string databaseName;

        public string ModelPortfolioCollectionName { get => modelPortfolioCollectionName; set => modelPortfolioCollectionName = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string DatabaseName { get => databaseName; set => databaseName = value; }
    }
}
