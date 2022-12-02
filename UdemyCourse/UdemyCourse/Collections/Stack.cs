using System;

namespace UdemyCourse.Collections;

public class Stack<T>
{
    T[] _elements;

    readonly int _initialCapacity;
    
    int _length;
    public int Count => _length;
    

    public Stack(int capacity = 4)
    {
        _initialCapacity = capacity;

        _elements = new T[_initialCapacity];
    }
    
    public void Push(T element)
    {
        if (_length == _elements.Length)
        {
            var copy = new T[Math.Max(2, _length * 2)];
            
            _elements.CopyTo(copy, 0);

            copy[_length] = element;

            _elements = copy;
        }
        else if (_length < _elements.Length)
        {
            _elements[_length] = element;
        }
        
        _length++;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var element = _elements[_length - 1];

        _elements[_length - 1] = default;
        
        _length--;

        return element;
    }
    
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _elements[_length - 1];
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (element == null && _elements[i] == null || 
                element != null && _elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsEmpty()
    {
        return _length == 0;
    }

    public void Clear()
    {
        _elements = new T[_initialCapacity];
        _length = 0;
    }
}