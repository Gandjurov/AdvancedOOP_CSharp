using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BarracksWarsReturnOfTheDependencies.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }
}
