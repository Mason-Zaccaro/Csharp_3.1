using System;
using System.Collections.Generic;

public class Fibonacci : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        int a = 0, b = 1;
        while (true)
        {
            yield return a;
            (a, b) = (b, a + b);
        }
    }
    // Явная реализация необобщенного интерфейса (требуется для IEnumerable)
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

// Пример использования
public class Program
{
    public static void Main()
    {
        Fibonacci fib = new Fibonacci();
        int count = 0;
        foreach (var num in fib)
        {
            Console.WriteLine(num);
            if (++count >= 10) break;
        }
    }
}