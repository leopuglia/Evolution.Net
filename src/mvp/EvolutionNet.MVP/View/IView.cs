/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma visão (view) básica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IView//<PresenterT> where PresenterT : IPresenter
	{
		IHelperFactory HelperFactory { get; }

//		event EventHandler Load;
//		event EventHandler LoadComplete;
	}
}