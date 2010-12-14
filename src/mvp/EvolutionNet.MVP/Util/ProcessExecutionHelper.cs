using System.Diagnostics;
using System.IO;
using log4net;

namespace EvolutionNet.MVP.Util
{
	public abstract class ProcessExecutionHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ProcessExecutionHelper));

		public static void RunDosBatch(string workingDirectory, string fileName)
		{
			RunDosBatch(workingDirectory, fileName, true, false, ProcessWindowStyle.Normal);
		}

		public static void RunDosBatch(
			string workingDirectory, string fileName, bool generateException, bool waitForExit, ProcessWindowStyle windowStyle)
		{
			Run(workingDirectory, @"C:\Windows\System32\cmd.exe", "/c " + fileName, generateException, waitForExit, windowStyle);
		}

		public static void Run(string workingDirectory, string fileName)
		{
			Run(workingDirectory, fileName, "");
		}

		public static void Run(string workingDirectory, string fileName, string arguments)
		{
			Run(workingDirectory, fileName, arguments, true, false, ProcessWindowStyle.Normal);
		}

		public static void Run(
			string workingDirectory, string fileName, string arguments, bool generateException, bool waitForExit, ProcessWindowStyle windowStyle)
		{
			if (File.Exists(fileName))
			{
				// get some key from the config file.
				Process proc = new Process();
				// attach the file
				proc.StartInfo.FileName = fileName;
				// pass arguments
				proc.StartInfo.Arguments = arguments;
				// hidden run
				proc.StartInfo.WindowStyle = windowStyle;
				// no need in my case for show errors.
				proc.StartInfo.ErrorDialog = false;
				// set the running path
				proc.StartInfo.WorkingDirectory = workingDirectory;
				// start the process
				proc.Start();

				if (log.IsInfoEnabled)
					log.InfoFormat("Batch {0} executado\r\n", fileName);

				if (waitForExit)
				{
					// wait until its done
					proc.WaitForExit();

					// any other number then 0 means it is an error.
					if (proc.ExitCode != 0)
					{
						if (log.IsErrorEnabled)
							log.ErrorFormat("Erro executando batch {0}", fileName);

						throw new ProcessExecutionException(string.Format("Erro executando batch {0}", fileName));
					}
					
					if (log.IsInfoEnabled)
						log.InfoFormat("Batch {0} executado\r\n", fileName);
				}
			}
			else if (generateException)
			{
				throw new FileNotFoundException(string.Format("O arquivo {0} não existe!", fileName));
			}
		}

	}

}