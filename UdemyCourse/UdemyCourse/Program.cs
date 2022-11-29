using System;

namespace UdemyCourse;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new[] { 1, 2, 5, 7, 11, 16, 18, 24, 29, 40, 50, 55, 69, 82, 90 };

        var binaryIndex = Search.BinarySearch(numbers, 40);

        Console.WriteLine("Index: " + binaryIndex.ToString());

        while (Console.ReadLine() != "ok")
        {
            Console.WriteLine("Enter 'ok' to exit the program");
        }
    }
}

static class Search
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
    public static int BinarySearch(int[] items, int key)
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
}

class Recursion
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