using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ISoftUniList<string> softUniList = new SoftUniList<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];
                string element = string.Empty;

                switch (command)
                {
                    case "Add":
                        element = inputArgs[1];
                        softUniList.Add(element);
                        break;
                    case "Remove":
                        int index = int.Parse(inputArgs[1]);
                        softUniList.Remove(index);
                        break;
                    case "Contains":
                        element = inputArgs[1];
                        Console.WriteLine(softUniList.Contains(element));
                        break;
                    case "Swap":
                        int index1 = int.Parse(inputArgs[1]);
                        int index2 = int.Parse(inputArgs[2]);
                        softUniList.Swap(index1, index2);
                        break;
                    case "Greater":
                        element = inputArgs[1];
                        Console.WriteLine(softUniList.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(softUniList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(softUniList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(softUniList);
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
