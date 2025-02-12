using System;

class Button
{
    private EventHandler _click;
    private int _subscriberCount = 0;
    private const int MaxSubscribers = 3;

    public string Text { get; set; }

    public event EventHandler Click
    {
        add
        {
            if (_subscriberCount < MaxSubscribers)
            {
                _click += value;
                _subscriberCount++;
                Console.WriteLine($"Subscriber added. Total subscribers: {_subscriberCount}");
            }
            else
            {
                Console.WriteLine("Maximum number of subscribers reached.");
            }
        }
        remove
        {
            _click -= value;
            _subscriberCount--;
            Console.WriteLine($"Subscriber removed. Total subscribers: {_subscriberCount}");
        }
    }

    public void OnClick()
    {
        _click?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Button button = new Button { Text = "Click Me" };

        // Подписчики на событие Click
        button.Click += (sender, e) => Console.WriteLine($"Button text: {((Button)sender).Text}");
        button.Click += (sender, e) => Console.WriteLine("Button clicked!");
        button.Click += (sender, e) => Console.WriteLine("Another action on click.");

        // Попытка добавить четвертого подписчика
        button.Click += (sender, e) => Console.WriteLine("This should not be added.");

        // Вызов события Click
        button.OnClick();

        // Удаление одного подписчика
        button.Click -= (sender, e) => Console.WriteLine("Button clicked!");

        // Повторный вызов события Click
        button.OnClick();
    }
}