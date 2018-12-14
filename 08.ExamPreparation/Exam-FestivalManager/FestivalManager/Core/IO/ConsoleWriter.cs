using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Core.IO.Contracts
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string contents)
        {
            Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
}
