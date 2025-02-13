using System;

namespace Task1
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public ArrayList()
        {
            capacity = 4;
            items = new T[capacity];
            count = 0;
        }

        public int Count => count;

        public void Add(T item)
        {
            if (count == capacity)
            {
                capacity *= 2;
                T[] newItems = new T[capacity];
                for (int i = 0; i < count; i++)
                    newItems[i] = items[i];
                items = newItems;
            }
            items[count++] = item;
        }

        public void Remove(T item)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (object.Equals(items[i], item))
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
            {
                for (int i = index; i < count - 1; i++)
                    items[i] = items[i + 1];
                count--;
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            items[index] = item;
        }
    }
}
