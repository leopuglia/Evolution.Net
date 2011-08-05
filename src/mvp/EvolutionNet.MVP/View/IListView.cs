using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.View
{
	public interface IListView<ModelT> : IView where ModelT : IBaseModel
	{
		SortableBindingList<ModelT> BindableList { get; set; }

//		void BindList();
	}
}