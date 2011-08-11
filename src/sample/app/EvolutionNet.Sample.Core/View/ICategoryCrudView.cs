using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Core.View
{
	public interface ICategoryCrudView : ICrudListView<Category, int>
	{
		int SlowWorkTime { get; set; }
//		int CurrentPosition { get; set; }
		void AdjustDataGridRowHeightColumnWidth();
		void Clear();
	}
}