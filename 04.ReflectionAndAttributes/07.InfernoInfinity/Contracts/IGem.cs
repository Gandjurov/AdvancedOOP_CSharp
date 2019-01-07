using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }
    }
}
