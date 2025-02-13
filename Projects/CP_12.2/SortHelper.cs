namespace Task2
{
    public static class SortHelper
    {
        // Простой пузырьковый алгоритм сортировки
        public static void SortArray<T>(T[] array, IComparer<T> comparer)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
