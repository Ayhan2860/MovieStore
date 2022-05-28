using System;

namespace MovieStoreUI.Services
{
    public class DatabaseLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"Database ilgili mesaj loglandı ==> {message}");
        }
    }
}