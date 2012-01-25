using System.Collections.Generic;

namespace EvolutionNet.Util.CommandLine
{
	public class ArgumentCommand : IArgument
	{
		private readonly ArgumentType type = ArgumentType.Command;

		public string Name { get; private set; }

		public string Description { get; private set; }

		public bool AllowMultipleExecutions { get; private set; }

		public List<ArgumentInternal> InternalArguments { get; private set; }

		public ProcessDelegate Process { get; private set; }

		public ArgumentType Type
		{
			get { return type; }
		}

		public ArgumentCommand(string name, string description, ProcessDelegate process)
			: this(name, description, true, null, process)
		{
		}

		public ArgumentCommand(string name, string description, List<ArgumentInternal> internalArguments, ProcessDelegate process)
			: this(name, description, true, internalArguments, process)
		{
		}

		public ArgumentCommand(string name, string description, bool allowMultipleExecutions, List<ArgumentInternal> internalArguments, ProcessDelegate process)
		{
			Name = name;
			Description = description;
			AllowMultipleExecutions = allowMultipleExecutions;
			if (internalArguments == null)
			{
				internalArguments = new List<ArgumentInternal>();
				internalArguments.Add(new ArgumentInternal("Current"));
			}
			InternalArguments = internalArguments;
			Process = process;
		}
	}

}