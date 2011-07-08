using System;

namespace EvolutionNet.Util
{
	public class UtilSingletonException : UtilException
	{
		public UtilSingletonException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public UtilSingletonException(string message) : base(message)
		{
		}

		public UtilSingletonException()
		{
		}

	}
}
