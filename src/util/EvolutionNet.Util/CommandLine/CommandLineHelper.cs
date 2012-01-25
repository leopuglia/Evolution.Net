using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EvolutionNet.Util.CommandLine
{
	public delegate void ProcessDelegate(params string[] args);

	/*
	 * A unica coisa que faltou agor foi colocar um ordenamento no processamento das opções.
	 * Tomando como exemplo o SQLCMD, se eu setar -S <server> -U <user> -P password, eu teria que executar as options -U e -P antes da -S
	 * 
	 * Pode ser feito por dependencia, criando uma propriedade tipo AfterOption (ou BeforeOption), que me parece complicado, mas fica bem flexivel.
	 * Ou pode ser implementado por um campo de prioridade (pior solução...)
	 * Ou ainda pode ser implementado pela ordem em que as opções são adicionadas à lista, que é mais simples, mas menos flexivel
	 * 
	 * Como eu fiz o processamento pela ordem dos argumentos, eu teria que criar uma lista com as opções e processá-las somente após o término da análise desses argumentos
	 */

	/// <summary>
	/// Helper class to process command line arguments
	/// </summary>
	public class CommandLineHelper
	{
		#region Private Attributes

		// Defines the prefixes for option arguments: -, / and --
		private string[] shortNamePrefixes = new[] { "-", "/" };
		private string fullNamePrefix = "--";

		#endregion

		#region Public Properties

		public ArgumentCommand Command { get; set; }
		public List<ArgumentOption> Options { get; set; }
//		public bool IsInSpecificOrder { get; set; }
		public bool AcceptEmptyArguments { get; set; }
		public ProcessDelegate EmptyArguments { get; set; }
		public ProcessDelegate Usage { get; set; }
		public string UsageText 
		{ 
			get { return GenerateUsageText(); }
		}

		#endregion

		#region Constructor

		public CommandLineHelper(List<ArgumentOption> options, ProcessDelegate usage)
			: this(null, options, usage, null)
		{
		}

		public CommandLineHelper(List<ArgumentOption> options, ProcessDelegate usage, ProcessDelegate emptyArguments)
			: this(null, options, usage, emptyArguments)
		{
		}

		public CommandLineHelper(ArgumentCommand command, List<ArgumentOption> options, ProcessDelegate usage, ProcessDelegate emptyArguments, bool acceptEmptyArguments/*, bool isInSpecificOrder*/)
		{
			Command = command;
			if (options == null)
				options = new List<ArgumentOption>();
			Options = options;
			Usage = usage;
			EmptyArguments = emptyArguments;
//			IsInSpecificOrder = isInSpecificOrder;
			AcceptEmptyArguments = acceptEmptyArguments;
		}

		public CommandLineHelper(ArgumentCommand command, List<ArgumentOption> options, ProcessDelegate usage, ProcessDelegate emptyArguments)
			: this(command, options, usage, emptyArguments, true/*, false*/)
		{
		}

		public CommandLineHelper(ArgumentCommand command, List<ArgumentOption> options, ProcessDelegate usage)
			: this(command, options, usage, null)
		{
		}

		#endregion

		#region Public Methods

		public void Process(string[] args)
		{
			// If there are no args, try to call EmptyArguments
			if (args.Length == 0)
			{
				if (!AcceptEmptyArguments)
					throw new ArgumentException("You must enter some argument! Enter -? for usage.");
				if (EmptyArguments == null)
					throw new ArgumentException("The EmptyArguments method must be set!");

				EmptyArguments();
				return;
			}

			// Show usage options, if Usage delegate is defined
			if (Usage != null)
			{
				foreach (var arg in args)
				{
					if (arg == "-?" || arg == "/?" || arg.ToLower() == "-h" || arg.ToLower() == "--help")
					{
						Usage();
						return;
					}
				}
			}

			// Process options and commands
			IArgument currentArgument = null;
			var expectedArgs = 0;
			var commandList = new List<IArgument>();
			var optionList = new Dictionary<string, IArgument>();
			var errorMessageStr = new StringBuilder();
			foreach (var arg in args)
			{
				// Verify if it is a option and remove prefixes from arg
				string argClean = CleanOptionArgument(arg);
				bool isOption = argClean != null;
				// If are not expecting some internal argument, begin processing options
				if (expectedArgs == 0)
				{
					// Process the option
					if (isOption)
					{
						// Search for the option in the Options list
						IArgument currentOption = GetCurrentOption(argClean);
						if (currentOption != null)
						{
							// If the option has already been added, generates an exception
							if (optionList.Count > 0 && optionList[currentOption.Name] != null)
								throw new ArgumentException(string.Format("Could not process option '{0}' argument '{1}' twice! Enter -? for usage.",
																		  currentOption.Name, arg));
							// Add the option to the option list
							optionList[currentOption.Name] = currentOption;
							currentArgument = currentOption;
							expectedArgs = currentOption.InternalArguments.Count;
							continue;
						}
						// If option not found, then we got a wrong argument
						throw new ArgumentException(string.Format("Option '{0}' doesn't exist! Enter '-?' for usage.", arg));
					}
					// Now process the Command, if exists
					if (Command != null)
					{
						// If the command doesn't allow multiple executions, generates an exception
						if (commandList.Count > 0 && ! Command.AllowMultipleExecutions)
							throw new ArgumentException(string.Format("Could not process command '{0}' argument '{1}' twice! Enter '-?' for usage.", 
							                                          Command.Name, arg));
						// Create a copy of internal arguments into a new list
						var internalArguments = Command.InternalArguments;
						List<ArgumentInternal> newInternalArguments = GetNewInternalArguments(internalArguments);
						// Set the first internal argument to arg
						newInternalArguments[0].Value = arg;
						// Create a new command and add to the commandList (to be executed after the options)
						var currentCommand = new ArgumentCommand(Command.Name, Command.Description, Command.AllowMultipleExecutions,
						                                         newInternalArguments, Command.Process);
						commandList.Add(currentCommand);
						// Set the currentArgument to the new command and set the expectedArgs 
						currentArgument = currentCommand;
						expectedArgs = newInternalArguments.Count - 1;
						continue;
					}
					// If it gets here, there is something wrong
					throw new ArgumentException(string.Format("Unespected argument '{0}'! Enter '-?' for usage.", arg));
				}
				// Now we are expecting some internal argument, so set it's values to arg
				if (expectedArgs > 0 && currentArgument != null)
				{
					// If the argument is a option, there is something wrong
					if (isOption)
						throw new ArgumentException(string.Format("Argument '{0}' invalid to option '{1}'! Enter '-?' for usage.",
																  arg, currentArgument.Name));
					
					currentArgument.InternalArguments[currentArgument.InternalArguments.Count - expectedArgs].Value = arg;
					expectedArgs--;
					continue;
				}
				// If it gets here, there is something wrong
				throw new ArgumentException(string.Format("Unespected argument '{0}'! Enter '-?' for usage.", arg));
			}
			// Process all the options, in the order that they were created
			foreach (var option in Options)
			{
				foreach (var optionKeyValue in optionList)
				{
					if (option.Name == optionKeyValue.Key)
					{
						try
						{
							RunCurrentProcess(optionKeyValue.Value);
						}
						catch (Exception e)
						{
							errorMessageStr.AppendLine(e.Message);
						}
					}
				}
			}
			// After processing all options, process the commands
			foreach (var command in commandList)
			{
				try
				{
					RunCurrentProcess(command);
				}
				catch (Exception e)
				{
					errorMessageStr.AppendLine(e.Message);
				}
			}
			// If any errors happened running the options or commands, throw an exception
			if (errorMessageStr.ToString() != "")
			{
				throw new ArgumentException(errorMessageStr.ToString());
			}
		}

		private IArgument GetCurrentOption(string argClean)
		{
			IArgument currentOption = null;
			foreach (var option in Options)
			{
				if (!option.IsCaseSensitive)
				{
					if (argClean.ToLower() == option.Name.ToLower())
					{
						currentOption = option;
						break;
					}
					if (argClean.ToLower() == option.ShortName.ToLower())
					{
						currentOption = option;
						break;
					}
				}
				else
				{
					if (argClean == option.Name)
					{
						currentOption = option;
						break;
					}
					if (argClean == option.ShortName)
					{
						currentOption = option;
						break;
					}
				}
			}
			return currentOption;
		}

		private string CleanOptionArgument(string arg)
		{
			string argClean = null;
			var isOption = arg.StartsWith(fullNamePrefix);
			if (isOption)
				argClean = arg.Remove(0, fullNamePrefix.Length);
			else
			{
				// Verify if it is a option and remove prefixes from arg
				foreach (var prefix in shortNamePrefixes)
				{
					isOption |= arg.StartsWith(prefix);
					if (isOption)
					{
						argClean = arg.Remove(0, prefix.Length);
						break;
					}
				}
			}
			return argClean;
		}

		private List<ArgumentInternal> GetNewInternalArguments(List<ArgumentInternal> internalArguments)
		{
			var newInternalArguments = new List<ArgumentInternal>();
			foreach (var internalArgument in internalArguments)
			{
				var newInternalArgument = new ArgumentInternal(internalArgument.Name, internalArgument.Description, internalArgument.Value);
				newInternalArguments.Add(newInternalArgument);
			}
			return newInternalArguments;
		}

		#endregion

		#region Local Auxiliary Methods

		// Call the Process delegate for an argument
		private void RunCurrentProcess(IArgument currentArgument)
		{
			if (currentArgument.Process == null)
				throw new ArgumentException("The Process method must be set!", currentArgument.Name);
			var internalArgs = new string[currentArgument.InternalArguments.Count];
			int i = 0;
			foreach (var argument in currentArgument.InternalArguments)
			{
				internalArgs[i] = argument.Value;
				i++;
			}
			currentArgument.Process(internalArgs);
		}

		// Generates the usage (help) text string, to be shown by the calling app
		private string GenerateUsageText()
		{
			var maxWordSize = CalculateMaxWordSize();

			// Print the command line example
			var str = new StringBuilder();
			var filename = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);
			str.AppendFormat("{0} ", filename);
			if (Command != null)
			{
				var name = Command.Name;
				if (Command.AllowMultipleExecutions)
				{
					name += string.Format(" [{0}{1}] [{2}{3}] [...]", Command.Name, "1", Command.Name, "2");
				}
				str.AppendFormat("{0} ", name);
				var i = 0;
				foreach (var internalArgument in Command.InternalArguments)
				{
					if (i != 0)
						str.AppendFormat("{0} ", internalArgument.Name);
					i++;
				}
			}
			str.Append("[-? | /?] ");
			foreach (var option in Options)
			{
				str.AppendFormat("[-{0}", option.ShortName);
				foreach (var internalArgument in option.InternalArguments)
				{
					str.AppendFormat(" {0}", internalArgument.Name);
				}
				str.Append("]");
			}
			str.AppendLine();
			str.AppendLine();

			// Print the command line description
			if (Command != null)
			{
				str.AppendLine(string.Format("{0}{1}", GetIndented(Command.Name, maxWordSize), Command.Description));
				var i = 0;
				foreach (var internalArgument in Command.InternalArguments)
				{
					if (i != 0)
						str.AppendLine(string.Format("{0}{1}", GetIndented(internalArgument.Name, maxWordSize), internalArgument.Description));
					i++;
				}
			}
			str.AppendLine();
			str.AppendLine("Options:");
			str.AppendLine(string.Format("{0}{1}", GetIndented("[-? | /?]", maxWordSize), "Show usage options."));
			str.AppendLine(string.Format("{0}{1}", GetIndented("[-h | --help]", maxWordSize), "Alias to -?."));
			foreach (var option in Options)
			{
				str.AppendLine(string.Format("{0}{1}", GetIndented(string.Format("[-{0} | --{1}]", option.ShortName, option.Name), maxWordSize), option.Description));
				foreach (var internalArgument in option.InternalArguments)
				{
					str.AppendLine(string.Format("{0}{1}", GetIndented("  " + internalArgument.Name, maxWordSize), internalArgument.Description));
				}
			}

			return str.ToString();
		}

		// Calculates the biggest word in the help commands, to indent properly
		private int CalculateMaxWordSize()
		{
			var maxWordSize = 13;
			if (Command != null)
			{
				if (maxWordSize < Command.Name.Length)
					maxWordSize = Command.Name.Length;
				var i = 0;
				foreach (var internalArgument in Command.InternalArguments)
				{
					if (i != 0 && maxWordSize < internalArgument.Name.Length)
						maxWordSize = internalArgument.Name.Length;
				}
			}
			foreach (var option in Options)
			{
				var optionNameSize = option.Name.Length + option.ShortName.Length + 10;
				if (maxWordSize < optionNameSize)
					maxWordSize = optionNameSize;
				foreach (var internalArgument in option.InternalArguments)
				{
					if (maxWordSize < internalArgument.Name.Length)
						maxWordSize = internalArgument.Name.Length;
				}
			}

			return maxWordSize;
		}

		// Get the indented string "  name\t...\t"
		private string GetIndented(string name, int maxWordSize)
		{
			var position = (name.Length + 2)/8;
			var maxPosition = (maxWordSize/8) + 1;
			var str = new StringBuilder();
			str.AppendFormat("  {0}", name);
			for (int i = position; i < maxPosition; i++)
			{
				str.Append("\t");
			}

			return str.ToString();
		}

		#endregion

	}

}