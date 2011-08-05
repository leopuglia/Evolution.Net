using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.Sample.Data.Definition
{
	public class CategoryCrudTO : CrudTO<Category, int>
	{
		public int SlowWorkTime { get; set; }
	}
}