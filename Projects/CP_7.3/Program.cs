using System;

namespace _7._3_КТ
{
    public class Calculator
    {
        public static double Add(double x, double y) => x + y;
        public static double Subtract(double x, double y) => x - y;
        public static double Multiply(double x, double y) => x * y;
        public static double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y;
        }

        public static double PerformOperation(double x, double y, Func<double, double, double> operation)
        {
            return operation(x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double a = 10, b = 5;

            Console.WriteLine(PerformOperation(a, b, Calculator.Add));       // 15
            Console.WriteLine(PerformOperation(a, b, Calculator.Subtract));  // 5
            Console.WriteLine(PerformOperation(a, b, Calculator.Multiply));  // 50
            Console.WriteLine(PerformOperation(a, b, Calculator.Divide));    // 2
        }

        public static double PerformOperation(double x, double y, Func<double, double, double> operation)
        {
            return operation(x, y);
        }
    }
}
