using Loger.Appenders.Contracts;
using Loger.Appenders.Factory.Contracts;
using Loger.Layouts.Contracts;
using Loger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLowerCase = type.ToLower();

            switch (typeAsLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
