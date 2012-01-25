namespace EvolutionNet.CodeGeneration.UI.ConsoleGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			var generator = new Scaffolding();
			generator.Run(args);
		}
	}

}
