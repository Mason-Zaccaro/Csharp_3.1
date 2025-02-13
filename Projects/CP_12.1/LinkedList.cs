using System;

namespace Task1
{
    public class LinkedList<T> : IList<T>
    {
        // Внутренний класс узла
        private class Node
        {
            public T Data;
            public Node Next;
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;

        public int Count => count;

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
                head = newNode;
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public void Remove(T item)
        {
            if (head == null)
                return;

            if (object.Equals(head.Data, item))
            {
                head = head.Next;
                count--;
                return;
            }

            Node current = head;
            while (current.Next != null && !object.Equals(current.Next.Data, item))
                current = current.Next;

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                count--;
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current.Data;
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            current.Data = item;
        }
    }
}
