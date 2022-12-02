using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UdemyCourse.Collections.Extensions;

[ExcludeFromCodeCoverage]
public static class LinkedListExtensions
{
    public static List<T> ToList<T>(this LinkedList<T> linkedList)
    {
        if (linkedList.First == null)
        {
            return new List<T>(0);
        }

        List<T> list = new(linkedList.Count);

        LinkedListNode<T> node = linkedList.First;

        for (int i = 0; i < linkedList.Count; i++)
        {
            list.Add(node.Item);

            node = node.Next;
        }

        return list;
    }

    public static List<LinkedListNode<T>> ToNodeList<T> (this LinkedList<T> linkedList)
    {
        if (linkedList.First == null)
        {
            return new List<LinkedListNode<T>>(0);
        }

        List<LinkedListNode<T>> list = new(linkedList.Count);

        LinkedListNode<T> node = linkedList.First;

        for (int i = 0; i < linkedList.Count; i++)
        {
            list.Add(node);

            node = node.Next;
        }

        return list;
    }

    public static T[] ToArray<T> (this LinkedList<T> linkedList)
    {
        if (linkedList.First == null)
        {
            return Array.Empty<T>();
        }

        T[] array = new T[linkedList.Count];

        LinkedListNode<T> node = linkedList.First;

        for (int i = 0; i < linkedList.Count; i++)
        {
            array[i] = node.Item;

            node = node.Next;
        }

        return array;
    }

    public static LinkedListNode<T>[] ToNodeArray<T>(this LinkedList<T> linkedList)
    {
        if (linkedList.First == null)
        {
            return Array.Empty<LinkedListNode<T>>();
        }

        LinkedListNode<T>[] array = new LinkedListNode<T>[linkedList.Count];

        LinkedListNode<T> node = linkedList.First;

        for (int i = 0; i < linkedList.Count; i++)
        {
            array[i] = node;

            node = node.Next;
        }

        return array;
    }
}