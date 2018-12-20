using System;
using System.Collections.Generic;

namespace Overview
{
    public class Overview
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { Name = "Pesho" });
            students.Add(new Student() { Name = "Gosho" });
            students.Add(new Student() { Name = "Kiro" });

            var studentEnumerator = students.GetEnumerator();

            //Current – returns the element in the collection at the current position of the enumerator
            Console.WriteLine(studentEnumerator.Current.Name);

            while (studentEnumerator.MoveNext())
            {
                Console.WriteLine(studentEnumerator.Current.Name);
            }

            //MoveNext() – advances the enumerator to the next element of the collection.
            Console.WriteLine(studentEnumerator.MoveNext());

            //Reset() – sets the enumerator to its initial position

            //==========================================================================================

            //Yield:
            //Indicates that the member in which it appears is an iterator
            //Simplifies the IEnumerator<T> implementations
            //Returns one element upon each loop cycle

            //==========================================================================================

            //Params:
            //Takes a variable number of arguments
            // Only one params keyword is allowed in a method declaration

            Calculator calculator = new Calculator();
            var result = calculator.Sum(1, 2, 4, 6, 8, 7);

            Console.WriteLine(result);

            //==========================================================================================
            //                              IComparable
            //==========================================================================================

            var sortedCars = new SortedSet<Car>(new CarComparer());

            sortedCars.Add(new Car() { Year = 2005});
            sortedCars.Add(new Car() { Year = 2008});
            sortedCars.Add(new Car() { Year = 2010});

            foreach (var item in sortedCars)
            {
                Console.WriteLine(item.Year);
            }
        }
    }
}
