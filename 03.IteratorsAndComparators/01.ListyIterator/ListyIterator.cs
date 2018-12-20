using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private T[] elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index < this.elements.Length)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.index < this.elements.Length - 1 ? true : false;
        }

        public void Print()
        {
            if (this.elements.Length != 0)
            {
                Console.WriteLine(this.elements[this.index]);
                return;
            }

            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}
