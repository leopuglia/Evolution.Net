using System;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	[Obsolete]
	public abstract class BaseCrudFacade<TO, ModelT, IdT> : BaseCrudListBO<TO, ModelT, IdT>
		where TO : CrudListTO<ModelT, IdT>
		where ModelT : class, IModel<IdT>
	{
		protected BaseCrudFacade(IPresenter presenter) : base(presenter)
		{
		}

	}
}
