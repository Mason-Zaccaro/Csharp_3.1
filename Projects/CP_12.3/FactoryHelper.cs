namespace Task3
{
    public static class FactoryHelper
    {
        public static T[] CreateArray<T>(IFactory<T> factory, int n)
        {
            T[] arr = new T[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = factory.Create();
            }
            return arr;
        }
    }
}
