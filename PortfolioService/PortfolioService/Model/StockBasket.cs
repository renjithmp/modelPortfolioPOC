using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioService.Model
{
    public class StockBasket
    {
        Stock _stock;
        int _quantity = 1;
        double _price;
        double _oneMonthReturn;
        double _threeMonthReturn;
        double _oneYearReturn;
        double _threeYearReturn;
        double _Return;

        public int Quantity { get => _quantity; set => _quantity = value; }
        public double Price { get => _price; set => _price = value; }
        public double OneMonthReturn { get => _oneMonthReturn; set => _oneMonthReturn = value; }
        public double ThreeMonthReturn { get => _threeMonthReturn; set => _threeMonthReturn = value; }
        public double OneYearReturn { get => _oneYearReturn; set => _oneYearReturn = value; }
        public double ThreeYearReturn { get => _threeYearReturn; set => _threeYearReturn = value; }
        public double Return { get => _Return; set => _Return = value; }
        public Stock Stock { get => _stock; set => _stock = value; }
    }
}
