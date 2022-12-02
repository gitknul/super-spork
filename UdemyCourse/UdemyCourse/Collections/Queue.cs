using System;

namespace UdemyCourse.Collections;

public class Queue<T>
{
    QueueNode<T>[] _elements;

    readonly int _initialCapacity;

    int _head;
    int _tail;

    public int Count
    {
        get
        {
            if (_head == _tail && _elements[_head] == null)
            {
                return 0;
            }

            return _tail - _head + 1;
        }
    }
    

    public Queue(int capacity = 4)
    {
        _initialCapacity = capacity;
        
        _elements = new QueueNode<T>[_initialCapacity];
    }

    public void Enqueue(T element)
    {
        if (_elements.Length == 0)
        {
            _elements = new[] { new QueueNode<T>(element) };
            
            return;
        }
        
        if (_elements[0] == null && Count == 0)
        {
            _elements[0] = new QueueNode<T>(element);
            
            return;
        }

        int itemsInArray = _tail - _head + 1;

        bool isArrayFull = _elements.Length == itemsInArray;
        
        if (isArrayFull)
        {
            var copy = new QueueNode<T>[Math.Max(2, Count * 2)];
        
            _elements.CopyTo(copy, 0);

            int newIndex = Count;

            copy[newIndex] = new QueueNode<T>(element);

            _elements = copy;
            _head = 0; 
            _tail = newIndex;
        }
        else if (_tail == _elements.Length - 1 && _head >= 0)
        {
            for (int i = 0; i < _elements.Length; i++)
            {
                int index = i + _head;
                if (index < _elements.Length)
                {
                    _elements[i] = _elements[index];
                    _tail = i;
                }
                else
                {
                    _elements[i] = null;
                }
            }

            _elements[_tail + 1] = new QueueNode<T>(element);

            _tail++;
            
            _head = 0;
        }
        else
        {
            _elements[_tail + 1] = new QueueNode<T>(element);

            _tail++;
        }
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        
        T item = _elements[_head].Data;

        _elements[_head] = null;
        
        _head++;

        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        
        return _elements[_head].Data;
    }

    public void Clear()
    {
        _elements = new QueueNode<T>[_initialCapacity];
        _head = 0;
        _tail = 0;
    }
    
    public bool Contains(T element)
    {
        for (int i = _head; i <= _tail; i++)
        {
            if (_elements[i] != null && _elements[i].Data.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsEmpty()
    {
        return _elements.Length == 0 || Count == 0;
    }
}

internal record QueueNode<T>(T Data);