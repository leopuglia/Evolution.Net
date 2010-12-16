using EvolutionNet.MVP.View;

namespace EvolutionNet.Sample.Core.View
{
	public interface IMainView : IControlView
	{
		void AddTabItemView(string text, IControlView controlView);
		void DeleteTabItem();
	}
}