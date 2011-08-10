using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BaseCrudPresenter<ViewT, ContractT, TO, T, IdT>
		: BaseListPresenter<ViewT, ContractT, TO, T, IdT>, ICrudPresenter<TO, T, IdT> 
		where ViewT : ICrudView <T, IdT>
		where ContractT : ICrudContract<TO, T, IdT>
		where TO : CrudTO<T, IdT>
		where T : class, IModel<IdT>
	{
		protected BaseCrudPresenter(ViewT view) : base(view)
		{
		}

		public abstract void Add();
		public abstract void Edit();
		public abstract void Save();
		public abstract void Delete();
		public abstract void Clear();
	}
}