namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        public List<IBag> baggageCompartment;
        public List<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.passengers = new List<IPassenger>();
            this.baggageCompartment = new List<IBag>();
        }

        //TODO add fields
        public int BaggageCompartments { get; }
        public int Seats { get; }

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<IBag> BaggageCompartment { get => this.baggageCompartment.AsReadOnly(); }
        
        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var baggage = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return baggage;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            //TODO can occur an error
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passenger;
        }
    }
}
