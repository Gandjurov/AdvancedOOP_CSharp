namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
	using Instruments;

	public class Performer
	{
		private readonly List<IInstrument> instruments;

		public Performer(string name, int age)
		{
			this.Name = name;
			this.Age = age;

			this.instruments = new List<IInstrument>();
		}

		public string Name { get; private set; }

		public int Age { get; private set; }

		public IReadOnlyCollection<IInstrument> Instruments => this.instruments.AsReadOnly();

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

        //NB: Might be a bug
		public override string ToString()
		{
			return this.Name;
		}
	}
}
