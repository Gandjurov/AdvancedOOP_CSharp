using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private const int LightSeats = 5;
        private const int LightBaggageCompartments = 8;

        public LightAirplane() 
            : base(LightSeats, LightBaggageCompartments)
        {
        }
    }
}
