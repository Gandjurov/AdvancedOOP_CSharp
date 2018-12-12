namespace CustomDI.Models
{
    using CustomDI.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }


    }
}
