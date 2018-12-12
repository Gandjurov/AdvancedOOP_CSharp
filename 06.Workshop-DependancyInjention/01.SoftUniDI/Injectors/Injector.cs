using SoftUniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI.Injectors
{
    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }
    }
}
