using System;

namespace _7._1_КТ
{
    public interface IConverter<in T, out U>
    {
        U Convert(T value);
    }

    public class StringToIntConverter : IConverter<string, int>
    {
        public int Convert(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new ArgumentException("Невозможно преобразовать строку в целое число.");
        }
    }

    public class ObjectToStringConverter : IConverter<object, string>
    {
        public string Convert(object value)
        {
            return value.ToString();
        }
    }

    public class Program
    {
        public static U[] ConvertArray<T, U>(T[] inputArray, IConverter<T, U> converter)
        {
            U[] resultArray = new U[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                resultArray[i] = converter.Convert(inputArray[i]);
            }
            return resultArray;
        }

        public static void Main(string[] args)
        {
            object[] objectArray = { 1, 2, 3, "пупупу" };
            IConverter<object, string> objectToStringConverter = new ObjectToStringConverter();
            string[] stringResult = ConvertArray(objectArray, objectToStringConverter);
            Console.WriteLine("Объекты в строки:");
            foreach (var str in stringResult)
            {
                Console.WriteLine(str);
            }

            string[] stringArray = { "1", "2", "3", "4" };
            IConverter<string, int> stringToIntConverter = new StringToIntConverter();
            int[] intArray = ConvertArray(stringArray, stringToIntConverter);
            Console.WriteLine("Строки в целые числа:");
            foreach (var num in intArray)
            {
                Console.WriteLine(num);
            }
        }
    }
}