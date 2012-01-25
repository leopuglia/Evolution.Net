using System.Collections.Generic;

namespace EvolutionNet.Util.CommandLine
{
	/// <summary>
	/// Interface that defines a basic argument for command-line processing.
	/// </summary>
	public interface IArgument
	{
		string Name { get; }
		string Description { get; }
		bool AllowMultipleExecutions { get; }
		List<ArgumentInternal> InternalArguments { get; }
		//int InternalArgumentsCount { get; }
		ProcessDelegate Process { get; }
		ArgumentType Type { get; }
	}

}