using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListIterator
{
    public interface ISoftUniList<T> : IEnumerable<T>
    {
        int Count { get; }

        T this[int number] { get; set; }

        void Add(T element);

        T Remove(int index);

        bool Contains(T element);

        void Swap(int index1, int index2);

        int CountGreaterThan(T element);

        T Max();

        T Min();

        void Sort();
    }
}
