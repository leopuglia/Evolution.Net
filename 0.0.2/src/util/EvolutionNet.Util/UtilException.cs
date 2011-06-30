using System;

namespace EvolutionNet.Util
{
	public abstract class UtilException : ApplicationException
	{
//		protected EvolutionException(SerializationInfo info, StreamingContext context) : base(info, context)
//		{
//		}

		protected UtilException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected UtilException(string message) : base(message)
		{
		}

		protected UtilException()
		{
		}

	}
}
