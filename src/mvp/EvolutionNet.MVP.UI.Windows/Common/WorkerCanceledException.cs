using System;
using EvolutionNet.MVP;

namespace EvolutionNet.MVP.UI.Windows.Common
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