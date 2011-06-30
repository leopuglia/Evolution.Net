using System;
using System.Collections.Generic;

namespace EvolutionNet.MVP
{
	public class MVPValidationException : MVPException
	{
		private IList<ValidationError> validationErrors;
		public IList<ValidationError> ValidationErrors
		{
			get { return validationErrors; }
			set { validationErrors = value; }
		}

		public MVPValidationException(string message, Exception innerException, IList<ValidationError> validationErrors)
			: base(message, innerException)
		{
			this.validationErrors = validationErrors;
		}

		public MVPValidationException(string message, IList<ValidationError> validationErrors)
			: this(message, null, validationErrors)
		{
		}

	}

}