namespace CustomDI.Core
{
    using CustomDI.Models.Contracts;
    using SoftUniDI.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        private readonly IWriter fileWriter;
        private readonly IReader consoleReader;

        public Engine(IWriter fileWriter, IReader consoleReader)
        {
            this.fileWriter = fileWriter;
            this.consoleReader = consoleReader;
        }

        public void Run()
        {
            string content = consoleReader.Read();
            this.fileWriter.Write(content);
        }

        //[Inject]
        //private IReader reader;

        //[Inject]
        //[Named("ConsoleWriter")]
        //private IWriter consoleWriter;

        //[Inject]
        //[Named("FileWriter")]
        //private IWriter fileWriter;

        //[Inject]
        //public Engine(IReader reader, IWriter consoleWriter, IWriter fileWriter)
        //{
        //    this.reader = reader;
        //    this.consoleWriter = consoleWriter;
        //    this.fileWriter = fileWriter;
        //}

        //public void Run()
        //{
        //    var readInput = this.reader.Read();
        //    this.consoleWriter.Write(readInput);
        //    this.fileWriter.Write(readInput);
        //}


    }
}
