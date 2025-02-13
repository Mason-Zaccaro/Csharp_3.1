using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования ArrayList<int>
            Console.WriteLine("ArrayList<int>:");
            IList<int> intArrayList = new ArrayList<int>();
            intArrayList.Add(1);
            intArrayList.Add(2);
            intArrayList.Add(3);
            for (int i = 0; i < intArrayList.Count; i++)
            {
                Console.WriteLine($"Element {i}: {intArrayList.Get(i)}");
            }

            // Пример использования LinkedList<string>
            Console.WriteLine("\nLinkedList<string>:");
            IList<string> stringLinkedList = new LinkedList<string>();
            stringLinkedList.Add("Hello");
            stringLinkedList.Add("World");
            stringLinkedList.Add("C#");
            for (int i = 0; i < stringLinkedList.Count; i++)
            {
                Console.WriteLine($"Element {i}: {stringLinkedList.Get(i)}");
            }

            // Пример использования ArrayList<Person>
            Console.WriteLine("\nArrayList<Person>:");
            IList<Person> personArrayList = new ArrayList<Person>();
            personArrayList.Add(new Person { Name = "Alice", Age = 30 });
            personArrayList.Add(new Person { Name = "Bob", Age = 25 });
            for (int i = 0; i < personArrayList.Count; i++)
            {
                Console.WriteLine($"Element {i}: {personArrayList.Get(i)}");
            }

            Console.ReadKey();
        }
    }
}
