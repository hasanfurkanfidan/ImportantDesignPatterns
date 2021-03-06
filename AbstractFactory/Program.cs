using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
        }
        public abstract class Logging
        {
            public abstract void Log(string message);
        }
        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with Log4Net");
            }
        }
        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with NLog");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }
        public class RedisCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with Redis");
            }
        }
        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }
        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
            public override Caching CreateCaching()
            {
                return new RedisCache();
            }
        }
        public class ProductManager
        {
            private readonly CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
            private Logging _logging;
            private Caching _caching;
            public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _caching = _crossCuttingConcernsFactory.CreateCaching();
                _logging = _crossCuttingConcernsFactory.CreateLogger();
            }
            public void GetAll()
            {
                _logging.Log("");
            }
        }
    }
}
