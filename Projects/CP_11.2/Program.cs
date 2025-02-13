using System;

// Узел связного списка
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

// Обобщенный класс LinkedList<T>
public class LinkedList<T> where T : class
{
    private Node<T> head;

    // Добавление элемента в конец списка
    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Удаление элемента
    public void Remove(T item)
    {
        if (head == null) return;

        if (head.Data.Equals(item))
        {
            head = head.Next;
            return;
        }

        Node<T> current = head;
        while (current.Next != null && !current.Next.Data.Equals(item))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    // Проверка наличия элемента
    public bool Contains(T item)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Вывод всех элементов
    public void PrintAll()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}

// Класс Person
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Person: {Name}, {Age} years old";
    }
}

// Класс Book
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public override string ToString()
    {
        return $"Book: {Title} by {Author}";
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        LinkedList<string> stringList = new LinkedList<string>();
        stringList.Add("Hello");
        stringList.Add("World");
        stringList.PrintAll();

        LinkedList<Person> personList = new LinkedList<Person>();
        personList.Add(new Person { Name = "Alice", Age = 30 });
        personList.Add(new Person { Name = "Bob", Age = 25 });
        personList.PrintAll();

        LinkedList<Book> bookList = new LinkedList<Book>();
        bookList.Add(new Book { Title = "1984", Author = "George Orwell" });
        bookList.Add(new Book { Title = "Brave New World", Author = "Aldous Huxley" });
        bookList.PrintAll();
    }
}
