using Loger.Appenders.Contracts;
using Loger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loger.Appenders.Factory.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout); 
    }
}
