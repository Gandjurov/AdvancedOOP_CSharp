namespace Loger
{
    using Appenders;
    using Appenders.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using Loger.Core;
    using Loger.Core.Contracts;
    using Loger.Loggers.Enums;
    using Loggers;
    using Loggers.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);

            engine.Run();

        }
    }
}
