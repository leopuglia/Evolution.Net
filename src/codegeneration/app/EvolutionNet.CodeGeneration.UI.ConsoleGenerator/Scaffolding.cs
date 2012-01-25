using System;
using System.Collections.Generic;
using System.IO;
using EvolutionNet.Util.CommandLine;

namespace EvolutionNet.CodeGeneration.UI.ConsoleGenerator
{
	public class Scaffolding
	{
		private CommandLineHelper commandLineHelper;
		private string basePath = Environment.CurrentDirectory;

		public void Run(params string[] args)
		{
			try
			{
				// Initialize
				Console.WriteLine();
				Console.WriteLine("EvolutionNet Project Generator");
				Console.WriteLine();

				// Create the command argument
				var command = new ArgumentCommand("project", "Project to be created.", CreateProject);
				// Create the options arguments 
				var options = new List<ArgumentOption>();
				var basePathOptionArguments = new List<ArgumentInternal>();
				basePathOptionArguments.Add(new ArgumentInternal("path", "Absolute path."));
				var basePathOption = new ArgumentOption("basepath", "b", "Base path for project creation.", basePathOptionArguments, SetBasePathOption);
				options.Add(basePathOption);
				// Create the CommandLineHelper (for processing the arguments)
				commandLineHelper = new CommandLineHelper(command, options, ShowHelp, GetProjectName);
				commandLineHelper.Process(args);

				// Finalize
				Console.WriteLine("SUCCESS: Project(s) created!");
			}
			catch (Exception ex)
			{
				// Write errors to screen
				Console.WriteLine("ERRORS:");
				Console.WriteLine("{0}", ex.Message);
				Console.WriteLine();
			}
			finally
			{
				Console.Write("Press any key to continue");
				Console.ReadKey();
			}
		}

		private void SetBasePathOption(params string[] args)
		{
			basePath = args[0];
		}

		private void ShowHelp(params string[] args)
		{
			Console.WriteLine(commandLineHelper.UsageText);
		}

		private void GetProjectName(params string[] args)
		{
			Console.Write("Project Name: ");
			var projectName = Console.ReadLine();
			CreateProject(projectName);
		}

		private void CreateProject(params string[] args)
		{
			var folders = new List<string>
			              	{
			              		"bin",
			              		"doc",
			              		"lib",
			              		"licenses",
			              		"resources",
			              		"sql",
			              		"src",
			              		"tools",
			              	};
			foreach (var arg in args)
			{
				// Verify if directory exists
				var path = Path.Combine(basePath, arg);
				if (Directory.Exists(path))
					throw new ArgumentException(string.Format("The path \"{0}\" already exists!", path));
				// Create project folders
				Console.WriteLine("Creating project \"{0}\"", arg);
				Console.WriteLine();
				Console.WriteLine("Base folder: {0}", path);
				Console.WriteLine("Creating folder: {0}", arg);
				Directory.CreateDirectory(path);
				foreach (var folder in folders)
				{
					var intPath = Path.Combine(path, folder);
					Console.WriteLine("Creating folder: {0}\\{1}", arg, folder);
					Directory.CreateDirectory(intPath);
				}
				Console.WriteLine();
			}
		}
	}

}