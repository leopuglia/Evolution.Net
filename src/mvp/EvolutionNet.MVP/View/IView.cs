/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma visão (view) básica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IView//<PresenterT> where PresenterT : IPresenter
	{
		IHelperFactory HelperFactory { get; }
//		IPathHelper PathHelper { get; }
//		IControlHelper ControlHelper { get; }
//		IMessageHelper MessageHelper { get; }

/*
		/// <summary>
		/// Realiza todas as inicializações necessárias.
		/// </summary>
		void DoLoad();
		void DoLoadComplete();
*/
//		event EventHandler Load;
//		event EventHandler LoadComplete;
	}
}