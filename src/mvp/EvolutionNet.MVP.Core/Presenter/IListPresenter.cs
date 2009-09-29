using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.Core.Presenter
{
	public interface IListPresenter<TO, T, IdT> : IListContract
		where TO : IListTo<T, IdT>
		where T : IModel<IdT>
	{
		ViewT GetView<ViewT>() where ViewT : IListView<TO, T, IdT>;
	}
}