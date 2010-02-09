
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public interface IContract
	{
        IPresenter Presenter { get; }
    }
}