using EvolutionNet.MVP.View;

namespace EvolutionNet.Sample.Core.View
{
	public interface IMainView : IControlView
	{
		void AddTabPageView(string text, IControlView controlView);
		void DeleteTabPage();
	}
}