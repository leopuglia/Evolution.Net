using System;

namespace EvolutionNet.Util
{
	public class UtilIoCException : UtilException
	{
		public UtilIoCException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public UtilIoCException(string message) : base(message)
		{
		}

		public UtilIoCException()
		{
		}

	}
}
