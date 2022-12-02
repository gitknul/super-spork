using System;
using UdemyCourse.Collections;
using UdemyCourse.Collections.Extensions;
using Xunit;

namespace UdemyCourse.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void TestAddFirst_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddFirst(9);
            list.AddFirst(3);
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(14);

            Assert.Equal(14, list.First.Item);
            Assert.Equal(9, list.Last.Item);
        }

        [Fact]
        public void TestAddFirst_AsNode_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddFirst(new LinkedListNode<int> (9));
            list.AddFirst(new LinkedListNode<int> (3));
            list.AddFirst(new LinkedListNode<int> (1));
            list.AddFirst(new LinkedListNode<int> (2));
            list.AddFirst(new LinkedListNode<int> (14));

            Assert.Equal(14, list.First.Item);
            Assert.Equal(9, list.Last.Item);
        }

        [Fact]
        public void TestAddLast_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddLast(9);
            list.AddLast(3);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(14);

            Assert.Equal(9, list.First.Item);
            Assert.Equal(14, list.Last.Item);
        }

        [Fact]
        public void TestAddLast_AsNode_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddLast(new LinkedListNode<int> (9));
            list.AddLast(new LinkedListNode<int> (3));
            list.AddLast(new LinkedListNode<int> (1));
            list.AddLast(new LinkedListNode<int> (2));
            list.AddLast(new LinkedListNode<int> (14));

            Assert.Equal(9, list.First.Item);
            Assert.Equal(14, list.Last.Item);
        }

        [Fact]
        public void TestAddBeforeOnlyNode_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddFirst(9);

            list.AddBefore(4, list.First);

            Assert.Equal(4, list.First.Item);
            Assert.Equal(9, list.Last.Item);
        }

        [Fact]
        public void TestAfterOnlyNode_First_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddFirst(9);

            list.AddAfter(4, list.First);

            Assert.Equal(9, list.First.Item);
            Assert.Equal(4, list.Last.Item);
        }

        [Fact]
        public void TestAfterOnlyNode_Last_Succeeds()
        {
            LinkedList<int> list = new();

            list.AddFirst(9);

            list.AddAfter(4, list.Last);

            Assert.Equal(9, list.First.Item);
            Assert.Equal(4, list.Last.Item);
        }

        [Fact]
        public void TestAndGetNextAndPrevious_Succeeds()
        {
            LinkedListNode<int> node1 = new(1);
            LinkedListNode<int> node2 = new(2);
            LinkedListNode<int> node3 = new(3);
            
            LinkedList<int> list = new();
            
            list.AddFirst(node1);
            list.AddAfter(node3, node1);
            list.AddBefore(node2, node3);
            
            Assert.Equal(node1, node2.Previous);
            Assert.Equal(node3, node2.Next);
        }

        [Fact]
        public void TestAndGetFirstAndLast_Succeeds()
        {
            LinkedListNode<int> node1 = new(1);
            LinkedListNode<int> node2 = new(2);
            LinkedListNode<int> node3 = new(3);
            
            LinkedList<int> list = new();
            
            list.AddFirst(node1);
            list.AddAfter(node2, node1);
            list.AddAfter(node3, node2);
            
            Assert.Equal(node1, list.First);
            Assert.Equal(node3, list.Last);
        }

        [Fact]
        public void TestCount()
        {
            LinkedList<int> list = new();

            int totalCount = 1000;

            for (int i = 0; i < totalCount / 2; i++)
            {
                list.AddFirst(i);
            }

            for (int i = totalCount / 2; i < totalCount; i++)
            {
                list.AddLast(i);
            }
            
            Assert.Equal(totalCount, list.Count);
        }

        [Fact]
        public void TestAdd_AfterNull_ThrowsArgumentNullException()
        {
            LinkedList<int> list = new();

            Assert.Throws<ArgumentNullException>(() => list.AddAfter(1, null));
        }

        [Fact]
        public void TestAdd_BeforeNull_ThrowsArgumentNullException()
        {
            LinkedList<int> list = new();

            Assert.Throws<ArgumentNullException>(() => list.AddBefore(1, null));
        }

        [Fact]
        public void TestNext_OfLast_IsFirst_WithOneItem()
        {
            LinkedList<int> list = new();

            LinkedListNode<int> node = new(4);

            list.AddFirst(node);

            Assert.Equal(node, list.Last.Next);
        }

        [Fact]
        public void TestNext_OfLast_IsFirst_WithMultipleItems()
        {
            LinkedList<int> list = new();

            LinkedListNode<int> node = new(4);

            list.AddFirst(node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);

            Assert.Equal(node, list.Last.Next);
        }

        [Fact]
        public void TestPrevious_OfFirst_IsLast_WithMultipleItems()
        {
            LinkedList<int> list = new();

            LinkedListNode<int> node = new(4);

            list.AddFirst(node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);
            list.AddAfter(4, node);

            Assert.Equal(node, list.First.Previous);
        }

        [Fact]
        public void TestRemoveFirst_Succeeds()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            
            list.RemoveFirst();
            
            Assert.Equal(5, list.First.Item);
            Assert.Equal(8, list.Last.Item);
            
            Assert.Equal(5, list.Last.Next.Item);
            Assert.Equal(8, list.First.Previous.Item);
        }

        [Fact]
        public void TestRemoveLast_Succeeds()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            
            list.RemoveLast();
            
            Assert.Equal(4, list.First.Item);
            Assert.Equal(7, list.Last.Item);
            
            Assert.Equal(4, list.Last.Next.Item);
            Assert.Equal(7, list.First.Previous.Item);
        }
        
        [Fact]
        public void TestRemoveValue_WhichIsFirst_Succeeds()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            
            list.Remove(4);
            
            Assert.Equal(4, list.Count);
            Assert.Equal(5, list.First.Item);
            Assert.Equal(5, list.First.Next.Previous.Item);
            Assert.Equal(5, list.Last.Next.Item);
        }
        
        [Fact]
        public void TestRemoveValue_WhichIsLast_Succeeds()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            
            list.Remove(8);
            
            Assert.Equal(4, list.Count);
            Assert.Equal(7, list.Last.Item);
            Assert.Equal(7, list.Last.Next.Previous.Item);
            Assert.Equal(7, list.First.Previous.Item);
        }

        [Fact]
        public void TestRemoveValue_NonExistingElement_ThrowsInvalidOperationException()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(7);
            list.AddLast(8);

            Assert.Throws<InvalidOperationException>(() => list.Remove(9));
        }

        [Fact]
        public void TestRemoveNode_WhichIsLast_Succeeds()
        {
            LinkedList<int> list = new();

            LinkedListNode<int> node = new(8);
            
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(node);
            
            list.Remove(node);
            
            Assert.Equal(4, list.Count);
            Assert.Equal(7, list.Last.Item);
            Assert.Equal(7, list.Last.Next.Previous.Item);
            Assert.Equal(7, list.First.Previous.Item);
        }
        
        [Fact]
        public void TestRemoveNode_NonExistingElement_ThrowsInvalidOperationException()
        {
            LinkedList<int> list = new();
            
            list.AddLast(4);
            list.AddLast(7);
            list.AddLast(8);

            Assert.Throws<InvalidOperationException>(() => list.Remove(new LinkedListNode<int>(9)));
        }

        [Fact]
        public void TestRemoveValue_InEmptyList_ThrowsInvalidOperationException()
        {
            LinkedList<int> list = new();
            
            var exception = Assert.Throws<InvalidOperationException>(() => list.Remove(9));
            
            Assert.Equal("List is empty", exception.Message);
        }

        [Fact]
        public void TestRemoveNode_InEmptyList_ThrowsInvalidOperationException()
        {
            LinkedList<int> list = new();
            
            var exception = Assert.Throws<InvalidOperationException>(() => list.Remove(new LinkedListNode<int>(9)));
            
            Assert.Equal("List is empty", exception.Message);
        }

        [Fact]
        public void TestRemoveNode_Succeeds()
        {
            LinkedList<int> list = new();
            
            list.AddFirst(7);
            list.AddFirst(8);
            list.AddFirst(1);
            list.AddFirst(4);
            list.AddFirst(9);
            
            list.Remove(1);
            list.Remove(4);
            
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestRemove_OnlyNode_Succeeds()
        {
            LinkedList<int> linkedList = new();

            LinkedListNode<int> node = new LinkedListNode<int>(9);
            
            linkedList.AddLast(node);
            
            linkedList.Remove(node);
            
            Assert.Equal(0, linkedList.Count);
            Assert.Null(linkedList.First);
            Assert.Null(linkedList.Last);
        }

        [Fact]
        public void TestToList_Succeeds()
        {
            LinkedList<int> linkedList = new();
            
            linkedList.AddLast(7);
            linkedList.AddLast(8);
            linkedList.AddLast(1);
            linkedList.AddLast(5);

            System.Collections.Generic.List<int> list = linkedList.ToList();
            
            Assert.Equal(7, list[0]);
            Assert.Equal(8, list[1]);
            Assert.Equal(1, list[2]);
            Assert.Equal(5, list[3]);
        }

        [Fact]
        public void TestToArray_Succeeds()
        {
            LinkedList<int> linkedList = new();
            
            linkedList.AddLast(7);
            linkedList.AddLast(8);
            linkedList.AddLast(1);
            linkedList.AddLast(5);

            int[] list = linkedList.ToArray();
            
            Assert.Equal(7, list[0]);
            Assert.Equal(8, list[1]);
            Assert.Equal(1, list[2]);
            Assert.Equal(5, list[3]);
        }
    }
}