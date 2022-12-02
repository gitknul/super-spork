using System;
using System.Collections;
using System.Collections.Generic;

namespace UdemyCourse.Collections
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        readonly LinkedList<T> _list;

        LinkedListNode<T> _node;

        T _current;

        int _index;

        public T Current => _current;

        object IEnumerator.Current
        {
            get
            {
                if (_index == 0 || _index == _list.Count + 1)
                {
                    throw new InvalidOperationException();
                }

                return Current;
            }
        }

        internal LinkedListEnumerator(EnumerableLinkedList<T> list)
        {
            _list = list;
            _node = list.First;
            _current = default(T);
            _index = 0;
        }

        public bool MoveNext()
        {
            if (_index == 0)
            {
                _node = _list.First;
            }

            if (_node == null)
            {
                _index = _list.Count + 1;
                return false;
            }

            _index++;
            _current = _node.Item;
            _node = _node.Next;

            if (_node == _list.First)
            {
                _node = null;
            }

            return true;
        }

        public void Dispose()
        {

        }

        public void Reset()
        {
            _current = default(T);
            _node = _list.First;
            _index = 0;
        }
    }

}

