using System;
using System.Collections.Generic;
using System.Text;

namespace Overview
{
    public class Calculator
    {
        public int Sum(params int[] numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result;
        }
    }
}
