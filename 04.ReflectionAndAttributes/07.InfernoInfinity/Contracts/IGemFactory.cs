using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string clarity, string gemType);
    }
}
