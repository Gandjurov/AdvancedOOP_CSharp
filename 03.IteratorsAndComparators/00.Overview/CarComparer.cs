﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Overview
{
    public class CarComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}
