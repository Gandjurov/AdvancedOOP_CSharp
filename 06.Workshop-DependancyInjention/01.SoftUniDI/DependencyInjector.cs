using SoftUniDI.Injectors;
using SoftUniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
