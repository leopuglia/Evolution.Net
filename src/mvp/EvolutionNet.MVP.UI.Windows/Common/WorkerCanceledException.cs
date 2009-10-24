using System;
using System.Runtime.Serialization;
using EvolutionNet.MVP;

namespace EvolutionNet.MVP.UI.Windows.Common
{
	public class WorkerCanceledException : FrameworkException
	{
		public WorkerCanceledException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public WorkerCanceledException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public WorkerCanceledException(string message) : base(message)
		{
		}

		public WorkerCanceledException() : base()
		{
		}
	}
}