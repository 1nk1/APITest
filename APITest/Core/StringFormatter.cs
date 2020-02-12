using System;

namespace APITest.Core
{
    public static class StringFormatter
    {
        public static void ShowConsoleMessage(string method, string body)
        {
            Console.WriteLine($"{new string('-', 30)}\n Method ['{method}'] -> {body}\n {new string('-', 30)}");
        }
    }
}
