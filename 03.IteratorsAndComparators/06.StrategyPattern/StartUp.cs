using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> peopleByName = new SortedSet<Person>(new PersonByName());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new PersonByAge());

            while (n-- > 0)
            {
                string[] args = Console.ReadLine().Split();

                Person p = new Person(args[0], int.Parse(args[1]));

                peopleByName.Add(p);
                peopleByAge.Add(p);
            }

            Console.WriteLine(string.Join(Environment.NewLine, peopleByName));
            Console.WriteLine(string.Join(Environment.NewLine, peopleByAge));
        }
    }
}
