using System;

namespace EvolutionNet.MVP
{
	public abstract class MVPException : ApplicationException
	{
//	    protected EvolutionException(SerializationInfo info, StreamingContext context) : base(info, context)
//		{
//		}

	    protected MVPException(string message, Exception innerException) : base(message, innerException)
		{
		}

	    protected MVPException(string message) : base(message)
		{
		}

	    protected MVPException()
		{
		}

	}
}
