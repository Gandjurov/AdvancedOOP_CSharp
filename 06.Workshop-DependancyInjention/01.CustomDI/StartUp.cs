using CustomDI.Core;
using SoftUniDI;
using System;
using System.Reflection;
using CustomDI.Modules;

namespace CustomDI
{
    public class StartUp
    {
        public static void Main()
        {
            var injector = DependencyInjector.CreateInjector(new Modules.Module());

            var engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}
