namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
			switch (type)
			{
				case "Item":
					return new Item();
				case "CellPhone":
					return new Colombian();
				case "Colombian":
					return new Colombian();
				case "Jewelery":
					return new Jewelery();
				case "Laptop":
					return new Laptop();
				case "toothbrush":
					return new Toothbrush();
				case "TravelKit":
					return new TravelKit();
				default:
					return new Soap();
			}
		}
	}
}
