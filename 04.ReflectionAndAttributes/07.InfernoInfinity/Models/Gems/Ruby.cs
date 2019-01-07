using InfernoInfinity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(GemClarity clarity)
            : base(clarity, 7, 2, 5)
        {
        }
    }
}
