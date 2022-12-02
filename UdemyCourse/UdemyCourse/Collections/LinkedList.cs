using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UdemyCourse.Collections
{
    public class LinkedList<T>
    {
        int _length;

        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public int Count => _length;


        public LinkedList()
        {
            _length = 0;
        }

        /// <summary>
        /// Inserts a node at the front of the list
        /// </summary>
        public void AddFirst(T data)
        {
            AddFirstInternal(new LinkedListNode<T>(data));
        }

        /// <summary>
        /// Inserts a node at the front of the list
        /// </summary>
        public void AddFirst(LinkedListNode<T> newNode)
        {
            AddFirstInternal(newNode);
        }

        /// <summary>
        /// Appends a node at the end of the list
        /// </summary>
        public void AddLast(T data)
        {
            AddLastInternal(new LinkedListNode<T>(data));
        }

        /// <summary>
        /// Appends a node at the end of the list
        /// </summary>
        public void AddLast(LinkedListNode<T> newNode)
        {
            AddLastInternal(newNode);
        }

        /// <summary>
        /// Inserts a node after a specific node in the list
        /// </summary>
        public void AddAfter(T element, LinkedListNode<T> after)
        {
            AddAfterInternal(new LinkedListNode<T>(element), after);
        }

        /// <summary>
        /// Inserts a node after a specific node in the list
        /// </summary>
        public void AddAfter(LinkedListNode<T> newNode, LinkedListNode<T> after)
        {
            AddAfterInternal(newNode, after);
        }

        /// <summary>
        /// Inserts a node before a specific node in the list
        /// </summary>
        public void AddBefore(T element, LinkedListNode<T> before)
        {
            AddBeforeInternal(new LinkedListNode<T>(element), before);
        }

        /// <summary>
        /// Inserts a node before a specific node in the list
        /// </summary>
        public void AddBefore(LinkedListNode<T> newNode, LinkedListNode<T> before)
        {
            AddBeforeInternal(newNode, before);
        }

        public void Remove(T value)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"List is empty");
            }

            if (value == null && First.Item == null || (value?.Equals(First.Item) ?? false))
            {
                RemoveFirst();
                return;
            }
            else if (value == null && Last.Item == null || (value?.Equals(Last.Item) ?? false))
            {
                RemoveLast();
                return;
            }

            LinkedListNode<T> node = First;

            bool breakOnNext = false;

            while (node.Item == null || !node.Item.Equals(value))
            {
                node = node.Next;

                if (node == Last || node.Item == null && value == null)
                {
                    breakOnNext = true;
                }
                else if (breakOnNext)
                {
                    node = null;
                    break;
                }
            }

            if (node == null)
            {
                throw new InvalidOperationException($"Element with value {(value == null ? null : value.ToString())} was not found");
            }

            RemoveInternal(node);
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException($"List is empty");
            }

            if (node == First)
            {
                RemoveFirst();
                return;
            }
            else if (node == Last)
            {
                RemoveLast();
                return;
            }
            
            LinkedListNode<T> element = First;

            bool breakOnNext = false;

            while (element != node)
            {
                element = element.Next;

                if (element == Last)
                {
                    breakOnNext = true;
                }
                else if (breakOnNext)
                {
                    element = null;
                    break;
                }
            }

            if (element == null)
            {
                throw new InvalidOperationException(
                    $"Element with value {(node.Item == null ? null : node.Item.ToString())} was not found");
            }

            RemoveInternal(node);
        }

        
        public void RemoveFirst()
        {
            if (_length == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                First = First.Next;

                First.Previous = Last;
                Last.Next = First;
            }

            _length--;
        }

        public void RemoveLast()
        {
            if (_length == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                Last = Last.Previous;

                First.Previous = Last;
                Last.Next = First; 
            }

            _length--;
        }

        public bool IsEmpty()
        {
            return _length == 0;
        }

        void AddFirstInternal(LinkedListNode<T> newNode)
        {
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;

                newNode.Previous = First;
                newNode.Next = Last;
            }
            else
            {
                newNode.Next = First;
                First.Previous = newNode;
            }

            First = newNode;

            Last ??= First;

            _length++;
        }

        void AddLastInternal(LinkedListNode<T> newNode)
        {
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                LinkedListNode<T> oldLast = Last;

                newNode.Previous = oldLast;
                newNode.Next = First;

                oldLast.Next = newNode;
            }

            Last = newNode;

            _length++;
        }

        void AddBeforeInternal(LinkedListNode<T> newNode, LinkedListNode<T> before)
        {
            if (before == null)
            {
                throw new ArgumentNullException(nameof(before));
            }

            newNode.Next = before;
            newNode.Previous = before.Previous;

            before.Previous = newNode;

            if (before == First)
            {
                First = newNode;
            }

            _length++;
        }

        void AddAfterInternal(LinkedListNode<T> newNode, LinkedListNode<T> after)
        {
            if (after == null)
            {
                throw new ArgumentNullException(nameof(after));
            }

            newNode.Previous = after;
            newNode.Next = after.Next;
            after.Next = newNode;

            if (after == Last)
            {
                Last = newNode;
            }

            _length += 1;
        }

        void RemoveInternal(LinkedListNode<T> node)
        {
            if (_length == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            _length--;
        }
    }
}