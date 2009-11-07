using System.Web.UI;

namespace EvolutionNet.MVP.View
{
	public interface IWebUCView : IUCView
	{
		T CreateControl<T>(string virtualPath) where T : Control;
		T CreateControl<T>(params object[] args) where T : Control;
	}
}