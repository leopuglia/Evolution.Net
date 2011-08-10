using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BaseReadPresenter<ViewT, ContractT, TO, T, IdT>
		: BasePresenter<ViewT, ContractT>, IReadPresenter<TO, T, IdT>
		where ViewT : IReadView<T, IdT>
		where ContractT : IReadContract<TO, T, IdT>
		where TO : ReadTO<T, IdT>
		where T : class, IModel<IdT>
	{
		protected BaseReadPresenter(ViewT view) : base(view)
		{
		}

		public TO To
		{
			get { return Bo.To; }
		}

		public abstract void Find();
	}
}