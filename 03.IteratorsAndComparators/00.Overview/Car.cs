using System;
using System.Collections.Generic;
using System.Text;

namespace Overview
{
    public class Car : IComparable<Car>
    {
        public int Year { get; set; }

        public int CompareTo(Car other)
        {
            return this.Year.CompareTo(other.Year);
        }
    }
}
