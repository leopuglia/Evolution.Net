using System.Collections.Generic;

namespace EvolutionNet.Util.CommandLine
{
	public class ArgumentOption : IArgument
	{
		private readonly ArgumentType type = ArgumentType.Option;

		public string ShortName { get; private set; }

		public bool IsCaseSensitive { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public bool AllowMultipleExecutions { get; private set; }

		public List<ArgumentInternal> InternalArguments { get; private set; }

		public ProcessDelegate Process { get; private set; }

		public ArgumentType Type
		{
			get { return type; }
		}

/*
		public ArgumentOption(string name, string description, ProcessDelegate process)
			: this(name, name, description, false, false, new List<ArgumentInternal>(), process)
		{
		}

		public ArgumentOption(string name, string description, List<ArgumentInternal> internalArguments, ProcessDelegate process)
			: this(name, name, description, false, false, internalArguments, process)
		{
		}
*/

		public ArgumentOption(string name, string shortName, string description, List<ArgumentInternal> internalArguments, ProcessDelegate process)
			: this(name, shortName, description, false, /*false, */internalArguments, process)
		{
		}

		public ArgumentOption(string name, string shortName, string description, bool isCaseSensitive, /*bool allowMultipleExecutions, */List<ArgumentInternal> internalArguments, ProcessDelegate process)
		{
			Name = name;
			ShortName = shortName;
			Description = description;
			IsCaseSensitive = isCaseSensitive;
//			AllowMultipleExecutions = allowMultipleExecutions;
			AllowMultipleExecutions = false;
			InternalArguments = internalArguments;
			Process = process;
		}
	}

}