
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
        private bool isRunning;
	    private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, 
                      IWriter writer, 
                      IFestivalController festivalCоntroller, 
                      ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

		public void Run()
		{
            this.isRunning = true;

			while (isRunning) 
			{
				var input = reader.ReadLine();

                if (input == "END")
                {
                    this.isRunning = false;
                }

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		private  string ProcessCommand(string input)
		{
			string[] tokens = input.Split();

			var command = tokens[0];
			var args = tokens
                        .Skip(1)
                        .ToArray();

            string result;

			if (command == "LetsRock")
			{
				result = this.setCоntroller.PerformSets();
			}
            else
            {
                var festivalControllerMethod = this.festivalCоntroller
                                                   .GetType()
                                                   .GetMethods()
                                                   .FirstOrDefault(x => x.Name == command);
                result = (string)festivalControllerMethod.Invoke(this.festivalCоntroller, new object[] { args });
            }

            return result;
		}
	}
}