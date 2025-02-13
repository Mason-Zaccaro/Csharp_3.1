using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Словарь: страна -> столица
            Dictionary<string, string> countryToCapital = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Россия", "Москва" },
                { "США", "Вашингтон" },
                { "Франция", "Париж" },
                { "Германия", "Берлин" },
                { "Япония", "Токио" }
            };

            // Словарь: страна -> население (примерные данные)
            Dictionary<string, int> countryToPopulation = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "Россия", 144500000 },
                { "США", 331000000 },
                { "Франция", 67000000 },
                { "Германия", 83000000 },
                { "Япония", 126500000 }
            };

            Console.WriteLine("Введите название страны:");
            string country = Console.ReadLine();

            // Проверяем наличие страны в словарях
            if (countryToCapital.ContainsKey(country) && countryToPopulation.ContainsKey(country))
            {
                Console.WriteLine("Страна: " + country);
                Console.WriteLine("Столица: " + countryToCapital[country]);
                Console.WriteLine("Население: " + countryToPopulation[country]);
            }
            else
            {
                Console.WriteLine("Информация о стране \"" + country + "\" отсутствует.");
            }

            Console.ReadKey();
        }
    }
}
