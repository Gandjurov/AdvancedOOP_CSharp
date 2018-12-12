namespace Loger.Loggers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);

        void Info(string dateTime, string infoMessage);
    }
}
