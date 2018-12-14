namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
