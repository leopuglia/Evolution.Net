using System.Collections.Generic;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.View
{
	public interface IListView<T, IdT> : IControlView where T : class, IModel<IdT>
	{
		int CurrentPosition { get; set; }
		T CurrentEditModel { get; /*set;*/ }
		IList<T> CurrentList { get; }
		SortableBindingList<T> BindableList { get; set; }
		PropertySortInfo SortInfo { get; }
	}
}