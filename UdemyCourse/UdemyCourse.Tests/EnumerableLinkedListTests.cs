using UdemyCourse.Collections;
using Xunit;

namespace UdemyCourse.Tests;

public class EnumerableLinkedListTests
{
    [Fact]
    public void TestIterate()
    {
        var linkedList = new EnumerableLinkedList<int>();

        for (int i = 0; i < 100; i++)
        {
            linkedList.AddLast(i);
        }

        int lastValue = -1;
        
        foreach (int value in linkedList)
        {
            Assert.True(value > lastValue);

            lastValue = value;
        }
    }
}