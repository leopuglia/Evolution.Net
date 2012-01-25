namespace EvolutionNet.Util.CommandLine
{
	public class ArgumentInternal
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public string Description { get; set; }

		public ArgumentInternal(string name)
			: this(name, null)
		{
		}

		public ArgumentInternal(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public ArgumentInternal(string name, string description, string value)
		{
			Name = name;
			Description = description;
			Value = value;
		}

	}

}