using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> top;

        public Stack()
        {
            this.top = null;
        }


        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.top == null)
            {
                this.top = newNode;
            }
            else
            {
                Node<T> saveCurrentTop = this.top;
                this.top = newNode;
                this.top.prev = saveCurrentTop;
            }
        }

        public T Pop()
        {
            if (this.top != null)
            {
                T returnValue = this.top.element;
                Node<T> current = this.top;
                this.top = this.top.prev;
                current = null;
                return returnValue;
            }

            throw new InvalidOperationException("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.top;

            while (current != null)
            {
                yield return current.element;

                current = current.prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.element = element;
                this.prev = null;
            }

            public T element { get; private set; }
            public Node<T> prev { get; set; }
        }
    }
}
