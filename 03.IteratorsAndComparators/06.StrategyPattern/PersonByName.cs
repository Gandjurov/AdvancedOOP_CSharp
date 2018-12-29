using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class PersonByName : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);

            if (result == 0)
            {
                char firstLetter = char.ToLower(first.Name[0]);
                char secondLetter = char.ToLower(second.Name[0]);

                result = firstLetter.CompareTo(secondLetter);
            }

            return result;
        }
    }
}
