/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;
using System.ComponentModel;

namespace EvolutionNet.MVP.View
{
	public interface IControlView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
		[Category("Behavior"), Description("Event fired after all the controls are loaded.")]
		event EventHandler AfterLoadComplete;
		void OnAfterLoadComplete(EventArgs e);


	}
}