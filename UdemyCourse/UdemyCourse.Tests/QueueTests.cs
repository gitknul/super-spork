using System;
using UdemyCourse.Collections;
using Xunit;

namespace UdemyCourse.Tests;

public class QueueTests
{
    [Fact]
    public void TestEnqueue_ThatFits_Succeeds()
    {
        Queue<int> queue = new(8);
        
        queue.Enqueue(1);
        
        Assert.Equal(1, queue.Count);
    }    
    
    [Fact]
    public void TestEnqueue_InZeroCapacityQueue_Succeeds()
    {
        Queue<int> queue = new(0);
        
        queue.Enqueue(1);
        
        Assert.Equal(1, queue.Count);
    }
    
    [Fact]
    public void TestEnqueue_ThatDoesntFit_Succeeds()
    {
        Queue<int> queue = new(1);
        
        queue.Enqueue(1);
        queue.Enqueue(1);
        queue.Enqueue(1);
        queue.Enqueue(1);
        
        Assert.Equal(4, queue.Count);
    }

    [Fact]
    public void TestDequeue_OnFilledQueue_Succeeds()
    {
        Queue<int> queue = new(1);
        
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        int dequeued = queue.Dequeue();
        
        Assert.Equal(1, dequeued);
    }

    [Fact]
    public void TestPeek_OnFilledQueue_Succeeds()
    {
        Queue<int> queue = new(1);
        
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        int dequeued = queue.Peek();
        
        Assert.Equal(1, dequeued);
    }
    
    [Fact]
    public void TestDequeue_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        Queue<int> queue = new(1);
        
        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            queue.Dequeue();
        });
        
        Assert.Equal("Queue is empty", exception.Message);
    }
    
    [Fact]
    public void TestPeek_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        Queue<int> queue = new(1);
        
        var exception = Assert.Throws<InvalidOperationException>(() => queue.Peek());
        
        Assert.Equal("Queue is empty", exception.Message);
    }

    [Fact]
    public void TestContains_ThatContainsValue_Succeeds()
    {
        Queue<int> queue = new(1);

        queue.Enqueue(1);
        
        Assert.True(queue.Contains(1));
    }

    [Fact]
    public void TestContains_ThatDoesntContainsValue_Succeeds()
    {
        Queue<int> queue = new(1);

        queue.Enqueue(9);
        
        Assert.False(queue.Contains(1));
    }

    [Fact]
    public void TestClear_Succeeds()
    {
        Queue<int> queue = new(1);

        queue.Enqueue(9);
        queue.Enqueue(9);
        queue.Enqueue(9);
        queue.Enqueue(9);
        queue.Enqueue(9);
        queue.Enqueue(9);
        
        queue.Clear();
        
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void TestEnqueue_Dequeue_ContentsIsValid()
    {
        Queue<int> queue = new(4);
        
        queue.Enqueue(8);
        queue.Enqueue(4);

        queue.Dequeue();
        
        queue.Enqueue(99);
        queue.Enqueue(33);
        
        Assert.True(queue.Contains(4));
        Assert.True(queue.Contains(99));
        Assert.True(queue.Contains(33));
        
        Assert.False(queue.Contains(8));
        
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void TestEnqueue_Dequeue_BeyondCapcity_ContentsIsValid()
    {
        Queue<int> queue = new(4);
        
        queue.Enqueue(8);
        queue.Enqueue(4);
        queue.Enqueue(2);
        queue.Enqueue(1);

        queue.Dequeue();
        
        queue.Enqueue(99);
        queue.Enqueue(33);
        
        Assert.True(queue.Contains(4));
        Assert.True(queue.Contains(2));
        Assert.True(queue.Contains(1));
        Assert.True(queue.Contains(99));
        Assert.True(queue.Contains(33));
        
        Assert.False(queue.Contains(8));
        
        Assert.Equal(5, queue.Count);
    }
}