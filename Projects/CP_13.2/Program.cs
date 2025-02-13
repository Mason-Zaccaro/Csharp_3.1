using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример для int
            int x = 5, y = 10;
            Console.WriteLine("Before swap: x = {0}, y = {1}", x, y);
            Utils.Swap(ref x, ref y);
            Console.WriteLine("After swap:  x = {0}, y = {1}\n", x, y);

            // Пример для string
            string str1 = "hello", str2 = "world";
            Console.WriteLine("Before swap: str1 = {0}, str2 = {1}", str1, str2);
            Utils.Swap(ref str1, ref str2);
            Console.WriteLine("After swap:  str1 = {0}, str2 = {1}\n", str1, str2);

            // Пример для Person
            Person p1 = new Person { Name = "Alice", Age = 30 };
            Person p2 = new Person { Name = "Bob", Age = 25 };
            Console.WriteLine("Before swap: p1 = {0}, p2 = {1}", p1, p2);
            Utils.Swap(ref p1, ref p2);
            Console.WriteLine("After swap:  p1 = {0}, p2 = {1}", p1, p2);

            Console.ReadKey();
        }
    }
}
