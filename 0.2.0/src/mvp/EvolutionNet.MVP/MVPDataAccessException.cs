using System;

namespace EvolutionNet.MVP
{
    public class MVPDataAccessException : MVPException
	{
	    public MVPDataAccessException(string message, Exception innerException) : base(message, innerException)
		{
		}

	    public MVPDataAccessException(string message) : base(message)
		{
		}

        public MVPDataAccessException()
		{
		}

	}
}
