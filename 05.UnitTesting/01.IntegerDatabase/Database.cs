using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegerDatabase
{
    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[Capacity];
            //TODO: Test this Value
            this.index = -1;
        }

        public Database(int[] values)
            : this()
        {
            if (values.Length > 16)
            {
                throw new InvalidOperationException("Parameter is too long!");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];
            }
            this.index = values.Length - 1;
        }

        public void Add(int value)
        {
            //TODO: Test if Index value is 15
            if (this.index < Capacity - 1)
            {
                this.data[++this.index] = value;
                return;
            }

            throw new InvalidOperationException("Database is full!");
        }

        public void Remove()
        {
            //TODO test this case 
            if (this.index == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[this.index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.index + 1).ToArray();
        }
    }
}
