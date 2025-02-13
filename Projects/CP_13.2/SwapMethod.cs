namespace Task2
{
    public static class Utils
    {
        // Метод меняет местами значения двух переменных.
        // Ограничение where T : notnull позволяет использовать как ссылочные (class),
        // так и типы значений (struct), при этом указатели в безопасном коде недопустимы,
        // а динамические типы не имеют собственного ограничения.
        public static void Swap<T>(ref T x, ref T y) where T : notnull
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
