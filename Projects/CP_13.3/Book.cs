namespace Task3
{
    // Пример класса Book, переопределяющего метод ToString().
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public override string ToString() => $"\"{Title}\" by {Author} (${Price})";
    }
}
