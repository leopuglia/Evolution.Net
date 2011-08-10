using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.View
{
	public interface IListView<T, IdT> : IControlView where T : class, IModel<IdT>
	{
		SortableBindingList<T> BindableList { get; set; }

//		void BindList();
	}
}