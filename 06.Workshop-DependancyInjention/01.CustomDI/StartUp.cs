using System;

namespace CustomDI
{
    public class StartUp
    {
        public static void Main()
        {
            var injector = DependencyInjector.CreateInjector(new Module());

            var engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}
