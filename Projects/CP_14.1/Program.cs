using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь к текстовому файлу (файл должен находиться в папке с исполняемым файлом)
            string filePath = "D:\\Study\\3_Course\\1_Semester\\Csharp_3.1\\Projects\\CP_14.1\\Input.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден: " + filePath);
                return;
            }

            // Чтение всего текста из файла
            string text = File.ReadAllText(filePath);

            // Используем регулярное выражение для разделения на слова (игнорируя знаки препинания)
            string pattern = @"\w+";
            MatchCollection matches = Regex.Matches(text, pattern);

            // Словарь для подсчета частоты слов
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (Match match in matches)
            {
                string word = match.Value.ToLower(); // Приводим к нижнему регистру для корректного сравнения

                // Если слово уже встречалось, увеличиваем счётчик, иначе добавляем его в словарь
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency.Add(word, 1);
                }
            }

            // Сортировка словаря по убыванию частоты
            var sortedFrequency = wordFrequency.OrderByDescending(pair => pair.Value);

            // Вывод результата на консоль
            Console.WriteLine("Слово\tЧастота");
            foreach (var pair in sortedFrequency)
            {
                Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}
