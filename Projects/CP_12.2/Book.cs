namespace Task2
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public override string ToString() => $"Book: {Title}, Author: {Author}, Price: {Price}";
    }
}
