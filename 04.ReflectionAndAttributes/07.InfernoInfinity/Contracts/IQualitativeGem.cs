﻿using InfernoInfinity.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Contracts
{
    public interface IQualitativeGem
    {
        GemClarity Clarity { get; }
    }
}
