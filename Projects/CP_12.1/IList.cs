namespace Task1
{
    public interface IList<T>
    {
        void Add(T item);
        void Remove(T item);
        T Get(int index);
        void Set(int index, T item);
        int Count { get; }
    }
}
