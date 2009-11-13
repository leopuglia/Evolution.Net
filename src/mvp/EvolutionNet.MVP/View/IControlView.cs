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
	public interface IControlView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
		void ShowMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg, Exception ex);

		T CreateControlView<T>(params object[] args) where T : IControlView;
		void AddControlView(IControlView view);
		void RemoveControlView(IControlView view);
		T GetControlView<T>(object sender) where T : IControlView;
	}
}