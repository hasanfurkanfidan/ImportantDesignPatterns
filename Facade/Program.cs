using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new CustomerManager();
            manager.Save();

        }
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade _facade;
        public CustomerManager()
        {
            _facade = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _facade._caching.Cache();
            _facade._authorize.CheckUser();

           
        }

    }
    class CrossCuttingConcernsFacade
    {
        public ILogging _logging;
        public ICaching _caching;
        public IAuthorize _authorize;
        public CrossCuttingConcernsFacade()
        {
            _logging = new Logging();
            _caching = new Caching();
            _authorize = new Authorize();
        }
    }
}
