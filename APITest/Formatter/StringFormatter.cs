using System;

namespace APITest.Formatter
{
    public static class StringFormatter
    {
        public static void Get(string body) => Console.WriteLine($"{new string('-', 30)}\n Method ['GET'] -> {body}\n {new string('-', 30)}");
        public static void Post(string body) => Console.WriteLine($"{new string('-', 30)}\n Method ['POST'] -> {body}\n {new string('-', 30)}");
        public static void Delete(string body) => Console.WriteLine($"{new string('-', 30)}\n Method ['DELETE'] -> {body}\n {new string('-', 30)}");
    }
}
