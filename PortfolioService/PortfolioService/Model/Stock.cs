namespace PortfolioService
{
    public class Stock
    {
        int _id;
        string _name;
        double _ltpPrice;
        string _currency;


        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

    }
}