using System.Collections;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Core.View
{
	public interface ICategoryCrudView : ICrudListView<Category, int>
	{
		IEnumerable WebCache { get; }
		int SlowWorkTime { get; set; }
//		int CurrentPosition { get; set; }
		void AdjustDataGridRowHeightColumnWidth();
		void Clear();
	}
}