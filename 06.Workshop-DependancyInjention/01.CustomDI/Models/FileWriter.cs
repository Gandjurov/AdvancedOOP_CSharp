namespace CustomDI.Models
{
    using CustomDI.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FileWriter : IWriter
    {
        private const string FilePath = "log.txt";

        public void Write(string text)
        {
            File.AppendAllText(FilePath, text);
        }
    }
}
