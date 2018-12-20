namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Entities.Airplanes;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
			switch (type)
			{
				case "LightAirplane":
					return new LightAirplane();
				case "MediumAirplane":
					return new MediumAirplane();
				default:
					return null; //TODO what to return
			}
		}
	}
}