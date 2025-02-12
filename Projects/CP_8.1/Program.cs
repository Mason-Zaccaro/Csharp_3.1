using System;
using System.Threading;

class Timer
{
    public event EventHandler Tick;

    public void Start()
    {
        while (true)
        {
            Thread.Sleep(1000); // Задержка в 1 секунду
            OnTick();
        }
    }

    protected virtual void OnTick()
    {
        Tick?.Invoke(this, EventArgs.Empty);
    }
}

class Clock
{
    public Clock(Timer timer)
    {
        timer.Tick += OnTick;
    }

    private void OnTick(object sender, EventArgs e)
    {
        Console.WriteLine($"Current Time: {DateTime.Now.ToLongTimeString()}");
    }
}

class Counter
{
    private int _count;

    public Counter(Timer timer)
    {
        timer.Tick += OnTick;
    }

    private void OnTick(object sender, EventArgs e)
    {
        _count++;
        Console.WriteLine($"Counter: {_count}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Timer timer = new Timer();
        Clock clock = new Clock(timer);
        Counter counter = new Counter(timer);

        timer.Start();
    }
}