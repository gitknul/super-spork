using System;
using System.Diagnostics.CodeAnalysis;
using UdemyCourse.Collections;
using UdemyCourse.Collections.Extensions;

namespace UdemyCourse;

[ExcludeFromCodeCoverage]
internal class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Enter 'ok' to exit the program");
        } while (Console.ReadLine() != "ok");
    }

    static void ShowLinkedListDemo()
    {
        EnumerableLinkedList<int> list = new();

        for (int i = 0; i < 5; i++)
        {
            list.AddLast(i);
        }

        list.AddFirst(9);
        list.AddFirst(7);
        list.AddLast(99);

        foreach (int value in list)
        {
            Console.WriteLine("Value: " + value.ToString());
        }

        Console.WriteLine("***");

        foreach (int value in list.ToList ())
        {
            Console.WriteLine("Value: " + value);
        }

        Console.WriteLine("***");

        foreach (int value in list.ToArray ())
        {
            Console.WriteLine("Value: " + value);
        }
    }
}

[ExcludeFromCodeCoverage]
internal static class Search
{
    /// <returns>The index of the item in the array</returns>
    public static int LinearSearch(int[] items, int value)
    {
        for (int index = 0; index < items.Length; index++)
        {
            if (items[index] == value)
            {
                return index;
            }
        }

        return -1;
    }

    /// <returns>The index of the item in the array</returns>
    /// <param name="items">Sorted array</param>
    public static int BinarySearchLinear(int[] items, int key)
    {
        Console.WriteLine("BinarySearch");

        int left = 0;
        int right = items.Length - 1;

        while (left <= right)
        {
            int index = (int) Math.Floor((decimal) (left + right) / 2);
            int valueInArray = items[index];

            if (key == valueInArray)
            {
                return index;
            }
            else if (key < valueInArray)
            {
                right = index - 1;
            }
            else if (key > valueInArray)
            {
                left = index + 1;
            }
        }

        return -1;
    }

    /// <returns>The index of the item in the array</returns>
    /// <param name="items">Sorted array</param>
    public static int BinarySearchRecursive(int[] items, int key, int left, int right)
    {
        if (left > right)
        {
            return -1;
        }

        int index = (int) Math.Floor((decimal) (left + right) / 2);
        int valueInArray = items[index];

        if (key == valueInArray)
        {
            return index;
        }
        else if (key < valueInArray)
        {
            return BinarySearchRecursive(items, key, left, index - 1);
        }
        else
        {
            return BinarySearchRecursive(items, key, index + 1, right);
        }
    }
}

[ExcludeFromCodeCoverage]
internal class Recursion
{
    public int Sum(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        return Sum(n - 1) + n;
    }

    public int Factorial(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        return Factorial(n - 1) * n;
    }

    public void CalculateTail(int n)
    {
        if (n > 0)
        {
            int k = n * n;
            Console.WriteLine(k);
            CalculateTail(n - 1);
        }
    }

    public void CalculateHead(int n)
    {
        if (n > 0)
        {
            CalculateHead(n - 1);
            int k = n * n;
            Console.WriteLine(k);
        }
    }

    public void CalculateMiddle(int n)
    {
        if (n > 0)
        {
            CalculateMiddle(n - 1);
            int k = n * n;
            Console.WriteLine(k);
            CalculateMiddle(n - 1);
        }
    }
}