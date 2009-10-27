/*using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Contract;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BaseListPresenter<ContractT, TO, T, IdT>
		where ContractT : IListContract<TO, T, IdT>
		where TO : ListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		#region Variáveis Protegidas

		protected readonly IListView view;
		protected readonly ContractT facade;

		#endregion

		#region Construtores

		protected BaseListPresenter(IListView view)
		{
			facade = GetListFacade();

			this.view = view;
			view.Initialize();
		}

		protected virtual ContractT GetListFacade()
		{
			return AbstractIoCFactory<IFacadeFactory>.Instance.GetFromListContract<ContractT, TO, T, IdT>();
		}

		#endregion

	}
}*/