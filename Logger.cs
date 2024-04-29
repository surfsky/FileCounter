using System;

namespace FileCounter
{
    internal static class Logger
    {
        public static void Log(string format, params object[] parameters)
        {
            Console.WriteLine(format, parameters);
        }
    }
}