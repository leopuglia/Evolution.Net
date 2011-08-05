using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.Presenter
{
	public interface IPresenter
	{
		IHelperFactory HelperFactory { get; }
//		IPathHelper PathHelper { get; }
//		IControlHelper ControlHelper { get; }
//		IMessageHelper MessageHelper { get; }
	}
}