using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3; // количество создаваемых объектов

            // Создание массива случайных чисел
            Console.WriteLine("Array of random numbers:");
            int[] randomNumbers = FactoryHelper.CreateArray(new RandomNumberFactory(), n);
            foreach (var num in randomNumbers)
                Console.WriteLine(num);

            // Создание массива объектов Person (с вводом пользователя)
            Console.WriteLine("\nEnter details for Persons:");
            Person[] persons = FactoryHelper.CreateArray(new PersonFactory(), n);
            foreach (var person in persons)
                Console.WriteLine(person);

            Console.ReadKey();
        }
    }
}
