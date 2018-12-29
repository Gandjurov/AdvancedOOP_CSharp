using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split();

                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                Person p = new Person(name, age, town);
                people.Add(p);


                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person comparePerson = people[index];

            int equalPeople = 0;

            foreach (var p in people)
            {
                if (p.CompareTo(comparePerson) == 0)
                {
                    equalPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
