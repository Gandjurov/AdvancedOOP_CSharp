using CustomDI.Core;
using SoftUniDI;
using System;
using System.Reflection;
using CustomDI.Modules;
using SurviceProvider;
using CustomDI.Core.Contracts;
using CustomDI.Models.Contracts;
using CustomDI.Models;

namespace CustomDI
{
    public class StartUp
    {
        public static void Main()
        {
            //var injector = DependencyInjector.CreateInjector(new Modules.Module());

            //var engine = injector.Inject<Engine>();

            //engine.Run();

            IServiceCollection serviceProvider = ConfigureServices();

            var engine = serviceProvider.CreateInstance<Engine>();
            engine.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddService<IEngine, Engine>();
            serviceCollection.AddService<IWriter, ConsoleWriter>();
            serviceCollection.AddService<IWriter, FileWriter>();
            serviceCollection.AddService<IReader, ConsoleReader>();

            return serviceCollection;
        }
    }
}
