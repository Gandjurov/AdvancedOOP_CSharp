namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport
	{
		public List<IBag> takenBags;
		public List<IBag> notTakenBags;
		public List<ITrip> adventures;
		public List<IPassenger> people;

		public IPassenger GetPassenger(string username) => throw new MissingMethodException();

		public ITrip GetTrip(string id) => throw new MissingMethodException();

		public void AddPassenger(IPassenger passenger) => throw new MissingMethodException();

		public void AddTrip(ITrip trip) => throw new MissingMethodException();

		public void AddCheckedBag(IBag bag) => throw new MissingMethodException();

		public void AddConfiscatedBag(IBag bag) => throw new MissingMethodException();
	}
}