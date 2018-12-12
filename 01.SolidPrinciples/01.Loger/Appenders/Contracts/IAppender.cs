using Loger.Loggers.Enums;

namespace Loger.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }
    }
}
