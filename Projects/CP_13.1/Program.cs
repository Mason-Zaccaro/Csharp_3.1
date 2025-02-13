using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример для int
            int a = 5, b = 10;
            Console.WriteLine("Max of {0} and {1} is {2}", a, b, Utils.Max(a, b));

            // Пример для string
            string s1 = "apple", s2 = "banana";
            Console.WriteLine("Max of \"{0}\" and \"{1}\" is \"{2}\"", s1, s2, Utils.Max(s1, s2));

            // Пример для DateTime
            DateTime dt1 = new DateTime(2023, 1, 1);
            DateTime dt2 = new DateTime(2023, 12, 31);
            Console.WriteLine("Max of {0} and {1} is {2}", dt1, dt2, Utils.Max(dt1, dt2));

            Console.ReadKey();
        }
    }
}
