using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using log4net.Config;

namespace EvolutionNet.Sample.Business
{
	public class MainFacade : BaseFacade<NullTO>, IMainContract
	{
		public MainFacade(IPresenter presenter) : base(presenter)
		{
		}
	}
}