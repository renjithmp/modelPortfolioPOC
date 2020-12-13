using NUnit.Framework;
using System.Collections.Generic;
using PortfolioService;
using PortfolioService.Services;

namespace PortfolioServiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadAllModelPortfolio()
        {
            IModelPortfolioService modelPortfolio = null;

            List<ModelPortfolio> modelPortfolios = modelPortfolio.GetAllModelPortfolios();

            Assert.Equals(modelPortfolios.Count, 1);
        }
    }
}