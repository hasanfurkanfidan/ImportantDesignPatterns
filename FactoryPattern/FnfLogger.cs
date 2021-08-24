using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class FnfLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With FnfLogger");
        }
    }
}
