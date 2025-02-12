public interface IClonable<T>
{
    T Clone();
}

public class Point : IClonable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point() { }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Point other)
    {
        X = other.X;
        Y = other.Y;
    }

    public Point Clone() => new Point(this);
}

public class Rectangle : IClonable<Rectangle>
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle() { }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Rectangle(Rectangle other)
    {
        Width = other.Width;
        Height = other.Height;
    }

    public Rectangle Clone() => new Rectangle(this);
}

public static class CloningHelper
{
    public static T CloneObject<T>(T obj) where T : IClonable<T>
    {
        return obj.Clone();
    }
}

class Program
{
    static void Main()
    {
        // Тестирование CloneObject
        Point p1 = new Point(5, 10);
        Point p2 = CloningHelper.CloneObject(p1);
        Console.WriteLine($"Клон точки: X = {p2.X}, Y = {p2.Y}");

        Rectangle r1 = new Rectangle(20, 30);
        Rectangle r2 = CloningHelper.CloneObject(r1);
        Console.WriteLine($"Клон прямоугольника: Width = {r2.Width}, Height = {r2.Height}");
    }
}