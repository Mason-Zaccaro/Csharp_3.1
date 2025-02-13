using System;

// Универсальный интерфейс для печати, работающий с классами и структурами
public interface IPrintable<T> where T : notnull
{
    void Print();
}

// Класс Student, реализующий интерфейс IPrintable
class Student : IPrintable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public void Print()
    {
        Console.WriteLine($"Student: {Name}, {Age} years old, Grade: {Grade}");
    }
}

// Структура Vector, реализующая интерфейс IPrintable
struct Vector : IPrintable<Vector>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public void Print()
    {
        Console.WriteLine($"Vector: X = {X}, Y = {Y}, Z = {Z}");
    }
}

class Program
{
    static void Main()
    {
        IPrintable<Student> student = new Student { Name = "John", Age = 20, Grade = "A" };
        student.Print();

        IPrintable<Vector> vector = new Vector { X = 1.0, Y = 2.0, Z = 3.0 };
        vector.Print();
    }
}
