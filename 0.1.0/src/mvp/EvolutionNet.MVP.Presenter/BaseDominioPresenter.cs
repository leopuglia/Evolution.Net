using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.Presenter
{
	public class BaseDominioPresenter<TO, T, IdT> : BasePresenter<TO, T, IdT>, IDominioContract
		where TO : ITo<T, IdT>
		where T : IModel<IdT>
	{
		public BaseDominioPresenter(IView<TO, T, IdT> view) : base(view)
		{
		}

		public void FindAllForEdit()
		{
			((IDominioContract) Facade).FindAllForEdit();
		}
	}
}