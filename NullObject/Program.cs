using System;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class CustomerManager
    {
        private readonly ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }
    class NullObjectLogger : ILogger
    {
        static object _lock = new object();
        static NullObjectLogger _nullObjectLogger;
        private NullObjectLogger()
        {

        }
        public static NullObjectLogger CreateAsSinglton()
        {
            if (_nullObjectLogger == null)
            {
                lock (_lock)
                {
                    _nullObjectLogger = new NullObjectLogger();
                }
            }
            return _nullObjectLogger;
        }
        public void Log()
        {

        }
    }
    interface ILogger
    {
        void Log();
    }
    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            throw new NotImplementedException();
        }
    }
    class NLogLogger : ILogger
    {
        public void Log()
        {
            throw new NotImplementedException();
        }
    }
    public class CustomerManagerTest
    {
        CustomerManager customerManager = new CustomerManager(NullObjectLogger.CreateAsSinglton());
    }
}
