using System;
using UdemyCourse.Collections;
using Xunit;

namespace UdemyCourse.Tests;

public class StackTests
{
    [Fact]
    public void TestPush_ThatFits_Succeeds()
    {
        Stack<int> stack = new(8);
        
        stack.Push(1);
        
        Assert.Equal(1, stack.Count);
    }
    
    [Fact]
    public void TestPush_ThatDoesntFit_Succeeds()
    {
        Stack<int> stack = new(1);
        
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);
        
        Assert.Equal(4, stack.Count);
    }

    [Fact]
    public void TestPop_OnFilledStack_Succeeds()
    {
        Stack<int> stack = new(1);
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        int poppedValue = stack.Pop();
        
        Assert.Equal(3, poppedValue);
    }

    [Fact]
    public void TestPeek_OnFilledStack_Succeeds()
    {
        Stack<int> stack = new(1);
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        int poppedValue = stack.Peek();
        
        Assert.Equal(3, poppedValue);
    }
    
    [Fact]
    public void TestPop_OnEmptyStack_ThrowsInvalidOperationException()
    {
        Stack<int> stack = new(1);
        
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Pop());
        
        Assert.Equal("Stack is empty", exception.Message);
    }
    
    [Fact]
    public void TestPeek_OnEmptyStack_ThrowsInvalidOperationException()
    {
        Stack<int> stack = new(1);
        
        var exception = Assert.Throws<InvalidOperationException>(() => stack.Peek());
        
        Assert.Equal("Stack is empty", exception.Message);
    }

    [Fact]
    public void TestContains_ThatContainsValue_Succeeds()
    {
        Stack<int> stack = new(1);

        stack.Push(1);
        
        Assert.True(stack.Contains(1));
    }

    [Fact]
    public void TestContains_ThatDoesntContainsValue_Succeeds()
    {
        Stack<int> stack = new(1);

        stack.Push(9);
        
        Assert.False(stack.Contains(1));
    }

    [Fact]
    public void TestClear_Succeeds()
    {
        Stack<int> stack = new(1);

        stack.Push(9);
        stack.Push(9);
        stack.Push(9);
        stack.Push(9);
        stack.Push(9);
        stack.Push(9);
        
        stack.Clear();
        
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void TestPush_Pop_ContentsIsValid()
    {
        Stack<int> stack = new();
        
        stack.Push(8);
        stack.Push(4);

        stack.Pop();
        
        stack.Push(99);
        stack.Push(33);
        
        Assert.True(stack.Contains(8));
        Assert.True(stack.Contains(99));
        Assert.True(stack.Contains(33));
        Assert.False(stack.Contains(4));
        
        Assert.Equal(3, stack.Count);
    }
}