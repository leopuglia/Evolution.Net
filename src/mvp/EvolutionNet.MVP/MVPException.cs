
using System;
using System.Runtime.Serialization;

namespace EvolutionNet.MVP
{
	public class MVPException : ApplicationException
	{
		public MVPException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public MVPException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public MVPException(string message) : base(message)
		{
		}

		public MVPException()
			: base()
		{
		}

	}
}
