using System;

namespace EvolutionNet.MVP.View.BackgroundWork
{
	public class WorkerCanceledException : MVPException
	{
		public WorkerCanceledException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public WorkerCanceledException(string message) : base(message)
		{
		}

		public WorkerCanceledException()
		{
		}
	}
}