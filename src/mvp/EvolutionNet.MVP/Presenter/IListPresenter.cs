using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public interface IListPresenter<TO, T, IdT> : IPresenter
		where TO : ListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		TO To { get; }

		void FindAll();
//		SortableBindingList<ModelT> BindableList { get; }
	}
}