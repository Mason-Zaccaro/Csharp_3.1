using System;
using System.Collections;

public class PrimeNumbers : IEnumerator<int>
{
    private int _current = 1; // Текущее простое число
    private int _count = 0;   // Счетчик найденных простых чисел

    // Возвращает текущее простое число
    public int Current => _current;
    object IEnumerator.Current => Current;

    // Поиск следующего простого числа
    public bool MoveNext()
    {
        while (true)
        {
            _current++;
            if (IsPrime(_current)) // Проверка на простоту
            {
                _count++;
                return true; // Найдено следующее простое число
            }
        }
    }

    // Сброс состояния к начальному
    public void Reset()
    {
        _current = 1; // Возврат к начальному значению
        _count = 0;   // Сброс счетчика
    }

    // Реализация интерфейса IDisposable (не требуется в данном примере)
    public void Dispose() { }

    // Проверка числа на простоту
    private bool IsPrime(int n)
    {
        if (n <= 1) return false;
        // Проверка делителей до квадратного корня из n
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        PrimeNumbers primes = new PrimeNumbers();
        int count = 0;
        while (count < 10)
        {
            primes.MoveNext(); // Переход к следующему простому числу
            Console.WriteLine(primes.Current); // Вывод текущего числа
            count++;
        }
    }
}