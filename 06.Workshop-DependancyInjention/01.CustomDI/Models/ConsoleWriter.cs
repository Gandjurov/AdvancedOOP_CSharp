using CustomDI.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDI.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
