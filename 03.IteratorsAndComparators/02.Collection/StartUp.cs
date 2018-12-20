using System;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            ListyIterator<string> list = new ListyIterator<string>(data);

            string input = Console.ReadLine();

            while (input != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", list));

                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
