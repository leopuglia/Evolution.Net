using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.Sample.Data.Definition
{
	public class CategoryCrudTO : CrudListTO<Category, int>
	{
		public int SlowWorkTime { get; set; }
	}
}