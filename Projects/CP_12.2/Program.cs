using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сортировка массива строк по длине
            string[] strings = { "apple", "banana", "kiwi", "strawberry", "pear" };
            Console.WriteLine("Before sorting strings:");
            foreach (var s in strings)
                Console.WriteLine(s);
            SortHelper.SortArray(strings, new StringComparer());
            Console.WriteLine("\nAfter sorting strings (by length):");
            foreach (var s in strings)
                Console.WriteLine(s);

            // Сортировка массива книг по цене
            Book[] books = {
                new Book { Title = "Book A", Author = "Author A", Price = 15.99 },
                new Book { Title = "Book B", Author = "Author B", Price = 9.99 },
                new Book { Title = "Book C", Author = "Author C", Price = 20.0 }
            };
            Console.WriteLine("\nBefore sorting books:");
            foreach (var b in books)
                Console.WriteLine(b);
            SortHelper.SortArray(books, new BookComparer());
            Console.WriteLine("\nAfter sorting books (by price):");
            foreach (var b in books)
                Console.WriteLine(b);

            Console.ReadKey();
        }
    }
}
