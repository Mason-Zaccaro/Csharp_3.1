using System;

class Program
{
    // Обобщенный метод Swap с ограничением на типы значений (struct)
    public static void Swap<T>(ref T x, ref T y) where T : struct
    {
        T temp = x;
        x = y;
        y = temp;
    }

    static void Main()
    {
        int a = 5, b = 10;
        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");

        double c = 1.5, d = 2.5;
        Console.WriteLine($"Before swap: c = {c}, d = {d}");
        Swap(ref c, ref d);
        Console.WriteLine($"After swap: c = {c}, d = {d}");

        bool e = true, f = false;
        Console.WriteLine($"Before swap: e = {e}, f = {f}");
        Swap(ref e, ref f);
        Console.WriteLine($"After swap: e = {e}, f = {f}");
    }
}