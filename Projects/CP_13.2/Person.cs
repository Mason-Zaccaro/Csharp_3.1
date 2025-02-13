namespace Task2
{
    // Пример пользовательского класса для демонстрации работы Swap.
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"Person: {Name}, {Age} years old";
    }
}
