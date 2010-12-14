namespace EvolutionNet.MVP
{
	public struct ValidationError
	{
		private string propertyName;
		public string PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		private string message;
		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		public ValidationError(string propertyName, string message)
		{
			this.propertyName = propertyName;
			this.message = message;
		}
	}

}