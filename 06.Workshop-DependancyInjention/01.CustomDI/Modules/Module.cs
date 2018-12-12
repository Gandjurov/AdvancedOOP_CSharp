namespace CustomDI.Modules
{
    using CustomDI.Models;
    using CustomDI.Models.Contracts;
    using SoftUniDI.Modules.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Module : IModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }

        
    }
}
