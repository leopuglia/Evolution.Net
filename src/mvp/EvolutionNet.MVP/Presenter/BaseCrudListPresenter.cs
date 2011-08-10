using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BaseCrudListPresenter<ViewT, ContractT, TO, T, IdT>
		: BaseListPresenter<ViewT, ContractT, TO, T, IdT>, ICrudListPresenter<TO, T, IdT> 
		where ViewT : ICrudListView <T, IdT>
		where ContractT : ICrudListContract<TO, T, IdT>
		where TO : CrudListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		protected BaseCrudListPresenter(ViewT view) : base(view)
		{
		}

		public abstract void Add();
		public abstract void Edit();
		public abstract void Save();
		public abstract void SaveList();
		public abstract void Delete();
		public abstract void DeleteList();
		public abstract void Clear();
	}
}