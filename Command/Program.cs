using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;
        public void Buy()
        {
            Console.WriteLine($"Stock: {_name},{_quantity} bought");
        }
        public void Sell()
        {
            Console.WriteLine($"Stock: {_name},{_quantity} sold");
        }
    }
    interface IOrder
    {
        void Execute();
    }
    class BuyStock : IOrder
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    class SellStock : IOrder
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
