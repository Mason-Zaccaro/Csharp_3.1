using System;

namespace Task1
{
    public static class Utils
    {
        // Метод возвращает максимальное значение из двух аргументов,
        // используя ограничение, что T должен реализовывать IComparable<T>.
        public static T Max<T>(T x, T y) where T : IComparable<T>
        {
            // Если x больше или равен y, возвращаем x, иначе y.
            return x.CompareTo(y) >= 0 ? x : y;
        }
    }
}
