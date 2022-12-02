using System;

namespace UdemyCourse.Collections
{
    public class LinkedListNode<T>
    {
        public T Item { get; }

        public LinkedListNode<T> Next { get; internal set; }

        public LinkedListNode<T> Previous { get; internal set; }


        public LinkedListNode(T data)
        {
            Item = data;
        }
    }
}

