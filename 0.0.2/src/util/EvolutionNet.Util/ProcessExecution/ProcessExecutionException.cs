using System;

namespace EvolutionNet.Util.ProcessExecution
{
	public class ProcessExecutionException : UtilException
	{
		public ProcessExecutionException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public ProcessExecutionException(string message) : base(message)
		{
		}

		public ProcessExecutionException()
		{
		}

	}
}
