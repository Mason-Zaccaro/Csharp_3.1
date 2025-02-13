using System;
using System.Collections.Generic;

public class Matrix
{
    private double[,] _data; // Внутренний двумерный массив для хранения данных

    public Matrix(int rows, int columns)
    {
        _data = new double[rows, columns];
    }

    // Индексатор для удобного доступа к элементам матрицы
    public double this[int row, int column]
    {
        get => _data[row, column];
        set => _data[row, column] = value;
    }

    // Метод для получения элементов строки через yield return
    public IEnumerable<double> GetRow(int index)
    {
        for (int j = 0; j < _data.GetLength(1); j++)
            yield return _data[index, j]; 
    }

    // Метод для получения элементов столбца через yield return
    public IEnumerable<double> GetColumn(int index)
    {
        for (int i = 0; i < _data.GetLength(0); i++)
            yield return _data[i, index]; 
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        Matrix matrix = new Matrix(3, 3);
        // Заполнение матрицы примерами значений
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                matrix[i, j] = i * 3 + j + 1;

        // Вывод строки 0 (1, 2, 3)
        Console.WriteLine("Строка 0:");
        foreach (var num in matrix.GetRow(0))
            Console.Write(num + " ");

        // Вывод столбца 1 (2, 5, 8)
        Console.WriteLine("\nСтолбец 1:");
        foreach (var num in matrix.GetColumn(1))
            Console.Write(num + " ");
    }
}