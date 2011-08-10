using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BaseListPresenter<ViewT, ContractT, TO, T, IdT>
		: BasePresenter<ViewT, ContractT>, IListPresenter<TO, T, IdT>
		where ViewT : IListView<T, IdT>
		where ContractT : IListContract<TO, T, IdT>
		where TO : ListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		protected BaseListPresenter(ViewT view) : base(view)
		{
		}

		public TO To
		{
			get { return Bo.To; }
		}

		public abstract void FindAll();
	}
}