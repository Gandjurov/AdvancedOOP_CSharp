namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStage stage = new Stage();
            IFestivalController festivalControler = new FestivalController(stage);
            ISetController setConstroler = new SetController(stage);

			IEngine engine = new Engine(reader, writer, festivalControler, setConstroler);

			engine.Run();
		}
	}
}