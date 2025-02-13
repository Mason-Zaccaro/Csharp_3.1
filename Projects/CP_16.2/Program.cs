using System;
using System.IO;
using System.Threading;

public class BackgroundGCDemo
{
    public static void Main()
    {
        GC.RegisterForFullGCNotification(10, 10);
        ThreadPool.QueueUserWorkItem(_ => MonitorGC());

        // Потоки для нагрузки
        for (int i = 0; i < 4; i++)
        {
            new Thread(AllocateMemory).Start();
            new Thread(ReadFile).Start();
        }

        Console.ReadLine();
    }

    private static void AllocateMemory()
    {
        while (true)
        {
            _ = new byte[1000];
            Thread.Sleep(1);
        }
    }

    private static void ReadFile()
    {
        while (true)
        {
            File.ReadAllBytes("temp.txt");
            Thread.Sleep(10);
        }
    }

    private static void MonitorGC()
    {
        while (true)
        {
            GCNotificationStatus status = GC.WaitForFullGCApproach();
            if (status == GCNotificationStatus.Succeeded)
            {
                Console.WriteLine($"Сборка началась. Поколение: {GC.GetGeneration(new object())}, Память: {GC.GetTotalMemory(false)}");
                GC.WaitForFullGCComplete();
                Console.WriteLine($"Сборка завершена. Память: {GC.GetTotalMemory(false)}");
            }
        }
    }
}