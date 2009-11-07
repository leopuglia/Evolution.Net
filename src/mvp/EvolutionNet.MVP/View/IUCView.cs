/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma visão (view) básica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IUCView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
		/// <summary>
		/// Transfer Object, contém a referência ao To, que é criado automaticamente pelo framework.
		/// </summary>
		//		TO To { get; /*set;*/ }

		object CreateControl(string virtualPath);
		object CreateControl(Type t, params object[] args);
		void ShowMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg, Exception ex);

//		PresenterT Presenter { get; }
	}
}