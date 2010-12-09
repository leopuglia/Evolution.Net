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
	public interface IControlView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
		void ShowMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg, string exceptionMessage);

        T CreateControlView<T>() where T : IControlView;
		T CreateControlView<T>(params object[] args) where T : IControlView;
		void AddControlView(IControlView view);
		void AddControlViewAt(int index, IControlView view);
		void RemoveControlView(IControlView view);
		void RemoveControlViewAt(int index);
		T GetControlView<T>(object sender) where T : IControlView;
	}
}