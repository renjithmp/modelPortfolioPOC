using System.Collections.Generic;

namespace PortfolioService.Model
{
    public class SearchResult<T>
    {
        private List<T> _results; 

        public SearchResult(List<T> results)
        {
            Results = results;
        }

        public List<T> Results { get => _results; set => _results = value; }

        public void Add(T result)
        {
            var results = Results == null ? new List<T>() : Results;
            results.Add(result);
        }
    }
}