namespace CustomDI.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        [Inject]
        private IReader reader;

        [Inject]
        [Named("ConsoleWriter")]
        private IWriter consoleWriter;

        [Inject]
        [Named("FileWriter")]
        private IWriter fileWriter;

        //[Inject]
        //public Engine(IReader reader, IWriter consoleWriter, IWriter fileWriter)
        //{
        //    this.reader = reader;
        //    this.consoleWriter = consoleWriter;
        //    this.fileWriter = fileWriter;
        //}

        public void Run()
        {
            var readInput = this.reader.Read();
            this.consoleWriter.Write(readInput);
            this.fileWriter.Write(readInput);
        }
    }
}
