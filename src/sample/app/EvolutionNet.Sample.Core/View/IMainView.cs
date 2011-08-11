using EvolutionNet.MVP.View;

namespace EvolutionNet.Sample.Core.View
{
	public interface IMainView : IControlView
	{
		void AddTabPage(string text, IControlView controlView);
		void RemoveSelectedTabPage();
		int TabSelectedIndex { get; set; }
		int TabCount { get; }
	}
}