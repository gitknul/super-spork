using System;
using System.Collections;
using System.Collections.Generic;

namespace UdemyCourse.Collections
{
    public class EnumerableLinkedList<T> : LinkedList<T>, IEnumerable<T>
    {
        LinkedListEnumerator<T> _enumerator;


        public EnumerableLinkedList()
        {
            _enumerator = new LinkedListEnumerator<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }
    }
}
