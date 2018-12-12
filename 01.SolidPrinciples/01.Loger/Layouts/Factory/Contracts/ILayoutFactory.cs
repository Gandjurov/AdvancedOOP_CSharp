using Loger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loger.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
