// 3. Ограниченный интерфейс IComparer<T>
public interface IComparer<T> where T : struct
{
    int Compare(T x, T y);
}

public struct ComplexNumber : IComparer<ComplexNumber>
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public int Compare(ComplexNumber x, ComplexNumber y)
    {
        double magX = Math.Sqrt(x.Real * x.Real + x.Imaginary * x.Imaginary);
        double magY = Math.Sqrt(y.Real * y.Real + y.Imaginary * y.Imaginary);
        return magX.CompareTo(magY);
    }
}

public struct RationalNumber : IComparer<RationalNumber>
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");
        Numerator = numerator;
        Denominator = denominator;
    }

    public int Compare(RationalNumber x, RationalNumber y)
    {
        double valX = (double)x.Numerator / x.Denominator;
        double valY = (double)y.Numerator / y.Denominator;
        return valX.CompareTo(valY);
    }
}