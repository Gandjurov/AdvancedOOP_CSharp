namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Entities.Airplanes;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            var airplaneInstance = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplaneInstance;

        }
	}
}