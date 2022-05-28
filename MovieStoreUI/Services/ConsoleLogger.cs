using System;

namespace MovieStoreUI.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
           Console.WriteLine($"Console'la ilgili mesaj loglandı ==> {message}");
        }
    }
}