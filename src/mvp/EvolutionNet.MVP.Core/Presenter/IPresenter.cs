/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.Core.Presenter
{
	public interface IPresenter<TO, T, IdT> : IContract
		where TO : ITo<T, IdT>
		where T : IModel<IdT>
	{
		ViewT GetView<ViewT>() where ViewT : IView<TO, T, IdT>;

//		void InitializeView(IView<TO, T, IdT> view);
	}
}