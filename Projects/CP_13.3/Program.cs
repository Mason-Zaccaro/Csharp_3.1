using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример для int[]
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Printing int array:");
            Utils.Print(numbers);

            // Пример для string[]
            string[] words = { "hello", "world", "C#" };
            Console.WriteLine("Printing string array:");
            Utils.Print(words);

            // Пример для Book[]
            Book[] books = new Book[]
            {
                new Book { Title = "1984", Author = "George Orwell", Price = 9.99 },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", Price = 12.5 },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Price = 8.75 }
            };
            Console.WriteLine("Printing Book array:");
            Utils.Print(books);

            Console.ReadKey();
        }
    }
}
