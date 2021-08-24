using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = new CustomerManager();
            customerManager.Save();
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger();
            logger.Log();
            Console.Read();
        }
       
       
    }
}
