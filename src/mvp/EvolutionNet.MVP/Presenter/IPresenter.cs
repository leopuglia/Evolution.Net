using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.Presenter
{
	public interface IPresenter
	{
		IHelperFactory HelperFactory { get; }
	}
}