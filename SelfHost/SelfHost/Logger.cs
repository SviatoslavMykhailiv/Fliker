using System;

namespace SelfHost
{
    public class Logger : ILogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine(log);
        }

        public static ILogger Instance => _instance ?? (_instance = new Logger());

        private static ILogger _instance;

        private Logger()
        {
            
        }
    }
}
