using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.Presenter
{
	public interface IListPresenter<ModelT> : IPresenter where ModelT : IBaseModel
	{
//		void FindAll();
//		SortableBindingList<ModelT> BindableList { get; }
	}
}