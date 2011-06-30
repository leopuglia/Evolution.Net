using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Core.View
{
	public interface ICategoryEditView : IControlView
	{
		Category Model { get; set; }
//		void SetEditValues(Category category);
//		Category GetEditValues();
	}
}