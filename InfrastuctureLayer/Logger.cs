using System;

namespace InfrastuctureLayer
{
    public class Logger
    {
        public void Info(string details)
        {
            Console.WriteLine($"INFO: {details}");
        }
    }
}