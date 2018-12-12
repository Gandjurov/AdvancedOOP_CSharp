using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags)62)
                                 .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors((BindingFlags)62)
                                 .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }
    }
}
