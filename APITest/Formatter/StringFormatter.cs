using System;

namespace APITest.Formatter
{
    public static class StringFormatter
    {
        public static void GET(string body)
        {
            Console.WriteLine($"{new string('-', 30)}\n Method ['GET'] -> {body}\n {new string('-', 30)}");
        }
        public static void POST(string body)
        {
            Console.WriteLine($"{new string('-', 30)}\n Method ['POST'] -> {body}\n {new string('-', 30)}");
        }
        public static void DELETE(string body)
        {
            Console.WriteLine($"{new string('-', 30)}\n Method ['DELETE'] -> {body}\n {new string('-', 30)}");
        }
    }
}
