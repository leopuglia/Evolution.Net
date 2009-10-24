
using System;
using System.Runtime.Serialization;

namespace EvolutionNet.MVP
{
	public class FrameworkException : ApplicationException
	{
		public FrameworkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public FrameworkException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public FrameworkException(string message) : base(message)
		{
		}

		public FrameworkException()
			: base()
		{
		}

	}
}
