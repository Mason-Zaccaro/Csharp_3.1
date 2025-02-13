using System;

namespace Task3
{
    public static class Utils
    {
        // Метод выводит элементы массива, разделенные запятыми.
        // Ограничение where T : notnull гарантирует, что тип T наследуется от Object.
        // В данном случае предполагается, что для корректного строкового представления
        // тип T переопределяет метод ToString().
        public static void Print<T>(T[] array) where T : notnull
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString());
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}
