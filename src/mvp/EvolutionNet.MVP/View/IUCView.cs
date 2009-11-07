/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma vis�o (view) b�sica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IUCView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
		//		TO To { get; /*set;*/ }

		object CreateControl(string virtualPath);
		object CreateControl(Type t, params object[] args);
		void ShowMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg, Exception ex);

//		PresenterT Presenter { get; }
	}
}