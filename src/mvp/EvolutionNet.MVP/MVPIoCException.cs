using System;

namespace EvolutionNet.MVP
{
	public class MVPIoCException : MVPException
	{
		public MVPIoCException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public MVPIoCException(string message) : base(message)
		{
		}

		public MVPIoCException()
		{
		}

	}
}
