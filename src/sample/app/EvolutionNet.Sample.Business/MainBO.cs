using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;

namespace EvolutionNet.Sample.Business
{
	public class MainBO : BaseBO<NullTO>, IMainContract
	{
		public MainBO(IPresenter presenter) : base(presenter)
		{
		}
	}
}