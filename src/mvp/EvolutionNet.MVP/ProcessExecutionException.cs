using System;

namespace EvolutionNet.MVP
{
	public class ProcessExecutionException : MVPException
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
