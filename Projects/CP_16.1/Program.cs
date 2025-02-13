using System;
using System.Diagnostics;
using System.Threading;

public class GCTimingTest
{
    public static void Main()
    {
        // Создание объектов разных поколений
        var obj = new object();
        GC.Collect(0, GCCollectionMode.Forced, blocking: true);
        GC.Collect(1, GCCollectionMode.Forced, blocking: true);
        GC.Collect(2, GCCollectionMode.Forced, blocking: true);

        // Тестирование режимов
        TestGCMode("Параллельная (по умолчанию)", GCCollectionMode.Default);
        TestGCMode("Фоновая", GCCollectionMode.Optimized);
        TestGCMode("Непараллельная", GCCollectionMode.Forced, blocking: true);
    }

    private static void TestGCMode(string modeName, GCCollectionMode mode, bool blocking = false)
    {
        // Генерация объектов
        for (int i = 0; i < 1000000; i++)
        {
            _ = new object();
        }

        var sw = Stopwatch.StartNew();
        GC.Collect(2, mode, blocking);
        GC.WaitForPendingFinalizers();
        sw.Stop();

        Console.WriteLine($"{modeName}: {sw.ElapsedMilliseconds} мс");
    }
}