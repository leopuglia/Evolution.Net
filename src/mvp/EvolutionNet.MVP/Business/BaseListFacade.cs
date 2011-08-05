using System;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	[Obsolete]
	public abstract class BaseListFacade<TO, T, IdT> : BaseListBO<TO, T, IdT>
		where TO : ListTO<T, IdT> 
		where T : class, IModel<IdT>
	{
		protected BaseListFacade(IPresenter presenter) : base(presenter)
		{
		}

	}
}
