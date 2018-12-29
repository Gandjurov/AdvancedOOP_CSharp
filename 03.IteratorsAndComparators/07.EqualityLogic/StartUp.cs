using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> SortedPeople = new SortedSet<Person>();
            HashSet<Person> peopleByHash = new HashSet<Person>();

            while (n-- > 0)
            {
                string[] args = Console.ReadLine().Split();

                Person p = new Person(args[0], int.Parse(args[1]));

                SortedPeople.Add(p);
                peopleByHash.Add(p);
            }

            Console.WriteLine(SortedPeople.Count);
            Console.WriteLine(peopleByHash.Count);
        }
    }
}
